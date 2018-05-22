using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dtos.Versions
{
    public class WebChunkFileVersionDto : WebFileVersionDto
    {
       [JsonProperty("chunks")]
        public IEnumerable<int> Chunks { get; set; }
    }
}
