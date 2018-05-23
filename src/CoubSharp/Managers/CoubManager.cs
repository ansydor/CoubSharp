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
    public class CoubManager
    {
        private string _accessToken;
        internal const string CoubsUrlBase = "/api/v2/coubs/";

        internal CoubManager(string accessToken)
        {
            _accessToken = accessToken;
        }

        public async Task<Coub> GetCoubAsync(string coubId)
        {
            if (string.IsNullOrWhiteSpace(coubId)) throw new ArgumentNullException("coubId", "coubId can't be null or empty");
            var url = $"{CoubService.ApiUrlBase}{CoubsUrlBase}{coubId}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var coub = JsonConvert.DeserializeObject<Coub>(json);
                return coub;
            }
        }

        public async Task<Coub> EditCoubAsync(string coubId, EditCoub editCoub)
        {
            if (string.IsNullOrWhiteSpace(coubId)) throw new ArgumentNullException("coubId", "coubId can't be null or empty");
            var url = $"{CoubService.ApiUrlBase}{CoubsUrlBase}{coubId}/update_info?access_token={_accessToken}";
            using (HttpClient httpClient = new HttpClient())
            {
                var content = new Dictionary<string, string>
                {
                    { "coub[title]", editCoub.Title },
                    { "coub[channel_id]", editCoub.ChannelId.ToString() },
                    { "coub[original_visibility_type]", editCoub.OriginalVisibilityType.ToString() },
                    { "coub[tags]", string.Join(",", editCoub.Tags) }
                };

                var formContent = new FormUrlEncodedContent(content);
                HttpResponseMessage response = await httpClient.PostAsync(url, formContent);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var coub = JsonConvert.DeserializeObject<Coub>(json);
                return coub;
            }
        }

        public async Task<bool> DeleteCoubAsync(string coubId)
        {
            throw new NotImplementedException("Not implemented yet");
            var url = $"{CoubService.ApiUrlBase}{CoubsUrlBase}{coubId}?access_token={_accessToken}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var action = JObject.Parse(json);
                var status = action.SelectToken("status").Value<string>();
                return status == "ok";
            }
        }
    }
}
