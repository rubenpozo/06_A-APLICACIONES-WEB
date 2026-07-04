using EvaluacionParcial2.Data;
using EvaluacionParcial2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaluacionParcial2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SesionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sesiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SesionDTO>>> GetSesiones()
        {
            var sesiones = await _context.Sesiones
                .Include(s => s.Miembro)
                .Include(s => s.Entrenador)
                .Select(s => new SesionDTO
                {
                    SesionId = s.SesionId,
                    FechaSesion = s.FechaSesion,
                    Duracion = s.Duracion,
                    TipoSesion = s.TipoSesion,
                    MiembroNombre = s.Miembro.Nombre + " " + s.Miembro.Apellido,
                    EntrenadorNombre = s.Entrenador.Nombre
                })
                .ToListAsync();

            return sesiones;
        }

        // GET: api/Sesiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SesionDTO>> GetSesion(int id)
        {
            var sesion = await _context.Sesiones
                .Include(s => s.Miembro)
                .Include(s => s.Entrenador)
                .Where(s => s.SesionId == id)
                .Select(s => new SesionDTO
                {
                    SesionId = s.SesionId,
                    FechaSesion = s.FechaSesion,
                    Duracion = s.Duracion,
                    TipoSesion = s.TipoSesion,
                    MiembroNombre = s.Miembro.Nombre + " " + s.Miembro.Apellido,
                    EntrenadorNombre = s.Entrenador.Nombre
                })
                .FirstOrDefaultAsync();

            if (sesion == null)
            {
                return NotFound();
            }

            return sesion;
        }

        // POST: api/Sesiones
        [HttpPost]
        public async Task<ActionResult<SesionEntrenamiento>> PostSesion(SesionEntrenamiento sesion)
        {
            _context.Sesiones.Add(sesion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSesion), new { id = sesion.SesionId }, sesion);
        }

        // PUT: api/Sesiones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSesion(int id, SesionEntrenamiento sesion)
        {
            if (id != sesion.SesionId)
            {
                return BadRequest();
            }

            _context.Entry(sesion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SesionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Sesiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSesion(int id)
        {
            var sesion = await _context.Sesiones.FindAsync(id);
            if (sesion == null)
            {
                return NotFound();
            }

            _context.Sesiones.Remove(sesion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SesionExists(int id)
        {
            return _context.Sesiones.Any(e => e.SesionId == id);
        }
    }
}
