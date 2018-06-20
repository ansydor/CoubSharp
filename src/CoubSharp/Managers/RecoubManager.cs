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
    public class RecoubManager
    {

        public string AccessToken { get; set; }
        internal const string RecoubsUrlBase = "/api/v2/recoubs";
        public RecoubManager(string accessToken)
        {
            AccessToken = accessToken;
        }
        public RecoubManager()
        {
        }

        public async Task<Coub> MakeRecoubAsync(int recoubToId, int channelId)
        {
            if (recoubToId < 0) throw new ArgumentOutOfRangeException("recoubToId", "recoubToId can't be negative");
            if (channelId < 0) throw new ArgumentOutOfRangeException("channelId", "channelId can't be negative");
            var url = $"{CoubService.ApiUrlBase}{RecoubsUrlBase}?access_token={AccessToken}";
            var jsonObject = JsonConvert.SerializeObject(new MakeRecoubDto { RecoubToId = recoubToId.ToString(), ChannelId = channelId.ToString() });
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var coub = JsonConvert.DeserializeObject<Coub>(json);
                return coub;
            }
        }
    }
}
