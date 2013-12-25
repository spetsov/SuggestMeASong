using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    class UserTracksResource : EntitiesGetBase<Track>
    {
        private const string RelativePathFormat = "/tracks";

        public UserTracksResource(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, string.Concat(relativePath, RelativePathFormat))
        {
        }
    }
}