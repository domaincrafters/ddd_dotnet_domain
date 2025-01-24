using Domaincrafters.Domain;
namespace UnitTests.Domaincrafters.Domain;

class BookingId(string? id = "") : UuidEntityId(id)
{
}

class Booking(
    BookingId id,
    string name
) : Entity<BookingId>(id)
{
    public string Name { get; private init; } = name;
    protected override void ValidateState()
    {
        throw new NotImplementedException();
    }
}

public sealed class EntityTests
{
    [Fact]
    public void CreatingAnUuidEntityId_WithInput_Works()
    {
        // Arrange + Act"
        string id = Guid.NewGuid().ToString();
        BookingId bookingId = new(id);

        // Assert
        Assert.Equal(id, bookingId.Value);
        Assert.Equal(id, bookingId.ToString());
    }

    [Fact]
    public void CreatingAnUuidEntityId_WithNoInput_CreatesARandomId()
    {
        // Arrange + Act
        BookingId bookingId = new();

        // Assert
        Assert.NotNull(bookingId.Value);
        Assert.Equal(36, bookingId.Value.Length);
    }

    [Fact]
    public void TwoUuidEntityIds_WithSameValue_AreEqual()
    {
        // Arrange
        string id = Guid.NewGuid().ToString();
        BookingId bookingId1 = new(id);
        BookingId bookingId2 = new(id);

        // Assert
        Assert.Equal(bookingId1, bookingId2);
        Assert.True(bookingId1.Equals(bookingId2));
        Assert.True(bookingId1 == bookingId2);
        Assert.False(bookingId1 != bookingId2);
    }

    [Fact]
    public void TwoUuidEntityIds_WithDifferentValue_AreNotEqual()
    {
        // Arrange
        BookingId bookingId1 = new();
        BookingId bookingId2 = new();

        // Assert
        Assert.NotEqual(bookingId1, bookingId2);
        Assert.False(bookingId1.Equals(bookingId2));
        Assert.False(bookingId1 == bookingId2);
        Assert.True(bookingId1 != bookingId2);
    }

    [Fact]
    public void TwoUuidEntityIds_WithDifferentType_AreNotEqual()
    {
        // Arrange
        string id = Guid.NewGuid().ToString();
        BookingId bookingId = new(id);
        SeatId seatId = new(id);

        // Assert
        Assert.NotEqual<UuidEntityId>(bookingId, seatId);
        Assert.False(bookingId.Equals(seatId));
        Assert.False(bookingId == seatId);
        Assert.True(bookingId != seatId);
    }

    [Fact]
    public void AddingEntityToHashSet_WithSameValue_AddsOnlyOne()
    {
        // Arrange
        string id = Guid.NewGuid().ToString();
        BookingId bookingId1 = new(id);
        BookingId bookingId2 = new(id);
        HashSet<BookingId> hashSet =
        [
            // Act
            bookingId1,
            bookingId2,
        ];

        // Assert
        Assert.Single(hashSet);
    }

    [Fact]
    public void AddingEntityToHashSet_WithDifferentValue_AddsBoth()
    {
        // Arrange
        BookingId bookingId1 = new();
        BookingId bookingId2 = new();
        HashSet<BookingId> hashSet =
        [
            // Act
            bookingId1,
            bookingId2,
        ];

        // Assert
        Assert.Equal(2, hashSet.Count);
    }

    [Fact]
    public void CreatingAnEntity_WithIdAndName_Works()
    {
        // Arrange
        string id = Guid.NewGuid().ToString();
        string name = "Booking";

        // Act
        Booking booking = new(new BookingId(id), name);

        // Assert
        Assert.Equal(id, booking.Id.Value);
        Assert.Equal(name, booking.Name);
    }

    [Fact]
    public void TwoEntities_WithSameId_AreEqual()
    {
        // Arrange
        string id = Guid.NewGuid().ToString();
        Booking booking1 = new(new BookingId(id), "booking1");
        Booking booking2 = new(new BookingId(id), "booking2");

        // Assert
        Assert.Equal(booking1, booking2);
        Assert.True(booking1.Equals(booking2));
    }

    [Fact]
    public void TwoEntities_WithDifferentId_AreNotEqual()
    {
        // Arrange
        string name = "Booking";
        Booking booking1 = new(new BookingId(), name);
        Booking booking2 = new(new BookingId(), name);

        // Assert
        Assert.NotEqual(booking1, booking2);
        Assert.False(booking1.Equals(booking2));
    }

    [Fact]
    public void AddingTwoEntitiesToHashSet_WithSameId_AddsOnlyOne()
    {
        // Arrange
        string id = Guid.NewGuid().ToString();
        Booking booking1 = new(new BookingId(id), "booking1");
        Booking booking2 = new(new BookingId(id), "booking2");
        HashSet<Booking> hashSet =
        [
            // Act
            booking1,
            booking2,
        ];

        // Assert
        Assert.Single(hashSet);
    }

    [Fact]
    public void AddingTwoEntitiesToHashSet_WithDifferentId_AddsBoth()
    {
        // Arrange
        Booking booking1 = new(new BookingId(), "booking1");
        Booking booking2 = new(new BookingId(), "booking2");
        HashSet<Booking> hashSet =
        [
            // Act
            booking1,
            booking2,
        ];

        // Assert
        Assert.Equal(2, hashSet.Count);
    }

    [Fact]
    public void AssigningEntityIdBackToConcreteType_Works()
    {
        // Arrange
        string id = Guid.NewGuid().ToString();
        BookingId bookingId = new(id);
        IEntityId entityId = bookingId;

        // Act
        BookingId newBookingId = (BookingId)entityId;

        // Assert
        Assert.Equal(bookingId, newBookingId);
        Booking booking = new(newBookingId, "Booking");
        CheckIfIdParameterToFunctionsAcceptsIEntityId(booking.Id);
        CheckIfIdParameterToFunctionsAcceptsConcreteId(booking.Id);
    }

    private static void CheckIfIdParameterToFunctionsAcceptsIEntityId(IEntityId _entityId)
    {
        // Method intentionally left empty.
    }

    private static void CheckIfIdParameterToFunctionsAcceptsConcreteId(BookingId _bookingId)
    {
        // Method intentionally left empty.
    }
}