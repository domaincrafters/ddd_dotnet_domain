namespace Domaincrafters.Domain;

/// <summary>
/// Represents the contract for a unique identifier of a domain entity.
/// </summary>
public interface IEntityId
{
    /// <summary>
    /// Gets the unique identifier value for the entity.
    /// </summary>
    string Value { get; }
}