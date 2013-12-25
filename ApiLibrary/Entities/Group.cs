using System;
using System.Globalization;
using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Resources;
using Ewk.SoundCloud.ApiLibrary.Resources.Groups;

namespace Ewk.SoundCloud.ApiLibrary.Entities
{
    /// <summary>
    /// Represents a group.
    /// </summary>
    public class Group : Entity, IGroupResources
    {
        public int id { get; set; } // integer ID	123
        public string uri { get; set; } // API resource URL	http://api.soundcloud.com/comments/32562
        public string created_at { get; set; } // timestamp of creation	"2009/08/13 18:30:10 +0000"
        public string permalink { get; set; } // permalink of the resource	"sbahn-sounds"
        public string permalink_url { get; set; } // URL to the SoundCloud.com page	"http://soundcloud.com/bryan/sbahn-sounds"
        public string artwork_url { get; set; } // URL to a JPEG image	"http://i1.sndcdn.com/a....-large.jpg?142a848"
        public string name { get; set; } // name of the group	"Field Recordings"
        public string description { get; set; } // description of the group	"field recordings from across the world"
        public string short_description { get; set; } // short description of the group	"field recordings!"
        public MiniUser creator { get; set; } // mini user representation of the owner	{id: 343, username: "Doctor Wilson"...}         

        #region Implementation of IEntityGet<Group>

        public Group Get()
        {
            return _resources.Get();
        }

        public async Task<Group> GetAsync()
        {
            return await _resources.GetAsync();
        }

        #endregion

        #region Implementation of IGroupResources

        public IEntitiesGet<User> Moderators
        {
            get { return _resources.Moderators; }
        }

        public IEntitiesGet<User> Members
        {
            get { return _resources.Members; }
        }

        public IEntitiesGet<User> Contributors
        {
            get { return _resources.Contributors; }
        }

        public IEntitiesGet<User> Users
        {
            get { return _resources.Users; }
        }

        public IEntitiesGet<Track> Tracks
        {
            get { return _resources.Tracks; }
        }

        public IEntitiesResource<Track, IGroupPendingTrackResources> PendingTracks
        {
            get { return _resources.PendingTracks; }
        }

        #endregion

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
                _resources = new GroupResources(SoundCloudClient, "/groups", id.ToString(CultureInfo.InvariantCulture));
                if (creator != null) creator.SoundCloudClient = value;
            }
        }
        private IGroupResources _resources;
    }
}