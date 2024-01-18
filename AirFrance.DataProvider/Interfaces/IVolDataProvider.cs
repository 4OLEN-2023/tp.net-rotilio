using AirFrance.Model;

namespace AirFrance.DataProvider.Interfaces;

public interface IVolDataProvider
{
    public Vol? GetMyFlight();

    public IEnumerable<Vol>? GetMyFlights();
    public Vol? GetFlightById(int gameId);

    public void Add(Vol volAAjouter);
    
    public void Update(Vol vol);
}