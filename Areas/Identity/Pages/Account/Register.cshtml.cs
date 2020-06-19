using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Octopus.Data;
using Octopus.Models;

namespace Octopus.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public RegisterModel(ApplicationDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "El {0} debe contener minimo {2} y máximo {1} caracteres.", MinimumLength = 6)]
            [Display(Name = "Nombre")]
            public string Nombre { get; set; }

            [Required]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "El número debe contener 10 dígitos")]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Teléfono")]
            public string PhoneNumber { get; set; }

           
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string Email { get; set; }


            [Required(ErrorMessage = "El password debe ser obligatorio")]
            [StringLength(100, ErrorMessage = "El {0} debe contener minimo {2} y máximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password, ErrorMessage = "Debes incluir una mayuscula minuscula y caracter especial")]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Comisión")]
            [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Asigna una Comisión entre 1 y 7")]
            public double Comision { get; set; }
            [Required]
            [Display(Name = "Servicios")]
            [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Asigna la cantidad a cobrar para pago de servicios")]
            public double CuotaServicios { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Views/Users/Index.cshtml");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var createdBy = "self";
                bool isRegisteredByUser = this._signInManager.IsSignedIn(User);
                if (isRegisteredByUser) {
                    createdBy = User.FindFirstValue(ClaimTypes.NameIdentifier);
                }
                var user = new User {CreatedBy = createdBy, PhoneNumber = Input.PhoneNumber, UserName = Input.PhoneNumber + "@octopus.com", Email = Input.Email != "" || Input.Email != null ? Input.Email: Input.PhoneNumber+"@octopus.com",Nombre = Input.Nombre };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.PhoneNumber, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.PhoneNumber });
                    }
                    else
                    {
                       /* if (!isRegisteredByUser)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                        else {*/
                            var userCreated = await _userManager.FindByEmailAsync(user.Email);
                            var regions = _context.Regions.ToList();
                            List<UsuarioRegion> usuarioRegiones = new List<UsuarioRegion>();
                            foreach (var region in regions) {
                                var UserRegion = new UsuarioRegion() {
                                    RegionId = region.Id,
                                    UserId = userCreated.Id,
                                    Comision = Input.Comision,
                                    Status = true
                                };
                                usuarioRegiones.Add(UserRegion);
                            }
                            _context.UsuarioRegions.AddRange(usuarioRegiones);
                        var ownertUser = await _context.Users.Include(s => s.Cartera).AsNoTracking()
                            .FirstOrDefaultAsync(s => s.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
                        var ownerId = ownertUser != null ? ownertUser.Id : userCreated.Id;
                        var nuevaCartera = new Cartera {CuotaServicios =Input.CuotaServicios, FatherId = ownerId, OwnerId = userCreated.Id, UserLevel = ownertUser != null ? ownertUser.Cartera.UserLevel+1:0 , Inicial = 0, Enviado = 0, Venta = 0, Asignado = 0, SaldoNormal = 0, SaldoTAE = 0, ComisionTAE = Input.Comision };
                        var nuevoGrupo = new Grupo { GroupName = Input.PhoneNumber.ToString(), OwnerId =  user.Id};
                            _context.Grupos.Add(nuevoGrupo);
                            _context.Carteras.Add(nuevaCartera);
                            _context.SaveChanges();
                            userCreated.CarteraId = nuevaCartera.Id;
                            _context.UsuarioGrupos.Add(new UsuarioGrupo {GrupoId = nuevoGrupo.Id,UserId = user.Id, Status = true });
                            _context.SaveChanges();
                            return RedirectToAction("CreateUserRegions", "UserRegions",new { userId = user.Id });
                            //return RedirectToAction(nameof(Index));
                       // }
                        
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
