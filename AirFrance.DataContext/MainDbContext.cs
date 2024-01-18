using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using AirFrance.Model;
using AirFrance.DataContext.EntityTypesConfiguration;

namespace AirFrance.DataContext;

public class MainDbContext : DbContext
{
    protected MainDbContext()
    {
    }

    public MainDbContext([NotNull] DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new VolEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PassagerEntityTypeConfiguration());

        this.SeedDatabase(modelBuilder);
    }

    public DbSet<Vol> Vols { get; set; }
    public DbSet<Passager> Passagers { get; set; }

    private void SeedDatabase(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vol>()
            .HasData(
                new Vol { Id = 1, Destination = "USA", IsDelayed = true, NetSales = 50000.00f, OnBoardingMessage = "welcome to the flight to the USA", SeatCount = 80, TakeOffDate = DateTime.Parse("20/01/2024") }
            );

        modelBuilder.Entity<Passager>()
            .HasData(
                new Passager { Birthdate = DateTime.Parse("01/08/2002"), FirstName = "Jules", LastName = "ROTILIO", IsCheckedId = true, TicketPrice = 50, VolId = 1, Id = 1 },
                new Passager { Birthdate = DateTime.Parse("23/12/1999"), FirstName = "Enzo", LastName = "ROTILIO", IsCheckedId = true, TicketPrice = 50, VolId = 1, Id = 2 }
            );
    }
}
