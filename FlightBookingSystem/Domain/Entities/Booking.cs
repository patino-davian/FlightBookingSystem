using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Domain.Entities
{
    public record Booking(
        string PassengerEmail, 
        byte NumberOfSeats
        );

}
