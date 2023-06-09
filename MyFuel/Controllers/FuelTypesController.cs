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
    public class FuelTypesController : Controller
    {
        private readonly MyFuelContext _context;

        public FuelTypesController(MyFuelContext context)
        {
            _context = context;
        }

        // GET: FuelTypes
        public async Task<IActionResult> Index()
        {
              return _context.FuelType != null ? 
                          View(await _context.FuelType.ToListAsync()) :
                          Problem("Entity set 'MyFuelContext.FuelType'  is null.");
        }

        // GET: FuelTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FuelType == null)
            {
                return NotFound();
            }

            var fuelType = await _context.FuelType
                .FirstOrDefaultAsync(m => m.Fuel_id == id);
            if (fuelType == null)
            {
                return NotFound();
            }

            return View(fuelType);
        }

        // GET: FuelTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FuelTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fuel_id,FuelName")] FuelType fuelType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuelType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuelType);
        }

        // GET: FuelTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FuelType == null)
            {
                return NotFound();
            }

            var fuelType = await _context.FuelType.FindAsync(id);
            if (fuelType == null)
            {
                return NotFound();
            }
            return View(fuelType);
        }

        // POST: FuelTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Fuel_id,FuelName")] FuelType fuelType)
        {
            if (id != fuelType.Fuel_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuelType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelTypeExists(fuelType.Fuel_id))
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
            return View(fuelType);
        }

        // GET: FuelTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FuelType == null)
            {
                return NotFound();
            }

            var fuelType = await _context.FuelType
                .FirstOrDefaultAsync(m => m.Fuel_id == id);
            if (fuelType == null)
            {
                return NotFound();
            }

            return View(fuelType);
        }

        // POST: FuelTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FuelType == null)
            {
                return Problem("Entity set 'MyFuelContext.FuelType'  is null.");
            }
            var fuelType = await _context.FuelType.FindAsync(id);
            if (fuelType != null)
            {
                _context.FuelType.Remove(fuelType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelTypeExists(int id)
        {
          return (_context.FuelType?.Any(e => e.Fuel_id == id)).GetValueOrDefault();
        }
    }
}
