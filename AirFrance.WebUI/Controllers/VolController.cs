using AirFrance.DataProvider.Interfaces;
using AirFrance.Model;
using AirFrance.Models;
using AirFrance.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Resources;

namespace AirFrance.Controllers
{
    public class VolController : Controller
    {
        private readonly ILogger<VolController> _logger;
        public IVolDataProvider volDataProvider { get; set; }

        public VolController(ILogger<VolController> logger, IVolDataProvider volDataProvider)
        {
            _logger = logger;
            this.volDataProvider = volDataProvider;
        }

        public IActionResult Index()
        {
            var Vols = volDataProvider.GetMyFlights().ToList();

            VolListViewModel model = new()
            {
                PageTitle = ""
            };

            if (Vols != null)
            {
                model.Vols = Vols;
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
