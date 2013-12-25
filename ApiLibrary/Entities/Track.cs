using System;
using System.Globalization;
using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Resources;
using Ewk.SoundCloud.ApiLibrary.Resources.Tracks;

namespace Ewk.SoundCloud.ApiLibrary.Entities
{
    /// <summary>
    /// Represents a track on soundcloud.
    /// </summary>
    public class Track : Entity, ITrackResources
    {
        /// <summary>
        /// The unique identifier.
        /// </summary>
        /// <example>123</example>
        public int id { get; set; }

        /// <summary>
        /// Timestamp of creation
        /// </summary>
        /// <example>"2009/08/13 18:30:10 +0000"</example>
        public string created_at { get; set; }

        /// <summary>
        /// User-id of the owner
        /// </summary>
        /// <example>343</example>
        public int user_id { get; set; }

        /// <summary>
        /// Mini user representation of the owner
        /// </summary>
        /// <example>{id: 343, username: "Doctor Wilson"...}</example>
        public MiniUser user { get; set; }

        /// <summary>
        /// Track title
        /// </summary>
        /// <example>"S-Bahn Sounds"</example>
        public string title { get; set; }

        /// <summary>
        /// Permalink of the resource
        /// </summary>
        /// <example>"sbahn-sounds"</example>
        public string permalink { get; set; }

        /// <summary>
        /// URL to the SoundCloud.com page
        /// </summary>
        /// <example>"http://soundcloud.com/bryan/sbahn-sounds"</example>
        public string permalink_url { get; set; }

        /// <summary>
        /// API resource URL
        /// </summary>
        /// <example>"http://api.soundcloud.com/tracks/123"</example>
        public string uri { get; set; }

        /// <summary>
        /// Public/private sharing
        /// </summary>
        /// <example>"public"</example>
        public string sharing { get; set; }

        /// <summary>
        /// Who can embed this track or playlist
        /// </summary>
        /// <example>"all", "me", or "none"</example>
        public string embeddable_by { get; set; }

        /// <summary>
        /// External purchase link
        /// </summary>
        /// <example>"http://amazon.com/buy/a43aj0b03"</example>
        public string purchase_url { get; set; }

        /// <summary>
        /// URL to a JPEG image
        /// </summary>
        /// <example>"http://i1.sndcdn.com/a....-large.jpg?142a848"</example>
        public string artwork_url { get; set; }

        /// <summary>
        /// HTML description
        /// </summary>
        /// <example>"my first track"</example>
        public string description { get; set; }

        public MiniUser label { get; set; } // label mini user object	{id:123, username: "BeatLabel"...}
        public int? duration { get; set; } // duration in milliseconds	1203400
        public string genre { get; set; } // genre	"HipHop"
        public int? shared_to_count { get; set; } // number of sharings (if private)	45
        public string tag_list { get; set; } // list of tags	"tag1 \"hip hop\" geo:lat=32.444 geo:lon=55.33"
        public int? label_id { get; set; } // id of the label user	54677
        public string label_name { get; set; } // label name	"BeatLabel"
        public string license { get; set; } // creative common license	"no-rights-reserved"
        public string release { get; set; } // release number	3234
        public int? release_day { get; set; } // day of the release	21
        public int? release_month { get; set; } // month of the release	5
        public int? release_year { get; set; } // year of the release	2001
        public bool streamable { get; set; } // streamable via API (boolean)	true
        public bool downloadable { get; set; } // downloadable (boolean)	true
        public string state { get; set; } // encoding state	"finished"
        public string track_type { get; set; } // track type	"recording"
        public string waveform_url { get; set; } // URL to PNG waveform image	"http://w1.sndcdn.com/fxguEjG4ax6B_m.png"
        public string download_url { get; set; } // URL to original file	"http://api.soundcloud.com/tracks/3/download"
        public string stream_url { get; set; } // link to 128kbs mp3 stream	"http://api.soundcloud.com/tracks/3/stream"
        public string video_url { get; set; } // a link to a video page	"http://vimeo.com/3302330"

        /// <summary>
        /// beats per minute
        /// </summary>
        /// <example>120</example>
        public string bpm { get; set; }

        /// <summary>
        /// track commentable (boolean)
        /// </summary>
        /// <example>true</example>
        public bool commentable { get; set; }
        public string isrc { get; set; } // track ISRC	"I123-545454"
        public string key_signature { get; set; } // track key	"Cmaj"
        public int? comment_count { get; set; } // track comment count	12
        public int? download_count { get; set; } // track download count	45
        public int? playback_count { get; set; } // track play count	435
        public int? favoritings_count { get; set; } // track favoriting count	6
        public string original_format { get; set; } // file format of the original file	"aiff"
        public int? original_content_size { get; set; } // size in bytes of the original file	10211857
        public MiniApp created_with { get; set; } // the app that the track created	{"id"=>3434, "..."=>nil}
        public byte[] asset_data { get; set; } // binary data of the audio file	(only for uploading)
        public byte[] artwork_data { get; set; } // binary data of the artwork image	(only for uploading)
        public bool? user_favorite { get; set; } // track favorite of current user (boolean, authenticated requests only)	1

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
                _resources = new TrackResources(SoundCloudClient, "/tracks", id.ToString(CultureInfo.InvariantCulture));
                if (user != null) user.SoundCloudClient = value;
                if (label != null) label.SoundCloudClient = value;
            }
        }
        private ITrackResources _resources;

        #region Implementation of IEntityGet<Track>

        public Track Get()
        {
            return _resources.Get();
        }

        public async Task<Track> GetAsync()
        {
            return await _resources.GetAsync();
        }

        #endregion

        #region Implementation of IEntityPut<Track>

        public Track Put(Track entity)
        {
            return _resources.Put(entity);
        }

        public async Task<Track> PutAsync(Track entity)
        {
            return await _resources.PutAsync(entity);
        }

        #endregion

        #region Implementation of IEntityDelete

        public void Delete()
        {
            _resources.Delete();
        }

        public async Task DeleteAsync()
        {
            await _resources.DeleteAsync();
        }

        #endregion

        #region Implementation of ITrackResources

        public IEntitiesResource<Comment, ITrackCommentResources> Comments { get { return _resources.Comments; } }
        public IEntitiesResource<User, ITrackFavoriterResources> Favoriters { get { return _resources.Favoriters; } }

        #endregion
    }
}