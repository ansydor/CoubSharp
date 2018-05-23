using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dtos.Versions
{
    public class FileVersions
    {
        [JsonProperty("web")]
        public WebFileVersion Web { get; set; }

        [JsonProperty("web_chunks")]
        public WebChunkFileVersion WebChunks { get; set; }

        [JsonProperty("html5")]
        public Html5FileVersion Html5 { get; set; }

        [JsonProperty("iphone")]
        public IphoneFileVersion iphone { get; set; }
    }
}
