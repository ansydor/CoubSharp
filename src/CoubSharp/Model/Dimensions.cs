using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dtos
{
    public class Dimensions
    {
        [JsonProperty("big")]
        public IEnumerable<int> Big { get; set; }

        [JsonProperty("med")]
        public IEnumerable<int> Medium { get; set; }

        [JsonProperty("small")]
        public IEnumerable<int> Small { get; set; }
    }
}
