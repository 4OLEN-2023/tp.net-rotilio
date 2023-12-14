using System.Numerics;
using System.Text.Json.Serialization;

namespace MyVideoGames.Model
{


    public class Game
    {
        // Attribut indiquant à la librairie JSON le nom de la propriété JSON associée au champs
        public int Id { get; set; }

        public string Slug { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public float Rating { get; set; }

        public int RatingTop { get; set; }

        public int PlayTime { get; set; }

        public Platform? Platform { get; set; }

        public int PlatformId { get; set; }
    }
}