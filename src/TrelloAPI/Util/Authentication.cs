using Microsoft.AspNet.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrelloAPI.Util
{
    public class Authentication
    {
        TrelloConfiguration _config = null;

        public Authentication(TrelloConfiguration config)
        {
            this._config = config;
        }

        public string RetrieveAuthUrl()
        {
            IDictionary<string, string> queryParameters = new Dictionary<string, string>();
            
            queryParameters.Add("callback_method", "fragment");
            queryParameters.Add("return_url", "http://localhost:3000/trello-auth?");
            queryParameters.Add("scope", "read,write");
            queryParameters.Add("expiration", "never");
            queryParameters.Add("name", "My Trello API");
            queryParameters.Add("key", this._config.AppKey);

            var query = QueryHelpers.AddQueryString(this._config.TrelloAuthUrl, queryParameters);

            return query;
        }
    }
}
