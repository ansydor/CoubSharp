using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Model
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

        [JsonProperty("likes_count ")]
        public int? LikesCount { get; set; }

        [JsonProperty("background_image")]
        public string BackgroundImageUrl { get; set; }

        [JsonProperty("coubs_count")]
        public int? CoubsCount { get; set; }

        [JsonProperty("recoubs_count")]
        public int? RecoubsCount { get; set; }

        [JsonProperty("i_follow_him")]
        public bool? IFollowHim { get; set; }

        [JsonProperty("he_follows_me")]
        public bool? HeFollowsMe { get; set; }

        [JsonProperty("simple_coubs_count")]
        public int? SimpleCoubsCount { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
