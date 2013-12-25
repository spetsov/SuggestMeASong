using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    internal class UserFollowingResources : EntityResourceBase<User>, IUserFollowingResources
    {
        public UserFollowingResources(ISoundCloudClient soundCloudClient, string relativePath, string id)
            : base(soundCloudClient, string.Concat(relativePath, "/", id))
        {
        }

        #region Implementation of IEntityPut<User>

        public User Put(User entity)
        {
            return PutEntityAsync(entity).Result;
        }

        public async Task<User> PutAsync(User entity)
        {
            return await PutEntityAsync(entity);
        }

        #endregion

        #region Implementation of IEntityDelete

        public void Delete()
        {
            DeleteEntityAsync();
        }

        public async Task DeleteAsync()
        {
            await DeleteEntityAsync();
        }

        #endregion
    }
}