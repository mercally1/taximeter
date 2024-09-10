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
    public class ConductorController : Controller
    {
        private readonly TaximeterDbContext _context;

        public ConductorController(TaximeterDbContext context)
        {
            _context = context;
        }

        // GET: Conductor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conductores.ToListAsync());
        }

        // GET: Conductor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductores
                .FirstOrDefaultAsync(m => m.ConductorId == id);
            if (conductor == null)
            {
                return NotFound();
            }

            return View(conductor);
        }

        // GET: Conductor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conductor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConductorId,Nombre,Apellido,Licencia,Contacto")] Conductor conductor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conductor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conductor);
        }

        // GET: Conductor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductores.FindAsync(id);
            if (conductor == null)
            {
                return NotFound();
            }
            return View(conductor);
        }

        // POST: Conductor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConductorId,Nombre,Apellido,Licencia,Contacto")] Conductor conductor)
        {
            if (id != conductor.ConductorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conductor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConductorExists(conductor.ConductorId))
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
            return View(conductor);
        }

        // GET: Conductor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductores
                .FirstOrDefaultAsync(m => m.ConductorId == id);
            if (conductor == null)
            {
                return NotFound();
            }

            return View(conductor);
        }

        // POST: Conductor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conductor = await _context.Conductores.FindAsync(id);
            if (conductor != null)
            {
                _context.Conductores.Remove(conductor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConductorExists(int id)
        {
            return _context.Conductores.Any(e => e.ConductorId == id);
        }
    }
}
