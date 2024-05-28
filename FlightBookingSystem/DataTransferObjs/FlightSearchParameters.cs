using System.ComponentModel;

namespace FlightBookingSystem.DataTransferObjs
{
    public record FlightSearchParameters(

        [DefaultValue("12/25/2024 10:30:00 AM")]
        DateTime? FromDate,

        [DefaultValue("12/26/2024 10:30:00 AM")]
        DateTime? ToDate,

        [DefaultValue("Los Angleles")]
        string? From,

        [DefaultValue("New York")]
        string? Destination,

        [DefaultValue(1)]
        int? NumberOfPassengers
        );
}
