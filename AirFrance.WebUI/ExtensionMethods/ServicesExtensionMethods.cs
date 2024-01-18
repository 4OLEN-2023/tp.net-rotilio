using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AirFrance.DataProvider;
using AirFrance.DataProvider.Interfaces;
using AirFrance.DataContext;

namespace AirFrance.WebUI.ExtensionMethods;

public static class ServicesExtensionMethods
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        
        string connectionString = configuration.GetConnectionString("VolDatabase");
        services.AddDbContext<MainDbContext>(options =>
        {
            options.UseSqlServer(connectionString, options => { });
        });

        services.AddScoped<IVolDataProvider, VolDataProvider>();
        services.AddScoped<IPassagerDataProvider, PassagerDataProvider>();

        services.AddControllersWithViews();
        services.AddRazorPages();
        
        services.AddDbContext<MainDbContext>(options => options.UseSqlServer(connectionString));
        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<MainDbContext>();

        
        return services;
    }
}