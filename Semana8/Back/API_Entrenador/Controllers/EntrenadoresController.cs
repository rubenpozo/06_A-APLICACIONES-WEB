using API_Entrenador.Data;
using API_Entrenador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Entrenador.Controllers
{
    // Controllers/EntrenadoresController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class EntrenadoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EntrenadoresController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntrenadorDto>>> Get()
        {
            var entrenadores = await _context.Entrenadores
                .Include(e => e.Miembros)
                .Select(e => new EntrenadorDto
                {
                    EntrenadorId = e.EntrenadorId,
                    Nombre = e.Nombre,
                    Especialidad = e.Especialidad,
                    Miembros = e.Miembros.Select(m => new MiembroDto
                    {
                        MiembroId = m.MiembroId,
                        Nombre = m.Nombre,
                        Apellido = m.Apellido
                    }).ToList()
                })
                .ToListAsync();

            return entrenadores;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntrenadorDto>> Get(int id)
        {
            var entrenador = await _context.Entrenadores
                .Include(e => e.Miembros)
                .Where(e => e.EntrenadorId == id)
                .Select(e => new EntrenadorDto
                {
                    EntrenadorId = e.EntrenadorId,
                    Nombre = e.Nombre,
                    Especialidad = e.Especialidad,
                    Miembros = e.Miembros.Select(m => new MiembroDto
                    {
                        MiembroId = m.MiembroId,
                        Nombre = m.Nombre,
                        Apellido = m.Apellido
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (entrenador == null) return NotFound();
            return entrenador;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Entrenador entrenador)
        {
            _context.Entrenadores.Add(entrenador);
            await _context.SaveChangesAsync();
            return Ok(entrenador);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Entrenador entrenador)
        {
            if (id != entrenador.EntrenadorId) return BadRequest();
            _context.Entry(entrenador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _context.Entrenadores.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Entrenadores.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
