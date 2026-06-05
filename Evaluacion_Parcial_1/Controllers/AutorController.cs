
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Evaluacion_Parcial_1.Models;
using Evaluacion_Parcial_1.Data;

public class AutorController : Controller
{
    private readonly BibliotecaContext _context;

    public AutorController(BibliotecaContext context)
    {
        _context = context;
    }

    // GET: AUTORS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Autores.ToListAsync());
    }

    // GET: AUTORS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var autor = await _context.Autores
            .Include(a=>a.Libros)
            .FirstOrDefaultAsync(m => m.AutorId == id);
        if (autor == null)
        {
            return NotFound();
        }

        return View(autor);
    }

    // GET: AUTORS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: AUTORS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("AutorId,Nombre,Apellido,FechaNacimiento,Nacionalidad")] Autor autor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(autor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(autor);
    }

    // GET: AUTORS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var autor = await _context.Autores.FindAsync(id);
        if (autor == null)
        {
            return NotFound();
        }
        return View(autor);
    }

    // POST: AUTORS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, Autor autor)
    {
        if (id != autor.AutorId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(autor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(autor.AutorId))
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
        return View(autor);
    }

    // GET: AUTORS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var autor = await _context.Autores
            .FirstOrDefaultAsync(m => m.AutorId == id);
        if (autor == null)
        {
            return NotFound();
        }

        return View(autor);
    }

    // POST: AUTORS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var autor = await _context.Autores.FindAsync(id);
        if (autor != null)
        {
            _context.Autores.Remove(autor);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AutorExists(int? id)
    {
        return _context.Autores.Any(e => e.AutorId == id);
    }
}
