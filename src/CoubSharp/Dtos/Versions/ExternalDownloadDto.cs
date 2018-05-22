using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Dtos.Versions
{
    public class ExternalDownloadDto
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        //Defined conversion from ExternalDownloadDto to bool
        public static implicit operator bool(ExternalDownloadDto item)
        {
            return item != null;
        }
        //Defined conversion from bool to empty ExternalDownloadDto if True or null if False
        public static implicit operator ExternalDownloadDto(bool item)
        {
            return item ? new ExternalDownloadDto() : null;
        }
    }
}
