using System.Threading.Tasks;

namespace Ewk.SoundCloud.ApiLibrary.Resources
{
    /// <summary>
    /// Provides methods to put entities on soundcloud.
    /// </summary>
    public interface IEntityPost<TEntity>
    {
        /// <summary>
        /// Posts an <typeparamref name="TEntity"/> on soundcloud.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to put on soundcloud.</param>
        TEntity Post(TEntity entity);

        /// <summary>
        /// Posts an <typeparamref name="TEntity"/> on soundcloud.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to put on soundcloud.</param>
        Task<TEntity> PostAsync(TEntity entity);
    }
}