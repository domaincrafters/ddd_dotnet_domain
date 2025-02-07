using Microsoft.Extensions.Logging;

namespace Domaincrafters.Domain;

/// <summary>
///     Publishes domain events to registered subscribers.
/// </summary>
public sealed class DomainEventPublisher
{
    private static readonly DomainEventPublisher _instance = new();
    /// <summary>
    ///     Gets the singleton instance of the <see cref="DomainEventPublisher" />.
    /// </summary>
    public static DomainEventPublisher Instance => _instance;
    private readonly IList<IDomainEventSubscriber> _subscribers;
    private readonly ILogger<DomainEventPublisher> _logger;

    private DomainEventPublisher()
    {
        _subscribers = [];
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        _logger = loggerFactory.CreateLogger<DomainEventPublisher>();
    }

    /// <summary>
    ///     Adds a subscriber to the list of domain event subscribers.
    /// </summary>
    /// <param name="subscriber">The subscriber to add.</param>
    public void AddDomainEventSubscriber(IDomainEventSubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    /// <summary>
    ///     Publishes the specified domain event to all registered subscribers.
    /// </summary>
    /// <param name="domainEvent">The domain event to publish.</param>
    public void Publish(IDomainEvent domainEvent)
    {
        _logger.LogInformation("Publishing domain event: {EventName}", domainEvent.QualifiedEventName);
        _subscribers
            .Where(subscriber => subscriber.IsSubscribedTo(domainEvent))
            .ToList()
            .ForEach(subscriber => subscriber.HandleEvent(domainEvent));
    }
}
