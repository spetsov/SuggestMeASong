using SuggestMeASong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuggestMeASong.Recommenders
{
    public class ItemToItemRecommendationStrategy : IRecommendationStrategy
    {
        private string externalProviderName;
        private const int K = 3;

        public ItemToItemRecommendationStrategy(string externalProviderName)
        {
            this.externalProviderName = externalProviderName;
        }
        public async Task<List<Rating>> Recommend(int userId)
        {
            Dictionary<string, List<Rating>> allRatedItems = GetAllRatedItems(externalProviderName);


            Dictionary<int, List<Rating>> currentUserAllRatings = GetAllRatings(externalProviderName);


            //This is the item we will test against
            string currentUserTopRatedItemId = GetOneOfTopRatedItems(userId, currentUserAllRatings);


            //if no items return
            if (currentUserTopRatedItemId == null)
            {
                return new List<Rating>();
            }

            List<Rating> result = DoItemBasedFiltering(currentUserTopRatedItemId, allRatedItems);

            //List<Rating> recommendations = new List<Rating>();

            return result;
        }

        private List<Rating> DoItemBasedFiltering(string currentItem, Dictionary<string, List<Rating>> allRatedItems)
        {
            List<Rating> currentItemVector = allRatedItems[currentItem];
  
            Dictionary<string, double> allSimilarities = new Dictionary<string, double>();
            foreach (var element in allRatedItems)
            {
                if (element.Key != currentItem)
                {
                    List<Rating> otherItemVector = element.Value;
                    
                    var similarity = CalculateCosineSimilarity(currentItemVector, otherItemVector); 
                    
                    
                    if (similarity > 0.7)
                    {
                        allSimilarities.Add(element.Key, similarity);
                    }
                }
            }


            List<Rating> result = GetTopKRatings(K, allSimilarities, allRatedItems);
            return result;
        }

        private List<Rating> GetTopKRatings(int k, Dictionary<string, double> similarities, Dictionary<string, List<Rating>> ratedItems)
        {
            if (similarities.Count >= k && ratedItems.Count >= k)
            {
                List<Rating> result = new List<Rating>();

                similarities = similarities.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            
                int counter = 0;
                foreach (var pair in similarities)
                {
                    if (counter < k)
                    {
                        Rating itemRating = new Rating();

                        itemRating.ExternalId = pair.Key;
                        result.Add(itemRating);

                    }
                    else
                    {
                        break;
                    }
                    counter++;
                }

                return result;
            }

            return new List<Rating>();
        }


        private string GetOneOfTopRatedItems(int userId, Dictionary<int, List<Rating>> allRatings)
        {
            if (!allRatings.ContainsKey(userId))
            {
                return null;
            }

            List<Rating> currentUserRatings = allRatings[userId];     

            int topRating = 0;

            foreach (var rating in currentUserRatings)
            {
                if (rating.Value > topRating)
                {
                    topRating = rating.Value;
                }
            }


            
            List<Rating> topRatings = new List<Rating>();

            foreach (var rating in currentUserRatings)
            {
                if (rating.Value == topRating)
                {
                    topRatings.Add(rating);
                }
            }
            Random rnd = new Random();
            int randIndex = rnd.Next(topRatings.Count);
            Rating result = topRatings[randIndex];

            return result.ExternalId;
        }


        private Dictionary<string, List<Rating>> GetAllRatedItems(string externalProviderName)
        {
            using (SongsContext cntx = new SongsContext())
            {
                
                var ratings = cntx.Ratings.Where(r => r.ExternalProviderName == this.externalProviderName).ToList();
                Dictionary<string, List<Rating>> dict = new Dictionary<string, List<Rating>>();
                foreach (var rating in ratings)
                {

                    if (!dict.ContainsKey(rating.ExternalId))
                    {
                        dict.Add(rating.ExternalId, new List<Rating>());
                    }
                    dict[rating.ExternalId].Add(rating);
                }
                return dict;
            }
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


        private double CalculateCosineSimilarity(List<Rating> vector1, List<Rating> vector2)
        {
  
            if (vector1.Count < vector2.Count)
            {
                int difference = vector2.Count - vector1.Count;

                for (int i = 0; i < difference; ++i)
                {
                    Rating rat = new Rating();
                    vector1.Add(rat);
                }
            }
            if (vector1.Count > vector2.Count)
            {
                int difference = vector1.Count - vector2.Count;

                for (int i = 0; i < difference; ++i)
                {
                    Rating rat = new Rating();
                    vector2.Add(rat);
                }
            }

            double vector1Length = GetVectorLength(vector1);
            double vector2Length = GetVectorLength(vector2);

            double sum = 0.0;

            for (int i = 0; i < vector1.Count; ++i )
            {
                sum += vector1[i].Value * vector2[i].Value;
            }

            sum /= (vector1Length * vector2Length);

            return sum;
           
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