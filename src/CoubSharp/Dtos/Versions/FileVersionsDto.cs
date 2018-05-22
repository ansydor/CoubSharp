using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dtos.Versions
{
    public class FileVersionsDto
    {
        [JsonProperty("web")]
        public WebFileVersionDto Web { get; set; }

        [JsonProperty("web_chunks")]
        public WebChunkFileVersionDto WebChunks { get; set; }

        [JsonProperty("html5")]
        public Html5FileVersionDto Html5 { get; set; }

        [JsonProperty("iphone")]
        public IphoneFileVersion iphone { get; set; }
    }
}
