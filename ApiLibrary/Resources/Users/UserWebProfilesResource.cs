using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    class UserWebProfilesResource : EntitiesGetBase<WebProfile>
    {
        private const string RelativePathFormat = "/web-profiles";

        public UserWebProfilesResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }
    }
}