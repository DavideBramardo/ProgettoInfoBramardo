using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppAzienda.Data;
using WebAppAzienda.Models;

namespace WebAppAzienda.Controllers
{
    public class OrdiniController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdiniController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ordini
        public async Task<IActionResult> Index()
        {
              return _context.Ordine != null ? 
                          View(await _context.Ordine.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Ordine'  is null.");
        }

        // GET: Ordini/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ordine == null)
            {
                return NotFound();
            }

            var ordine = await _context.Ordine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordine == null)
            {
                return NotFound();
            }

            return View(ordine);
        }

        // GET: Ordini/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ordini/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,UtenteId,DescrProdotti")] Ordine ordine)
        {
            if (ModelState.IsValid)
            {
                //var userId = HttpContext.Session.GetString("UtenteId");
                //ordine.UtenteId = int.Parse(userId);
                _context.Add(ordine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View(ordine);
        }

        // GET: Ordini/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ordine == null)
            {
                return NotFound();
            }

            var ordine = await _context.Ordine.FindAsync(id);
            if (ordine == null)
            {
                return NotFound();
            }
            return View(ordine);
        }

        // POST: Ordini/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,UtenteId,DescrProdotti")] Ordine ordine)
        {
            if (id != ordine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdineExists(ordine.Id))
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
            return View(ordine);
        }

        // GET: Ordini/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ordine == null)
            {
                return NotFound();
            }

            var ordine = await _context.Ordine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordine == null)
            {
                return NotFound();
            }

            return View(ordine);
        }

        // POST: Ordini/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ordine == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ordine'  is null.");
            }
            var ordine = await _context.Ordine.FindAsync(id);
            if (ordine != null)
            {
                _context.Ordine.Remove(ordine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdineExists(int id)
        {
          return (_context.Ordine?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
