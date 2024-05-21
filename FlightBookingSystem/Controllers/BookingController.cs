using FlightBookingSystem.Data;
using FlightBookingSystem.ReadModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightBookingSystem.DataTransferObjs;
using FlightBookingSystem.Domain.Entities;
using FlightBookingSystem.Domain.Errors;

namespace FlightBookingSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly Entities _entities;

        public BookingController(Entities entities)
        {
            _entities = entities;
        }


        [HttpGet("{email}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(IEnumerable<BookingRM>), 200)]
        public ActionResult<IEnumerable<BookingRM>> List(string email) 
        {

            var booking = _entities.Flights.ToArray().SelectMany(flight => flight.Bookings
            .Where(booking => booking.PassengerEmail == email)
            .Select(booking => new BookingRM(
                flight.Id, 
                flight.Airline, 
                flight.Price.ToString(),
                new TimePlaceRm(flight.Arrival.Place, flight.Arrival.Time),
                new TimePlaceRm(flight.Departure.Place, flight.Departure.Time),
                booking.NumberOfSeats,
                email)));

            return Ok(booking);

        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Cancel(BookDto bookDto)
        {
            var flight = _entities.Flights.Find(bookDto.FlightId);

            var error = flight?.CancelBooking(bookDto.PassengerEmail, bookDto.NumberOfSeats);

            if (error == null)
            {
                _entities.SaveChanges();
                return NoContent();
            }

            if (error is NotFoundError) 
            {
                return NotFound();            
            
            }

            throw new Exception($"The error of type: {error.GetType().Name } occurred while canceling the flight made by {bookDto.PassengerEmail}");
        }
    }
}
