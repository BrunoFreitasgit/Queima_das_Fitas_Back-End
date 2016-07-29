using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Queima.Web.App.DAL;
using Queima.Web.App.Models;

namespace Queima.Web.App.Controllers
{
    public class BilhetesController : Controller
    {
        private readonly QueimaDbContext _context;

        public BilhetesController(QueimaDbContext context)
        {
            _context = context;    
        }

        // GET: Bilhetes
        public async Task<IActionResult> Index()
        {
            var queimaDbContext = _context.Bilhetes.Include(b => b.Bilheteira).Include(b => b.Link);
            return View(await queimaDbContext.ToListAsync());
        }

        // GET: Bilhetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilhete = await _context.Bilhetes.SingleOrDefaultAsync(m => m.Id == id);
            if (bilhete == null)
            {
                return NotFound();
            }

            return View(bilhete);
        }

        // GET: Bilhetes/Create
        public IActionResult Create()
        {
            ViewData["BilheteiraId"] = new SelectList(_context.Bilheteiras, "Id", "Id");
            ViewData["LinkId"] = new SelectList(_context.Links, "Id", "Descricao");
            return View();
        }

        // POST: Bilhetes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BilheteiraId,Data,LinkId,PrecoDiaAnterior,PrecoNoDia,PrecoNoDiaForaHoras,PrecoNormal")] Bilhete bilhete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bilhete);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BilheteiraId"] = new SelectList(_context.Bilheteiras, "Id", "Id", bilhete.BilheteiraId);
            ViewData["LinkId"] = new SelectList(_context.Links, "Id", "Descricao", bilhete.LinkId);
            return View(bilhete);
        }

        // GET: Bilhetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilhete = await _context.Bilhetes.SingleOrDefaultAsync(m => m.Id == id);
            if (bilhete == null)
            {
                return NotFound();
            }
            ViewData["BilheteiraId"] = new SelectList(_context.Bilheteiras, "Id", "Id", bilhete.BilheteiraId);
            ViewData["LinkId"] = new SelectList(_context.Links, "Id", "Descricao", bilhete.LinkId);
            return View(bilhete);
        }

        // POST: Bilhetes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BilheteiraId,Data,LinkId,PrecoDiaAnterior,PrecoNoDia,PrecoNoDiaForaHoras,PrecoNormal")] Bilhete bilhete)
        {
            if (id != bilhete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bilhete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BilheteExists(bilhete.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["BilheteiraId"] = new SelectList(_context.Bilheteiras, "Id", "Id", bilhete.BilheteiraId);
            ViewData["LinkId"] = new SelectList(_context.Links, "Id", "Descricao", bilhete.LinkId);
            return View(bilhete);
        }

        // GET: Bilhetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilhete = await _context.Bilhetes.SingleOrDefaultAsync(m => m.Id == id);
            if (bilhete == null)
            {
                return NotFound();
            }

            return View(bilhete);
        }

        // POST: Bilhetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bilhete = await _context.Bilhetes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Bilhetes.Remove(bilhete);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BilheteExists(int id)
        {
            return _context.Bilhetes.Any(e => e.Id == id);
        }
    }
}
