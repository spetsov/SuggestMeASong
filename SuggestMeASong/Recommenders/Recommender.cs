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

        protected abstract Task<IEnumerable<Rating>> RecommendByLikes(FacebookLike like, int count);

        protected abstract Task<IEnumerable<Rating>> RecommendRandomly(int count);

        public async Task<IEnumerable<Rating>> Recommend(IPrincipal user, int count)
        {
            var userId = WebSecurity.GetUserId(user.Identity.Name);
            List<Rating> recommendations;
            recommendations = await Strategy.Recommend(userId);
            if (recommendations.Count() < count)
            {
                if (this.UserHasFacebookLikes(userId))
                {
                    FacebookLike like = this.GetUserFacebookLike(userId);
                    var recommendedLikes = await this.RecommendByLikes(like, count);
                    recommendations.AddRange(recommendedLikes);
                }
                else
                {
                    var randomRecommendations = await this.RecommendRandomly(count);
                    recommendations.AddRange(randomRecommendations);
                }
            }

            return recommendations.Take(count);
        }

        private FacebookLike GetUserFacebookLike(int userId)
        {
            using (SongsContext cntx = new SongsContext())
            {
                FacebookLike like = cntx.FacebookLikes.Where(l => l.UserId == userId && !l.AlreadyRecommended).First();
                like.AlreadyRecommended = true;
                cntx.FacebookLikes.Attach(like);
                var entry = cntx.Entry(like);
                entry.Property(l => l.AlreadyRecommended).IsModified = true;
                cntx.SaveChanges();
                return like;
            }
        }

        private bool UserHasFacebookLikes(int userId)
        {
            bool hasLikes = false;
            using (SongsContext cntx = new SongsContext())
            {
                hasLikes = cntx.FacebookLikes.Any(l => l.UserId == userId && !l.AlreadyRecommended);
            }
            return hasLikes;
        }
    }
}