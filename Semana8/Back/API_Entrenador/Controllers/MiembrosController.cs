namespace API_Entrenador.Controllers
{
    using API_Entrenador.Data;
    using API_Entrenador.Models;
    // Controllers/MiembrosController.cs
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    // Controllers/MiembrosController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class MiembrosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MiembrosController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiembroDto>>> Get()
        {
            var miembros = await _context.Miembros
                .Select(m => new MiembroDto
                {
                    MiembroId = m.MiembroId,
                    Nombre = m.Nombre,
                    Apellido = m.Apellido
                })
                .ToListAsync();

            return miembros;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MiembroDto>> Get(int id)
        {
            var miembro = await _context.Miembros
                .Where(m => m.MiembroId == id)
                .Select(m => new MiembroDto
                {
                    MiembroId = m.MiembroId,
                    Nombre = m.Nombre,
                    Apellido = m.Apellido
                })
                .FirstOrDefaultAsync();

            if (miembro == null) return NotFound();
            return miembro;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Miembro miembro)
        {
            _context.Miembros.Add(miembro);
            await _context.SaveChangesAsync();
            return Ok(miembro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Miembro miembro)
        {
            if (id != miembro.MiembroId) return BadRequest();
            _context.Entry(miembro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _context.Miembros.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Miembros.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
