using CoubSharp.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.ConsoleSample.Snippets
{
    public class AuthorizeSnippets
    {
        public async Task<string> AuthorizeAsync()
        {
            var token = string.Empty;
            IAuthorizationService authorizationService = new AuthorizationService("", "");
            LocalhostServerCodeReceiver receiver = new LocalhostServerCodeReceiver("http://localhost:8080/");

            var urlToGetAuthorizeCode = authorizationService.AuthorizationCodeUrlAsync("http://localhost:8080/", new string[] { AuthorizationService.Scope.LoggedIn, AuthorizationService.Scope.Recoub, AuthorizationService.Scope.Create, AuthorizationService.Scope.Like, AuthorizationService.Scope.ChannelEdit, AuthorizationService.Scope.Follow });

            var code = await authorizationService.AuthorizeCodeWithReceiverAsync(receiver, new string[] { AuthorizationService.Scope.LoggedIn, AuthorizationService.Scope.Recoub, AuthorizationService.Scope.Create, AuthorizationService.Scope.ChannelEdit, AuthorizationService.Scope.Follow });
            var auth = await authorizationService.AuthorizeTokenAsync("http://localhost:8080/", code);
            token = auth.AccessToken;
            return token;
        }
    }
}
