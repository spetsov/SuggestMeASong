using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Tracks
{
    internal class TrackCommentsResource : EntitiesResourceBase<Comment, ITrackCommentResources>
    {
        private const string RelativePathFormat = "/comments";

        public TrackCommentsResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }

        #region Overrides of EntitiesResourceBase<User,IUserResources>

        public override ITrackCommentResources this[string id]
        {
            get { return new TrackCommentResources(SoundCloudClient, RelativePath, id); }
        }

        #endregion
    }
}