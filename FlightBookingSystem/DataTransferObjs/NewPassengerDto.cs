using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.DataTransferObjs
{
    public record NewPassengerDto(
        [Required]
        [EmailAddress]
        [StringLength(35, MinimumLength = 1)]
        string Email,

        [Required]
        [MaxLength(20)] 
        [MinLength(1)]
        string FirstName,

        [Required]
        [MaxLength(20)]
        [MinLength(1)]
        string LastName,

        [Required]
        bool Gender
        );
}
