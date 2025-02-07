namespace Domaincrafters.Domain;

/// <summary>
///     Represents a domain event.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    ///     Gets the qualified name of the event.
    /// </summary>
    public string QualifiedEventName { get; }
    /// <summary>
    ///     Gets the date and time the event occurred.
    /// </summary>
    public DateTime OccurredOn { get; }
}