using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dtos
{
    public class CategoryDto
    {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("visible")]
        public string Visible { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }
    }
}
