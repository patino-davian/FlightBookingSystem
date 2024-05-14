using FlightBookingSystem.Domain.Entities;
using System;

namespace FlightBookingSystem.Data
{
    public class Entities
    {
        public IList<Passenger> Passengers = new List<Passenger>();
        public List<Flight> Flights = new List<Flight>();
    }
}
