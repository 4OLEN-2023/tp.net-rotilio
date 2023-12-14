using MyVideoGames.Model;

namespace MyVideoGames.Console.DataProvider.Interfaces;

public interface IGameDataProvider
{
    public Game GetMyGame();

    public IEnumerable<Game> GetMyGames();

    public void Add(Game gameToAdd);
    public Game? GetGameById(int gameId);
    public void Update(Game Game);
}
