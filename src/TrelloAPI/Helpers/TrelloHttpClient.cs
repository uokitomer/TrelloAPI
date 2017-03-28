using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TrelloAPI.Model;
using TrelloAPI.Util;

namespace TrelloAPI.Helpers
{
    public class TrelloHttpClient
    {
        private HttpClient _client;
        private TrelloConfiguration _config;

        public TrelloHttpClient(TrelloConfiguration config)
        {
            this._client = new HttpClient();
            this._client.BaseAddress = new Uri("https://api.trello.com/1/");
            this._client.DefaultRequestHeaders.Accept.Clear();
            this._client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this._config = config;
        }

        public async Task<IEnumerable<TrelloCardList>> GetTrelloCardLists(string boardId)
        {
            IEnumerable<TrelloCardList> lists = null;
            var query = $"boards/{boardId}/lists?cards=open&card_fields=name&fields=name&key={this._config.AppKey}&token={this._config.UserToken}";
            HttpResponseMessage response = await this._client.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                lists = await response.Content.ReadAsAsync<IEnumerable<TrelloCardList>>();
            }

            return lists;
        }

        public async Task<Member> GetCurrentMember()
        {
            Member member = null;

            var query = $"members/me?fields=username,fullName,url&boards=all&board_fields=name&key={this._config.AppKey}&token={this._config.UserToken}";
            HttpResponseMessage response = await this._client.GetAsync(query);

            if (response.IsSuccessStatusCode)
            {
                member = await response.Content.ReadAsAsync<Member>();
            }

            return member;
        }

        public void AddComment(NewComment comment)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("text", comment.Comment));
            var query = $"cards/{comment.CardId}/actions/comments?key={this._config.AppKey}&token={this._config.UserToken}";
            HttpContent content = new FormUrlEncodedContent(postData);
            var response = this._client.PostAsync(query, content);
        }
    }
}
