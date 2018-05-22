using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dtos.Versions
{
    public class Html5FileVersionDto
    {
        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("chunks")]
        public IEnumerable<int> Chunks { get; set; }
    }
}
