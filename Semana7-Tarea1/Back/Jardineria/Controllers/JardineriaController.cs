using Jardineria.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jardineria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JardineriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JardineriaController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jardineria.Models.Jardineria>>> Get() =>
            await _context.Jardinerias.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Jardineria.Models.Jardineria>> Post(Jardineria.Models.Jardineria item)
        {
            _context.Jardinerias.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }
    }
}
