using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Model
{
    public class EditCoub
    {
        [JsonProperty("original_visibility_type")]
        public string OriginalVisibilityType { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("channed_id")]
        public int ChannelId { get; set; }

        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }
    }
}
