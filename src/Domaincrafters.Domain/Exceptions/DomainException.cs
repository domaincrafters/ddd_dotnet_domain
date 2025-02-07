namespace Howestprime.Movies.Domain.Shared.Exceptions;

/// <summary>
///     Represents an exception that occurs within the domain.
/// </summary>
/// <param name="message">The message that describes the error.</param>
public sealed class DomainException(string message) : Exception(message)
{
}