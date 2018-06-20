using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using CoubSharp.Model;

namespace CoubSharp.Managers
{
    public class ChannelManager
    {
        public string AccessToken { get; set; }
        internal const string ChannelUrlBase = "/api/v2/channels";

        public ChannelManager()
        {
        }

        public ChannelManager(string accessToken)
        {
            AccessToken = accessToken;
        }

        public async Task<Channel> GetChannelAsync(string permalink)
        {
            if (string.IsNullOrWhiteSpace(permalink)) throw new ArgumentNullException("permalink", "permalink can't be null or empty");
            var url = $"{CoubService.ApiUrlBase}{ChannelUrlBase}/{permalink}?access_token={AccessToken}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var channel = JsonConvert.DeserializeObject<Channel>(json);
                return channel;
            }
        }
    }
}
