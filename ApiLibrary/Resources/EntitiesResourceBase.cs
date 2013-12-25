using System.Globalization;
using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources
{
    abstract class EntitiesResourceBase<TEntity, TEntityResource> : EntitiesGetBase<TEntity>, IEntitiesResource<TEntity, TEntityResource>
        where TEntityResource : IEntityGet<TEntity>
        where TEntity : Entity
    {
        #region Constructors

        protected EntitiesResourceBase(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, relativePath)
        {
        }

        #endregion

        #region Implementation of IEntitiesResource<TEntity, TEntityResource>

        public TEntityResource this[int id]
        {
            get { return this[id.ToString(CultureInfo.InvariantCulture)]; }
        }

        public abstract TEntityResource this[string id] { get; }

        #endregion

        #region Implementation of IEntityPost<TEntity>

        public TEntity Post(TEntity entity)
        {
            return PostEntityAsync(entity).Result;
        }

        public async Task<TEntity> PostAsync(TEntity entity)
        {
            return await PostEntityAsync(entity);
        }

        #endregion

        protected async Task<TEntity> PostEntityAsync(TEntity entity)
        {
            return await SoundCloudClient.PostAsync<TEntity, TEntity>(RelativePath, entity)
                                         .ContinueWith(task => task.SetSoundCloudClient(SoundCloudClient));
        }
    }
}