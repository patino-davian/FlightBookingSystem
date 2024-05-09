﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightBookingSystem.DataTransferObjs;
using FlightBookingSystem.ReadModels;

namespace FlightBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassengerController : ControllerBase
    {
        static private IList<NewPassengerDto> Passengers = new List<NewPassengerDto>();

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Register(NewPassengerDto dto)
        {
            Passengers.Add(dto);
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