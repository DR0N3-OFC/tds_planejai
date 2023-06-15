using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanejaiBack.Data;
using PlanejaiBack.Models;

namespace PlanejaiBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("/Users/")]
        public IActionResult Get([FromServices] AppDbContext context)
        {
            return Ok(context.Users!.OrderBy(u => u.Name).ToList());
        }

        [HttpGet("/Users/{id:int}")]
        public IActionResult GetByID([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var user = context.Users!.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("/Users/{email}/{password}")]
        public IActionResult GetByEmailAndPassword([FromRoute] string email, string password, [FromServices] AppDbContext context)
        {
            var user = context.Users!.FirstOrDefault(u => (u.Email == email) && (u.Password == password));

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("/Users/")]
        public IActionResult Post([FromBody] UserModel user, [FromServices] AppDbContext context)
        {
            var existingUser = context.Users!.SingleOrDefault(u => u.Id == user.Id);

            if (existingUser == null)
            {
                context.Users!.Add(user);
                context.SaveChanges();

                return Created($"/{user.Id}", user);
            }

            return BadRequest("O usuário já existe!");
        }

        [HttpPut("/Users/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] UserModel user, [FromServices] AppDbContext context)
        {
            var existingUser = context.Users!.FirstOrDefault(u => u.Id == id);

            if (existingUser != null)
            {
                existingUser.Password = user.Password;

                context.Users!.Update(existingUser);
                context.SaveChanges();

                return Ok(existingUser);
            }

            return NotFound();
        }
    }
}
