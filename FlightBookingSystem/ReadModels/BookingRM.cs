namespace FlightBookingSystem.ReadModels
{
    public record BookingRM(
        Guid FlightId, 
        string Airline, 
        string Price, 
        TimePlaceRm Departure, 
        TimePlaceRm Arrival, 
        int NumberOfBookedSeats, 
        string PassengerEmail);
}
