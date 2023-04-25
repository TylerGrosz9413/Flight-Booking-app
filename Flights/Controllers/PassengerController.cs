using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flights.DTOs;
using Flights.ReadModels;
using Flights.Domain.Entities;
using Microsoft.JSInterop.Infrastructure;
using Flights.Data;

namespace Flights.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly Entities _entities;

        public PassengerController(Entities entities)
        {
            _entities = entities;
        }

        [HttpPost]
        [ProducesResponseType(201)] // status code for created
        [ProducesResponseType(400)] // bad request
        [ProducesResponseType(500)] // server failure
        public IActionResult Register(NewPassengerDTO dto)
        {
            _entities.Passengers.Add(new Passenger(
                dto.Email,
                dto.FirstName,
                dto.LastName,
                dto.Gender
                ));

            _entities.SaveChanges();
            
            return CreatedAtAction(nameof(Find), new {email = dto.Email});
        }

        [HttpGet("{email}")]
        public ActionResult<PassengerRm> Find(string email)
        {
            var passenger = _entities.Passengers.FirstOrDefault(p => p.Email == email);

            if (passenger == null)
                return NotFound();

            var rm = new PassengerRm(
                passenger.Email,
                passenger.FirstName,
                passenger.LastName,
                passenger.Gender
                );

            return Ok(rm);
        }
    }
}
