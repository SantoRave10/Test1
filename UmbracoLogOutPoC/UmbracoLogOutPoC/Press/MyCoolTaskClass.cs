using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace UmbracoLogOutPoC.Press
{
    public class MyCoolTaskClass
    {

        public static Releases GetTtData()
        {
            string feed = "https://via.tt.se/json/v2/releases";

            return serialized_data<Releases>(feed);
        }

        private static T serialized_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                w.Encoding = System.Text.Encoding.UTF8;

                var json_data = string.Empty;

                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

    }
}