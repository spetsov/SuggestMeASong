using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ewk.SoundCloud.ApiLibrary.Entities;

namespace Ewk.SoundCloud.ApiLibrary.Resources
{
    internal static class EntityExtensions
    {
        public static TEntity SetSoundCloudClient<TEntity>(this Task<TEntity> task,
                                                           ISoundCloudClient soundCloudClient)
            where TEntity : Entity
        {
            try
            {
                return task.Result.SetSoundCloudClient(soundCloudClient);
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
        }

        public static IEnumerable<TEntity> SetSoundCloudClient<TEntity>(this Task<IEnumerable<TEntity>> task,
                                                                        ISoundCloudClient soundCloudClient)
            where TEntity : Entity
        {
            try
            {
                return task.Result.SetSoundCloudClient(soundCloudClient);
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
        }

        public static TEntity SetSoundCloudClient<TEntity>(this TEntity entity,
                                                           ISoundCloudClient soundCloudClient)
            where TEntity : Entity
        {
            entity.SoundCloudClient = soundCloudClient;
            return entity;
        }

        public static IEnumerable<TEntity> SetSoundCloudClient<TEntity>(this IEnumerable<TEntity> entities,
                                                                        ISoundCloudClient soundCloudClient)
            where TEntity : Entity
        {
            entities = entities.ToList();
            foreach (var entity in entities)
            {
                entity.SetSoundCloudClient(soundCloudClient);
            }

            return entities;
        }
    }
}