using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EncuestasApp.Models;

namespace EncuestasApp.Controllers
{
    public class RespuestasController : Controller
    {
        private readonly EncuestasDbContext _context;

        public RespuestasController(EncuestasDbContext context)
        {
            _context = context;
        }

        // GET: Respuestas
        public async Task<IActionResult> Index()
        {
            var encuestasDbContext = _context.Respuestas.Include(r => r.Opcion).Include(r => r.Pregunta).Include(r => r.Usuario);
            return View(await encuestasDbContext.ToListAsync());
        }

        // GET: Respuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas
                .Include(r => r.Opcion)
                .Include(r => r.Pregunta)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.RespuestaId == id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return View(respuesta);
        }

        // GET: Respuestas/Create
        public IActionResult Create()
        {
            ViewData["OpcionId"] = new SelectList(_context.OpcionesRespuesta, "OpcionId", "OpcionId");
            ViewData["PreguntaId"] = new SelectList(_context.Preguntas, "PreguntaId", "PreguntaId");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: Respuestas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RespuestaId,UsuarioId,PreguntaId,OpcionId,TextoLibre,FechaRespuesta")] Respuesta respuesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OpcionId"] = new SelectList(_context.OpcionesRespuesta, "OpcionId", "OpcionId", respuesta.OpcionId);
            ViewData["PreguntaId"] = new SelectList(_context.Preguntas, "PreguntaId", "PreguntaId", respuesta.PreguntaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", respuesta.UsuarioId);
            return View(respuesta);
        }

        // GET: Respuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas.FindAsync(id);
            if (respuesta == null)
            {
                return NotFound();
            }
            ViewData["OpcionId"] = new SelectList(_context.OpcionesRespuesta, "OpcionId", "OpcionId", respuesta.OpcionId);
            ViewData["PreguntaId"] = new SelectList(_context.Preguntas, "PreguntaId", "PreguntaId", respuesta.PreguntaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", respuesta.UsuarioId);
            return View(respuesta);
        }

        // POST: Respuestas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RespuestaId,UsuarioId,PreguntaId,OpcionId,TextoLibre,FechaRespuesta")] Respuesta respuesta)
        {
            if (id != respuesta.RespuestaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespuestaExists(respuesta.RespuestaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OpcionId"] = new SelectList(_context.OpcionesRespuesta, "OpcionId", "OpcionId", respuesta.OpcionId);
            ViewData["PreguntaId"] = new SelectList(_context.Preguntas, "PreguntaId", "PreguntaId", respuesta.PreguntaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", respuesta.UsuarioId);
            return View(respuesta);
        }

        // GET: Respuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas
                .Include(r => r.Opcion)
                .Include(r => r.Pregunta)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.RespuestaId == id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return View(respuesta);
        }

        // POST: Respuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respuesta = await _context.Respuestas.FindAsync(id);
            if (respuesta != null)
            {
                _context.Respuestas.Remove(respuesta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespuestaExists(int id)
        {
            return _context.Respuestas.Any(e => e.RespuestaId == id);
        }
    }
}
