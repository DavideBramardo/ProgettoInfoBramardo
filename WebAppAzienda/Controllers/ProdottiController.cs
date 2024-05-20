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
    public class ProdottiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdottiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prodotti
        public async Task<IActionResult> Index()
        {
              return _context.Prodotto != null ? 
                          View(await _context.Prodotto.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Prodotto'  is null.");
        }

        // GET: Prodotti/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Prodotto == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // GET: Prodotti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prodotti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Ingredienti,Peso,Prezzo")] Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodotto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prodotto);
        }

        // GET: Prodotti/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Prodotto == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotto.FindAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto);
        }

        // POST: Prodotti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nome,Ingredienti,Peso,Prezzo")] Prodotto prodotto)
        {
            if (id != prodotto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodotto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdottoExists(prodotto.Id))
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
            return View(prodotto);
        }

        // GET: Prodotti/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Prodotto == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // POST: Prodotti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Prodotto == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Prodotto'  is null.");
            }
            var prodotto = await _context.Prodotto.FindAsync(id);
            if (prodotto != null)
            {
                _context.Prodotto.Remove(prodotto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdottoExists(string id)
        {
          return (_context.Prodotto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
