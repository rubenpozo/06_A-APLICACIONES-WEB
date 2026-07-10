
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen_Final.Models;
using Examen_Final.Data;

public class ReservaController : Controller
{
    private readonly HotelDbContext _context;

    public ReservaController(HotelDbContext context)
    {
        _context = context;
    }

    // GET: RESERVAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Reservas.ToListAsync());
    }

    // GET: RESERVAS/Details/5
    public async Task<IActionResult> Details(int? reservaid)
    {
        if (reservaid == null)
        {
            return NotFound();
        }

        var reserva = await _context.Reservas
            .FirstOrDefaultAsync(m => m.ReservaId == reservaid);
        if (reserva == null)
        {
            return NotFound();
        }

        return View(reserva);
    }

    // GET: RESERVAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RESERVAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ReservaId,ClienteId,HabitacionId,FechaInicio,FechaFin,Cliente,Habitacion,Pagos")] Reserva reserva)
    {
        if (ModelState.IsValid)
        {
            _context.Add(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(reserva);
    }

    // GET: RESERVAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }
        return View(reserva);
    }

    // POST: RESERVAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, Reserva reserva)
    {
        if (id != reserva.ReservaId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(reserva);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(reserva.ReservaId))
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
        return View(reserva);
    }

    // GET: RESERVAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var reserva = await _context.Reservas
            .FirstOrDefaultAsync(m => m.ReservaId == id);
        if (reserva == null)
        {
            return NotFound();
        }

        return View(reserva);
    }

    // POST: RESERVAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva != null)
        {
            _context.Reservas.Remove(reserva);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ReservaExists(int? id)
    {
        return _context.Reservas.Any(e => e.ReservaId == id);
    }
}
