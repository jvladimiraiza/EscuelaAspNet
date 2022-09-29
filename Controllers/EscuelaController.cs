using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspNet.Models;

namespace aspNet.Controllers
{
    public class EscuelaController : Controller
    {
        private readonly EscuelaContext _context;

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Escuela
        public async Task<IActionResult> Index()
        {
              return _context.Escuelas != null ? 
                          View(await _context.Escuelas.ToListAsync()) :
                          Problem("Entity set 'EscuelaContext.Escuelas'  is null.");
        }

        // GET: Escuela/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Escuelas == null)
            {
                return NotFound();
            }

            var escuela = await _context.Escuelas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escuela == null)
            {
                return NotFound();
            }

            return View(escuela);
        }

        // GET: Escuela/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escuela/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnioCreacion,Pais,Ciudad,Dirección,TipoEscuela,Id,Nombre")] Escuela escuela)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escuela);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escuela);
        }

        // GET: Escuela/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Escuelas == null)
            {
                return NotFound();
            }

            var escuela = await _context.Escuelas.FindAsync(id);
            if (escuela == null)
            {
                return NotFound();
            }
            return View(escuela);
        }

        // POST: Escuela/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AnioCreacion,Pais,Ciudad,Dirección,TipoEscuela,Id,Nombre")] Escuela escuela)
        {
            if (id != escuela.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escuela);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscuelaExists(escuela.Id))
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
            return View(escuela);
        }

        // GET: Escuela/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Escuelas == null)
            {
                return NotFound();
            }

            var escuela = await _context.Escuelas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escuela == null)
            {
                return NotFound();
            }

            return View(escuela);
        }

        // POST: Escuela/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Escuelas == null)
            {
                return Problem("Entity set 'EscuelaContext.Escuelas'  is null.");
            }
            var escuela = await _context.Escuelas.FindAsync(id);
            if (escuela != null)
            {
                _context.Escuelas.Remove(escuela);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscuelaExists(string id)
        {
          return (_context.Escuelas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
