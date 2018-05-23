using CoubSharp.Dtos;
using CoubSharp.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Managers
{
    public class CoubManager
    {

        internal const string CoubsUrlBase = "/api/v2/coubs/";
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

        public async Task<Coub> EditCoubAsync(string coubId, string token, string title, string channelId, OriginalVisibilityType visibility, IEnumerable<string> tags)
        {
            if (string.IsNullOrWhiteSpace(coubId)) throw new ArgumentNullException("coubId", "coubId can't be null or empty");
            var url = $"{CoubService.ApiUrlBase}{CoubsUrlBase}{coubId}/update_info";
            using (HttpClient httpClient = new HttpClient())
            {
                var coubDto = JsonConvert.SerializeObject(new { access_token = token, coub = new { title = title, channel_id = channelId, original_visibility_type = visibility.ToString(), tags = tags } });

                var content = new StringContent(coubDto, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var coub = JsonConvert.DeserializeObject<Coub>(json);
                return coub;
            }
        }

        public async Task<bool> DeleteCoubAsync(string coubId, string token)
        {
            //if (coubId < 0) throw new ArgumentOutOfRangeException("coubId", "coubId can't be negative");
            var url = $"{CoubService.ApiUrlBase}{CoubsUrlBase}{coubId}?access_token={token}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(url);
                //response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var action = JObject.Parse(json);
                var status = action.SelectToken("status").Value<string>();
                return status == "ok";
            }
        }
    }
}
