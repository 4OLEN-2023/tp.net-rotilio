using AirFrance.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AirFrance.Model;

public class Vol
{
    public string Destination { get; set; }
    public int SeatCount { get; set; }
    public DateTime TakeOffDate { get; set; }
    public string OnBoardingMessage { get; set; }
    public bool IsDelayed { get; set; }
    public float NetSales { get; set; }
    public int Id { get; set; }
    public List<Passager> Passagers { get; set; }
}
