using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Domain.Entities
{
    public record NewPassenger(

        string Email,
        string FirstName,
        string LastName,
        bool Gender

        );
}
