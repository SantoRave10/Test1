using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace UmbracoLogOutPoC.Press
{
    public class Contacts
    {
        [JsonProperty("persons")]
        public List<Person> Persons { get; set; }
    }
}