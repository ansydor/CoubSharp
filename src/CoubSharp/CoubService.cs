using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using CoubSharp.Receivers;
using Newtonsoft.Json;
using CoubSharp.Dtos;
using CoubSharp.Managers;

namespace CoubSharp
{
    public interface ICoubService
    {
        /// <summary>
        /// Return authorize code
        /// </summary>
        /// <param name="redirectUrl">The callback URL which the Coub server responses in with client credentials</param>
        /// <param name="scopes">List of scopes</param>
        /// <returns></returns>
        string AuthorizationCodeUrlAsync(string redirectUrl, IEnumerable<string> scopes = default(IEnumerable<string>));
        Task<string> AuthorizeWithReceiverAsync(ICodeReceiver receiver, IEnumerable<string> scopes = null);
    }
    public class CoubService : ICoubService
    {
        /// <summary>
        /// Access modes
        /// </summary>
        public static class Scope
        {
            /// <summary>The default access mode</summary>
            public const string LoggedIn = "logged_in";

            /// <summary>With the ability to create coub videos</summary>
            public const string Create = "create";

            /// <summary>With the ability to do a like on coub videos</summary>
            public const string Like = "like";

            /// <summary>With the ability to recoub coub videos</summary>
            public const string Recoub = "recoub";

            /// <summary>With the ability to follow channels</summary>
            public const string Follow = "follow";

            /// <summary>With the ability to edit channels</summary>
            public const string ChannelEdit = "channel_edit";

        }
        /// <summary>
        /// Endpoint url base part
        /// </summary>
        internal const string _apiUrlBase = "http://coub.com";
        internal const string _authorizeCodeUrlBase = "/oauth/authorize";
        internal const string _authorizeTokenUrlBase = "/oauth/token";

        public string ApplicationId { get; set; }
        public string ApplicationSecret { get; set; }


        public CoubManager Coubs { get; set; }

        /// <summary>
        /// Create an instance of <see cref="CoubService"/>.
        /// </summary>
        public CoubService()
        {

        }

        /// <summary>
        /// Construstor for Coub application client https://coub.com/dev/applications/
        /// </summary>
        /// <param name="appId">Application Identifier</param>
        /// <param name="appSecret">Application Secret Token</param>
        public CoubService(string appId, string appSecret)
        {
            ApplicationId = appId;
            ApplicationSecret = appSecret;
        }

        public string AuthorizationCodeUrlAsync(string redirectUrl, IEnumerable<string> scopes = default(IEnumerable<string>))
        {
            if (redirectUrl == null)
                throw new ArgumentNullException("redirectUrl", "redirectUrl can't be null");
            var scopeList = scopes ?? Enumerable.Empty<string>();
            var scope = string.Join("+", scopeList);
            var url = $"{_apiUrlBase}{_authorizeCodeUrlBase}?response_type=code&client_id={ApplicationId}&redirect_uri={redirectUrl}&scope={scope}";
            return url;
        }

        public async Task<string> AuthorizeWithReceiverAsync(ICodeReceiver receiver, IEnumerable<string> scopes = null)
        {
            var scopeList = scopes ?? Enumerable.Empty<string>();
            var scope = string.Join("+", scopeList);
            var url = $"{_apiUrlBase}{_authorizeCodeUrlBase}?response_type=code&client_id={ApplicationId}&scope={scope}";
            var code = await receiver.ReceiveCodeAsync(url, new System.Threading.CancellationToken());
            return code;
        }

        public async Task<AuthorizationDto> AuthorizeTokenAsync(string redirectUrl, string code)
        {
            if (code == null)
                throw new ArgumentNullException("code", "code can't be null");
            var url = $"{_apiUrlBase}{_authorizeTokenUrlBase}?grant_type=authorization_code&response_type=code&client_id={ApplicationId}&client_secret={ApplicationSecret}&code={code}&redirect_uri={redirectUrl}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.PostAsync(url, null);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var authorization = JsonConvert.DeserializeObject<AuthorizationDto>(result);
                return authorization;
            }
        }
    }
}
