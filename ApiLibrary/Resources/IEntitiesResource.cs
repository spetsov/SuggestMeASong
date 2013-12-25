using System;

namespace Ewk.SoundCloud.ApiLibrary.Resources
{
    /// <summary>
    /// Defines the common accessibility of an entity resource.
    /// </summary>
    /// <typeparam name="TEntity">The <see cref="Type"/> of the entity that can be retrieved from the resource.</typeparam>
    /// <typeparam name="TEntityResource">The type of the resource.</typeparam>
    public interface IEntitiesResource<TEntity, out TEntityResource> : IEntitiesGet<TEntity>, IEntityPost<TEntity>
        where TEntityResource : IEntityGet<TEntity>
    {
        /// <summary>
        /// Gets the resource of a <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="id">The identifier of the <typeparamref name="TEntity"/>.</param>
        TEntityResource this[int id] { get; }

        /// <summary>
        /// Gets the resource of a <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="id">The identifier of the <typeparamref name="TEntity"/>.</param>
        TEntityResource this[string id] { get; }
    }
}