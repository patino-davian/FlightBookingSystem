using FlightBookingSystem.DataTransferObjs;
using FlightBookingSystem.ReadModels;
using Microsoft.AspNetCore.Mvc;
using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {

        private readonly ILogger<FlightController> _logger;

        static Random random = new Random();

        static private Flight[] flights = new Flight[]
        {
             new (
                Guid.NewGuid(),
                "American Airlines",
                random.Next(90, 600).ToString(),
                new TimePlace("Los Angeles", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlace("San Antonio", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),
            new (
                Guid.NewGuid(),
                "Delta Airlines",
                random.Next(90, 700).ToString(),
                new TimePlace("Chicago", DateTime.Now.AddHours(random.Next(1,10))),
                new TimePlace("Dallas", DateTime.Now.AddHours(random.Next(4,24))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "United Airlines",
                random.Next(90, 500).ToString(),
                new TimePlace("New York", DateTime.Now.AddHours(random.Next(1,12))),
                new TimePlace("Miami", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),
            new (
                Guid.NewGuid(),
                "Southwest Airlines",
                random.Next(90, 700).ToString(),
                new TimePlace("Houston", DateTime.Now.AddHours(random.Next(1,12))),
                new TimePlace("Denver", DateTime.Now.AddHours(random.Next(12,24))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "JetBlue Airways",
                random.Next(90, 500).ToString(),
                new TimePlace("Orlando", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlace("Seattle", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "Alaska Airlines",
                random.Next(90, 500).ToString(),
                new TimePlace("Portland", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlace("Las Vegas", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "Spirit Airlines",
                random.Next(90, 500).ToString(),
                new TimePlace("Atlanta", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlace("Boston", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "Frontier Airlines",
                random.Next(90, 500).ToString(),
                new TimePlace("Phoenix", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlace("Detroit", DateTime.Now.AddHours(random.Next(12,24))),
                random.Next(1, 100))
        };

        public FlightController(ILogger<FlightController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<FlightRm>), 200)]
        public IEnumerable<FlightRm> Search()
        {
            var flightRmList = flights.Select(flight => new FlightRm(
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
            var flight = flights.SingleOrDefault(f => f.Id == id);

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

            var flight = flights.SingleOrDefault(f => f.Id == bookDto.FlightId );

            if (flight == null)
            {
                return NotFound();
            }

            if (flight.RemainingNumberOfSeats < bookDto.NumberOfSeats)
            {
                return Conflict(new { message = "The number of requested seats exceeds the number of remaining seats" });
            }

            var booking = new Booking(
                bookDto.FlightId,
                bookDto.PassengerEmail,
                bookDto.NumberOfSeats
                );

            flight.Bookings.Add(booking);

            flight.RemainingNumberOfSeats -= bookDto.NumberOfSeats;

            return CreatedAtAction(nameof(Find), new {id = bookDto.FlightId});
        }

    }
}