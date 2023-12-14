using System.Numerics;
using System.Text.Json.Serialization;

namespace MyVideoGames.Model;

public class Platform
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("id")]
    public int Id { get; set; }
    public IList<Game>? RelatedGames { get; set; }

}