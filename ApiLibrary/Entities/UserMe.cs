namespace Ewk.SoundCloud.ApiLibrary.Entities
{
    public class UserMe : User
    {
        public string plan { get; set; } // subscription plan of the user	Pro Plus
        public int private_tracks_count { get; set; } // number of private tracks	34
        public int private_playlists_count { get; set; } // number of private playlists	6
        public bool primary_email_confirmed { get; set; } // boolean if email is confirmed	true         
    }
}