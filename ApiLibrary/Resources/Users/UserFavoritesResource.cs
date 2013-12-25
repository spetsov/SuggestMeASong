using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    class UserFavoritesResource : EntitiesResourceBase<Track, IUserFavoriteResources>
    {
        private const string RelativePathFormat = "/favorites";

        public UserFavoritesResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }

        #region Overrides of EntitiesResourceBase<Track,ITrackResources>

        public override IUserFavoriteResources this[string id]
        {
            get { return new UserFavoriteResources(SoundCloudClient, RelativePath, id); }
        }

        #endregion
    }
}