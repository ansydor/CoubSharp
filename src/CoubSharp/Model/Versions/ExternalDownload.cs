using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dtos.Versions
{
    public class ExternalDownload
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        //Defined conversion from ExternalDownload to bool
        public static implicit operator bool(ExternalDownload item)
        {
            return item != null;
        }
        //Defined conversion from bool to empty ExternalDownload if True or null if False
        public static implicit operator ExternalDownload(bool item)
        {
            return item ? new ExternalDownload() : null;
        }
    }
}
