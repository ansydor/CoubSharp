using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Model.Versions
{
    public class WebChunkFileVersion : WebFileVersion
    {
       [JsonProperty("chunks")]
        public IEnumerable<int> Chunks { get; set; }
    }
}
