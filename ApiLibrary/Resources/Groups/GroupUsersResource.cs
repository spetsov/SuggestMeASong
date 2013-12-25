using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Groups
{
    class GroupUsersResource : EntitiesGetBase<User>
    {
        private const string RelativePathFormat = "/users";

        public GroupUsersResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }
    }
}