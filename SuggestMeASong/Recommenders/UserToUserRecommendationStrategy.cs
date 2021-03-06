﻿using SuggestMeASong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuggestMeASong.Recommenders
{
    public class UserToUserRecommendationStrategy : IRecommendationStrategy
    {
        private string externalProviderName;
        private const int K = 3;

        public UserToUserRecommendationStrategy(string externalProviderName)
        {
            this.externalProviderName = externalProviderName;
        }
        public async Task<List<Rating>> Recommend(int userId)
        {
            Dictionary<int, List<Rating>> allRatings = GetAllRatings(externalProviderName);
            if (!allRatings.ContainsKey(userId))
            {
                return new List<Rating>();
            }
            return GetAllSuggestionsOfKNearestUsers(K, userId, allRatings).Where(r => r.Value >= 3).ToList();
        }

        private List<Rating> GetAllSuggestionsOfKNearestUsers(int k, int userId, Dictionary<int, List<Rating>> allRatings)
        {
            var currentUserRatings = allRatings[userId];
            var currentUserVectorLength = this.GetVectorLength(currentUserRatings);
            Dictionary<int, double> allSimilarities = new Dictionary<int, double>();
            foreach (var rating in allRatings)
            {
                if (rating.Key != userId)
                {
                    var similarity = this.CalculateCosineSimilarity(userId, currentUserVectorLength,
                        currentUserRatings, rating.Key, allRatings);
                    if (similarity >= 0.2)
                    {
                        allSimilarities.Add(rating.Key, similarity);
                    }
                }
            }
            var nearestUserIds = allSimilarities.OrderByDescending(i => i.Value).Take(k);
            List<Rating> result = new List<Rating>();
            foreach (var pair in nearestUserIds)
            {
                result.AddRange(allRatings[pair.Key].Where(r => !currentUserRatings.Any(i => i.ExternalId == r.ExternalId)));
            }
            return result;
        }

        private Dictionary<int, List<Rating>> GetAllRatings(string externalProviderName)
        {
            using (SongsContext cntx = new SongsContext())
            {
                var ratings = cntx.Ratings.Where(r => r.ExternalProviderName == this.externalProviderName).ToList();
                Dictionary<int, List<Rating>> dict = new Dictionary<int, List<Rating>>();
                foreach (var rating in ratings)
                {
                    if (!dict.ContainsKey(rating.UserId))
                    {
                        dict.Add(rating.UserId, new List<Rating>());
                    }
                    dict[rating.UserId].Add(rating);
                }
                return dict;
            }
        }

        private double CalculateCosineSimilarity(int userId, double currentUserVectorLength, List<Rating> currentUserRatings,
            int otherUserId, Dictionary<int, List<Rating>> allRatings)
        {
            double otherUserVectorLength = this.GetVectorLength(allRatings[otherUserId]);
            List<Rating> otherUserRatings = allRatings[otherUserId];
            int sum = 0;
            foreach (var rating in currentUserRatings)
            {
                var otherUserRating = otherUserRatings.Where(r => r.ExternalId == rating.ExternalId).FirstOrDefault();
                int otherUserRatingValue = 0;
                if (otherUserRating != null)
                {
                    otherUserRatingValue = otherUserRating.Value;
                }
                sum += rating.Value * otherUserRatingValue;
            }

            return sum / (currentUserVectorLength * otherUserVectorLength);
        }

        private double GetVectorLength(List<Rating> ratings)
        {
            double sum = 0;
            foreach (var rating in ratings)
            {
                sum += Math.Pow(rating.Value, 2);
            }

            return Math.Sqrt(sum);
        }
    }
}