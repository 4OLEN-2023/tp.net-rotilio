using AirFrance.DataProvider;
using AirFrance.DataProvider.Interfaces;
using AirFrance.Model;
using AirFrance.Models;
using AirFrance.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Resources;

namespace AirFrance.Controllers
{
    public class PassagerController : Controller
    {
        private readonly ILogger<PassagerController> _logger;
        public IPassagerDataProvider PassagerDataProvider { get; set; }

        public PassagerController(ILogger<PassagerController> logger, IPassagerDataProvider PassagerDataProvider)
        {
            _logger = logger;
            this.PassagerDataProvider = PassagerDataProvider;
        }

        public IActionResult Index()
        {
            var Passagers = PassagerDataProvider.GetMyPassagers().ToList();

            PassagerListViewModel model = new()
            {
                PageTitle = ""
            };

            if (Passagers != null)
            {
                model.Passagers = Passagers;
            }

            return View(model);
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
