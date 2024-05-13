using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightBookingSystem.DataTransferObjs;
using FlightBookingSystem.ReadModels;
using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassengerController : ControllerBase
    {
        static private IList<Passenger> Passengers = new List<Passenger>();

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Register(NewPassengerDto dto)
        {
            var passenger = new Passenger(
                dto.Email,
                dto.FirstName,
                dto.LastName,
                dto.Gender
                );

            Passengers.Add(passenger);
            System.Diagnostics.Debug.WriteLine(Passengers.Count); 
            return CreatedAtAction(nameof(Find), new { email = dto.Email });
        }

        [HttpGet("{email}")]
        public ActionResult<PassengerRm> Find(string email)
        {
            var passenger = Passengers.FirstOrDefault(passenger => passenger.Email == email);

            if(passenger == null)
            {
                return NotFound();
            }

            var passengerReadModel = new PassengerRm(
                passenger.Email,
                passenger.FirstName,
                passenger.LastName,
                passenger.Gender
                );

            return Ok(passengerReadModel);
        }
    }
}
