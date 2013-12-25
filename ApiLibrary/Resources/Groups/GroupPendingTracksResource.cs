using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Groups
{
    class GroupPendingTracksResource : EntitiesResourceBase<Track, IGroupPendingTrackResources>
    {
        private const string RelativePathFormat = "/pending_tracks";

        public GroupPendingTracksResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }

        #region Overrides of EntitiesResourceBase<Track,ITrackResources>

        public override IGroupPendingTrackResources this[string id]
        {
            get { return new GroupPendingTrackResources(SoundCloudClient, RelativePath, id); }
        }

        #endregion
    }
}