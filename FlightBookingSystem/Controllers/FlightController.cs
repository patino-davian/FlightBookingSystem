using FlightBookingSystem.ReadModels;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {

        private readonly ILogger<FlightController> _logger;

        public FlightController(ILogger<FlightController> logger)
        {
            _logger = logger;
        }

        Random random = new Random();

        [HttpGet]
        public IEnumerable<FlightRm> Search() => new FlightRm[]
        {
            new (
                Guid.NewGuid(), 
                "American Airlines", 
                random.Next(90, 5000).ToString(), 
                new TimePlaceRm("Los Angeles", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlaceRm("San Antonio", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 10)),
            new (
                Guid.NewGuid(),
                "Delta Airlines",
                random.Next(90, 5000).ToString(),
                new TimePlaceRm("Chicago", DateTime.Now.AddHours(random.Next(1,10))),
                new TimePlaceRm("Dallas", DateTime.Now.AddHours(random.Next(4,15))),
                random.Next(1, 10)),

            new (
                Guid.NewGuid(),
                "United Airlines",
                random.Next(90, 5000).ToString(),
                new TimePlaceRm("New York", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlaceRm("Miami", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 10)),
            new (
                Guid.NewGuid(),
                "Southwest Airlines",
                random.Next(90, 5000).ToString(),
                new TimePlaceRm("Houston", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlaceRm("Denver", DateTime.Now.AddHours(random.Next(4,15))),
                random.Next(1, 10)),

            new (
                Guid.NewGuid(),
                "JetBlue Airways",
                random.Next(90, 5000).ToString(),
                new TimePlaceRm("Orlando", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlaceRm("Seattle", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 10)),

            new (
                Guid.NewGuid(),
                "Alaska Airlines",
                random.Next(90, 5000).ToString(),
                new TimePlaceRm("Portland", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlaceRm("Las Vegas", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 10)),

            new (
                Guid.NewGuid(),
                "Spirit Airlines",
                random.Next(90, 5000).ToString(),
                new TimePlaceRm("Atlanta", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlaceRm("Boston", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 10)),

            new (
                Guid.NewGuid(),
                "Frontier Airlines",
                random.Next(90, 5000).ToString(),
                new TimePlaceRm("Phoenix", DateTime.Now.AddHours(random.Next(1,3))),
                new TimePlaceRm("Detroit", DateTime.Now.AddHours(random.Next(4,10))),
                random.Next(1, 10))

        };
    }
}