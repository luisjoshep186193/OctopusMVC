using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Models;
using Octopus.Services;

namespace Octopus.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _SignInManager;
        private readonly UserManager<User> _UserManager;
        private readonly IUserData _userData;
        public const string SessionKeyName = "UserData";
        private RoleManager<IdentityRole> _roleManager;

        public UsersController(ApplicationDbContext context,
            SignInManager<User> SignInManager,
            UserManager<User> UserManager,
            IUserData userData,
            RoleManager<IdentityRole> roleMgr)
        {
            _context = context;
            _SignInManager = SignInManager;
            _UserManager = UserManager;
            _userData = userData;
            _roleManager = roleMgr;
        }

        private string getCurrentUserId(string attr)
        {

            switch (attr)
            {
                case "id":
                    return _SignInManager.IsSignedIn(User) ? User.FindFirstValue(ClaimTypes.NameIdentifier) : "";

                case "name":
                    return _SignInManager.IsSignedIn(User) ? User.FindFirstValue(ClaimTypes.Name) : "";

                default:
                    break;

            }
            return "";
        }

        // GET: Users
        public async Task<IActionResult> Index(bool partial = false)
        {
            var userId = getCurrentUserId("id");
            var users = await _context.Users.Where(s => s.CreatedBy == userId || s.Id == userId).Include(s=>s.Cartera).AsNoTracking().ToListAsync();
            var currentUser = users.Find(s => s.Id == userId);
            ViewBag.useId = currentUser.Cartera;
            users.Remove(currentUser);

            /* IdentityResult result = await _roleManager.CreateAsync(new IdentityRole("Superadmin"));
             await _roleManager.CreateAsync(new IdentityRole("Administrador"));
             await _roleManager.CreateAsync(new IdentityRole("Servicios"));
             /* if (!result.Succeeded)
              return RedirectToAction("Index", "Home");
               else*/
            if (partial)
                return PartialView(users);

            return View(users);
            
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id, bool partial)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return PartialView(user);
        }

        // GET: Users/Create
        public IActionResult CreateAsync()
        {
           
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,CreatedBy,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index","UserRegion");
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id, bool partial = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.AsNoTracking().FirstOrDefaultAsync(s=>s.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var userId = getCurrentUserId("id");
            var currentUser = await _context.Users.FindAsync(userId);
            //ViewData["Rol"] = new SelectList(null);
            ViewBag.isAdmin = false;
            if (currentUser != null)
            {
                var isInRol = await _UserManager.IsInRoleAsync(
            currentUser,
            "Administrador");
                ViewBag.rolesUser = await _UserManager.GetRolesAsync(user) as List<string>;
                ViewBag.isAdmin = currentUser.CreatedBy == "self" || isInRol;
                ViewData["Rol"] = new SelectList(_context.Roles.AsNoTracking(), "Id", "Name");

            }

            if(partial)
             return PartialView(user);

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nombre,CreatedBy,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,CarteraId,Rol")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    if (user.Rol != "")
                    {
                        var isInRole =  await _UserManager.IsInRoleAsync(user, user.Rol);
                        var role = await _roleManager.FindByIdAsync(user.Rol);
                        _ = isInRole == true && role != null ? null : await _UserManager.AddToRoleAsync(
                        user, role.Name);
                        //List<string> userRoles = await _UserManager.GetRolesAsync(user) as List<string>;


                        //await _UserManager.AddToRoleAsync(
                        //user, "Administrador");
                        //await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.rolesUser = await _UserManager.GetRolesAsync(user) as List<string>;
            ViewData["Rol"] = new SelectList(_context.Roles.AsNoTracking(), "Id", "Name");
            return View(user);
        }

        public async Task<User> getCurrentUser() {
            return await _context.Users.Where(s => s.Id == getCurrentUserId("id"))
                    .Include(s => s.Cartera).FirstOrDefaultAsync();
        }
            [HttpPost]

        public async Task<double> UpdateWallet([Bind("Id,OperacionDesc,Monto")] CarteraTransaction carteraTransaction)
        {
            var currentUser = await getCurrentUser();

            if (!ModelState.IsValid)
            {
                return -999.99;

            }

            var montoNotComision = carteraTransaction.Monto;
            double comision = (Double.Parse(currentUser.Cartera.ComisionTAE.ToString()) / 100) * carteraTransaction.Monto;
            carteraTransaction.Monto += comision;
            switch (carteraTransaction.OperacionDesc)
            {
                case "Compra-TAE":
                    //verifica que la cartera tenga saldo normal suficiaente para hacer la compra TAE
                    if (currentUser.Cartera.SaldoNormal < montoNotComision)
                    {
                        return -999.99;
                    }
                    currentUser.Cartera.SaldoTAE += carteraTransaction.Monto;
                    currentUser.Cartera.SaldoNormal -= montoNotComision;
                    _context.Entry(currentUser.Cartera).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    carteraTransaction.CarteraId = currentUser.Cartera.Id;
                    carteraTransaction.FechaOperation = new DateTime();
                    _context.CarteraTransactions.Add(carteraTransaction);
                    await _context.SaveChangesAsync();
                    return currentUser.Cartera.SaldoTAE;
                case "Traspaso-TAE":
                    //verifica que la catidad de saldo TAE sea mayo  o igual a la cantidad a descontar
                    if (currentUser.Cartera.SaldoTAE >= carteraTransaction.Monto)
                    {
                        currentUser.Cartera.SaldoTAE -= carteraTransaction.Monto;
                        currentUser.Cartera.SaldoNormal += montoNotComision;
                        _context.Entry(currentUser.Cartera).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        carteraTransaction.CarteraId = currentUser.Cartera.Id;
                        carteraTransaction.FechaOperation = new DateTime();
                        _context.CarteraTransactions.Add(carteraTransaction);
                        await _context.SaveChangesAsync();
                        return currentUser.Cartera.SaldoNormal;

                    }
                    else { return -999.99; }

            }


            return -999.99;
        }
        [HttpPost]
     
        public async Task<double> NewTransactionTAE([Bind("Id,OperacionDesc,Monto,CarteraId")] CarteraTransaction carteraTransaction)
        {
            if (ModelState.IsValid)
            {
                var userCartera = await getCurrentUser();
                var carteraUpdate = await _context.Carteras.FirstOrDefaultAsync(s => s.Id == carteraTransaction.CarteraId);
                double comision = (Double.Parse(carteraUpdate.ComisionTAE.ToString()) / 100)* carteraTransaction.Monto;
                carteraTransaction.Monto += comision;
                switch (carteraTransaction.OperacionDesc) {
                    case "Abono-TAE":
                        if (userCartera.Cartera.SaldoTAE >= carteraTransaction.Monto)
                        {
                            //actualizando cartera de hijo
                            carteraUpdate.SaldoTAE += carteraTransaction.Monto;
                            carteraUpdate.Asignado += carteraTransaction.Monto;
                            _context.Entry(carteraUpdate).State = EntityState.Modified;

                            //actualizando cartera de padre
                            userCartera.Cartera.SaldoTAE -= carteraTransaction.Monto;
                            userCartera.Cartera.Enviado += carteraTransaction.Monto;
                            await _context.SaveChangesAsync();
                            //Agregando transaccion a la cartera
                            _context.CarteraTransactions.Add(carteraTransaction);
                            await _context.SaveChangesAsync();
                            return carteraUpdate.SaldoTAE;
                        }
                        else {
                            return -999.99;
                        }
                       
                    case "Reverso-TAE":
                        var montoPositive = Math.Abs(carteraTransaction.Monto);
                        if (montoPositive <= carteraUpdate.SaldoTAE)
                        {
                           
                            carteraUpdate.SaldoTAE += carteraTransaction.Monto;
                            carteraUpdate.Asignado += carteraTransaction.Monto;
                            _context.Entry(carteraUpdate).State = EntityState.Modified;

                            //actualizando cartera de padre abuelo y superuser
                            userCartera.Cartera.SaldoTAE -= carteraTransaction.Monto;
                            userCartera.Cartera.Enviado += carteraTransaction.Monto;
                            await _context.SaveChangesAsync();
                            //Agregando transaccion a la cartera
                            _context.CarteraTransactions.Add(carteraTransaction);
                            await _context.SaveChangesAsync();
                            return carteraUpdate.SaldoTAE;
                        }
                        else
                        {
                            return -999.99;
                        }

                }

              
                //actualizando cartera de hijo
                

               
            }
                return -999.99;
        }
        [HttpPost]

        public async Task<double> NewTransactionGlobal([Bind("Id,OperacionDesc,Monto,CarteraId")] CarteraTransaction carteraTransaction)
        {
            if (ModelState.IsValid)
            {
                carteraTransaction.Monto = System.Math.Abs(carteraTransaction.Monto);
                var userCartera = await getCurrentUser();
                var carteraUpdate = await _context.Carteras.FirstOrDefaultAsync(s => s.Id == carteraTransaction.CarteraId);
                //comisión de la cartera del hijo en base al saldo
                double comisionHijo = (Double.Parse(carteraUpdate.ComisionTAE.ToString()) / 100) * carteraTransaction.Monto;
                double comisionPadre = (Double.Parse(userCartera.Cartera.ComisionTAE.ToString()) / 100) * carteraTransaction.Monto;
                //Monto mas comisión de la cartera del hijo

                var saldoComisionH = carteraTransaction.Monto + comisionHijo;
                var saldoComisionP = carteraTransaction.Monto + comisionPadre;

                switch (carteraTransaction.OperacionDesc)
                {
                    case "Abono-Global":
                        if (userCartera.Cartera.SaldoNormal >= carteraTransaction.Monto)
                        {
                            //actualizando cartera de hijo
                            carteraUpdate.SaldoNormal += carteraTransaction.Monto;
                            carteraUpdate.SaldoTAE += saldoComisionH;
                            //carteraUpdate.SaldoTAE += carteraTransaction.Monto;
                            //carteraUpdate.Asignado += carteraTransaction.Monto;
                            _context.Entry(carteraUpdate).State = EntityState.Modified;


                            //actualizando cartera de padre
                            userCartera.Cartera.SaldoNormal -= carteraTransaction.Monto;
                            userCartera.Cartera.SaldoTAE -= saldoComisionH;
                            //userCartera.Cartera.SaldoTAE -= carteraTransaction.Monto;


                            userCartera.Cartera.Enviado += carteraTransaction.Monto;
                            _context.Entry(userCartera.Cartera).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            //Agregando transaccion a la cartera
                            _context.CarteraTransactions.Add(carteraTransaction);
                            await _context.SaveChangesAsync();
                            return carteraUpdate.SaldoNormal;
                        }
                        else
                        {
                            return -999.99;
                        }
                    #region GET ALL WALLETS
                    case "Reverso-Global": //get all wallets to remove comision
                        var montoPositive = Math.Abs(carteraTransaction.Monto);
                        if (montoPositive <= carteraUpdate.SaldoNormal)
                        {
                            //Actualizando saldo de hijo
                            carteraUpdate.SaldoNormal -= carteraTransaction.Monto;
                            carteraUpdate.SaldoTAE -= saldoComisionH;
                            //carteraUpdate.SaldoTAE -= carteraTransaction.Monto;
                            //carteraUpdate.Asignado += carteraTransaction.Monto;
                            _context.Entry(carteraUpdate).State = EntityState.Modified;

                            //actualizando cartera de padre
                            userCartera.Cartera.SaldoNormal += carteraTransaction.Monto;
                            userCartera.Cartera.SaldoTAE += saldoComisionH;
                            //userCartera.Cartera.SaldoTAE += carteraTransaction.Monto;

                            userCartera.Cartera.Enviado -= carteraTransaction.Monto;
                            _context.Entry(userCartera.Cartera).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            //Agregando transaccion a la cartera
                            _context.CarteraTransactions.Add(carteraTransaction);
                            await _context.SaveChangesAsync();
                            return carteraUpdate.SaldoNormal;
                        }
                        #endregion
                        else
                        {
                            return -999.99;
                        }

                }


                //actualizando cartera de hijo



            }
            return -999.99;
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRol(string name, string userId)
        {
            var rolId = await _context.Roles.Where(s => s.Name == name).FirstOrDefaultAsync();
            if (rolId != null) {
                var userRole = await _context.UserRoles.Where(s => s.RoleId == rolId.Id && s.UserId == userId).FirstOrDefaultAsync();
                var roleDeleted = userRole != null ? _context.UserRoles.Remove(userRole) : null;
                if (roleDeleted != null) {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Edit),new { id= userId, partial=true});
                }
                
            }
            return RedirectToAction(nameof(Edit), new { id = userId, partial = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetSaldo() {
            var userId = getCurrentUserId("id");
            var user = await _context.Users.Where(s =>s.Id == userId).Include(s => s.Cartera).AsNoTracking().FirstOrDefaultAsync();
            
            return RedirectToAction("Details", "Carteras", new { id = user.Cartera.Id });
        }
        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
