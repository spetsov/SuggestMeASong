using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    class UserFollowersResource : EntitiesResourceBase<User, IUserFollowerResources>
    {
        private const string RelativePathFormat = "/followers";

        public UserFollowersResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }

        #region Overrides of EntitiesResourceBase<User,IUserFollowerResources>

        public override IUserFollowerResources this[string id]
        {
            get { return new UserFollowerResources(SoundCloudClient, RelativePath, id); }
        }

        #endregion
    }
}