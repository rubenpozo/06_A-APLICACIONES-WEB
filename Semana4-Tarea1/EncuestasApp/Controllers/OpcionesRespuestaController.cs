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
    public class OpcionesRespuestaController : Controller
    {
        private readonly EncuestasDbContext _context;

        public OpcionesRespuestaController(EncuestasDbContext context)
        {
            _context = context;
        }

        // GET: OpcionesRespuesta
        public async Task<IActionResult> Index()
        {
            var encuestasDbContext = _context.OpcionesRespuesta.Include(o => o.Pregunta);
            return View(await encuestasDbContext.ToListAsync());
        }

        // GET: OpcionesRespuesta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opcionesRespuestum = await _context.OpcionesRespuesta
                .Include(o => o.Pregunta)
                .FirstOrDefaultAsync(m => m.OpcionId == id);
            if (opcionesRespuestum == null)
            {
                return NotFound();
            }

            return View(opcionesRespuestum);
        }

        // GET: OpcionesRespuesta/Create
        public IActionResult Create()
        {
            ViewData["PreguntaId"] = new SelectList(_context.Preguntas, "PreguntaId", "PreguntaId");
            return View();
        }

        // POST: OpcionesRespuesta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OpcionId,Texto,PreguntaId,Valor,Activa")] OpcionesRespuestum opcionesRespuestum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opcionesRespuestum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PreguntaId"] = new SelectList(_context.Preguntas, "PreguntaId", "PreguntaId", opcionesRespuestum.PreguntaId);
            return View(opcionesRespuestum);
        }

        // GET: OpcionesRespuesta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opcionesRespuestum = await _context.OpcionesRespuesta.FindAsync(id);
            if (opcionesRespuestum == null)
            {
                return NotFound();
            }
            ViewData["PreguntaId"] = new SelectList(_context.Preguntas, "PreguntaId", "PreguntaId", opcionesRespuestum.PreguntaId);
            return View(opcionesRespuestum);
        }

        // POST: OpcionesRespuesta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OpcionId,Texto,PreguntaId,Valor,Activa")] OpcionesRespuestum opcionesRespuestum)
        {
            if (id != opcionesRespuestum.OpcionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opcionesRespuestum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpcionesRespuestumExists(opcionesRespuestum.OpcionId))
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
            ViewData["PreguntaId"] = new SelectList(_context.Preguntas, "PreguntaId", "PreguntaId", opcionesRespuestum.PreguntaId);
            return View(opcionesRespuestum);
        }

        // GET: OpcionesRespuesta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opcionesRespuestum = await _context.OpcionesRespuesta
                .Include(o => o.Pregunta)
                .FirstOrDefaultAsync(m => m.OpcionId == id);
            if (opcionesRespuestum == null)
            {
                return NotFound();
            }

            return View(opcionesRespuestum);
        }

        // POST: OpcionesRespuesta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opcionesRespuestum = await _context.OpcionesRespuesta.FindAsync(id);
            if (opcionesRespuestum != null)
            {
                _context.OpcionesRespuesta.Remove(opcionesRespuestum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpcionesRespuestumExists(int id)
        {
            return _context.OpcionesRespuesta.Any(e => e.OpcionId == id);
        }
    }
}
