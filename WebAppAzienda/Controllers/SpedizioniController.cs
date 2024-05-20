using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppAzienda.Data;
using WebAppAzienda.Models;

namespace WebAppAzienda.Controllers
{
    public class SpedizioniController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpedizioniController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Spedizioni
        public async Task<IActionResult> Index()
        {
              return _context.Spedizione != null ? 
                          View(await _context.Spedizione.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Spedizione'  is null.");
        }

        // GET: Spedizioni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Spedizione == null)
            {
                return NotFound();
            }

            var spedizione = await _context.Spedizione
                .FirstOrDefaultAsync(m => m.IdSpedizione == id);
            if (spedizione == null)
            {
                return NotFound();
            }

            return View(spedizione);
        }

        // GET: Spedizioni/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spedizioni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSpedizione,IdOrdine,DataSpedizione,IndirizzoSpedizione")] Spedizione spedizione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spedizione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spedizione);
        }

        // GET: Spedizioni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Spedizione == null)
            {
                return NotFound();
            }

            var spedizione = await _context.Spedizione.FindAsync(id);
            if (spedizione == null)
            {
                return NotFound();
            }
            return View(spedizione);
        }

        // POST: Spedizioni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IdSpedizione,IdOrdine,DataSpedizione,IndirizzoSpedizione")] Spedizione spedizione)
        {
            if (id != spedizione.IdSpedizione)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spedizione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpedizioneExists(spedizione.IdSpedizione))
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
            return View(spedizione);
        }

        // GET: Spedizioni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Spedizione == null)
            {
                return NotFound();
            }

            var spedizione = await _context.Spedizione
                .FirstOrDefaultAsync(m => m.IdSpedizione == id);
            if (spedizione == null)
            {
                return NotFound();
            }

            return View(spedizione);
        }

        // POST: Spedizioni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Spedizione == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Spedizione'  is null.");
            }
            var spedizione = await _context.Spedizione.FindAsync(id);
            if (spedizione != null)
            {
                _context.Spedizione.Remove(spedizione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpedizioneExists(int? id)
        {
          return (_context.Spedizione?.Any(e => e.IdSpedizione == id)).GetValueOrDefault();
        }
    }
}
