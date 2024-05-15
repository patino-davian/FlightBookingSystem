using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightBookingSystem.DataTransferObjs;
using FlightBookingSystem.ReadModels;
using FlightBookingSystem.Domain.Entities;
using FlightBookingSystem.Data;

namespace FlightBookingSystem.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PassengerController : ControllerBase
    {
        private readonly Entities _entities;

        public PassengerController(Entities entities)
        {
           _entities = entities;
        }

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

            _entities.Passengers.Add(passenger);

            _entities.SaveChanges();

            return CreatedAtAction(nameof(Find), new { email = dto.Email });

            
           
        }

        [HttpGet("{email}")]
        public ActionResult<PassengerRm> Find(string email)
        {
            var passenger = _entities.Passengers.FirstOrDefault(passenger => passenger.Email == email);

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
