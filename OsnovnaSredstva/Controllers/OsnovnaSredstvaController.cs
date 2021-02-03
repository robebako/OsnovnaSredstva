using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OsnovnaSredstva.Data;
using OsnovnaSredstva.Models;

namespace OsnovnaSredstva.Controllers
{
    [Authorize]
    public class OsnovnaSredstvaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OsnovnaSredstvaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OsnovnaSredstva
        [AllowAnonymous]
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["SortiranjePoNazivu"] = String.IsNullOrEmpty(sortOrder) ? "Naziv_desc" : "";
            ViewData["SortiranjePoDatumuNabave"] = sortOrder == "DatumNabave" ? "DatumNabave_desc" : "DatumNabave";

            var osnovnaSredstva = from o in _context.OsnSredstvo
                                  select o;
            switch(sortOrder)
            {
                case "Naziv_desc":
                    osnovnaSredstva = osnovnaSredstva.OrderByDescending(o => o.Naziv);
                    break;
                case "DatumNabave":
                    osnovnaSredstva = osnovnaSredstva.OrderBy(o => o.DatumNabave);
                    break;
                case "DatumNabave_desc":
                    osnovnaSredstva = osnovnaSredstva.OrderByDescending(o => o.DatumNabave);
                    break;
                default:
                    osnovnaSredstva = osnovnaSredstva.OrderBy(o => o.Naziv);
                    break;
            }
            return View(await osnovnaSredstva.Include(o=>o.Grupa).AsNoTracking().ToListAsync());
        }

        // GET: OsnovnaSredstva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osnSredstvo = await _context.OsnSredstvo
                .Include(o => o.Grupa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (osnSredstvo == null)
            {
                return NotFound();
            }

            return View(osnSredstvo);
        }

        // GET: OsnovnaSredstva/Create
        public IActionResult Create()
        {
            ViewData["GrupaId"] = new SelectList(_context.Grupa, "Id", "NazivGrupe");
            return View();
        }

        // POST: OsnovnaSredstva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,InventurniBroj,DatumNabave,Kolicina,NabavnaCijena,GrupaId")] OsnSredstvo osnSredstvo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(osnSredstvo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupaId"] = new SelectList(_context.Grupa, "Id", "NazivGrupe", osnSredstvo.GrupaId);
            return View(osnSredstvo);
        }

        // GET: OsnovnaSredstva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osnSredstvo = await _context.OsnSredstvo.FindAsync(id);
            if (osnSredstvo == null)
            {
                return NotFound();
            }
            ViewData["GrupaId"] = new SelectList(_context.Grupa, "Id", "NazivGrupe", osnSredstvo.GrupaId);
            return View(osnSredstvo);
        }

        // POST: OsnovnaSredstva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,InventurniBroj,DatumNabave,Kolicina,NabavnaCijena,GrupaId")] OsnSredstvo osnSredstvo)
        {
            if (id != osnSredstvo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(osnSredstvo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OsnSredstvoExists(osnSredstvo.Id))
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
            ViewData["GrupaId"] = new SelectList(_context.Grupa, "Id", "NazivGrupe", osnSredstvo.GrupaId);
            return View(osnSredstvo);
        }

        // GET: OsnovnaSredstva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osnSredstvo = await _context.OsnSredstvo
                .Include(o => o.Grupa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (osnSredstvo == null)
            {
                return NotFound();
            }

            return View(osnSredstvo);
        }

        // POST: OsnovnaSredstva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var osnSredstvo = await _context.OsnSredstvo.FindAsync(id);
            _context.OsnSredstvo.Remove(osnSredstvo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsnSredstvoExists(int id)
        {
            return _context.OsnSredstvo.Any(e => e.Id == id);
        }
    }
}
