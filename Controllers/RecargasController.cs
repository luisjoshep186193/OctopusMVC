using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Models;
using Octopus.Services;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml;
using Microsoft.AspNetCore.Authorization;

namespace Octopus.Controllers
{
    [Authorize]
    public class RecargasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserData _userData;
        private readonly SignInManager<User> _SignInManager;
        private UserData userData;
        private RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _UserManager;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string sendRecarga = "<?xml version='1.0' encoding='utf-8'?>"+
            " <soap12:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'"+
            " xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap12='http://www.w3.org/2003/05/soap-envelope'>"+
            "<soap12:Body><TAE xmlns='DMM'><usuario>meximedia0@gmail.com</usuario><password>789456</password>"+
            "<producto>telcel</producto><telefono>7751299313</telefono><monto>20</monto><puntov></puntov></TAE>"+
            "</soap12:Body>;</soap12:Envelope>";
        private readonly string getProducts = "<?xml version='1.0' encoding='utf-8'?>" +
            " <soap12:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'" +
            " xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap12='http://www.w3.org/2003/05/soap-envelope'>" +
            "<soap12:Body><ObtenProductosTAE xmlns='DMM'><usuario>meximedia0@gmail.com</usuario><password>789456</password></ObtenProductosTAE>" +
            "</soap12:Body>;</soap12:Envelope>";
        private readonly string headerTAE = "<?xml version='1.0' encoding='utf-8'?>" +
            " <soap12:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'" +
            " xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap12='http://www.w3.org/2003/05/soap-envelope'>" +
            "<soap12:Body><TAE xmlns='DMM'><usuario>meximedia0@gmail.com</usuario><password>789456</password>";
        private readonly string footerTAE = "</soap12:Body>;</soap12:Envelope>";

        private readonly string sendSecond = "Request_Transaction?jrquest={'User':'7972661217','Password':'Lunes1$','Carrier':'01'," +
            "'Price':'50','Number':'5555555555','Folio_POS':'1000803112700'}";
        private readonly string evolutionHeader = "Request_Transaction?jrquest={'User':'7972661217','Password':'Lunes1$','Carrier':'";
        private readonly string evolutionFooter = "','Folio_POS':'1000803112700'}";


        Uri uri = new Uri("http://www.itmultiwebservice.net/wsdmm_p/fdmm.asmx?op=TAE");


