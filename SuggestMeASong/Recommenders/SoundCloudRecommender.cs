﻿using Ewk.SoundCloud.ApiLibrary;
using Ewk.SoundCloud.ApiLibrary.Entities;
using SuggestMeASong.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuggestMeASong.Recommenders
{
    public class SoundCloudRecommender : Recommender
    {
        private SoundCloud scManager;
        private const string SOUNDCLOUD_PROVIDER_NAME = "SoundCloud";

        public SoundCloudRecommender()
        {
            this.scManager = new SoundCloud(ConfigurationManager.AppSettings["SoundCloudApiKey"]);
        }

        public override IRecommendationStrategy Strategy
        {
            get
            {
                return new UserToUserRecommendationStrategy(SOUNDCLOUD_PROVIDER_NAME);
            }
        }

        protected async override Task<IEnumerable<Rating>> RecommendByLikes(FacebookLike like, int count)
        {
            this.scManager.SetPageSize(count);
            var tracks = await this.scManager.Tracks.GetAsync(1, new Dictionary<string, string>() { 
            { "q", like.Name } ,
            {"filter", "all"} ,
            {"embeddable_by", "all"},
            {"types", "original,recording"},
            {"duration[from]", "2000"},
            {"order", "hotness"}
            });

            return this.TracksToRatings(tracks);
        }

        protected async override Task<IEnumerable<Rating>> RecommendRandomly(int count)
        {
            DateTime startDate = new DateTime(2010, 1, 1);
            TimeSpan timeSpan = DateTime.Now - startDate;
            var rand = new Random();
            TimeSpan newSpan = new TimeSpan(0, rand.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime randomDate = startDate + newSpan;

            this.scManager.SetPageSize(count);
            var tracks = await this.scManager.Tracks.GetAsync(1, new Dictionary<string, string>() { 
            {"filter", "all"} ,
            {"embeddable_by", "all"},
            {"types", "original,recording"},
            {"duration[from]", "2000"},
            {"order", "hotness"},
            {"created_at[from]", string.Format("{0}-{1}-{2}", randomDate.Year, randomDate.Month, randomDate.Day)},
            {"created_at[to]", string.Format("{0}-{1}-{2}", randomDate.Year, randomDate.Month, randomDate.Day + 2)}
            });

            return this.TracksToRatings(tracks);
        }

        private IEnumerable<Rating> TracksToRatings(IEnumerable<Track> tracks)
        {
            List<Rating> recommendedTracks = new List<Rating>();

            foreach (var track in tracks)
            {
                recommendedTracks.Add(new Rating()
                {
                    ExternalProviderName = SOUNDCLOUD_PROVIDER_NAME,
                    ExternalId = track.id.ToString()
                });
            }

            return recommendedTracks;
        }
    }
}