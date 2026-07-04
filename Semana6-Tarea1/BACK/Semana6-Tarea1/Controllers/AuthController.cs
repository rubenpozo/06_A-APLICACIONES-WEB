using Microsoft.AspNetCore.Mvc;
using Semana6_Tarea1.Data;
using Semana6_Tarea1.Models;
namespace Semana6_Tarea1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Usuarios
            .FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);
            // Validación simple (ejemplo)
            if (user != null)
            {
                return Ok(new { token = "fake-jwt-token", user = request.Username });
            }

            return Unauthorized(new { message = "Credenciales inválidas" });
        }
    }
}
