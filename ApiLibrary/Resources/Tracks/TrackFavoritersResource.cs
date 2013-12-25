using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Tracks
{
    internal class TrackFavoritersResource : EntitiesResourceBase<User, ITrackFavoriterResources>
    {
        private const string RelativePathFormat = "/favoriters";

        public TrackFavoritersResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }

        #region Overrides of EntitiesResourceBase<User,IUserResources>

        public override ITrackFavoriterResources this[string id]
        {
            get { return new TrackFavoriterResources(SoundCloudClient, RelativePath, id); }
        }

        #endregion
    }
}