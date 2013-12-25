using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    class UsersResource : EntitiesResourceBase<User, IUserResources<User>>
    {
        private const string RelativePathFormat = "/users";

        #region Constructors

        public UsersResource(ISoundCloudClient soundCloudClient)
            : base(soundCloudClient, RelativePathFormat)
        {
        }

        public UsersResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }

        #endregion

        #region Overrides of EntitiesResourceBase<User,IUserResources>

        public override IUserResources<User> this[string id]
        {
            get { return new UserResources(SoundCloudClient, RelativePath, id); }
        }

        #endregion
    }
}