using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ewk.SoundCloud.ApiLibrary.Resources
{
    /// <summary>
    /// Provides methods to get entities from soundcloud.
    /// </summary>
    /// <typeparam name="TEntity">The <see cref="Type"/> of the entities to get.</typeparam>
    public interface IEntitiesGet<TEntity>
    {

        /// <summary>
        /// Gets the <typeparamref name="TEntity"/> instances from soundcloud.
        /// </summary>
        Task<IEnumerable<TEntity>> GetAsync();


        /// <summary>
        /// Gets the <typeparamref name="TEntity"/> instances from soundcloud.
        /// </summary>
        Task<IEnumerable<TEntity>> GetAsync(IDictionary<string, string> parameters);

        /// <summary>
        /// Gets the <typeparamref name="TEntity"/> instances from soundcloud.
        /// </summary>
        /// <param name="order">The order of the results.</param>
        Task<IEnumerable<TEntity>> GetAsync(string order);


        /// <summary>
        /// Gets the <typeparamref name="TEntity"/> instances from soundcloud.
        /// </summary>
        /// <param name="order">The order of the results.</param>
        Task<IEnumerable<TEntity>> GetAsync(string order, IDictionary<string, string> parameters);

        /// <summary>
        /// Gets the <typeparamref name="TEntity"/> instances from soundcloud.
        /// </summary>
        /// <param name="page">The page number that defines an offset.</param>
        Task<IEnumerable<TEntity>> GetAsync(int page);


        /// <summary>
        /// Gets the <typeparamref name="TEntity"/> instances from soundcloud.
        /// </summary>
        /// <param name="page">The page number that defines an offset.</param>
        Task<IEnumerable<TEntity>> GetAsync(int page, IDictionary<string, string> parameters);

        /// <summary>
        /// Gets the <typeparamref name="TEntity"/> instances from soundcloud.
        /// </summary>
        /// <param name="order">The order of the results.</param>
        /// <param name="page">The page number that defines an offset.</param>
        Task<IEnumerable<TEntity>> GetAsync(string order, int page);

        /// <summary>
        /// Gets the <typeparamref name="TEntity"/> instances from soundcloud.
        /// </summary>
        /// <param name="order">The order of the results.</param>
        /// <param name="page">The page number that defines an offset.</param>
        Task<IEnumerable<TEntity>> GetAsync(string order, int page, IDictionary<string, string> parameters);
    }
}