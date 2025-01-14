namespace Domaincrafters.Domain;

[System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S4035",
 Justification = "Entity class handles equality safely and prevents invalid comparisons between different entity types. Using IEqualityComparer is redundant and less type-safe in this scenario.")]
/// <summary>
/// Base class for domain entities that provides 
/// equality checks based on the entity's unique identifier.
/// </summary>
/// <param name="id">The unique identifier for this entity.</param>
public abstract class Entity(IEntityId id) : IEquatable<Entity>
{
    /// <summary>
    /// Unique identifier of the entity.
    /// </summary>
    public IEntityId Id { get; private init; } = id;

    /// <summary>
    /// Validates the current state of the entity.
    /// </summary>
    /// <exception cref="System.Exception">Thrown when the entity's state is invalid.</exception>
    protected abstract void ValidateState();

    /// <summary>
    /// Determines whether the specified entity is equal to the current entity.
    /// </summary>
    /// <param name="other">The entity to compare.</param>
    /// <returns>
    /// True if the other entity has the same identifier and type; otherwise, false.
    /// </returns>
    public bool Equals(Entity? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return Id.Equals(other.Id);
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current entity.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns>
    /// True if the object is an entity with the same identifier and type; otherwise, false.
    /// </returns>
    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity);
    }

    /// <summary>
    /// Serves as the default hash function, returning the identifier's hash code.
    /// </summary>
    /// <returns>The hash code for this entity's identifier.</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
