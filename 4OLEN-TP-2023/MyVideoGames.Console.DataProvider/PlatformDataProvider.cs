using System.Text.Json;
using MyVideoGames.Console.DataProvider.Interfaces;
using MyVideoGames.Model;
using MyVideoGames.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MyVideoPlatforms.Console.DataProvider;

public class PlatformDataProvider : IPlatformDataProvider
{
    private readonly MainDbContext _context;

    public PlatformDataProvider(MainDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Platform> GetMyPlatforms()
    {
        //string jsonString = File.ReadAllText(myPlatformsFile);
        //IList<Platform> Platforms = JsonConvert.DeserializeObject<List<Platform>>(jsonString);

        IEnumerable<Platform>? Platforms = _context.Platforms.ToList();
        return Platforms;
    }
    public void Add(Platform PlatformToAdd)
    {
        _context.Add(PlatformToAdd);
        _context.SaveChanges();
    }
    public Platform? GetPlatformById(int PlatformId)
    {
        return _context.Platforms.SingleOrDefault(Platform => Platform.Id == PlatformId);
    }
    public void Update(Platform PlatformToUpdate)
    {
        _context.Update(PlatformToUpdate);
        _context.SaveChanges();
    }
}