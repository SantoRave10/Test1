using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoLogOutPoC.Models.ViewModels
{
    public class UmbracoSchedulerViewModel
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public string Role { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public DateTime ScheduleDateTime { get; set; }
    }
}