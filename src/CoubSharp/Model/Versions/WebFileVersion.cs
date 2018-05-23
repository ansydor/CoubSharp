using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dtos.Versions
{
    public class WebFileVersion
    {
        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("types")]
        public IEnumerable<string> Types { get; set; }

        [JsonProperty("version")]
        public IEnumerable<string> Versions { get; set; }
    }
}
