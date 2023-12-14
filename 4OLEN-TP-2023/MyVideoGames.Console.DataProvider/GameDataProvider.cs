﻿using System.Text.Json;
using MyVideoGames.Console.DataProvider.Interfaces;
using MyVideoGames.Model;
using MyVideoGames.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MyVideoGames.Console.DataProvider;

public class GameDataProvider : IGameDataProvider
{
    private readonly MainDbContext _context;

    public GameDataProvider(MainDbContext context)
    {
        _context = context;
    }
    // Propriété retournant le chemin
    private string myGamesFilePath
    {
        get { return "\\Users\\jules\\OneDrive\\documents\\C#\\dotnet cours\\tp.net-rotilio\\4OLEN-TP-2023\\MyVideoGames.Console.DataProvider\\JsonFiles\\"; }
    }

    // Propriété qui concatène le chemin et le nom du fichier
    private string myGameFile
    {
        get { return Path.Combine(myGamesFilePath, "MyGame.json"); }
    }

    private string myGamesFile
    {
        get { return Path.Combine(myGamesFilePath, "MyGames.json"); }
    }

    // Méthode de lecture et de déserialisation du fichier JSON
    public Game? GetMyGame()
    {
        // Ouverture du fichier et lecture de son contenu texte
        string jsonString = File.ReadAllText(myGameFile);

        // Transformation de l'objet en Objet (deserialisation)
        Game? game = JsonSerializer.Deserialize<Game>(jsonString);

        // Renvoi
        return game;
    }

    public IEnumerable<Game> GetMyGames()
    {
        //string jsonString = File.ReadAllText(myGamesFile);
        //IList<Game> games = JsonConvert.DeserializeObject<List<Game>>(jsonString);

        IEnumerable<Game>? games = _context.Games.Include(game => game.Platform).ToList();
        return games;
    }
    public void Add(Game gameToAdd)
    {
        _context.Add(gameToAdd);
        _context.SaveChanges();
    }
    public Game? GetGameById(int gameId)
    {
        return _context.Games.SingleOrDefault(game => game.Id == gameId);
    }
    public void Update(Game gameToUpdate)
    {
        _context.Update(gameToUpdate);
        _context.SaveChanges();
    }
}