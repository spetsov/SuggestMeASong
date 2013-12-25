using System.Threading.Tasks;

namespace Ewk.SoundCloud.ApiLibrary.Resources
{
    /// <summary>
    /// Provides methods to put entities on soundcloud.
    /// </summary>
    public interface IEntityPut<TEntity>
    {
        /// <summary>
        /// Puts an <typeparamref name="TEntity"/> on soundcloud.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to put on soundcloud.</param>
        TEntity Put(TEntity entity);

        /// <summary>
        /// Puts an <typeparamref name="TEntity"/> on soundcloud.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to put on soundcloud.</param>
        Task<TEntity> PutAsync(TEntity entity);
    }
}