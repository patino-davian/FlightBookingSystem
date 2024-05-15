using FlightBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FlightBookingSystem.Data
{
    public class Entities : DbContext
    {
        public Entities(DbContextOptions<Entities> options) : base(options) 
        {
        }

        public DbSet<Passenger> Passengers => Set<Passenger>();

        public DbSet<Flight> Flights => Set<Flight>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>().HasKey(passenger => passenger.Email);

            modelBuilder.Entity<Flight>().Property(property => property.RemainingNumberOfSeats).IsConcurrencyToken();

            modelBuilder.Entity<Flight>().OwnsOne(flight => flight.Departure);
            modelBuilder.Entity<Flight>().OwnsOne(flight => flight.Arrival);
        }
    }
}
