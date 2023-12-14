using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.Json;
using MyVideoGames.Console.DataProvider;
using MyVideoGames.Console.DataProvider.Interfaces;
using MyVideoGames.Model;
using MyVideoGames.WebUI.Models;
using System.Diagnostics;

namespace MyVideoGames.WebUI.Controllers
{
    public class GameController : Controller
    {
        public IGameDataProvider _gameDataProvider;

        public GameController(IGameDataProvider gameDataProvider)
        {
            _gameDataProvider = gameDataProvider;
        }

        public IActionResult Index()
        {
            GameListViewModel model = new()
            {
                PageTitle = "Ma collection de jeux vidéos",
                WelcomeMessage = "Bienvenue"

            };

            model.myGames = _gameDataProvider.GetMyGames();

            return View(model);
        }

        // Création d'une action de type HttpGET
    [HttpGet]
    public IActionResult AddOrEdit(int? id)
    {
        Game gameToAddOrEdit = new();

        if (id.HasValue)
        {
            gameToAddOrEdit = _gameDataProvider.GetGameById(id.Value);
        }

        AddOrEditGameViewModel model = new()
        {
            GameToAddOrEdit = gameToAddOrEdit,
            PlatformsAvailable = InitializePlatforms()
        };

        return View(model);
    }

    // Création d'une action de type HttpPost
    [HttpPost]
    public IActionResult AddOrEdit(AddOrEditGameViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.PlatformsAvailable = InitializePlatforms();
            return View(model);
        }

        if(model.GameToAddOrEdit.Id != 0)
        {
            _gameDataProvider.Update(model.GameToAddOrEdit);
        }
        else
        {
            _gameDataProvider.Add(model.GameToAddOrEdit);
        }

        return this.RedirectToAction("Index");
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
        private List<SelectListItem> InitializePlatforms()
        {
            return new List<SelectListItem>
            {
                new() {Text = "Xbox",Value="1"},
                new() {Text = "Playstation",Value="2"},
                new() {Text = "PC",Value="3"}
            };
        }
    }
}
