using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    class UserCommentsResource : EntitiesGetBase<Comment>
    {
        private const string RelativePathFormat = "/comments";

        public UserCommentsResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }
    }
}