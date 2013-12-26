using SuggestMeASong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuggestMeASong.Recommenders
{
    public class ItemToItemRecommendationStrategy : IRecommendationStrategy
    {
        public async System.Threading.Tasks.Task<IEnumerable<Models.Rating>> Recommend(int userId)
        {
            return null;
        }
    }
}