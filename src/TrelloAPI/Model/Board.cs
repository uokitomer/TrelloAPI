using Newtonsoft.Json;

namespace TrelloAPI.Model
{
    public class Board
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
