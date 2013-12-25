using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    class UserFollowingsResource : EntitiesResourceBase<User, IUserFollowingResources>
    {
        private const string RelativePathFormat = "/followings";

        public UserFollowingsResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }

        #region Overrides of EntitiesResourceBase<User,IUserFollowingResources>

        public override IUserFollowingResources this[string id]
        {
            get { return new UserFollowingResources(SoundCloudClient, RelativePath, id); }
        }

        #endregion
    }
}