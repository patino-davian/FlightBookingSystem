using FlightBookingSystem.DataTransferObjs;
using FlightBookingSystem.ReadModels;
using Microsoft.AspNetCore.Mvc;
using FlightBookingSystem.Domain.Entities;
using FlightBookingSystem.Domain.Errors;
using FlightBookingSystem.Data;

namespace FlightBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {

        private readonly ILogger<FlightController> _logger;
        private readonly Entities _entities;

        public FlightController(ILogger<FlightController> logger, Entities entities)
        {
            _logger = logger;
            _entities = entities;
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<FlightRm>), 200)]
        public IEnumerable<FlightRm> Search()
        {
            var flightRmList = _entities.Flights.Select(flight => new FlightRm(
                flight.Id,
                flight.Airline,
                flight.Price,
                new TimePlaceRm(flight.Departure.Place.ToString(), flight.Departure.Time),
                new TimePlaceRm(flight.Arrival.Place.ToString(), flight.Arrival.Time),
                flight.RemainingNumberOfSeats
                )).ToArray();

            return flightRmList;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(FlightRm), 200)]
        [HttpGet("{id}")]
        public ActionResult<FlightRm> Find(Guid id)
        {
            var flight = _entities.Flights.SingleOrDefault(f => f.Id == id);

            if (flight == null)
            {
                return NotFound();
            }

            var flightReadModel = new FlightRm(
                flight.Id,
                flight.Airline,
                flight.Price,
                new TimePlaceRm(flight.Departure.Place.ToString(), flight.Departure.Time),
                new TimePlaceRm(flight.Arrival.Place.ToString(), flight.Arrival.Time),
                flight.RemainingNumberOfSeats
                );

            return Ok(flightReadModel);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Book(BookDto bookDto)
        {
            System.Diagnostics.Debug.WriteLine( $"Booking a new flight {bookDto.FlightId}");

            var flight = _entities.Flights.SingleOrDefault(f => f.Id == bookDto.FlightId );

            if (flight == null)
                return NotFound();

            var error = flight.MakeBooking(bookDto.PassengerEmail, bookDto.NumberOfSeats);

            if (error is OverbookError)
            {
                return Conflict(new {message = "The number of seats requested is more than the number of seats available"});
            }

            _entities.SaveChanges();

            return CreatedAtAction(nameof(Find), new {id = bookDto.FlightId});
        }

    }
}