        public RecargasController(SignInManager<User> SignInManager,
            ApplicationDbContext context, IUserData userData,
            UserManager<User> UserManager,
            IHttpClientFactory clientFactory,
            RoleManager<IdentityRole> roleMgr)
        {
            _context = context;
            _userData = userData;
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            _clientFactory = clientFactory;
            _roleManager = roleMgr;

        }
        public async Task<User> getCurrentUser()
        {
            return await _context.Users.Where(s => s.Id == getCurrentUserId("id"))
                    .Include(s => s.Cartera).FirstOrDefaultAsync();
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
        // GET: Recargas
        public async Task<IActionResult> Index(string id = "", bool partial = false, string datInit="", string datEnd="")
        {
            Console.WriteLine(await getProductosTAE(getProducts));
            if (_SignInManager.IsSignedIn(User))
            {
                var userId = _SignInManager.IsSignedIn(User) ? User.FindFirstValue(ClaimTypes.NameIdentifier) : "";
                DateTime dateInit = datInit == null || datInit == ""? DateTime.Now.AddDays(-1) :DateTime.Parse(datInit);
                DateTime dateEnd = datEnd == null || datEnd == ""?  DateTime.Now: DateTime.Parse(datEnd);
               
                if (id == null)
                { 
                    var listaRecargas = await _context.Recargas
                        .Where(s => s.UserId == userId && s.DateCreated > dateInit && s.DateCreated < dateEnd)
                        .Include(r => r.Carrier).Include(r => r.Monto)
                        .Include(r => r.WebServDesc).Include(r => r.Status).Include(s => s.User).AsNoTracking().OrderByDescending(s => s.Id).ToListAsync();
                    var carteraUser = await _context.User.Include(s => s.Cartera).FirstOrDefaultAsync(s => s.Id == userId);
                    ViewBag.cartera = carteraUser.Cartera;
                    if (partial)
                        return PartialView(listaRecargas);
                    return View(listaRecargas);
                }
                else {
                   
                    var applicationDbContext = _context.Recargas.Where(s => s.UserId == userId)
                        .Include(r => r.Carrier).Include(r => r.Monto)
                        .Include(r => r.WebServDesc).Include(r => r.Status).Include(s => s.User).AsNoTracking().OrderByDescending(s => s.Id);
                    var carteraUser = await _context.User.Include(s => s.Cartera).FirstOrDefaultAsync(s => s.Id == userId);
                    ViewBag.cartera = carteraUser.Cartera;
                    if (partial)
                        return PartialView();
                    return View(await applicationDbContext.ToListAsync());
                }
                
            }
            else {
                return RedirectToAction("Index", "Home");
            }
          
        }

        [HttpGet]
        public async Task<IEnumerable<SelectListItem>> GetMontos(string name) {
            var montos = await _context.Montos.Where(s=>s.CarrierId == Int32.Parse(name)).Include(s=>s.Carrier).OrderBy(s => s.MontoCant).ToListAsync();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var monto in montos) {
                items.Add(new SelectListItem() { Text = monto.Id.ToString(), Value = monto.MontoCant.ToString() });
            }
           
          
            // you may replace the above code with data reading from database based on the id

            return new SelectList(items, "Value", "Text"); 
            //return await _context.Montos.ToListAsync());
        }
        // GET: Recargas/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id, bool partial)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recarga = await _context.Recargas
                .Include(r => r.Carrier)
                .Include(r => r.Monto)
                .Include(r => r.User)
                .Include(r => r.WebServDesc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recarga == null)
            {
                return NotFound();
            }
            if (partial)
                return PartialView(recarga);
            return View(recarga);
        }

        // GET: Recargas/Create
        public async Task<IActionResult> Create()
        {
            
            if (_SignInManager.IsSignedIn(User))
            {
                var currentUser = await getCurrentUser();
                var carriers = _context.Carriers.AsNoTracking();
                if (await _UserManager.IsInRoleAsync(currentUser, "Administrador"))
                    ViewData["CarrierId"] = new SelectList(carriers, "Id", "CarrierName");
                else
                ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking().Where(s => s.CarrierName != "Octopus"), "Id", "CarrierName");

                ViewData["MontoId"] = new SelectList(_context.Montos.Where(s => s.CarrierId == carriers.First().Id).Include(s => s.Carrier).AsNoTracking().OrderBy(s=>s.MontoCant), "Id", "MontoCant");
                ViewData["WebServDescId"] = new SelectList(_context.WebServDescs.AsNoTracking(), "Id", "WebServiceName");
                return View();
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Recargas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MontoId,PhoneNumber,CarrierId,ConfirmPhone,MontoCant")] Recarga recarga)
        {//,DateCreated,DateResolved,StatusCode,WebServDescId,IdentityUserId

            var userId = _SignInManager.IsSignedIn(User) ? User.FindFirstValue(ClaimTypes.NameIdentifier) : "";
            var currentUser = await getCurrentUser();
            if (ModelState.IsValid)
            {
              
                if (userId != "")
                {//validando que el usuario este logueado y trayendo la cartera del mismo
                    //var currentUser = await _context.User.Include(s => s.Cartera).FirstOrDefaultAsync(s => s.Id == userId);
                    //validando el saldo del usuario
                    var montoRecarga = Double.Parse(recarga.MontoCant);
                    var service = await _context.Carriers.FindAsync(recarga.CarrierId);
                    if (service != null) {
                    if (service.CarrierName.Equals("Octopus")) {//option to perform a product transaction
                            var userUpdate = await _context.User.Include(s => s.Cartera).AsNoTracking()
                              .Where(s => s.PhoneNumber == recarga.PhoneNumber.ToString()).FirstOrDefaultAsync();
                            var carteraTransaction = new CarteraTransaction { CarteraId = userUpdate.Cartera.Id, Monto = montoRecarga, OperacionDesc = "Traspaso-Saldo" };
                            carteraTransaction.Monto = System.Math.Abs(carteraTransaction.Monto);
                            var userCartera = await getCurrentUser();
                            var carteraUpdate = await _context.Carteras.FirstOrDefaultAsync(s => s.Id == carteraTransaction.CarteraId);
                            //comisión de la cartera del hijo en base al saldo
                            double comisionHijo = (Double.Parse(carteraUpdate.ComisionTAE.ToString()) / 100) * carteraTransaction.Monto;
                            double comisionPadre = (Double.Parse(userCartera.Cartera.ComisionTAE.ToString()) / 100) * carteraTransaction.Monto;
                            //Monto mas comisión de la cartera del hijo

                            var saldoComisionH = carteraTransaction.Monto + comisionHijo;
                            var saldoComisionP = carteraTransaction.Monto + comisionPadre;

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
                                _context.CarteraTransactions.Add(
                                           new CarteraTransaction()
                                           {
                                               CarteraId = currentUser.Cartera.Id,
                                               OperacionDesc = "Traspaso de " + montoRecarga + " - " + recarga.PhoneNumber,
                                               FechaOperation = DateTime.Today,
                                               Monto = montoRecarga

                                           });
                                carteraTransaction.OperacionDesc += " de "+currentUser.PhoneNumber+" por ";
                                carteraTransaction.FechaOperation = DateTime.Now;
                                _context.CarteraTransactions.Add(carteraTransaction);
                                await _context.SaveChangesAsync();
                                return RedirectToAction("Index", "Users");
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                                //return -999.99;
                            }

                        }
                    else if (currentUser.Cartera.SaldoTAE >= montoRecarga)//option to perform a TAE recarga
                    {
                        userData = new UserData();
                        var ladaSubstr = recarga.PhoneNumber.ToString().Substring(0, 1);
                        var lada = new Lada();
                        if (ladaSubstr == "4" || ladaSubstr == "7" || ladaSubstr == "8" || ladaSubstr == "9")
                        {
                            lada = getLada(7, recarga.PhoneNumber.ToString());
                        }
                        else
                        {
                            lada = getLada(3, recarga.PhoneNumber.ToString());
                        }




                        if (lada != null)
                        {//obteniendo la lada correspondiente del numero a recargar

                            var userAccessRegion = await _context.UsuarioRegions
                                .Where(s => s.RegionId == lada.RegionId && s.UserId == userId
                                ).AsNoTracking().FirstOrDefaultAsync();
                            if (userAccessRegion != null)
                            {//trayendo la lista de web servers para la region que pertenece la lada
                                var webServReg = await _context.WebServRegions
                                    .Where(s => s.RegionId == userAccessRegion.RegionId && s.WebService.Status == true)
                                    .Include(s => s.WebService).ThenInclude(s => s.WebServDesc)
                                    .OrderBy(s => s.WebService.Order).AsNoTracking().ToListAsync();
                                if (webServReg.Count() > 0)
                                {//lista de webservers asignados a la region 
                                    var webServUrl = webServReg[0].WebService.WebServDesc.URL;
                                    var name = webServReg[0].WebService.WebServDesc.WebServiceName;
                                        //choose the webserver to send
                                    Console.WriteLine("Sending recarga to: " + webServUrl);
                                        Recarga recargaResponse = new Recarga();
                                        recarga.CarrierTempName = service.CarrierName;
                                        if (webServReg.Count() > 1)
                                        {
                                            var desc = webServReg[0].WebService.WebServDesc.WebServiceName;
                                            recarga.WSTempName = desc;
                                            recarga.WSTempName = desc == "MX TAE WebService" ? "Evolution": "TAE";
                                            recarga.Intent = 0;
                                        }
                                        else {
                                            recarga.Intent = -1;
                                        }
                                        

                                        switch (name) {
                                            case "MX TAE WebService":
                                                
                                                recarga.CarrierTempName = service.CarrierName;
                                                recargaResponse = await sendRecargaTAE(recarga);
                                                break;
                                            case "VENTA MÓVIL":
                                                recargaResponse = await sendRecargaEvolution(recarga);
                                                
                                                break;
                                        }
                                   
                                    if (recargaResponse != null )
                                 //if(true)
                                        {
                                            if (recargaResponse.Ok) {
                                                double comision = 0;
                                                if (currentUser.Cartera.SaldoNormal > montoRecarga)
                                                {
                                                    comision = (Double.Parse(currentUser.Cartera.ComisionTAE.ToString()) / 100) * montoRecarga;
                                                }
                                                else if (currentUser.Cartera.SaldoNormal > 0)
                                                {
                                                    comision = (Double.Parse(currentUser.Cartera.ComisionTAE.ToString()) / 100) * currentUser.Cartera.SaldoNormal;
                                                }
                                                else
                                                {
                                                    comision = 0;
                                                }
                                                
                                                Console.WriteLine(recargaResponse.ToString());
                                                recarga.DateCreated = DateTime.Now;
                                                recarga.StatusId = recargaResponse.StatusId;
                                                recarga.StatusCode = recargaResponse.StatusCode;
                                                recarga.UserId = userId;
                                                recarga.WebServDescId = webServReg[0].WebService.WebServDescId;
                                                currentUser.Cartera.SaldoNormal -= montoRecarga;
                                                currentUser.Cartera.SaldoNormal = currentUser.Cartera.SaldoNormal <= 0 ? 0 : currentUser.Cartera.SaldoNormal;
                                                currentUser.Cartera.Venta += montoRecarga;
                                                currentUser.Cartera.SaldoTAE -= montoRecarga;
                                            
                                                _context.Entry(currentUser.Cartera).State = EntityState.Modified;
                                                _context.CarteraTransactions.Add(
                                                    new CarteraTransaction()
                                                    {
                                                        CarteraId = currentUser.Cartera.Id,
                                                        OperacionDesc = "Recarga " + service.CarrierName + " de " + montoRecarga + " - " + recarga.PhoneNumber,
                                                        FechaOperation = DateTime.Now,
                                                        Monto = montoRecarga,
                                                        CarrierResponse = recargaResponse.ResponseFromCarrier

                                                    }); ;
                                                await _context.SaveChangesAsync();
                                                _context.Add(recarga);
                                                await _context.SaveChangesAsync();
                                                return RedirectToAction("Index", "Home");

                                            }

                                        }
                                    else
                                    {
                                        ViewBag.error = "Error al realizar recarga";
                                    }
                                }
                                else//no hay webservers asignados para la region
                                {
                                    ViewBag.error = "no hay webservers asignados para la region";
                                }

                            }
                            else
                            {
                                //No tiene acceso a esa region
                                ViewBag.error = "No tiene acceso a esa region";
                            }
                        }
                        else
                        {
                            //el numero no pertenece a alguna lada
                            ViewBag.error = "Numero erroneo";
                        }
                    }
                    else {
                        ViewBag.error = "No tienes suficiente saldo tae para realizar la recarga";
                    }
                    }
                }
                else {
                    ViewBag.error = "No estas logueado";
                }
                   
            }
           
            var carriers = _context.Carriers.AsNoTracking();
            if (await _UserManager.IsInRoleAsync(currentUser, "Administrador"))
                ViewData["CarrierId"] = new SelectList(carriers, "Id", "CarrierName", recarga.CarrierId);
            else
                ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking().Where(s => s.CarrierName != "Octopus"), "Id", "CarrierName", recarga.CarrierId);

            ViewData["MontoId"] = new SelectList(_context.Montos.Include(s => s.Carrier).AsNoTracking().OrderBy(s => s.MontoCant), "Id", "MontoCant", recarga.MontoId);
            ViewData["WebServDescId"] = new SelectList(_context.WebServDescs.AsNoTracking(), "Id", "WebServiceName", recarga.WebServDescId);
            return View(recarga);
        }
        private async Task<String> getProductosTAE(string req)
        {
            Recarga recarga = new Recarga();
            uri = new Uri("http://www.itmultiwebservice.net/wsdmm_p/fdmm.asmx?op=ObtenProductosTAE");
            recarga.StatusId = 1;


            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            var client = _clientFactory.CreateClient("MXTAE");
            client.BaseAddress = uri;


            request.Content = new StringContent(req,
                                          Encoding.UTF8,
                                          "application/soap+xml");
            var response = await client.SendAsync(request);
            string responseStream = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return responseStream;

            }
            return response.StatusCode.ToString();
        }


        private async Task<Recarga> sendRecargaTAE(Recarga rec)
        {
            var cuerpo = headerTAE + "<producto>" + rec.CarrierTempName + "</producto>" +
                                                    "<telefono>" + rec.PhoneNumber + "</telefono><monto>" + rec.MontoCant +
                                                    "</monto><puntov></puntov></TAE>','Folio_POS':'1000803112700'}"+footerTAE;
            rec.RecargaReq = cuerpo;

           // Recarga recarga = new Recarga();
            uri = new Uri("http://www.itmultiwebservice.net/wsdmm/fdmm.asmx?op=TAE");
            rec.StatusId = 1;
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            var client = _clientFactory.CreateClient("MXTAE");

          
            request.Content = new StringContent(rec.RecargaReq,
                                          Encoding.UTF8,
                                          "application/soap+xml");
            var response = await client.SendAsync(request);
            string responseStream = await response.Content.ReadAsStringAsync();
            Console.Out.WriteLine("respuesta: " + responseStream);
            if (response.IsSuccessStatusCode)
            {
                var usuario = betweenStrings(responseStream, "Usuario&gt;", "&lt;/");
                var producto = betweenStrings(responseStream, "Producto&gt;", "&lt;/");
                var monto = betweenStrings(responseStream, "Monto&gt;", "&lt;/");
                var telefono = betweenStrings(responseStream, "Telefono&gt;", "&lt;/");
                var estado = betweenStrings(responseStream, "estado&gt;", "&lt;/");
                var folio = betweenStrings(responseStream, "Folio&gt;", "&lt;/");

                var transaction = betweenStrings(responseStream, "Transaccion&gt;", "&lt;/");

                //recarga.PhoneNumber = telefono;
                rec.StatusId = 4;
                rec.StatusCode = folio;
                rec.Ok = true;
                rec.ResponseFromCarrier = responseStream;
                rec.WebServDescId = 1;
                return rec;
            }
            else {
                if (rec.Intent == 0)
                {

                    rec.Intent += 1;
                    if (rec.WSTempName != "TAE")
                        return await sendRecargaEvolution(rec);

                }
                
                    return null;
                
                
            }
            
        }


        private async Task<Recarga> sendRecargaEvolution(Recarga rec) {
            var req = evolutionHeader + "0"+rec.CarrierId + "','Price':'" + rec.MontoCant + "','Number':'"
                                                    + rec.PhoneNumber + evolutionFooter;
            rec.RecargaReq = req;
           // Recarga recarga = new Recarga();
            uri = new Uri("http://www.ventamovil.com.mx:9094/service.asmx/" +req );
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var client = _clientFactory.CreateClient("Evolution");
            rec.StatusId = 1;

            request.Content = new StringContent(rec.RecargaReq,
                                           Encoding.UTF8,
                                           "application/soap+xml");
            var response = await client.SendAsync(request);
            string responseStream = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(responseStream);
                
                Console.WriteLine(xml.InnerText);
                var json = JsonConvert.SerializeObject(xml.InnerText);
                Console.WriteLine(json);
                
                string replaced = xml.InnerText.Replace("\"","");
                var folio = betweenStrings(replaced, "Folio:", ",");
                //recarga.MontoCant = monto;
                //recarga.PhoneNumber = telefono;
                rec.StatusCode = folio;
                rec.Ok = true;
                rec.StatusId = 4;
                rec.ResponseFromCarrier = replaced;
                rec.WebServDescId = 2;
                return rec;
            }
            else
            {
                if (rec.Intent == 0)
                {
                    rec.Intent += 1;
                    if (rec.WSTempName != "Evolution")
                        return await sendRecargaTAE(rec);

                }
               
                    return null;
                

            }
        }

        private Lada getLada(int count, string lada)
        {
           
            var subLada = lada.Substring(0, count);
            Lada ladaList = new Lada();
            var ladaMatch = ladaList.ladasInit.Find(s => s.LadaName == subLada);
            return ladaMatch == null && count > 1 ? getLada(count-1,lada):ladaMatch;

            //await _context.Ladas.Where(s => s.LadaName == ladaSubstr).AsNoTracking().FirstOrDefaultAsync(); 
        }

        public static String betweenStrings(String text, String start, String end)
        {
            int p1 = text.IndexOf(start) + start.Length;
            int p2 = text.IndexOf(end, p1);

            if (end == "") return (text.Substring(p1));
            else return text.Substring(p1, p2 - p1);
        }
        // GET: Recargas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recarga = await _context.Recargas.FindAsync(id);
            if (recarga == null)
            {
                return NotFound();
            }
            ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking(), "Id", "CarrierName", recarga.CarrierId);
            ViewData["MontoId"] = new SelectList(_context.Montos.Include(s => s.Carrier).AsNoTracking(), "Id", "MontoCant", recarga.MontoId);
            ViewData["WebServDescId"] = new SelectList(_context.WebServDescs.AsNoTracking(), "Id", "WebServiceName", recarga.WebServDescId);
            return View(recarga);
        }

        

        // POST: Recargas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MontoId,PhoneNumber,CarrierId,DateCreated,DateResolved,StatusCode,WebServDescId,IdentityUserId")] Recarga recarga)
        {
            if (id != recarga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recarga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecargaExists(recarga.Id))
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
            ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking(), "Id", "CarrierName", recarga.CarrierId);
            ViewData["MontoId"] = new SelectList(_context.Montos.AsNoTracking(), "Id", "MontoCant", recarga.MontoId);
            ViewData["WebServDescId"] = new SelectList(_context.WebServDescs.AsNoTracking(), "Id", "WebServiceName", recarga.WebServDescId);
            return View(recarga);
        }

        // GET: Recargas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recarga = await _context.Recargas
                .Include(r => r.Carrier)
                .Include(r => r.Monto)
                .Include(r => r.WebServDesc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recarga == null)
            {
                return NotFound();
            }

            return View(recarga);
        }

        // POST: Recargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recarga = await _context.Recargas.FindAsync(id);
            _context.Recargas.Remove(recarga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecargaExists(int id)
        {
            return _context.Recargas.Any(e => e.Id == id);
        }
    }
}
