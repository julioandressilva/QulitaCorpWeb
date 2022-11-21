using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QualitaCoprWeb.Repository.Models;
using QualitaCorpWeb.Entities.Models;

namespace QualitaCorpWeb.Controllers
{
    public class MeseroController : Controller
    {
        private readonly ModelContext _context;

        public MeseroController(ModelContext context)
        {
            _context = context;
        }

        // GET: Mesero
        public async Task<IActionResult> Index()
        {
              return View(await _context.Meseros.ToListAsync());
        }

        // GET: Mesero/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Meseros == null)
            {
                return NotFound();
            }

            var mesero = await _context.Meseros
                .FirstOrDefaultAsync(m => m.Idmesero == id);
            if (mesero == null)
            {
                return NotFound();
            }

            return View(mesero);
        }

        // GET: Mesero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mesero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmesero,Nombres,Apellidos,Edad,Antiguedad")] Mesero mesero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mesero);
        }

        // GET: Mesero/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Meseros == null)
            {
                return NotFound();
            }

            var mesero = await _context.Meseros.FindAsync(id);
            if (mesero == null)
            {
                return NotFound();
            }
            return View(mesero);
        }

        // POST: Mesero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Idmesero,Nombres,Apellidos,Edad,Antiguedad")] Mesero mesero)
        {
            if (id != mesero.Idmesero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mesero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeseroExists(mesero.Idmesero))
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
            return View(mesero);
        }

        // GET: Mesero/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Meseros == null)
            {
                return NotFound();
            }

            var mesero = await _context.Meseros
                .FirstOrDefaultAsync(m => m.Idmesero == id);
            if (mesero == null)
            {
                return NotFound();
            }

            return View(mesero);
        }

        // POST: Mesero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Meseros == null)
            {
                return Problem("Entity set 'ModelContext.Meseros'  is null.");
            }
            var mesero = await _context.Meseros.FindAsync(id);
            if (mesero != null)
            {
                _context.Meseros.Remove(mesero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeseroExists(decimal id)
        {
          return _context.Meseros.Any(e => e.Idmesero == id);
        }
    }
}
