using CoubSharp.Dto;
using CoubSharp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Managers
{
    public class RecoubManager : IDisposable
    {

        public string AccessToken { get; set; }
        internal const string RecoubsUrlBase = "recoubs";
        internal HttpClient _httpClient;

        public RecoubManager()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(CoubService.ApiUrlBase);
        }

        public RecoubManager(string accessToken) : this()
        {
            AccessToken = accessToken;
        }

        public RecoubManager(string accessToken, HttpClient httpClient)
        {
            AccessToken = accessToken;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(CoubService.ApiUrlBase);
        }

        public async Task<Coub> MakeRecoubAsync(int recoubToId, int channelId)
        {
            if (recoubToId < 0) throw new ArgumentOutOfRangeException("recoubToId", "recoubToId can't be negative");
            if (channelId < 0) throw new ArgumentOutOfRangeException("channelId", "channelId can't be negative");
            var url = $"{RecoubsUrlBase}?access_token={AccessToken}";
            var jsonObject = JsonConvert.SerializeObject(new MakeRecoubDto { RecoubToId = recoubToId.ToString(), ChannelId = channelId.ToString() });
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var coub = JsonConvert.DeserializeObject<Coub>(json);
            return coub;

        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
