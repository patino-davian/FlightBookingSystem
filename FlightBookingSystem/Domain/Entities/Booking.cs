using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Domain.Entities
{
    public record Booking(
        Guid FlightId, 
        string PassengerEmail, 
        byte NumberOfSeats
        );

}
