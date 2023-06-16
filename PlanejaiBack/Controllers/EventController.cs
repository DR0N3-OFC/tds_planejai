using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanejaiBack.Data;
using PlanejaiBack.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PlanejaiBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        [Route("/Events/")]
        public IActionResult Get([FromServices] AppDbContext context)
        {
            return Ok(context.Events!.OrderBy(e => e.StartDate).ToList());
        }

        [HttpGet("/Events/{id:int}")]
        public IActionResult GetByID([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var eventModel = context.Events!.SingleOrDefault(e => e.EventId == id);

            if (eventModel == null)
            {
                return NotFound();
            }

            return Ok(eventModel);
        }

        [HttpGet("/EventsByUser/{id:int}")]
        public IActionResult GetByUSer([FromRoute] int id, [FromServices] AppDbContext context)
        {
            return Ok(context.Events!.Where(e => e.Organizer!.UserId == id).OrderBy(e => e.StartDate).ToList());
        }

        [HttpPost("/Events/")]
        public IActionResult Post([FromBody] EventModel eventModel, [FromServices] AppDbContext context)
        {
            var user = context.Users!.Include(u => u.Events).FirstOrDefault(u => u.UserId == eventModel.OrganizerId);
            var existingEvent = context.Events!.SingleOrDefault(e => e.Name == eventModel.Name);

            if (existingEvent == null)
            {
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                };

                var jsonEvent = JsonSerializer.Serialize(eventModel, options);
                var deserializedEvent = JsonSerializer.Deserialize<EventModel>(jsonEvent, options);

                context.Events!.Add(deserializedEvent!);
                context.SaveChanges();

                return Created($"/{eventModel.EventId}", eventModel);
            }

            return BadRequest("O evento já foi criado!");
        }

        [HttpPut("/Events/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] EventModel eventModel, [FromServices] AppDbContext context)
        {
            var existingEvent = context.Events!.FirstOrDefault(e => e.EventId == id);

            if (existingEvent != null)
            {
                existingEvent.Name = eventModel.Name;
                existingEvent.Description = eventModel.Description;
                existingEvent.StartDate = eventModel.StartDate;
                existingEvent.StartsAt = eventModel.StartsAt;
                existingEvent.EndDate = eventModel.EndDate;
                existingEvent.EndsAt = eventModel.EndsAt;
                existingEvent.Local = eventModel.Local;

                context.Events!.Update(existingEvent);
                context.SaveChanges();

                return Ok(existingEvent);
            }

            return NotFound();
        }
    }
}
