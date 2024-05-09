using FlightBookingSystem.DataTransferObjs;
using FlightBookingSystem.ReadModels;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {

        private readonly ILogger<FlightController> _logger;

        static Random random = new Random();

        static private FlightRm[] flights = new FlightRm[]
        {
             new (
                Guid.NewGuid(),
                "American Airlines",
                random.Next(90, 600).ToString(),
                new TimePlaceRm("Los Angeles", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlaceRm("San Antonio", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),
            new (
                Guid.NewGuid(),
                "Delta Airlines",
                random.Next(90, 700).ToString(),
                new TimePlaceRm("Chicago", DateTime.Now.AddHours(random.Next(1,10))),
                new TimePlaceRm("Dallas", DateTime.Now.AddHours(random.Next(4,24))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "United Airlines",
                random.Next(90, 500).ToString(),
                new TimePlaceRm("New York", DateTime.Now.AddHours(random.Next(1,12))),
                new TimePlaceRm("Miami", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),
            new (
                Guid.NewGuid(),
                "Southwest Airlines",
                random.Next(90, 700).ToString(),
                new TimePlaceRm("Houston", DateTime.Now.AddHours(random.Next(1,12))),
                new TimePlaceRm("Denver", DateTime.Now.AddHours(random.Next(12,24))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "JetBlue Airways",
                random.Next(90, 500).ToString(),
                new TimePlaceRm("Orlando", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlaceRm("Seattle", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "Alaska Airlines",
                random.Next(90, 500).ToString(),
                new TimePlaceRm("Portland", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlaceRm("Las Vegas", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "Spirit Airlines",
                random.Next(90, 500).ToString(),
                new TimePlaceRm("Atlanta", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlaceRm("Boston", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 100)),

            new (
                Guid.NewGuid(),
                "Frontier Airlines",
                random.Next(90, 500).ToString(),
                new TimePlaceRm("Phoenix", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlaceRm("Detroit", DateTime.Now.AddHours(random.Next(12,24))),
                random.Next(1, 100))
        };

        static private IList<BookDto> Bookings = new List<BookDto>();

        public FlightController(ILogger<FlightController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<FlightRm>), 200)]
        public IEnumerable<FlightRm> Search() => flights;

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

            return Ok(flight);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Book(BookDto bookDto)
        {
            System.Diagnostics.Debug.WriteLine( $"Booking a new flight {bookDto.FlightId}");

            var flightFound = flights.Any(f => f.Id == bookDto.FlightId );

            if (flightFound == false)
            {
                return NotFound();
            }

            Bookings.Add(bookDto);

            return CreatedAtAction(nameof(Find), new {id = bookDto.FlightId});
        }

    }
}