﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFuel.Data;
using MyFuel.Models;

namespace MyFuel.Controllers
{
    public class RefillsController : Controller
    {
        private readonly MyFuelContext _context;

        public RefillsController(MyFuelContext context)
        {
            _context = context;
        }

        // GET: Refills
        public async Task<IActionResult> Index()
        {
              return _context.Refill != null ? 
                          View(await _context.Refill.ToListAsync()) :
                          Problem("Entity set 'MyFuelContext.Refill'  is null.");
        }

        // GET: Refills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Refill == null)
            {
                return NotFound();
            }

            var refill = await _context.Refill
                .FirstOrDefaultAsync(m => m.Refill_id == id);
            if (refill == null)
            {
                return NotFound();
            }

            return View(refill);
        }

        // GET: Refills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Refills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Refill_id,Fuel_id")] Refill refill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refill);
        }

        // GET: Refills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Refill == null)
            {
                return NotFound();
            }

            var refill = await _context.Refill.FindAsync(id);
            if (refill == null)
            {
                return NotFound();
            }
            return View(refill);
        }

        // POST: Refills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Refill_id,Fuel_id")] Refill refill)
        {
            if (id != refill.Refill_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefillExists(refill.Refill_id))
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
            return View(refill);
        }

        // GET: Refills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Refill == null)
            {
                return NotFound();
            }

            var refill = await _context.Refill
                .FirstOrDefaultAsync(m => m.Refill_id == id);
            if (refill == null)
            {
                return NotFound();
            }

            return View(refill);
        }

        // POST: Refills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Refill == null)
            {
                return Problem("Entity set 'MyFuelContext.Refill'  is null.");
            }
            var refill = await _context.Refill.FindAsync(id);
            if (refill != null)
            {
                _context.Refill.Remove(refill);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefillExists(int id)
        {
          return (_context.Refill?.Any(e => e.Refill_id == id)).GetValueOrDefault();
        }
    }
}
