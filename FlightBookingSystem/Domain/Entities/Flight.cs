namespace FlightBookingSystem.Domain.Entities
{
    public record Flight(Guid Id, string Airline, string Price, TimePlace Departure, TimePlace Arrival, int RemainingNumberOfSeats);
}
