
using Evaluacion_Parcial_1.Data;
using Evaluacion_Parcial_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class LibroController : Controller
{
    private readonly BibliotecaContext _context;

    public LibroController(BibliotecaContext context)
    {
        _context = context;
    }

    // GET: LIBROS
    public async Task<IActionResult> Index()    
    {
        var libros = _context.Libros
       .Include(l => l.Autor); // carga el autor relacionado
        return View(await libros.ToListAsync());
    }

    // GET: LIBROS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var libro = await _context.Libros
            .Include(l => l.Autor)
            .FirstOrDefaultAsync(m => m.LibroId == id);
        if (libro == null)
        {
            return NotFound();
        }

        return View(libro);
    }

    // GET: LIBROS/Create
    public IActionResult Create()
    {
        ViewBag.Autores = _context.Autores
            .Select(a => new { a.AutorId, NombreCompleto = a.Nombre + " " + a.Apellido })
            .ToList();

        ViewBag.Autores = new SelectList(ViewBag.Autores, "AutorId", "NombreCompleto");
        return View();
    }

    // POST: LIBROS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("LibroId,Titulo,Genero,FechaPublicacion,ISBN,AutorId,Autor")] Libro libro)
    {
        if (ModelState.IsValid)
        {
            _context.Add(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(libro);
    }

    // GET: LIBROS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var libro = await _context.Libros.FindAsync(id);
        if (libro == null)
        {
            return NotFound();
        }
        var autores = _context.Autores
        .Select(a => new { a.AutorId, NombreCompleto = a.Nombre + " " + a.Apellido })
        .ToList();

        ViewBag.Autores = new SelectList(autores, "AutorId", "NombreCompleto", libro.AutorId);
        return View(libro);
    }

    // POST: LIBROS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("LibroId,Titulo,Genero,FechaPublicacion,ISBN,AutorId,Autor")] Libro libro)
    {
        if (id != libro.LibroId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(libro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(libro.LibroId))
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
        return View(libro);
    }

    // GET: LIBROS/Delete/5
    public async Task<IActionResult> Delete(int? libroid)
    {
        if (libroid == null)
        {
            return NotFound();
        }

        var libro = await _context.Libros
            .FirstOrDefaultAsync(m => m.LibroId == libroid);
        if (libro == null)
        {
            return NotFound();
        }

        return View(libro);
    }

    // POST: LIBROS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var libro = await _context.Libros.FindAsync(id);
        if (libro != null)
        {
            _context.Libros.Remove(libro);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LibroExists(int? id)
    {
        return _context.Libros.Any(e => e.LibroId == id);
    }
}
