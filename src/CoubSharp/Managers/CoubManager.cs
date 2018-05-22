using CoubSharp.Dtos;
using Newtonsoft.Json;
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
        public async Task<CoubDto> GetCoubAsync(string coubId)
        {
            if (string.IsNullOrWhiteSpace(coubId)) throw new ArgumentNullException("coubId", "coubId can't be null or empty");
            var url = $"{CoubService.ApiUrlBase}{CoubsUrlBase}{coubId}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var coub = JsonConvert.DeserializeObject<CoubDto>(result);
                return coub;
            }
        }
    }
}
