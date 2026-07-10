
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen_Final.Models;
using Examen_Final.Data;

public class HabitacionController : Controller
{
    private readonly HotelDbContext _context;

    public HabitacionController(HotelDbContext context)
    {
        _context = context;
    }

    // GET: HABITACIONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Habitaciones.ToListAsync());
    }

    // GET: HABITACIONS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var habitacion = await _context.Habitaciones
            .FirstOrDefaultAsync(m => m.HabitacionId == id);
        if (habitacion == null)
        {
            return NotFound();
        }

        return View(habitacion);
    }

    // GET: HABITACIONS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: HABITACIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Habitacion habitacion)
    {
        if (ModelState.IsValid)
        {
            _context.Add(habitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(habitacion);
    }

    // GET: HABITACIONS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var habitacion = await _context.Habitaciones.FindAsync(id);
        if (habitacion == null)
        {
            return NotFound();
        }
        return View(habitacion);
    }

    // POST: HABITACIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("HabitacionId,Numero,Tipo,PrecioNoche,Estado,Reservas")] Habitacion habitacion)
    {
        if (id != habitacion.HabitacionId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(habitacion);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitacionExists(habitacion.HabitacionId))
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
        return View(habitacion);
    }

    // GET: HABITACIONS/Delete/5
    public async Task<IActionResult> Delete(int? habitacionid)
    {
        if (habitacionid == null)
        {
            return NotFound();
        }

        var habitacion = await _context.Habitaciones
            .FirstOrDefaultAsync(m => m.HabitacionId == habitacionid);
        if (habitacion == null)
        {
            return NotFound();
        }

        return View(habitacion);
    }

    // POST: HABITACIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var habitacion = await _context.Habitaciones.FindAsync(id);
        if (habitacion != null)
        {
            _context.Habitaciones.Remove(habitacion);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool HabitacionExists(int? habitacionid)
    {
        return _context.Habitaciones.Any(e => e.HabitacionId == habitacionid);
    }
}
