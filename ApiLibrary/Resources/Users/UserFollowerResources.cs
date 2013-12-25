using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    internal class UserFollowerResources : EntityResourceBase<User>, IUserFollowerResources
    {
        public UserFollowerResources(ISoundCloudClient soundCloudClient, string relativePath, string id)
            : base(soundCloudClient, string.Concat(relativePath, "/", id))
        {
        }
    }
}