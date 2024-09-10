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
    public class TaxiController : Controller
    {
        private readonly TaximeterDbContext _context;

        public TaxiController(TaximeterDbContext context)
        {
            _context = context;
        }

        // GET: Taxi
        public async Task<IActionResult> Index()
        {
            var taximeterDbContext = _context.Taxis.Include(t => t.Conductor);
            return View(await taximeterDbContext.ToListAsync());
        }

        // GET: Taxi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxi = await _context.Taxis
                .Include(t => t.Conductor)
                .FirstOrDefaultAsync(m => m.TaxiId == id);
            if (taxi == null)
            {
                return NotFound();
            }

            return View(taxi);
        }

        // GET: Taxi/Create
        public IActionResult Create()
        {
            ViewData["ConductorId"] = new SelectList(_context.Conductores, "ConductorId", "Apellido");
            return View();
        }

        // POST: Taxi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaxiId,ConductorId,Placa,Marca,Model,Anho")] Taxi taxi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConductorId"] = new SelectList(_context.Conductores, "ConductorId", "Apellido", taxi.ConductorId);
            return View(taxi);
        }

        // GET: Taxi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxi = await _context.Taxis.FindAsync(id);
            if (taxi == null)
            {
                return NotFound();
            }
            ViewData["ConductorId"] = new SelectList(_context.Conductores, "ConductorId", "Apellido", taxi.ConductorId);
            return View(taxi);
        }

        // POST: Taxi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaxiId,ConductorId,Placa,Marca,Model,Anho")] Taxi taxi)
        {
            if (id != taxi.TaxiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxiExists(taxi.TaxiId))
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
            ViewData["ConductorId"] = new SelectList(_context.Conductores, "ConductorId", "Apellido", taxi.ConductorId);
            return View(taxi);
        }

        // GET: Taxi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxi = await _context.Taxis
                .Include(t => t.Conductor)
                .FirstOrDefaultAsync(m => m.TaxiId == id);
            if (taxi == null)
            {
                return NotFound();
            }

            return View(taxi);
        }

        // POST: Taxi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxi = await _context.Taxis.FindAsync(id);
            if (taxi != null)
            {
                _context.Taxis.Remove(taxi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxiExists(int id)
        {
            return _context.Taxis.Any(e => e.TaxiId == id);
        }
    }
}
