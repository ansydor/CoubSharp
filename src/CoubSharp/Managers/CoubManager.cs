using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using CoubSharp.Model;
using CoubSharp.Enums;

namespace CoubSharp.Managers
{
    public class CoubManager : IDisposable
    {
        public string AccessToken { get; set; }
        internal const string CoubsUrlBase = "coubs/";
        internal HttpClient _httpClient;

        public CoubManager()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(CoubService.ApiUrlBase);
        }

        public CoubManager(string accessToken) : this()
        {
            AccessToken = accessToken;
        }

        public CoubManager(string accessToken, HttpClient httpClient)
        {
            AccessToken = accessToken;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(CoubService.ApiUrlBase);
        }

        public async Task<Coub> GetCoubAsync(string coubId)
        {
            if (string.IsNullOrWhiteSpace(coubId)) throw new ArgumentNullException("coubId", "coubId can't be null or empty");
            var url = $"{CoubsUrlBase}{coubId}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var coub = JsonConvert.DeserializeObject<Coub>(json);
            return coub;
        }

        public async Task<Coub> EditCoubAsync(string coubId, EditCoub editCoub)
        {
            if (string.IsNullOrWhiteSpace(coubId)) throw new ArgumentNullException("coubId", "coubId can't be null or empty");
            var url = $"{CoubsUrlBase}{coubId}/update_info?access_token={AccessToken}";
            var content = new Dictionary<string, string>
                {
                    { "coub[title]", editCoub.Title },
                    { "coub[channel_id]", editCoub.ChannelId.ToString() },
                    { "coub[original_visibility_type]", editCoub.OriginalVisibilityType.ToString() },
                    { "coub[tags]", string.Join(",", editCoub.Tags) }
                };
            var formContent = new FormUrlEncodedContent(content);
            HttpResponseMessage response = await _httpClient.PostAsync(url, formContent);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var coub = JsonConvert.DeserializeObject<Coub>(json);
            return coub;
        }

        public async Task<bool> DeleteCoubAsync(string coubId)
        {
            throw new NotImplementedException("Not implemented yet");
            var url = $"{CoubsUrlBase}{coubId}?access_token={AccessToken}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var action = JObject.Parse(json);
                var status = action.SelectToken("status").Value<string>();
                return status == "ok";
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
