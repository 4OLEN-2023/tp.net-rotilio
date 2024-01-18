using AirFrance.Model;

namespace AirFrance.WebUI.Models;

public class PassagerListViewModel
{
    public string PageTitle { get; set; }

    public List<Passager> Passagers { get; set; }
}