using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using taximeter.Data;
using taximeter.Entity;

namespace taximeter.Controllers
{
    public class TrayectoController : Controller
    {
        private readonly TaximeterDbContext _context;

        public TrayectoController(TaximeterDbContext context)
        {
            _context = context;
        }

        // GET: Trayecto
        public async Task<IActionResult> Index()
        {
            var taximeterDbContext = _context.Trayectos.Include(t => t.Taxi);
            return View(await taximeterDbContext.ToListAsync());
        }

        // GET: Trayecto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trayecto = await _context.Trayectos
                .Include(t => t.Taxi)
                .FirstOrDefaultAsync(m => m.TrayectoId == id);
            if (trayecto == null)
            {
                return NotFound();
            }

            return View(trayecto);
        }

        // GET: Trayecto/Create
        public IActionResult Create()
        {
            ViewData["TaxiId"] = new SelectList(_context.Taxis, "TaxiId", "Marca");
            return View();
        }

        // POST: Trayecto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrayectoId,Ubicacion_Inicial,Ubicacion_Final,Kilometraje,TaxiId")] Trayecto trayecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trayecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaxiId"] = new SelectList(_context.Taxis, "TaxiId", "Marca", trayecto.TaxiId);
            return View(trayecto);
        }

        // GET: Trayecto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trayecto = await _context.Trayectos.FindAsync(id);
            if (trayecto == null)
            {
                return NotFound();
            }
            ViewData["TaxiId"] = new SelectList(_context.Taxis, "TaxiId", "Marca", trayecto.TaxiId);
            return View(trayecto);
        }

        // POST: Trayecto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrayectoId,Ubicacion_Inicial,Ubicacion_Final,Kilometraje,TaxiId")] Trayecto trayecto)
        {
            if (id != trayecto.TrayectoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trayecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrayectoExists(trayecto.TrayectoId))
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
            ViewData["TaxiId"] = new SelectList(_context.Taxis, "TaxiId", "Marca", trayecto.TaxiId);
            return View(trayecto);
        }

        // GET: Trayecto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trayecto = await _context.Trayectos
                .Include(t => t.Taxi)
                .FirstOrDefaultAsync(m => m.TrayectoId == id);
            if (trayecto == null)
            {
                return NotFound();
            }

            return View(trayecto);
        }

        // POST: Trayecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trayecto = await _context.Trayectos.FindAsync(id);
            if (trayecto != null)
            {
                _context.Trayectos.Remove(trayecto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrayectoExists(int id)
        {
            return _context.Trayectos.Any(e => e.TrayectoId == id);
        }
    }
}
