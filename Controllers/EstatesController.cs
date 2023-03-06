using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiplomenProekt.Data;
using DiplomenProekt.Data.Models;
using DiplomenProekt.DTO;

namespace DiplomenProekt.Controllers
{
    public class EstatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estates1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Estates.Include(e => e.Address);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Estates1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estates == null)
            {
                return NotFound();
            }

            var estate = await _context.Estates
                .Include(e => e.Address)
                .Include(e => e.Extras)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estate == null)
            {
                return NotFound();
            }

            return View(estate);
        }

        // GET: Estates1/Create
        public IActionResult Create()
        {
            ViewData["Neigbhourhoods"] = _context.Addresses.Where(x => !x.IsDeleted).Select(a => new AddressChoiseDTO(a.Id, a.City.ToString(), a.Neighbourhood, a.Description, a.Pics)).ToList();
            return View();
        }

        // POST: Estates1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
          [Bind("Id,MainPic,Price,Rooms,AddressId,Description,Pictures,EstateType,EstateStatus,Area,Floor,MaxFloor,ExtrasId,IsDeleted")] 
        Estate estate)
        {
            ModelState.Remove("Address");
            ModelState.Remove("Extras");
            if (ModelState.IsValid)
            {
                _context.Add(estate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Neigbhourhoods"] = _context.Addresses.Where(x => !x.IsDeleted).Select(a => new AddressChoiseDTO(a.Id, a.City.ToString(), a.Neighbourhood, a.Description, a.Pics)).ToList();
              return View(estate);
        }

        // GET: Estates1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null || _context.Estates == null)
            {
                

                return NotFound();
            }

            var estate = await _context.Estates
                .Include(e => e.Extras)
                .Include(e => e.Address)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (estate == null)
            {
                return NotFound();
            }
            ViewData["Neigbhourhoods"] = _context.Addresses.Where(x => !x.IsDeleted).Select(a => new AddressChoiseDTO(a.Id, a.City.ToString(), a.Neighbourhood, a.Description, a.Pics)).ToList();
            return View(estate);
        }

        // POST: Estates1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
        int id, [Bind("Id,MainPic,Price,Rooms,AddressId,Description,Pictures,EstateType,EstateStatus,Area,Floor,MaxFloor,ExtrasId,IsDeleted")] 
        Estate estate)
        {
            if (id != estate.Id)
            {
                return NotFound();
            }

            //estate.Extras = _context.EstateExtras.FirstOrDefault(x => x.Id == estate.ExtrasId);
            //estate.Address = _context.Addresses.FirstOrDefault(x => x.Id == estate.AddressId);
            ModelState.Remove("Address");
            ModelState.Remove("Extras");
            //ModelState.Remove("Address.Estates");
            //ModelState.Remove("Extras.Estate");


            if (ModelState.IsValid)
            {
                try
                {
            //        _context.Remove(estate);
                //    _context.Remove(estate.Extras);
                     _context.Update(estate);
                     _context.Update(estate.Extras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstateExists(estate.Id))
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
            else
            {
                ViewData["Neigbhourhoods"] = _context.Addresses.Where(x => !x.IsDeleted).Select(a => new AddressChoiseDTO(a.Id, a.City.ToString(), a.Neighbourhood, a.Description, a.Pics)).ToList();
            return View(estate);
            }

        }

        // GET: Estates1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estates == null)
            {
                return NotFound();
            }

            var estate = await _context.Estates
                .Include(e => e.Extras)
                .Include(e => e.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estate == null)
            {
                return NotFound();
            }

            return View(estate);
        }

        // POST: Estates1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estates == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Estates'  is null.");
            }
            var estate = await _context.Estates.FindAsync(id);
            if (estate != null)
            {
                _context.Estates.Remove(estate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstateExists(int id)
        {
            return _context.Estates.Any(e => e.Id == id);
        }
    }
}
