namespace Domaincrafters.Domain;

/// <summary>
///     Represents a subscriber to domain events.
/// </summary>
public interface IDomainEventSubscriber
{
    /// <summary>
    ///     Determines whether this subscriber is subscribed to the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>
    ///     <c>true</c> if this subscriber is subscribed to the event; otherwise, <c>false</c>.
    /// </returns>
    public bool IsSubscribedTo(IDomainEvent domainEvent);

    /// <summary>
    ///     Handles the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event to handle.</param>
    public void HandleEvent(IDomainEvent domainEvent);
}