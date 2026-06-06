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
    public class EncuestasController : Controller
    {
        private readonly EncuestasDbContext _context;

        public EncuestasController(EncuestasDbContext context)
        {
            _context = context;
        }

        // GET: Encuestas
        public async Task<IActionResult> Index()
        {
            var encuestasDbContext = _context.Encuestas.Include(e => e.Usuario);
            return View(await encuestasDbContext.ToListAsync());
        }

        // GET: Encuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuestas
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(m => m.EncuestaId == id);
            if (encuesta == null)
            {
                return NotFound();
            }

            return View(encuesta);
        }

        // GET: Encuestas/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: Encuestas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EncuestaId,Titulo,Descripcion,FechaCreacion,UsuarioId,Estado")] Encuesta encuesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", encuesta.UsuarioId);
            return View(encuesta);
        }

        // GET: Encuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuestas.FindAsync(id);
            if (encuesta == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", encuesta.UsuarioId);
            return View(encuesta);
        }

        // POST: Encuestas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EncuestaId,Titulo,Descripcion,FechaCreacion,UsuarioId,Estado")] Encuesta encuesta)
        {
            if (id != encuesta.EncuestaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncuestaExists(encuesta.EncuestaId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", encuesta.UsuarioId);
            return View(encuesta);
        }

        // GET: Encuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuestas
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(m => m.EncuestaId == id);
            if (encuesta == null)
            {
                return NotFound();
            }

            return View(encuesta);
        }

        // POST: Encuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encuesta = await _context.Encuestas.FindAsync(id);
            if (encuesta != null)
            {
                _context.Encuestas.Remove(encuesta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncuestaExists(int id)
        {
            return _context.Encuestas.Any(e => e.EncuestaId == id);
        }
    }
}
