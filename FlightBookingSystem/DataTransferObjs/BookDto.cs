using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.DataTransferObjs
{
    public record BookDto(
        [Required] 
        Guid FlightId, 

        [Required]
        [EmailAddress] 
        string PassengerEmail, 

        [Required]
        [Range(1,244)] 
        byte NumberOfSeats
        );

}
