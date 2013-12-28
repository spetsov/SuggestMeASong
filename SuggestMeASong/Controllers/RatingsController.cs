using SuggestMeASong.Models;
using SuggestMeASong.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMatrix.WebData;

namespace SuggestMeASong.Controllers
{
    public class RatingsController : ApiController
    {
        // PUT api/<controller>/5
        public void Put([FromBody]RatingViewModel rating)
        {
            if (rating != null &&!string.IsNullOrEmpty(rating.ExternalId) &&
                rating.Value != 0 && !string.IsNullOrEmpty(rating.ExternalProviderName) && User.Identity.IsAuthenticated)
            {
                var userId = WebSecurity.GetUserId(User.Identity.Name);
                using (SongsContext cntx = new SongsContext())
                {
                    var existingRating = cntx.Ratings.Where(r => r.ExternalId == rating.ExternalId && r.ExternalProviderName == rating.ExternalProviderName
                        && r.UserId == userId).FirstOrDefault();
                    if (existingRating == null)
                    {
                        cntx.Ratings.Add(new Rating()
                        {
                            ExternalId = rating.ExternalId,
                            UserId = userId,
                            Value = rating.Value,
                            ExternalProviderName = rating.ExternalProviderName
                        });
                    }
                    else
                    {
                        existingRating.Value = rating.Value;
                        cntx.Ratings.Attach(existingRating);
                        var entry = cntx.Entry(existingRating);
                        entry.Property(r => r.Value).IsModified = true;
                    }
                    cntx.SaveChanges();
                }
            }
        }
    }
}