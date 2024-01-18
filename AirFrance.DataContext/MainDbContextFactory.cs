using AirFrance.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AirFrance.DataContext;

public class MainDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
{
    public MainDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var configuration = configurationBuilder.Build();

        DbContextOptionsBuilder<MainDbContext> builder = new DbContextOptionsBuilder<MainDbContext>();
        builder.UseSqlServer(configuration.GetConnectionString("VolDatabase"));

        MainDbContext context = new MainDbContext(builder.Options);

        return context;
    }
}