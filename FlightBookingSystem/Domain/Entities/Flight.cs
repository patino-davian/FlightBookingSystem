using FlightBookingSystem.DataTransferObjs;
using FlightBookingSystem.Domain.Errors;
using FlightBookingSystem.ReadModels;

namespace FlightBookingSystem.Domain.Entities
{
    public record Flight(Guid Id, string Airline, string Price, TimePlace Departure, TimePlace Arrival, int RemainingNumberOfSeats)
    {
        public IList<Booking> Bookings = new List<Booking>();

        public int RemainingNumberOfSeats { get; set;  } = RemainingNumberOfSeats;

        internal object? MakeBooking(string passengerEmail, byte numberOfSeats)
        {
            var flight = this;

            if (flight.RemainingNumberOfSeats < numberOfSeats)
            {
                return new OverbookError();
            }

            var booking = new Booking(
                passengerEmail,
                numberOfSeats
            );
            flight.Bookings.Add(booking);

            flight.RemainingNumberOfSeats -= numberOfSeats;
            return null;
        }
    }

}
