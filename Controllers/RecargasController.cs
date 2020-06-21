﻿using System;
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
using System.Net;
using Octopus.Helpers;

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
      /*  private readonly string sendRecarga = "<?xml version='1.0' encoding='utf-8'?>"+
            " <soap12:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'"+
            " xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap12='http://www.w3.org/2003/05/soap-envelope'>"+
            "<soap12:Body><TAE xmlns='DMM'><usuario>meximedia0@gmail.com</usuario><password>789456</password>"+
            "<producto>telcel</producto><telefono>7751299313</telefono><monto>20</monto><puntov></puntov></TAE>"+
            "</soap12:Body>;</soap12:Envelope>";*/
        private readonly string getProducts = "<?xml version='1.0' encoding='utf-8'?>" +
            " <soap12:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'" +
            " xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap12='http://www.w3.org/2003/05/soap-envelope'>" +
            "<soap12:Body><ObtenProductosTAE xmlns='DMM'><usuario>meximedia0@gmail.com</usuario><password>789456</password></ObtenProductosTAE>" +
            "</soap12:Body>;</soap12:Envelope>";
        private string headerTAE = "<?xml version='1.0' encoding='utf-8'?>" +
            " <soap12:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'" +
            " xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap12='http://www.w3.org/2003/05/soap-envelope'>" +
            "<soap12:Body><TAE xmlns='DMM'><usuario>USR</usuario><password>PWD</password>";
        private readonly string footerTAE = "</soap12:Body>;</soap12:Envelope>";

        private readonly string sendSecond = "Request_Transaction?jrquest={'User':'7972661217','Password':'Lunes1$','Carrier':'01'," +
            "'Price':'50','Number':'5555555555','Folio_POS':'1000803112700'}";
        private readonly string evolutionHeader = "Request_Transaction?jrquest={'User':'7972661217','Password':'Lunes1$','Carrier':'";
        private readonly string evolutionFooter = "','Folio_POS':'1000803112700'}";
        private PaginadorGenerico<Recarga> _PaginadorRecargas;
        private readonly int _RegistrosPorPagina = 20;
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
        public async Task<IActionResult> Index(string id = "", bool partial = false, string datInit="", string datEnd="", int pagina = 1)
        {
            int _TotalRegistros = 0;
            ViewBag.id = id;
            ViewBag.partial = partial;
            ViewBag.datInit = datInit;
            ViewBag.datEnd = datEnd;
            //Console.WriteLine(await getProductosTAE(getProducts));
            if (_SignInManager.IsSignedIn(User))
            {
                var userId = _SignInManager.IsSignedIn(User) ? User.FindFirstValue(ClaimTypes.NameIdentifier) : "";
                DateTime dateInit = datInit == null || datInit == ""? DateTime.Now.AddDays(-1) :DateTime.Parse(datInit);
                DateTime dateEnd = datEnd == null || datEnd == ""?  DateTime.Now: DateTime.Parse(datEnd);
               
                if (id == null)
                {
                    _TotalRegistros = _context.Recargas
                       .Where(s => s.UserId == userId && s.DateCreated > dateInit && s.DateCreated < dateEnd).Count();
                    // Número total de páginas de la tabla Customers
                    var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);


                    var listaRecargas = await _context.Recargas
                        .Where(s => s.UserId == userId && s.DateCreated > dateInit && s.DateCreated < dateEnd)
                        .Include(r => r.Carrier).Include(r => r.Monto)
                        .Include(r => r.WebServDesc).Include(r => r.Status).Include(s => s.User).AsNoTracking().Skip((pagina - 1) * _RegistrosPorPagina)
                                                 .Take(_RegistrosPorPagina).OrderByDescending(s => s.Id).ToListAsync();
                    var carteraUser = await _context.User.Include(s => s.Cartera).FirstOrDefaultAsync(s => s.Id == userId);
                    ViewBag.cartera = carteraUser.Cartera;

                    _PaginadorRecargas = new PaginadorGenerico<Recarga>()
                    {
                        RegistrosPorPagina = _RegistrosPorPagina,
                        TotalRegistros = _TotalRegistros,
                        TotalPaginas = _TotalPaginas,
                        PaginaActual = pagina,
                        Resultado = listaRecargas
                    };

                    if (partial)
                        return PartialView(_PaginadorRecargas);
                    return View(_PaginadorRecargas);
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
            ViewBag.masterU = false;
            ViewBag.bolerr= false;
            if (_SignInManager.IsSignedIn(User))
            {
                var currentUser = await getCurrentUser();
                var carriers = _context.Carriers.AsNoTracking();
                if (await _UserManager.IsInRoleAsync(currentUser, "Administrador"))
                {
                    if (currentUser.PhoneNumber != "5534040120")
                        ViewData["CarrierId"] =  new SelectList(carriers, "Id", "CarrierName");
                    else
                        ViewBag.masterU = true;
                }
                else
                    ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking().Where(s => s.CarrierName != "Octopus"), "Id", "CarrierName");

                if (currentUser.PhoneNumber != "5534040120") 
                    ViewData["MontoId"] = new SelectList(_context.Montos.Where(s => s.CarrierId == carriers.First().Id).Include(s => s.Carrier).AsNoTracking().OrderBy(s => s.MontoCant), "Id", "MontoCant");
                    //ViewData["WebServDescId"] = new SelectList(_context.WebServDescs.AsNoTracking(), "Id", "WebServiceName");
                
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
            ViewBag.masterU = false;
            bool isAnErr = true; 
            //return View();
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
                    if (service.CarrierName.Equals("Octopus") && montoRecarga > 0) {//option to perform a product transaction
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
                    else if (currentUser.Cartera.SaldoTAE >= montoRecarga)//----option to perform a TAE recarga
                    {//trayendo la cartera del usuario master para regresarle su saldo y comisión
                        var masterUser = await _context.User.Include(s => s.Cartera).FirstOrDefaultAsync(s => s.UserName == "5534040120@octopus.com" && s.CreatedBy == "self");
                            double comisionPadre = 0;
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
                                {//----lista de webservers asignados a la region 
                                    var webServUrl = webServReg[0].WebService.WebServDesc.URL;
                                    var name = webServReg[0].WebService.WebServDesc.WebServiceName;
                                        //choose the webserver to send
                                    Console.WriteLine("Sending recarga to: " + webServUrl);
                                        var error = "";
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
                                        //Validando User Credit before transaction

                                        bool canPerformRec = false;
                                        double tempSaldo = 0;
                                            if (currentUser.Cartera.SaldoNormal > montoRecarga)
                                            {//crea la comisión completa de la recarga si el usuario tiene suficiente saldo normal
                                            tempSaldo =  montoRecarga;
                                            comisionPadre = (Double.Parse(currentUser.Cartera.ComisionTAE.ToString()) / 100) * tempSaldo;
                                        }
                                            else if (currentUser.Cartera.SaldoNormal > 0)
                                            {//crea comisión de lo que tenga de saldo si no alcanza el monto de la recarga
                                            tempSaldo =  currentUser.Cartera.SaldoNormal;
                                            comisionPadre = (Double.Parse(currentUser.Cartera.ComisionTAE.ToString()) / 100) * tempSaldo;
                                        }
                                            else
                                            {//no genera comisión si ya no tiene saldo normal
                                            tempSaldo = 0;
                                            }
                                        //Actualizando saldos master
                                        masterUser.Cartera.SaldoNormal += tempSaldo;
                                        masterUser.Cartera.SaldoTAE += montoRecarga;
                                        _context.Entry(masterUser.Cartera).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();



                                        recarga.StatusId = 1;
                                        recarga.StatusCode = "0";
                                        recarga.DateCreated = DateTime.Now;
                                            recarga.UserId = userId;
                                            recarga.WebServDescId = webServReg[0].WebService.WebServDescId;
                                            currentUser.Cartera.SaldoNormal -= montoRecarga;
                                            currentUser.Cartera.SaldoNormal = currentUser.Cartera.SaldoNormal <= 0 ? 0 : currentUser.Cartera.SaldoNormal;
                                            currentUser.Cartera.Venta += montoRecarga;
                                            currentUser.Cartera.SaldoTAE -= montoRecarga;
                                       

                                        _context.Entry(currentUser.Cartera).State = EntityState.Modified;
                                            CarteraTransaction carteraTransaction =
                                                new CarteraTransaction()
                                                {
                                                    CarteraId = currentUser.Cartera.Id,
                                                    OperacionDesc = "R Pend " + service.CarrierName + " $ " + montoRecarga + " - " + recarga.PhoneNumber,
                                                    FechaOperation = DateTime.Now,
                                                    Monto = montoRecarga,
                                                };
                                            _context.CarteraTransactions.Add(carteraTransaction); 
                                            var carteraTransactionId = await _context.SaveChangesAsync();
                                            _context.Add(recarga);
                                        var recargaId = await _context.SaveChangesAsync();

                                        //realizar la recarga si se inserto nuevo registro de recarga y desconto en wallet
                                        canPerformRec = carteraTransactionId == 2 && recargaId == 1;

                                       
                                        if (canPerformRec) {//trayendo las ultima recarga y actualizacion de wallet para el mismo numero
                                            DateTime dateDiff = DateTime.Now.AddSeconds(-10);
                                            var lastRec = await _context.Recargas.AsNoTracking().OrderByDescending(s => s.DateCreated)
                                                .Where(s => s.PhoneNumber == recarga.PhoneNumber && s.DateCreated > dateDiff
                                                && s.Id != recarga.Id).FirstOrDefaultAsync();

                                            var lastCartTrans = await _context.CarteraTransactions.AsNoTracking().OrderByDescending(s => s.FechaOperation)
                                                .Where(s =>s.OperacionDesc.Contains(recarga.PhoneNumber.ToString())
                                                && s.CarteraId == currentUser.CarteraId && s.FechaOperation > dateDiff && s.Id !=carteraTransaction.Id)
                                                .FirstOrDefaultAsync();
                                            //validando que no se hayan hecho en el ultimo minuto
                                            //var dateToCompare = DateTime.Now.AddSeconds(-10);
                                            if (lastRec != null)
                                                canPerformRec = lastRec.DateCreated < dateDiff;


                                            if (lastCartTrans != null)
                                                canPerformRec = lastCartTrans.FechaOperation < dateDiff;
                                            //validando que aún se pueda realizar la recarga despues de las validaciones
                                            if (canPerformRec) {
                                                recarga.CarrierId = service.CarrierId;
                                                switch (name)
                                                {
                                                    
                                                    case "MX TAE WebService":
                                                        if(webServReg[0].RegionId == 9)
                                                        headerTAE = headerTAE.Replace("USR", "bhernandez@gmail.com").Replace("PWD", "789456");
                                                        else
                                                        headerTAE = headerTAE.Replace("USR", "meximedia0@gmail.com").Replace("PWD", "789456");

                                                        recarga.CarrierTempName = service.CarrierName;
                                                        recargaResponse = await sendRecargaTAE(recarga);
                                                        
                                                        break;
                                                    case "VENTA MÓVIL":
                                                        
                                                        if (webServReg[0].RegionId == 9)
                                                        headerTAE = headerTAE.Replace("USR", "meximedia0@gmail.com").Replace("PWD", "789456");
                                                        recargaResponse = await sendRecargaEvolution(recarga);

                                                        break;
                                                }
                                                recarga.CarrierId = service.Id;
                                                if (recargaResponse != null)
                                                //if(true)
                                                {
                                                    recargaResponse.CarrierId = service.Id;
                                                    if (recargaResponse.ResponseFromCarrier.Contains("Error"))
                                                    {
                                                        error = "Carr";
                                                        ViewBag.error = recargaResponse.ResponseFromCarrier;
                                                    }
                                                    else { 
                                                    Console.WriteLine(recargaResponse.ToString());

                                                    recarga.StatusId = recargaResponse.StatusId;
                                                    recarga.StatusCode = recargaResponse.StatusCode;
                                                    carteraTransaction.CarrierResponse = recargaResponse.ResponseFromCarrier;
                                                    carteraTransaction.OperacionDesc = "Recarga Exitosa " + service.CarrierName + " de " + montoRecarga + " - " + recarga.PhoneNumber;
                                                    _context.Entry(recarga).State = EntityState.Modified;
                                                    _context.Entry(carteraTransaction).State = EntityState.Modified;

                                                    var transactionsUpdate = await _context.SaveChangesAsync();
                                                    return RedirectToAction("Index", "Home");
                                                }
                                                }
                                                else {
                                                    error = "Carr";
                                                    ViewBag.error = "Error al realizar recarga por parte del carrier";
                                                }
                                                
                                            }//fin segunda validación de recarga doble en menos de un minuto
                                            else
                                            {
                                                ViewBag.error = "Error al realizar recarga por intento doble";
                                                error = "Dob ";
                                            }
                                            
                                        }//fin de primera validación para crear recarga, realizar registros
                                        else
                                        {
                                            error = "Oct ";
                                            ViewBag.error = "Error al realizar recarga Octopus";
                                        }
                                        //regresar saldo si no se realizo la recarga solo si se modifico la wallet e inserto registro de la misma
                                        if (carteraTransactionId == 2) {
                                            //actualizando saldos master
                                            //Actualizando saldos master
                                            masterUser.Cartera.SaldoNormal -= tempSaldo;
                                            masterUser.Cartera.SaldoTAE -= montoRecarga;
                                            _context.Entry(masterUser.Cartera).State = EntityState.Modified;
                                            await _context.SaveChangesAsync();

                                            currentUser.Cartera.SaldoNormal += tempSaldo;
                                            currentUser.Cartera.Venta -= montoRecarga;
                                            currentUser.Cartera.SaldoTAE += montoRecarga;
                                            _context.Entry(currentUser.Cartera).State = EntityState.Modified;
                                            await _context.SaveChangesAsync();
                                            carteraTransaction.CarrierResponse = recarga.ResponseFromCarrier;
                                            carteraTransaction.OperacionDesc =
                                                "Error " + error + " - " + service.CarrierName + " $" + recarga.MontoCant + "#" + recarga.PhoneNumber;
                                            _context.Entry(carteraTransaction).State = EntityState.Modified;
                                            await _context.SaveChangesAsync();
                                            
                                        }
                                        if (recargaId == 1) {
                                            _context.Recargas.Remove(recarga);
                                          
                                            await _context.SaveChangesAsync();
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
                    }//fin if, si no encuentra un servicio ligado o carrier
                    else
                    {
                       
                        ViewBag.error = "Carrier no válido";
                    }
                }
                else {
                    
                    ViewBag.error = "No estas logueado";
                }
                   
            }
           
            var carriers = _context.Carriers.AsNoTracking();
            if (await _UserManager.IsInRoleAsync(currentUser, "Administrador"))
            {
                if (currentUser.PhoneNumber != "5534040120")
                    ViewData["CarrierId"] = new SelectList(carriers, "Id", "CarrierName", recarga.CarrierId);
                else
                ViewBag.masterU = false;
            }
            else
                ViewData["CarrierId"] = new SelectList(_context.Carriers.AsNoTracking().Where(s => s.CarrierName != "Octopus"), "Id", "CarrierName", recarga.CarrierId);
            if (currentUser.PhoneNumber != "5534040120")
                ViewData["MontoId"] = new SelectList(_context.Montos.Include(s => s.Carrier).AsNoTracking().OrderBy(s => s.MontoCant), "Id", "MontoCant", recarga.MontoId);
           // ViewData["WebServDescId"] = new SelectList(_context.WebServDescs.AsNoTracking(), "Id", "WebServiceName", recarga.WebServDescId);
            ViewBag.error = ViewBag.error ?? "Posiblemente tus Datos Ingresados son Inválidos";
            ViewBag.bolerr = isAnErr;
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
        //private Recarga sendRecargaTAE(Recarga rec)
        {

            var cuerpo = "<producto>" + rec.CarrierTempName + "</producto>" +
                                                    "<telefono>" + rec.PhoneNumber + "</telefono><monto>" + rec.MontoCant +
                                                    "</monto><puntov></puntov></TAE>','Folio_POS':'1000803112700'}";

                var req = headerTAE + cuerpo + footerTAE;
            rec.RecargaReq = req;

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
            responseStream = responseStream == null ? "":responseStream ;
            Console.Out.WriteLine("respuesta: " + responseStream);
            if (response.IsSuccessStatusCode && !responseStream.Equals("") && response.StatusCode == HttpStatusCode.OK)
            {
               
                    
                var withOutHeader = betweenStrings(responseStream, "<TAEResult>", "</TAEResult>");
                string newResponse = withOutHeader.Replace("&gt;", "").Replace("&lt;", "");
                if (responseStream.Contains("error"))
                {

                    var error = betweenStrings(newResponse, "error", "/error");
                    rec.ResponseFromCarrier = "TAE Error: " +error;
                    if (rec.Intent == 0)
                    {

                        rec.Intent += 1;
                        if (rec.WSTempName != "TAE")
                            return await sendRecargaEvolution(rec);

                    }
                    return rec;

                }
                try
                {
                    var usuario = betweenStrings(newResponse, "Usuario", "/Usuario");
                    var producto = betweenStrings(newResponse, "Producto", "/Producto");
                    var monto = betweenStrings(newResponse, "Monto", "/Monto");
                    var telefono = betweenStrings(newResponse, "Telefono", "/Telefono");
                    var estado = betweenStrings(newResponse, "estado", "/estado");
                    var folio = betweenStrings(newResponse, "Folio", "/Folio");

                    var transaction = betweenStrings(responseStream, "Transaccion&gt;", "&lt;/");
                    rec.ResponseFromCarrier = "Usuario: " + usuario +
                    " Producto: " + producto + " Monto: " + monto + " Telefono: "
                    + telefono + " Estado: " + estado + " Transaction: " + transaction;
                    rec.StatusCode = folio;
                }
                catch (Exception e) {
                    //var folio = betweenStrings(newResponse, "Folio", "/Folio");
                    rec.ResponseFromCarrier = e.ToString() +" ---- "+ newResponse;
                    rec.StatusCode = "0000";
                }
                

                //recarga.PhoneNumber = telefono;
                rec.StatusId = 4;
                
                rec.Ok = true;
                
                rec.WebServDescId = 1;
                return rec;
            }
            else {
                rec.ResponseFromCarrier += responseStream;
                if (rec.Intent == 0)
                {

                    rec.Intent += 1;
                    if (rec.WSTempName != "TAE")
                        return await sendRecargaEvolution(rec);

                }
                
                    return null;
                
                
            }
           // return null;
        }


        private async Task<Recarga> sendRecargaEvolution(Recarga rec) {

            var carrierId = rec.CarrierId < 10 ? "0" + rec.CarrierId : rec.CarrierId.ToString();
            var cuerpo = carrierId + "','Price':'" + rec.MontoCant + "','Number':'"
                                                    + rec.PhoneNumber;
            var req = evolutionHeader + cuerpo + evolutionFooter;
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
            
            responseStream = responseStream == null ? "" : responseStream;
            if (response.IsSuccessStatusCode && !responseStream.Equals("") && response.StatusCode == HttpStatusCode.OK)
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(responseStream);

                Console.WriteLine(xml.InnerText);
                var json = JsonConvert.SerializeObject(xml.InnerText);
                Console.WriteLine(json);

                string replaced = xml.InnerText.Replace("\"", "");
                if (responseStream.Contains("000000"))
                {
                    var error = betweenStrings(replaced, "Description:", ",");
                    rec.ResponseFromCarrier ="Ev Error - "+ error;
                    if (rec.Intent == 0)
                    {
                        rec.Intent += 1;
                        if (rec.WSTempName != "Evolution")
                            return await sendRecargaTAE(rec);

                    }

                    return rec;
                }
                   
                
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
                rec.ResponseFromCarrier += responseStream;
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
