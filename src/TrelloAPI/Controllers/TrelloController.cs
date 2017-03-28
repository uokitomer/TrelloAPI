using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrelloAPI.Helpers;
using TrelloAPI.Model;
using TrelloAPI.Util;

namespace TrelloAPI.Controllers
{
    [Route("api/[controller]")]
    public class TrelloController : Controller
    {
        private TrelloHttpClient _httpClient = null;
        private TrelloConfiguration _config = null;
        private Authentication _authentication = null;

        public TrelloController(IOptions<TrelloConfiguration> trelloConfigAccesor)
        {
            this._httpClient = new TrelloHttpClient(trelloConfigAccesor.Value);
            this._config = trelloConfigAccesor.Value;
            this._authentication = new Authentication(this._config);
        }

        [HttpGet]
        [Route("auth")]
        public async Task<string> Authenticate()
        {
            Task<string> redirectUrl = Task.Run(() => this._authentication.RetrieveAuthUrl());
            var url = await redirectUrl;

            return url;
        }
        
        [HttpGet]
        [Route("user")]
        public async Task<Member> Get(string token)
        {
            this._config.UserToken = token;
            var member = await this._httpClient.GetCurrentMember();
            return member;
        }

        [HttpGet]
        [Route("board/list")]
        public Task<IEnumerable<TrelloCardList>> GetTrelloCardList(string id, string token)
        {
            this._config.UserToken = token;
            return this._httpClient.GetTrelloCardLists(id);
        }
        
        [HttpPost]
        [Route("card/comment")]
        public void AddNewComment([FromBody]NewComment comment)
        {
            this._config.UserToken = comment.Token;
            this._httpClient.AddComment(comment);
        }
    }
}
