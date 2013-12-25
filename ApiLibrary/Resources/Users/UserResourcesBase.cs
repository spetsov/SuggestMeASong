using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    class UserResourcesBase<T> : EntityResourceBase<T>, IUserResources<T> where T : User
    {
        public UserResourcesBase(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, relativePath)
        {
        }

        #region Implementation of IUserResources

        public IEntitiesGet<Track> Tracks
        {
            get { return _tracks ?? (_tracks = new UserTracksResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesGet<Track> _tracks;

        public IEntitiesGet<Group> Groups
        {
            get { return _groups ?? (_groups = new UserGroupsResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesGet<Group> _groups;

        public IEntitiesGet<Comment> Comments
        {
            get { return _comments ?? (_comments = new UserCommentsResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesGet<Comment> _comments;

        public IEntitiesGet<Playlist> Playlists
        {
            get { return _playlists ?? (_playlists = new UserPlaylistsResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesGet<Playlist> _playlists;

        public IEntitiesResource<User, IUserFollowerResources> Followers
        {
            get { return _followers ?? (_followers = new UserFollowersResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesResource<User, IUserFollowerResources> _followers;

        public IEntitiesResource<User, IUserFollowingResources> Followings
        {
            get { return _followings ?? (_followings = new UserFollowingsResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesResource<User, IUserFollowingResources> _followings;

        public IEntitiesResource<Track, IUserFavoriteResources> Favorites
        {
            get { return _favorites ?? (_favorites = new UserFavoritesResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesResource<Track, IUserFavoriteResources> _favorites;

        public IEntitiesGet<WebProfile> WebProfiles
        {
            get { return _webProfile ?? (_webProfile = new UserWebProfilesResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesGet<WebProfile> _webProfile;

        #endregion
    }
}