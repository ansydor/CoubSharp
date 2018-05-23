using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dtos.Versions
{
    public class MobileFileVersion
    {
        [JsonProperty("gifv")]
        public string Gigv { get; set; }

        [JsonProperty("looped_audio")]
        public string LoopedAudioUrl { get; set; }

        [JsonProperty("audio")]
        public IEnumerable<string> AudioUrls { get; set; }

        [JsonProperty("audio_url")]
        public string AudioUrl { get; set; }

        [JsonProperty("base64_url")]
        public string Base64Url { get; set; }

        [JsonProperty("base64_files")]
        public IEnumerable<string> Base64FilesUrls { get; set; }

        [JsonProperty("frames_count")]
        public int? FrameCount { get; set; }
    }
}
