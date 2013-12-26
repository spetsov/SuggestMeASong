﻿using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using SuggestMeASong.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuggestMeASong.Recommenders
{
    public class YouTubeRecommender : Recommender
    {
        private YouTubeService youtube;
        private const string YOUTUBE_PROVIDER_NAME = "YouTube";

        public YouTubeRecommender()
        {
            this.youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = ConfigurationManager.AppSettings["YouTubeApiKey"]
            }); 
        }

        public override IRecommendationStrategy Strategy
        {
            get
            {
                return new ItemToItemRecommendationStrategy();
            }
        }

        protected async override Task<IEnumerable<Rating>> RecommendByLikes(IList<FacebookLike> likes)
        {
            string q = this.GetRandomLikeName(likes);

            SearchResource.ListRequest listRequest = youtube.Search.List("snippet");
            listRequest.Q = q;
            listRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            listRequest.Type = "video";
            listRequest.MaxResults = 3;

            SearchListResponse searchResponse = await listRequest.ExecuteAsync();

            return TracksToRatings(searchResponse.Items);
        }

        protected async override Task<IEnumerable<Rating>> RecommendRandomly()
        {
            DateTime startDate = new DateTime(2008, 1, 1);
            TimeSpan timeSpan = DateTime.Now - startDate;
            var rand = new Random();
            TimeSpan newSpan = new TimeSpan(0, rand.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime randomDate = startDate + newSpan;

            SearchResource.ListRequest listRequest = youtube.Search.List("snippet");
            listRequest.PublishedAfter = randomDate;
            listRequest.PublishedBefore = randomDate.AddDays(2);
            listRequest.VideoCategoryId = "10";
            listRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
            listRequest.Type = "video";
            listRequest.MaxResults = 3;

            SearchListResponse searchResponse = await listRequest.ExecuteAsync();

            return TracksToRatings(searchResponse.Items);
        }

        private string GetRandomLikeName(IList<FacebookLike> likes)
        {
            Random rand = new Random();
            var randNumber = rand.Next(likes.Count() - 1);
            return likes[randNumber].Name;
        }

        private IEnumerable<Rating> TracksToRatings(IEnumerable<SearchResult> videos)
        {
            List<Rating> recommendedTracks = new List<Rating>();

            foreach (var video in videos)
            {
                recommendedTracks.Add(new Rating()
                {
                    ExternalProviderName = YOUTUBE_PROVIDER_NAME,
                    ExternalId = video.Id.VideoId
                });
            }

            return recommendedTracks;
        }
    }
}