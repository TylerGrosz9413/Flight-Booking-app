using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flights.DTOs;
using Flights.ReadModels;

namespace Flights.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        static private IList<NewPassengerDTO> Passengers = new List<NewPassengerDTO>();

        [HttpPost]
        [ProducesResponseType(201)] // status code for created
        [ProducesResponseType(400)] // bad request
        [ProducesResponseType(500)] // server failure
        public IActionResult Register(NewPassengerDTO dto)
        {
            Passengers.Add(dto);
            System.Diagnostics.Debug.WriteLine(Passengers.Count);
            return CreatedAtAction(nameof(Find), new {email = dto.Email});
        }

        [HttpGet("{email}")]
        public ActionResult<PassengerRm> Find(string email)
        {
            var passenger = Passengers.FirstOrDefault(p => p.Email == email);

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
