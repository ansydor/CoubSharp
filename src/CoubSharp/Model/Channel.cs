using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dtos
{
    public class Channel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("followers_count")]
        public int? FollowersCount { get; set; }

        [JsonProperty("following_count")]
        public int? FollowingCount { get; set; }

        [JsonProperty("background_image")]
        public string BackgroundImageUrl { get; set; }

        [JsonProperty("coubs_count")]
        public int? CoubsCount { get; set; }

        [JsonProperty("recoubs_count")]
        public int? EecoubsCount { get; set; }
    }
}
