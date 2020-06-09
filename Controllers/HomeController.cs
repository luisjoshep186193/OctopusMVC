using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Octopus.Models;

namespace Octopus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _SignInManager;
        public HomeController(ILogger<HomeController> logger, SignInManager<User> SignInManager)
        {
            _logger = logger;
            _SignInManager = SignInManager;
        }

        public IActionResult Index()
        {
            //return RedirectToAction("CreateUserRegions", "UserRegions", new { userId = "0a5fd8f4-f2ef-418d-bf4f-cd1292aa2ed2" });
            if (_SignInManager.IsSignedIn(User)) {
                return RedirectToAction("Create","Recargas");
            } else {
                return View();
            }


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return RedirectToAction("CreateUserRegions", "UserRegions", new { userId = "04a5ec97 - feb7 - 4644 - b305 - 10a3eb62b258" });
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
