using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using AirFrance.DataProvider.Interfaces;
using AirFrance.DataContext;
using AirFrance.Model;

namespace AirFrance.DataProvider;

public class PassagerDataProvider : IPassagerDataProvider
{
    private readonly MainDbContext _context;

    public PassagerDataProvider(MainDbContext context)
    {
        _context = context;
    }

    public Passager? GetMyPassager()
    {
        return null;
    }

    public IEnumerable<Passager>? GetMyPassagers()
    {
        IEnumerable<Passager>? passagers = _context.Passagers.Include(passager => passager.Vol);
        return passagers;
    }

    public Passager? GetPassagerById(int passagerId)
    {
        return _context.Passagers.SingleOrDefault(passager => passager.Id == passagerId);
    }

    public void Add(Passager passager)
    {
        _context.Add(passager);
        _context.SaveChanges();
    }

    public void Update(Passager passager)
    {
        _context.Update(passager);
        _context.SaveChanges();
    }
}