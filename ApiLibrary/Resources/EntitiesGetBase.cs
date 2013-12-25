using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources
{
    abstract class EntitiesGetBase<TEntity> : ResourceBase, IEntitiesGet<TEntity>
        where TEntity : Entity
    {
        #region Constructors

        protected EntitiesGetBase(ISoundCloudClient soundCloudClient, string relativePath)
            : base(soundCloudClient, relativePath)
        {
        }

        #endregion

        #region Implementation of IEntitiesGet<TEntity>

        public IEnumerable<TEntity> Get()
        {
            return GetAsync().Result;
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await SoundCloudClient.GetPageAsync<TEntity>(RelativePath)
                                         .ContinueWith(task => task.SetSoundCloudClient(SoundCloudClient));
        }

        public IEnumerable<TEntity> Get(IDictionary<string, string> parameters)
        {
            return GetAsync(parameters).Result;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(IDictionary<string, string> parameters)
        {
            return await SoundCloudClient.GetPageAsync<TEntity>(RelativePath, parameters)
                                         .ContinueWith(task => task.SetSoundCloudClient(SoundCloudClient));
        }

        public IEnumerable<TEntity> Get(string order)
        {
            return GetAsync(order).Result;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(string order)
        {
            return await SoundCloudClient.GetPageAsync<TEntity>(RelativePath, order)
                                         .ContinueWith(task => task.SetSoundCloudClient(SoundCloudClient));
        }

        public IEnumerable<TEntity> Get(string order, IDictionary<string, string> parameters)
        {
            return GetAsync(order, parameters).Result;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(string order, IDictionary<string, string> parameters)
        {
            return await SoundCloudClient.GetPageAsync<TEntity>(RelativePath, order, parameters)
                                         .ContinueWith(task => task.SetSoundCloudClient(SoundCloudClient));
        }

        public IEnumerable<TEntity> Get(int page)
        {
            return GetAsync(page).Result;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(int page)
        {
            return await SoundCloudClient.GetPageAsync<TEntity>(RelativePath, page)
                                         .ContinueWith(task => task.SetSoundCloudClient(SoundCloudClient));
        }

        public IEnumerable<TEntity> Get(int page, IDictionary<string, string> parameters)
        {
            return GetAsync(page, parameters).Result;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(int page, IDictionary<string, string> parameters)
        {
            return await SoundCloudClient.GetPageAsync<TEntity>(RelativePath, page, parameters)
                                         .ContinueWith(task => task.SetSoundCloudClient(SoundCloudClient));
        }

        public IEnumerable<TEntity> Get(string order, int page)
        {
            return GetAsync(order, page).Result;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(string order, int page)
        {
            return await SoundCloudClient.GetPageAsync<TEntity>(RelativePath, order, page)
                                         .ContinueWith(task => task.SetSoundCloudClient(SoundCloudClient));
        }

        public IEnumerable<TEntity> Get(string order, int page, IDictionary<string, string> parameters)
        {
            return GetAsync(order, page, parameters).Result;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(string order, int page, IDictionary<string, string> parameters)
        {
            return await SoundCloudClient.GetPageAsync<TEntity>(RelativePath, order, page, parameters)
                                         .ContinueWith(task => task.SetSoundCloudClient(SoundCloudClient));
        }

        #endregion
    }
}