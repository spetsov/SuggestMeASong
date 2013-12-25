using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Ewk.SoundCloud.ApiLibrary.Resources
{
    abstract class EntityResourceBase<TEntity> : ResourceBase, IEntityGet<TEntity>
        where TEntity : Entity
    {
        #region Constructors

        protected EntityResourceBase(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, relativePath)
        {
        }

        #endregion

        #region Implementation of IEntityGet<out TEntity>

        public TEntity Get()
        {
            return GetAsync().Result;
        }

        public async Task<TEntity> GetAsync()
        {
            return await SoundCloudClient.GetAsync<TEntity>(RelativePath)
                                         .ContinueWith(task => task.SetSoundCloudClient(SoundCloudClient));
        }

        #endregion

        protected async Task<TEntity> PutEntityAsync(TEntity entity)
        {
            return await SoundCloudClient.PutAsync<TEntity, TEntity>(RelativePath, entity)
                                         .ContinueWith(task => task.SetSoundCloudClient(SoundCloudClient));
        }

        protected async Task DeleteEntityAsync()
        {
            await SoundCloudClient.DeleteAsync<TEntity>(RelativePath);
        }
    }
}