using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Groups
{
    class GroupContributorsResource : EntitiesGetBase<User>
    {
        private const string RelativePathFormat = "/contributors";

        public GroupContributorsResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }
    }
}