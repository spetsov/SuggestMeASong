using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    class UserResources : UserResourcesBase<User>
    {
        public UserResources(ISoundCloudClient soundCloudClient, string relativePath, string id)
            : base(soundCloudClient, string.Concat(relativePath, "/", id))
        {
        }
    }
}