namespace Domaincrafters.Domain;

[System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S4035",
 Justification = "Entity class handles equality safely and prevents invalid comparisons between different entity types. Using IEqualityComparer is redundant and less type-safe in this scenario.")]
/// <summary>
/// Base class for UUID-based entity identifiers
/// providing equality checks and operator overrides.
/// </summary>
/// <param name="value">The initial UUID value or null to generate a new UUID.</param>
public abstract class UuidEntityId(string? value) : IEntityId, IEquatable<UuidEntityId>
{
    /// <summary>
    /// Gets or sets the entity's UUID string value,
    /// automatically generating a valid UUID if none is provided.
    /// </summary>
    public string Value { get; set; } = string.IsNullOrEmpty(value) ? Guid.NewGuid().ToString() : Guid.Parse(value).ToString();

    /// <summary>
    /// Determines whether the specified identifier is equal to the current identifier.
    /// </summary>
    /// <param name="other">The identifier to compare.</param>
    /// <returns>
    /// True if they represent the same UUID and type; otherwise, false.
    /// </returns>
    public bool Equals(UuidEntityId? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return Value.Equals(other.Value);
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current identifier.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns>
    /// True if the object is a UuidEntityId with the same UUID; otherwise, false.
    /// </returns>
    public override bool Equals(object? obj)
    {
        return Equals(obj as UuidEntityId);
    }

    /// <summary>
    /// Serves as the default hash function, returning the UUID string's hash code.
    /// </summary>
    /// <returns>The hash code of the UUID string.</returns>
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    /// <summary>
    /// Returns the UUID string value.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    /// <summary>
    /// Compares two UuidEntityId objects for equality.
    /// </summary>
    /// <param name="left">The left identifier to compare.</param>
    /// <param name="right">The right identifier to compare.</param>
    /// <returns>True if both identifiers are equal or both are null; otherwise, false.</returns>
    public static bool operator ==(UuidEntityId? left, UuidEntityId? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Compares two UuidEntityId objects for inequality.
    /// </summary>
    /// <param name="left">The left identifier to compare.</param>
    /// <param name="right">The right identifier to compare.</param>
    /// <returns>True if the identifiers are not equal; otherwise, false.</returns>
    public static bool operator !=(UuidEntityId? left, UuidEntityId? right)
    {
        return !Equals(left, right);
    }
}


