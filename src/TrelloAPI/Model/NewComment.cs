using Newtonsoft.Json;

namespace TrelloAPI.Model
{
    public class NewComment
    {
        [JsonProperty("cardId")]
        public string CardId { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}
