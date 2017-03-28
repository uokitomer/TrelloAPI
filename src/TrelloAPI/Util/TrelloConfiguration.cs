namespace TrelloAPI.Util
{
    public class TrelloConfiguration
    {
        public TrelloConfiguration()
        {
            this.AppKey = "188aea2192f48b0ed57a5be7249754ae";
            this.TrelloAuthUrl = @"https://trello.com/1/authorize";
        }

        public string UserToken { get; set; }
        public string AppKey { get; set; }
        public string TrelloAuthUrl { get; set; }
    }
}
