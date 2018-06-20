using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dto
{
    internal class MakeRecoubDto
    {
        [JsonProperty("recoub_to_id")]
        internal string RecoubToId { get; set; }
        [JsonProperty("channel_id")]
        internal string ChannelId { get; set; }
    }
}
