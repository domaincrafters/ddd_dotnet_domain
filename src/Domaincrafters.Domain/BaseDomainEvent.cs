namespace Domaincrafters.Domain;

/// <summary>
///     Base class for domain events.
/// </summary>
/// <param name="eventName">The name of the event.</param>
/// <param name="boundedContext">The bounded context the event belongs to.</param>
public abstract class BaseDomainEvent(
    string eventName,
    string boundedContext
) : IDomainEvent
{
    private readonly string _boundedContext = boundedContext;
    private readonly string _eventName = eventName;
    private readonly DateTime _occurredOn = DateTime.UtcNow;

    /// <inheritdoc />
    public string QualifiedEventName
    {
        get
        {
            return $"{_boundedContext}.{_eventName}";
        }
    }

    /// <summary>
    ///     Gets the name of the event.
    /// </summary>
    public string EventName => _eventName;
    
    /// <summary>
    ///     Gets the date and time the event occurred.
    /// </summary>
    public DateTime OccurredOn => _occurredOn;
}
