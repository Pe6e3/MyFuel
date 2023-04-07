using System;
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
    public class JournalLinesController : Controller
    {
        private readonly MyFuelContext _context;

        public JournalLinesController(MyFuelContext context)
        {
            _context = context;
        }

        // GET: JournalLines
        public async Task<IActionResult> Index()
        {
              return _context.JournalLine != null ? 
                          View(await _context.JournalLine.ToListAsync()) :
                          Problem("Entity set 'MyFuelContext.JournalLine'  is null.");
        }

        // GET: JournalLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JournalLine == null)
            {
                return NotFound();
            }

            var journalLine = await _context.JournalLine
                .FirstOrDefaultAsync(m => m.Line_id == id);
            if (journalLine == null)
            {
                return NotFound();
            }

            return View(journalLine);
        }

        // GET: JournalLines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JournalLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Line_id,Refill_id,RefillValue")] JournalLine journalLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(journalLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(journalLine);
        }

        // GET: JournalLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JournalLine == null)
            {
                return NotFound();
            }

            var journalLine = await _context.JournalLine.FindAsync(id);
            if (journalLine == null)
            {
                return NotFound();
            }
            return View(journalLine);
        }

        // POST: JournalLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Line_id,Refill_id,RefillValue")] JournalLine journalLine)
        {
            if (id != journalLine.Line_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(journalLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalLineExists(journalLine.Line_id))
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
            return View(journalLine);
        }

        // GET: JournalLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JournalLine == null)
            {
                return NotFound();
            }

            var journalLine = await _context.JournalLine
                .FirstOrDefaultAsync(m => m.Line_id == id);
            if (journalLine == null)
            {
                return NotFound();
            }

            return View(journalLine);
        }

        // POST: JournalLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JournalLine == null)
            {
                return Problem("Entity set 'MyFuelContext.JournalLine'  is null.");
            }
            var journalLine = await _context.JournalLine.FindAsync(id);
            if (journalLine != null)
            {
                _context.JournalLine.Remove(journalLine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JournalLineExists(int id)
        {
          return (_context.JournalLine?.Any(e => e.Line_id == id)).GetValueOrDefault();
        }
    }
}
