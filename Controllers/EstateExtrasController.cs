using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiplomenProekt.Data;
using DiplomenProekt.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace DiplomenProekt.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EstateExtrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstateExtrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EstateExtras
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EstateExtras.Include(e => e.Estate);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EstateExtras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstateExtras == null)
            {
                return NotFound();
            }

            var estateExtras = await _context.EstateExtras
                .Include(e => e.Estate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estateExtras == null)
            {
                return NotFound();
            }

            return View(estateExtras);
        }

        // GET: EstateExtras/Create
        public IActionResult Create()
        {
            ViewData["EstateId"] = new SelectList(_context.Estates, "Id", "Id");
            return View();
        }

        // POST: EstateExtras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HasElectricity,HasWater,HasGas,East,West,South,Elevator,North,Rent,EstateId,IsDeleted")] EstateExtras estateExtras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estateExtras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstateId"] = new SelectList(_context.Estates, "Id", "Id", estateExtras.EstateId);
            return View(estateExtras);
        }

        // GET: EstateExtras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstateExtras == null)
            {
                return NotFound();
            }

            var estateExtras = await _context.EstateExtras.FindAsync(id);
            if (estateExtras == null)
            {
                return NotFound();
            }
            ViewData["EstateId"] = new SelectList(_context.Estates, "Id", "Id", estateExtras.EstateId);
            return View(estateExtras);
        }

        // POST: EstateExtras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HasElectricity,HasWater,HasGas,East,West,South,Elevator,North,Rent,EstateId,IsDeleted")] EstateExtras estateExtras)
        {
            if (id != estateExtras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estateExtras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstateExtrasExists(estateExtras.Id))
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
            ViewData["EstateId"] = new SelectList(_context.Estates, "Id", "Id", estateExtras.EstateId);
            return View(estateExtras);
        }

        // GET: EstateExtras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstateExtras == null)
            {
                return NotFound();
            }

            var estateExtras = await _context.EstateExtras
                .Include(e => e.Estate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estateExtras == null)
            {
                return NotFound();
            }

            return View(estateExtras);
        }

        // POST: EstateExtras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstateExtras == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EstateExtras'  is null.");
            }
            var estateExtras = await _context.EstateExtras.FindAsync(id);
            if (estateExtras != null)
            {
                _context.EstateExtras.Remove(estateExtras);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstateExtrasExists(int id)
        {
          return _context.EstateExtras.Any(e => e.Id == id);
        }
    }
}
