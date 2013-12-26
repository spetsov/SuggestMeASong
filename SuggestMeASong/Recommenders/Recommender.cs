using SuggestMeASong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using WebMatrix.WebData;

namespace SuggestMeASong.Recommenders
{
    public abstract class Recommender : IRecommender
    {
        public abstract IRecommendationStrategy Strategy
        {
            get;
        }

        protected abstract Task<IEnumerable<Rating>> RecommendByLikes(IList<FacebookLike> likes);

        protected abstract Task<IEnumerable<Rating>> RecommendRandomly();

        public async Task<IEnumerable<Rating>> Recommend(IPrincipal user)
        {
            var userId = WebSecurity.GetUserId(user.Identity.Name);
            IEnumerable<Rating> recommendations;
            recommendations = await Strategy.Recommend(userId);
            if (recommendations == null || recommendations.Count() == 0)
            {
                if (this.UserHasFacebookLikes(userId))
                {
                    IList<FacebookLike> likes = this.GetUserFacebookLikes(userId);
                    return await this.RecommendByLikes(likes);
                }
                else
                {
                    return await this.RecommendRandomly();
                }
            }

            return recommendations;
        }

        private IList<FacebookLike> GetUserFacebookLikes(int userId)
        {
            List<FacebookLike> likes = new List<FacebookLike>();
            using (SongsContext cntx = new SongsContext())
            {
                likes = cntx.FacebookLikes.Where(l => l.UserId == userId).ToList();
            }
            return likes;
        }

        private bool UserHasFacebookLikes(int userId)
        {
            bool hasLikes = false;
            using (SongsContext cntx = new SongsContext())
            {
                hasLikes = cntx.FacebookLikes.Any(l => l.UserId == userId);
            }
            return hasLikes;
        }
    }
}