using AirFrance.Model;

namespace AirFrance.WebUI.Models;

public class VolListViewModel
{
    public string PageTitle { get; set; }

    public List<Vol> Vols { get; set; }
}