using Ewk.SoundCloud.ApiLibrary;
using Facebook;
using Microsoft.Web.WebPages.OAuth;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;
using SuggestMeASong.Filters;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System.Configuration;
using Google.Apis.YouTube.v3.Data;
using SuggestMeASong.Recommenders;
using WebMatrix.WebData;

namespace SuggestMeASong.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    IRecommender scRecommender = new SoundCloudRecommender();
                    ViewBag.Tracks = await scRecommender.Recommend(User, 3);
                }
                catch (Ewk.SoundCloud.ApiLibrary.SoundCloudException e)
                {

                }

                try
                {
                    IRecommender youTubeRecommender = new YouTubeRecommender();
                    ViewBag.Videos = await youTubeRecommender.Recommend(User, 3);
                }
                catch (HttpException e)
                {
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
