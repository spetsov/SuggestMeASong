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

namespace SuggestMeASong.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var scManager = new SoundCloud(ConfigurationManager.AppSettings["SoundCloudApiKey"]);
            scManager.SetPageSize(5);
            var tracks = await scManager.Tracks.GetAsync(1, new Dictionary<string, string>() { 
            { "q", "ladygaga" } ,
            {"filter", "all"} ,
            {"embeddable_by", "all"},
            {"types", "original,recording"},
            {"duration[from]", "2000"},
            {"order", "hotness"}
            });
            ViewBag.Tracks = tracks;

            YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = ConfigurationManager.AppSettings["YouTubeApiKey"]
            });

            SearchResource.ListRequest listRequest = youtube.Search.List("snippet");
            listRequest.Q = "ladygaga";
            listRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            listRequest.Type = "video";
            listRequest.MaxResults = 5;

            SearchListResponse searchResponse = listRequest.Execute();

            ViewBag.Videos = searchResponse.Items;

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
