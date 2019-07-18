using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace UmbracoLogOutPoC.Press
{
    public class PressRelease
    {
        [JsonProperty("sid")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("leadtext")]
        public string LeadText { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; }

        [JsonProperty("published")]
        public string Published { get; set; }

        [JsonProperty("publisher")]
        public Publisher Publisher { get; set; }

        [JsonProperty("contacts")]
        public Contacts Contacts { get; set; }

        [JsonProperty("sversion")]
        public int Version { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonIgnore]
        public List<Image> ListOfImages => Images.ToList();
    }
}