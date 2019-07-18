using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace UmbracoLogOutPoC.Press
{
    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("normal")]
        public string Normal { get; set; }
    }
}