using AirFrance.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AirFrance.Model;


public class Passager
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public float TicketPrice { get; set; }
    public bool IsCheckedId { get; set; }
    public int Id { get; set; }

    public Vol Vol { get; set; }
    public int VolId { get; set; }
}