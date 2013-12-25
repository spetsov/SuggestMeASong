using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Groups
{
    class GroupResources : EntityResourceBase<Group>, IGroupResources
    {
        public GroupResources(ISoundCloudClient soundCloudClient, string relativePath, string id)
            : base(soundCloudClient, string.Concat(relativePath, "/", id))
        {
        }

        #region Implementation of IGroupResources

        public IEntitiesGet<User> Moderators
        {
            get { return _moderators ?? (_moderators = new GroupModeratorsResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesGet<User> _moderators;

        public IEntitiesGet<User> Members
        {
            get { return _members ?? (_members = new GroupMembersResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesGet<User> _members;

        public IEntitiesGet<User> Contributors
        {
            get { return _contributors ?? (_contributors = new GroupContributorsResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesGet<User> _contributors;

        public IEntitiesGet<User> Users
        {
            get { return _users ?? (_users = new GroupUsersResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesGet<User> _users;

        public IEntitiesGet<Track> Tracks
        {
            get { return _tracks ?? (_tracks = new GroupTracksResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesGet<Track> _tracks;

        public IEntitiesResource<Track, IGroupPendingTrackResources> PendingTracks
        {
            get { return _pendingTracks ?? (_pendingTracks = new GroupPendingTracksResource(SoundCloudClient, RelativePath)); }
        }
        private IEntitiesResource<Track, IGroupPendingTrackResources> _pendingTracks;

        #endregion
    }
}