using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Model
{
    public class GeneralSearchResult
    {
        [JsonProperty("channels")]
        public IEnumerable<Channel> Channels { get; set; }
        [JsonProperty("coubs")]
        public IEnumerable<Coub> Coubs { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("per_page")]
        public int PerPage { get; set; }
        [JsonProperty("total_pages")]
        public int PagesCount { get; set; }
    }
}
