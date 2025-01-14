using System.Dynamic;
using Aornis;
using Domaincrafters.Domain;

namespace UnitTests.Domaincrafters.Domain;

class Seat(
    IEntityId id,
    int number
) : Entity(id)
{
    public int Number { get; private init; } = number;
    protected override void ValidateState()
    {
        throw new NotImplementedException();
    }
}

sealed class SeatRepository() : IRepository<Seat>
{
    private readonly ISet<Seat> _seats = new HashSet<Seat>();

    public Task<Optional<Seat>> ById(IEntityId id)
    {
        Optional<Seat> optionalSeat = Optional.Of(_seats.SingleOrDefault(s => s.Id == id));
        return Task.FromResult(optionalSeat);
    }

    public Task Remove(Seat entity)
    {
        _seats.Remove(entity);
        return Task.CompletedTask;
    }

    public Task Save(Seat entity)
    {
        _seats.Add(entity);
        return Task.CompletedTask;
    }
}
public sealed class RepositoryTests
{
    [Fact]
    public async Task SavingASeat_ThenRetrievingItById_ReturnsTheSameSeat()
    {
        // Arrange
        SeatId seatId = new();
        Seat seat = new(seatId, 1);
        SeatRepository repository = new();
        await repository.Save(seat);

        // Act
        Optional<Seat> optionalSeat = await repository.ById(seatId);

        // Assert
        Assert.True(optionalSeat.HasValue);
        Assert.Equal(seat, optionalSeat.Value);
    }

    [Fact]
    public async Task RemovingASeat_ThenRetrievingItById_ReturnsEmpty()
    {
        // Arrange
        SeatId seatId = new();
        Seat seat = new(seatId, 1);
        SeatRepository repository = new();

        // Act
        await repository.Save(seat);
        await repository.Remove(seat);
        Optional<Seat> optionalSeat = await repository.ById(seatId);

        // Assert
        Assert.False(optionalSeat.HasValue);
    }

}