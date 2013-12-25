using System;
using System.Threading.Tasks;

namespace Ewk.SoundCloud.ApiLibrary.Resources
{
    /// <summary>
    /// Provides methods to get entities from soundcloud.
    /// </summary>
    /// <typeparam name="TEntity">The <see cref="Type"/> of the entity to get.</typeparam>
    public interface IEntityGet<TEntity>
    {
        /// <summary>
        /// Gets the current <typeparamref name="TEntity"/> from soundcloud.
        /// </summary>
        TEntity Get();

        /// <summary>
        /// Gets the current <typeparamref name="TEntity"/> from soundcloud.
        /// </summary>
        Task<TEntity> GetAsync();
    }
}