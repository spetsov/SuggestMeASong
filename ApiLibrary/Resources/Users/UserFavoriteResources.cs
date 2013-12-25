using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources.Users
{
    internal class UserFavoriteResources : EntityResourceBase<Track>, IUserFavoriteResources
    {
        public UserFavoriteResources(ISoundCloudClient soundCloudClient, string relativePath, string id)
            : base(soundCloudClient, string.Concat(relativePath, "/", id))
        {
        }

        #region Implementation of IEntityPut<Track>

        public Track Put(Track entity)
        {
            return PutEntityAsync(entity).Result;
        }

        public async Task<Track> PutAsync(Track entity)
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