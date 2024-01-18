using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using AirFrance.DataProvider.Interfaces;
using AirFrance.DataContext;
using AirFrance.Model;

namespace AirFrance.DataProvider;

public class VolDataProvider : IVolDataProvider
{
    private readonly MainDbContext _context;

    public VolDataProvider(MainDbContext context)
    {
        _context = context;
    }

    public Vol? GetMyFlight()
    {
        return null;
    }

    public IEnumerable<Vol>? GetMyFlights()
    {

        IEnumerable<Vol>? vols = _context.Vols.Include(vol=>vol.Passagers);
        return vols;
    }


    public Vol? GetFlightById(int volId)
    {
        return _context.Vols.SingleOrDefault(vol => vol.Id == volId);
    }

    public void Add(Vol vol)
    {
        _context.Add(vol);
        _context.SaveChanges();
    }

    public void Update(Vol vol)
    {
        _context.Update(vol);
        _context.SaveChanges();
    }
}