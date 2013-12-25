using Facebook;
using Newtonsoft.Json.Linq;
using SuggestMeASong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuggestMeASong.Social
{
    public class FacebookLikesReader
    {
        private string accessToken;
        private FacebookClient fbClient;

        public FacebookLikesReader(string accessToken)
        {
            this.accessToken = accessToken;
            this.fbClient = new FacebookClient(accessToken);
        }

        public void PopulateNewUserLikes(int userId)
        {
            var likes = this.ReadLikes(userId);
        }

        public void UpdateExistingUserLikes(int userId)
        {
            var likes = this.ReadLikes(userId);
        }

        private IList<FbMusicLike> ReadLikes(int userId)
        {
            IList<FbMusicLike> likesList = new List<FbMusicLike>();
            JObject musicLikes = JObject.Parse(this.fbClient.Get("/me/music").ToString());
            if (musicLikes != null)
            {
                using (SongsContext context = new SongsContext())
                {
                    foreach (var item in musicLikes["data"].Children())
                    {
                        FbMusicLike like = new FbMusicLike();
                        var name = item["name"].ToString();
                        like.Name = name;
                        likesList.Add(like);
                        context.FacebookLikes.Add(new FacebookLike()
                        {
                            Name = like.Name,
                            UserId = userId
                        });
                    }
                    context.SaveChanges();
                }
            }

            return likesList;
        }
    }
}