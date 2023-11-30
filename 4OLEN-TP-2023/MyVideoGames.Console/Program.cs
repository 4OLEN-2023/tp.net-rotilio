// Imports des projets nécessaires
using MyVideoGames.Console.DataProvider;
using MyVideoGames.Model;

// Création d'un GameDataProvider
GameDataProvider gameDataProvider = new();

// Appel de la méthode qui retourne les données via un objet
List<GameModel> myGameModel = gameDataProvider.GetMyGames();

// Affichage des données
PrintMyGame(myGameModel);

// Mise en pause de la console
Console.ReadLine();

// Méthode permettant l'affichage de notre jeu issue du json
static void PrintMyGame(List<GameModel> gameList)
{
    foreach (GameModel game in gameList)
    {

        var newLine = $"{Environment.NewLine}{Environment.NewLine}";

        Console.WriteLine($"My video game : {newLine}" +
                          $"{game.Id} - {game.Slug} {newLine}" +
                          $"{game.Name} {newLine}" +
                          $"Release date : {game.ReleaseDate.ToShortDateString()}{newLine}" +
                          $"Platform : {game.Plateform.Name}{newLine}" +
                          $"Rating : {game.Rating}/{game.RatingTop}{newLine}" +
                          $"Play time : {game.PlayTime}h{newLine}" +
                          $"Description : {game.Description}{newLine}");
    }
}