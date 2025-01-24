using Aornis;

namespace Domaincrafters.Domain;

/// <summary>
/// Defines a repository for managing entities of type <typeparamref name="TEntity"/>.
/// </summary>
/// <typeparam name="TEntity">The domain entity type.</typeparam>
public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : IEntityId
{
    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The entity's unique identifier.</param>
    /// <returns>An optional containing the entity, or empty if not found.</returns>
    Task<Optional<TEntity>> ById(TId id);

    /// <summary>
    /// Saves the entity to the underlying data store.
    /// </summary>
    /// <param name="entity">The entity to persist.</param>
    Task Save(TEntity entity);

    /// <summary>
    /// Removes the entity from the data store.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    Task Remove(TEntity entity);
}