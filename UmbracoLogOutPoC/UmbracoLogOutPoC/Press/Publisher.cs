using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace UmbracoLogOutPoC.Press
{
    public class Publisher
    {
        [JsonProperty("pubid")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}