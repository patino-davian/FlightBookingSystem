using FlightBookingSystem.DataTransferObjs;
using FlightBookingSystem.Domain.Errors;
using FlightBookingSystem.ReadModels;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Domain.Entities
{
    public class Flight
    {
        public Guid Id { get; set; }
        public string Airline { get; set; }
        public string Price { get; set; }
        public TimePlace Departure { get; set; }
        public TimePlace Arrival { get; set; }
        public int RemainingNumberOfSeats { get; set; }

        public IList<Booking> Bookings = new List<Booking>();

        public Flight()
        {
        }

        public Flight(Guid id, string airline, string price, TimePlace departure, TimePlace arrival, int remainingNumberOfSeats)
        {
            Id = id;
            Airline = airline;
            Price = price;
            Departure = departure;
            Arrival = arrival;
            RemainingNumberOfSeats = remainingNumberOfSeats;
        }

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

        internal object? CancelBooking(string passengerEmail, byte numberOfSeats)
        {
            var booking = Bookings.FirstOrDefault( b =>  b.NumberOfSeats == numberOfSeats && passengerEmail.ToLower() == b.PassengerEmail.ToLower());

            if (booking == null)
            {
                return new NotFoundError();
            }

            Bookings.Remove(booking);

            RemainingNumberOfSeats += booking.NumberOfSeats;
            return null;
        }
    }

}
