using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppAzienda.Data;
using WebAppAzienda.Models;

namespace WebAppAzienda.Controllers
{
    public class UtentiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtentiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Utenti
        public async Task<IActionResult> Index()
        {
              return _context.Utente != null ? 
                          View(await _context.Utente.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Utente'  is null.");
        }

        // GET: Utenti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Utente == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }

        // GET: Utenti/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utenti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cognome,NTelefonico,Email")] Utente utente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utente);
        }

        // GET: Utenti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Utente == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente.FindAsync(id);
            if (utente == null)
            {
                return NotFound();
            }
            return View(utente);
        }

        // POST: Utenti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cognome,NTelefonico,Email")] Utente utente)
        {
            if (id != utente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtenteExists(utente.Id))
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
            return View(utente);
        }
        [HttpPost]
        public IActionResult AggiungiDatiUtente(Utente nuovoUtente)
        {
            if (ModelState.IsValid)
            {
                _context.Utente.Add(nuovoUtente);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home"); 
            }
            return View(); // Se il modello non è valido, rimanda alla stessa vista
        }

        // GET: Utenti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Utente == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }

        // POST: Utenti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Utente == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Utente'  is null.");
            }
            var utente = await _context.Utente.FindAsync(id);
            if (utente != null)
            {
                _context.Utente.Remove(utente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtenteExists(int id)
        {
          return (_context.Utente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
