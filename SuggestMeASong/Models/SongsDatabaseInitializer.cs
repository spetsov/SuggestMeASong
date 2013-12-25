using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace SuggestMeASong.Models
{
    public class SongsDatabaseInitializer : IDatabaseInitializer<SongsContext>
    {
        public void InitializeDatabase(SongsContext context)
        {
            if (!context.Database.Exists())
            {
                // Create the SimpleMembership database without Entity Framework migration schema
                ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
            }

            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }
    }
}