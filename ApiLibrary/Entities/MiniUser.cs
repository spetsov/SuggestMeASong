using System.Globalization;
using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Resources;
using Ewk.SoundCloud.ApiLibrary.Resources.Users;

namespace Ewk.SoundCloud.ApiLibrary.Entities
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public class MiniUser : Entity, IUserResources<User>
    {
        public int id { get; set; } // ": 3699101,
        public string permalink { get; set; } // ": "user2835985",
        public string username { get; set; } // ": "user2835985",
        public string uri { get; set; } // ": "http://api.soundcloud.com/users/3699101",
        public string permalink_url { get; set; } // ": "http://soundcloud.com/user2835985",
        public string avatar_url { get; set; } // ": "http://a1.sndcdn.com/images/default_avatar_large.png?142a848"

        #region Implementation of IEntityGet<User>

        /// <summary>
        /// Gets the current <see cref="User"/> from soundcloud.
        /// </summary>
        public User Get()
        {
            return _resources.Get();
        }

        /// <summary>
        /// Gets the current <see cref="User"/> from soundcloud.
        /// </summary>
        public async Task<User> GetAsync()
        {
            return await _resources.GetAsync();
        }

        #endregion

        #region Implementation of IUserResources<User>

        /// <summary>
        /// Represents the endpoint for the SoundCloud user tracks.
        /// </summary>
        public IEntitiesGet<Track> Tracks
        {
            get { return _resources.Tracks; }
        }

        /// <summary>
        /// Represents the endpoint for the SoundCloud user groups.
        /// </summary>
        public IEntitiesGet<Group> Groups
        {
            get { return _resources.Groups; }
        }

        /// <summary>
        /// Represents the endpoint for the SoundCloud user comments.
        /// </summary>
        public IEntitiesGet<Comment> Comments
        {
            get { return _resources.Comments; }
        }

        /// <summary>
        /// Represents the endpoint for the SoundCloud user playlists.
        /// </summary>
        public IEntitiesGet<Playlist> Playlists
        {
            get { return _resources.Playlists; }
        }

        /// <summary>
        /// Represents the endpoint for the SoundCloud user followers.
        /// </summary>
        public IEntitiesResource<User, IUserFollowerResources> Followers
        {
            get { return _resources.Followers; }
        }

        /// <summary>
        /// Represents the endpoint for the SoundCloud user followings.
        /// </summary>
        public IEntitiesResource<User, IUserFollowingResources> Followings
        {
            get { return _resources.Followings; }
        }

        /// <summary>
        /// Represents the endpoint for the SoundCloud user favorites.
        /// </summary>
        public IEntitiesResource<Track, IUserFavoriteResources> Favorites
        {
            get { return _resources.Favorites; }
        }

        /// <summary>
        /// Represents the endpoint for the SoundCloud user web-profiles.
        /// </summary>
        public IEntitiesGet<WebProfile> WebProfiles
        {
            get { return _resources.WebProfiles; }
        }

        #endregion

        internal override ISoundCloudClient SoundCloudClient
        {
            get { return base.SoundCloudClient; }
            set
            {
                base.SoundCloudClient = value;
                _resources = new UserResources(SoundCloudClient, "/users", id.ToString(CultureInfo.InvariantCulture));
            }
        }
        private IUserResources<User> _resources;
    }
}