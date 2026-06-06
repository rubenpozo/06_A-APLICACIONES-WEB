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
    public class PreguntasController : Controller
    {
        private readonly EncuestasDbContext _context;

        public PreguntasController(EncuestasDbContext context)
        {
            _context = context;
        }

        // GET: Preguntas
        public async Task<IActionResult> Index()
        {
            var encuestasDbContext = _context.Preguntas.Include(p => p.Encuesta);
            return View(await encuestasDbContext.ToListAsync());
        }

        // GET: Preguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Preguntas
                .Include(p => p.Encuesta)
                .FirstOrDefaultAsync(m => m.PreguntaId == id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return View(pregunta);
        }

        // GET: Preguntas/Create
        public IActionResult Create()
        {
            ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "EncuestaId");
            return View();
        }

        // POST: Preguntas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PreguntaId,Texto,Tipo,EncuestaId,Orden,Obligatoria")] Pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pregunta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "EncuestaId", pregunta.EncuestaId);
            return View(pregunta);
        }

        // GET: Preguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Preguntas.FindAsync(id);
            if (pregunta == null)
            {
                return NotFound();
            }
            ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "EncuestaId", pregunta.EncuestaId);
            return View(pregunta);
        }

        // POST: Preguntas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PreguntaId,Texto,Tipo,EncuestaId,Orden,Obligatoria")] Pregunta pregunta)
        {
            if (id != pregunta.PreguntaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pregunta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreguntaExists(pregunta.PreguntaId))
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
            ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "EncuestaId", pregunta.EncuestaId);
            return View(pregunta);
        }

        // GET: Preguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Preguntas
                .Include(p => p.Encuesta)
                .FirstOrDefaultAsync(m => m.PreguntaId == id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return View(pregunta);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pregunta = await _context.Preguntas.FindAsync(id);
            if (pregunta != null)
            {
                _context.Preguntas.Remove(pregunta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreguntaExists(int id)
        {
            return _context.Preguntas.Any(e => e.PreguntaId == id);
        }
    }
}
