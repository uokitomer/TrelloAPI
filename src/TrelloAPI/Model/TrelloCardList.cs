using Newtonsoft.Json;
using System.Collections.Generic;

namespace TrelloAPI.Model
{
    public class TrelloCardList
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cards")]
        public IEnumerable<Card> Cards { get; set; }
    }
}
