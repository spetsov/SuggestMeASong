namespace Ewk.SoundCloud.ApiLibrary.Entities
{
    public class User : MiniUser
    {
        public string country { get; set; } // country	"Germany"
        public string full_name { get; set; } // first and last name	"Tom Wilson"
        public string city { get; set; } // city	"Berlin"
        public string description { get; set; } // description	"Buskers playing in the S-Bahn station in Berlin"
        public string discogs_name { get; set; } // Discogs name	"myrandomband"
        public string myspace_name { get; set; } // MySpace name	"myrandomband"
        public string website { get; set; } // a URL to the website	"http://facebook.com/myrandomband"
        public string website_title { get; set; } // a custom title for the website	"myrandomband on Facebook"
        public bool online { get; set; } // online status (boolean)	true
        public int track_count { get; set; } // number of public tracks	4
        public int playlist_count { get; set; } // number of public playlists	5
        public int followers_count { get; set; } // number of followers	54
        public int followings_count { get; set; } // number of followed users	75
        public int public_favorites_count { get; set; } // number of favorited public tracks	7
        public byte[] avatar_data { get; set; } // binary data of user avatar	(only for uploading)
    }
}