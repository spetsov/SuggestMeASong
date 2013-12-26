using SuggestMeASong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestMeASong.Recommenders
{
    public interface IRecommendationStrategy
    {
        Task<IEnumerable<Rating>> Recommend(int userId);
    }
}
