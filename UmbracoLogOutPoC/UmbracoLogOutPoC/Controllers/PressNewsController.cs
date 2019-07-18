using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Umbraco.Core;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Security;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;
using UmbracoLogOutPoC.Press;


namespace UmbracoLogOutPoC.Controllers
{
    public class PressNewsController : UmbracoAuthorizedController
    {

        // GET: PressRelease
        [System.Web.Http.HttpGet]
        public void Import()
        {
            string userName = string.Empty;
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
                if (currentUser.IsAdmin())
                {

                }
                else
                {
                    //currentUser.UserState.
                    FormsAuthentication.SignOut();
                    //return RedirectToCurrentUmbracoPage();
                }
            }
            else
            {
                userName = "";
            }


            //var startPage = Umbraco.TypedContentAtRoot().First();
            //var settingsPage = startPage?.Descendants("settingsPage").FirstOrDefault();
            ////this gets the parent node.  under that page it will our import controller generate the new pages.
            //var pageId = settingsPage?.GetPropertyValue<int>("PressReleaserNode");

            ////Releases listofReleases = PressReleasesService.GetTtData();
            //Releases listofReleases = MyCoolTaskClass.GetTtData();
            //List<PressRelease> releasesList = new List<PressRelease>();

            //foreach (PressRelease pressRelease in listofReleases.releases)
            //{
            //    releasesList.Add(pressRelease);
            //}

            //if (pageId != null)
            //{
            //    CreatingContent((int)pageId, releasesList);

            //}
        }

        private void CreatingContent(int parent, IEnumerable<PressRelease> pages)
        {
            // Get the Umbraco Content Service
            var contentService = Services.ContentService;
            IPublishedContent parentNode = Umbraco.Content(parent);
            IEnumerable<IPublishedContent> children = parentNode.Children;

            foreach (PressRelease item in pages)
            {
                IContent newPageContent;

                bool containsItem = children.Any(x => x.GetPropertyValue<string>("pressReleaseId") == item.Id.ToString());

                if (!containsItem)
                {
                    newPageContent = contentService.CreateContent(item.Title, parent, "NewsPage");

                    newPageContent.SetValue("Heading", item.Title);
                    newPageContent.SetValue("Preamble", item.LeadText);
                    newPageContent.SetValue("MainBody", item.Body);
                    newPageContent.SetValue("pressReleaseId", item.Id);
                    newPageContent.SetValue("prImageUrl", item.ListOfImages?.FirstOrDefault()?.Url);
                    newPageContent.SetValue("pRDate", item.Published);
                    newPageContent.SetValue("PublishDate", DateTime.Now);

                    // Save and publish it.
                    contentService.SaveAndPublishWithStatus(newPageContent, 1, false);
                }
            }
        }

    }
}