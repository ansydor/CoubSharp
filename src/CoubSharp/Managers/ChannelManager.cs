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
    public class ChannelManager : IDisposable
    {
        public string AccessToken { get; set; }
        internal const string ChannelUrlBase = "channels";
        internal HttpClient _httpClient;
        public ChannelManager()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(CoubService.ApiUrlBase);
        }

        public ChannelManager(string accessToken) : this()
        {
            AccessToken = accessToken;
        }

        public ChannelManager(string accessToken, HttpClient httpClient)
        {
            AccessToken = accessToken;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(CoubService.ApiUrlBase);
        }

        public async Task<Channel> GetChannelAsync(string permalink)
        {
            if (string.IsNullOrWhiteSpace(permalink)) throw new ArgumentNullException("permalink", "permalink can't be null or empty");
            var url = $"{ChannelUrlBase}/{permalink}?access_token={AccessToken}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var channel = JsonConvert.DeserializeObject<Channel>(json);
            return channel;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
