
using Clase_2.Data;
using Clase_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class CentroRevisionsController : Controller
{
    private readonly ApplicationDbContext _context;

    public CentroRevisionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CENTROREVISIONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.CentrosRevision.ToListAsync());
    }

    // GET: CENTROREVISIONS/Details/5
    public async Task<IActionResult> Details(int? centrorevisionid)
    {
        if (centrorevisionid == null)
        {
            return NotFound();
        }

        var centrorevision = await _context.CentrosRevision
            .FirstOrDefaultAsync(m => m.CentroRevisionId == centrorevisionid);
        if (centrorevision == null)
        {
            return NotFound();
        }

        return View(centrorevision);
    }

    // GET: CENTROREVISIONS/Create
    public IActionResult Create()
    {
        ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "Nombre");
        return View();
    }

    // POST: CENTROREVISIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CentroRevision centrorevision)
    {
        if (ModelState.IsValid)
        {
            _context.Add(centrorevision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "Nombre", centrorevision.ProvinciaId);
        return View(centrorevision);
    }

    // GET: CENTROREVISIONS/Edit/5
    public async Task<IActionResult> Edit(int? centrorevisionid)
    {
        if (centrorevisionid == null)
        {
            return NotFound();
        }

        var centrorevision = await _context.CentrosRevision.FindAsync(centrorevisionid);
        if (centrorevision == null)
        {
            return NotFound();
        }
        return View(centrorevision);
    }

    // POST: CENTROREVISIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? centrorevisionid, [Bind("CentroRevisionId,Nombre,ProvinciaId,Provincia")] CentroRevision centrorevision)
    {
        if (centrorevisionid != centrorevision.CentroRevisionId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(centrorevision);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CentroRevisionExists(centrorevision.CentroRevisionId))
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
        return View(centrorevision);
    }

    // GET: CENTROREVISIONS/Delete/5
    public async Task<IActionResult> Delete(int? centrorevisionid)
    {
        if (centrorevisionid == null)
        {
            return NotFound();
        }

        var centrorevision = await _context.CentrosRevision
            .FirstOrDefaultAsync(m => m.CentroRevisionId == centrorevisionid);
        if (centrorevision == null)
        {
            return NotFound();
        }

        return View(centrorevision);
    }

    // POST: CENTROREVISIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? centrorevisionid)
    {
        var centrorevision = await _context.CentrosRevision.FindAsync(centrorevisionid);
        if (centrorevision != null)
        {
            _context.CentrosRevision.Remove(centrorevision);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CentroRevisionExists(int? centrorevisionid)
    {
        return _context.CentrosRevision.Any(e => e.CentroRevisionId == centrorevisionid);
    }
}
