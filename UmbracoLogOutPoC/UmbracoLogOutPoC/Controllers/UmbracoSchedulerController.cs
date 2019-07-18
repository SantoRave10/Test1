using System;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Security;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;
using UmbracoLogOutPoC.Models.ViewModels;

namespace UmbracoLogOutPoC.Controllers
{
    [PluginController("Scheduler")]
    public class UmbracoSchedulerController : UmbracoAuthorizedApiController
    {
        [HttpGet]
        public UmbracoSchedulerViewModel GetLoggedInUsers()
        {
            string userName = string.Empty, role= string.Empty;
            bool isAdmin = false;
            DateTime currentDateTime = new DateTime();

            bool isLoggedInUser = false;
            IUser currentUser = null;

            var userTicket = new System.Web.HttpContextWrapper(System.Web.HttpContext.Current).GetUmbracoAuthTicket();

            if (userTicket != null)
            {
                isLoggedInUser = true;
                currentUser = ApplicationContext.Services.UserService.GetByUsername(userTicket.Name);
            }
            
            if (isLoggedInUser)
            {
                userName = currentUser.Name;
                isAdmin = currentUser.IsAdmin();

                if (currentUser.IsAdmin())
                {
                    role = "Admin";
                }
                else
                {
                    //currentUser.UserState.
                    FormsAuthentication.SignOut();
                    //return RedirectToCurrentUmbracoPage();
                }
            }

            var homePageId = Umbraco.TypedContent(1064);
            var scheduleDateTime = homePageId.GetPropertyValue<DateTime>("startDate");
          
            currentDateTime = DateTime.Now;


            var vm = new UmbracoSchedulerViewModel
            {
                Name = userName,
                IsAdmin = isAdmin,
                Role = role,
                CurrentDateTime = currentDateTime,
                ScheduleDateTime = scheduleDateTime
            };

            return vm;
            
        }

    }
}