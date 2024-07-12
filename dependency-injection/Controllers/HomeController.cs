using DI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using DI.Services;

namespace DI.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        private ITransientNumberService _transientService;
        private IScopeNumberService _scopeNumber;
        private ISingletonNumberService _singleton;
        public HomeController(ILogger<HomeController> logger, ITransientNumberService transientService, IScopeNumberService scopeNumber, ISingletonNumberService singleton)
        {
            _logger = logger;
            _transientService = transientService;
            _scopeNumber = scopeNumber;
            _singleton = singleton;
        }
        public IActionResult Index()
        {
            ViewData["transient"] = _transientService.GetNumber();
            ViewData["scopeNumber"] = _scopeNumber.GetNumber();
            ViewData["singleton"] = _singleton.GetNumber();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
