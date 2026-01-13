using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class pyhas : Controller
    {
        private readonly ApplicationDbContext _context;

        public pyhas(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: pyhas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pyha.ToListAsync());
        }

        // GET: pyhas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pyha = await _context.Pyha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pyha == null)
            {
                return NotFound();
            }

            return View(pyha);
        }

        // GET: pyhas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: pyhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nimetus,Kuupaev")] Pyha pyha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pyha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pyha);
        }

        // GET: pyhas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pyha = await _context.Pyha.FindAsync(id);
            if (pyha == null)
            {
                return NotFound();
            }
            return View(pyha);
        }

        // POST: pyhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nimetus,Kuupaev")] Pyha pyha)
        {
            if (id != pyha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pyha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PyhaExists(pyha.Id))
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
            return View(pyha);
        }

        // GET: pyhas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pyha = await _context.Pyha
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pyha == null)
            {
                return NotFound();
            }

            return View(pyha);
        }

        // POST: pyhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pyha = await _context.Pyha.FindAsync(id);
            if (pyha != null)
            {
                _context.Pyha.Remove(pyha);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PyhaExists(int id)
        {
            return _context.Pyha.Any(e => e.Id == id);
        }
    }
}
