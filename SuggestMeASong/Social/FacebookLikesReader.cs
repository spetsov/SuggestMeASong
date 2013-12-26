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
            this.ReadLikes(userId);
        }

        public void UpdateExistingUserLikes(int userId)
        {
            this.ReadLikes(userId);
        }

        private void ReadLikes(int userId)
        {
            JObject musicLikes = JObject.Parse(this.fbClient.Get("/me/music").ToString());
            if (musicLikes != null)
            {
                using (SongsContext context = new SongsContext())
                {
                    foreach (var item in musicLikes["data"].Children())
                    {
                        var name = item["name"].ToString();
                        context.FacebookLikes.Add(new FacebookLike()
                        {
                            Name = name,
                            UserId = userId
                        });
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}