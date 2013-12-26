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
            context.Database.CreateIfNotExists();

            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }
    }
}