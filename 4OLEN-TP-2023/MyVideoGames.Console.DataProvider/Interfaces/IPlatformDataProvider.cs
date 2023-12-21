using MyVideoGames.Model;

namespace MyVideoGames.Console.DataProvider.Interfaces;

public interface IPlatformDataProvider
{
    public IEnumerable<Platform> GetMyPlatforms();

    public void Add(Platform platformToAdd);
    public Platform? GetPlatformById(int PlatformId);
    public void Update(Platform Game);
}
