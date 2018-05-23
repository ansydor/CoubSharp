using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Model.Versions
{
    public class ImageVersions
    {
        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("versions")]
        public IEnumerable<string>  Versions { get; set; }
    }
}
