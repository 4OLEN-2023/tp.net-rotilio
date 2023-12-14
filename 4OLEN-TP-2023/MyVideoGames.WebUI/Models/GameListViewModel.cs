using MyVideoGames.Console.DataProvider;
using MyVideoGames.Model;

namespace MyVideoGames.WebUI.Models
{
    public class GameListViewModel
    {
        
        public IEnumerable<Game> myGames;
        public string PageTitle;
        public string WelcomeMessage;
        
    }
}
