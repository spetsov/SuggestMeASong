using System;
using System.Collections.Generic;

namespace Ewk.SoundCloud.ApiLibrary.Entities
{
    /// <summary>
    /// Represents a playlist.
    /// </summary>
    public class Playlist : Entity
    {
        public int id { get; set; } // integer ID	123
        public string created_at { get; set; } // timestamp of creation	"2009/08/13 18:30:10 +0000"
        public int user_id { get; set; } // user-id of the owner	343
        public MiniUser user { get; set; } // mini user representation of the owner	{id: 343, username: "Doctor Wilson"...}
        public string title { get; set; } // title	track title	"S-Bahn Sounds"
        public string permalink { get; set; } // permalink of the resource	"sbahn-sounds"
        public string permalink_url { get; set; } // URL to the SoundCloud.com page	"http://soundcloud.com/bryan/sbahn-sounds"
        public string uri { get; set; } // API resource URL	"http://api.soundcloud.com/tracks/123"
        public string sharing { get; set; } // public/private sharing	"public"
        public string embeddable_by { get; set; } // who can embed this track or playlist	"all", "me", or "none"
        public string purchase_url { get; set; } // external purchase link	"http://amazon.com/buy/a43aj0b03"
        public string artwork_url { get; set; } // URL to a JPEG image	"http://i1.sndcdn.com/a....-large.jpg?142a848"
        public string description { get; set; } // HTML description	"my first track"
        public MiniUser label { get; set; } // label mini user object	{id:123, username: "BeatLabel"...}
        public int? duration { get; set; } // duration in milliseconds	1203400
        public string genre { get; set; } // genre	"HipHop"
        public int? shared_to_count { get; set; } // number of sharings (if private)	45
        public string tag_list { get; set; } // list of tags	"tag1 \"hip hop\" geo:lat=32.444 geo:lon=55.33"
        public int? label_id { get; set; } // id of the label user	54677
        public string label_name { get; set; } // label name	"BeatLabel"
        public string license { get; set; } // creative common license	"no-rights-reserved"
        public string release { get; set; } // release number	3234
        public string release_day { get; set; } // day of the release	21
        public int? release_month { get; set; } // month of the release	5
        public int? release_year { get; set; } // year of the release	2001
        public bool? streamable { get; set; } // streamable via API (boolean)	true
        public bool? downloadable { get; set; } // downloadable (boolean)	true
        public string ean { get; set; } // EAN identifier for the playlist	"123-4354345-43"
        public string playlist_type { get; set; } // playlist type	"recording"         
        public IEnumerable<Track> tracks { get; set; }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representation of the created_at string.
        /// </summary>
        public DateTime? CreatedAtUtc
        {
            get
            {
                if (!_createdAtUtc.HasValue)
                {
                    var converter = new DateTimeConverter();
                    _createdAtUtc = converter.Convert(created_at);
                }

                return _createdAtUtc;
            }
        }
        private DateTime? _createdAtUtc;

        internal override ISoundCloudClient SoundCloudClient
        {
            get
            {
                return base.SoundCloudClient;
            }
            set
            {
                base.SoundCloudClient = value;
                if (user != null) user.SoundCloudClient = value;
                if (label != null) label.SoundCloudClient = value;
            }
        }
    }
}