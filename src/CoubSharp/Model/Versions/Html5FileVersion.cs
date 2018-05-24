using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Model.Versions
{
    public class QualityVersions
    {
        [JsonProperty("high")]
        public UrlVersions High { get; set; }
        [JsonProperty("med")]
        public UrlVersions Medium { get; set; }
        [JsonProperty("small")]
        public UrlVersions Small { get; set; }
    }

    public class UrlVersions
    {
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Html5FileVersion
    {
        [JsonProperty("video")]
        public QualityVersions Video { get; set; }

        [JsonProperty("audio")]
        public QualityVersions Audio { get; set; }
    }
}
