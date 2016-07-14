using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Queima.Web.App.DAL;
using Queima.Web.App.Models;
using Queima.Web.App.Interfaces;

namespace Queima.Web.App.Controllers
{
    public class PontosInteresseController : Controller
    {
        public IGenericRepository<PontoInteresse> _repository;

        public PontosInteresseController(IGenericRepository<PontoInteresse> repository)
        {
            _repository = repository;
        }

        // GET: PontosInteresse
        public async Task<IActionResult> Index()
        {
            return View(await _repository.FindAll());
        }

        // GET: PontosInteresse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresse = await _repository.Get(id.Value);
            if (pontoInteresse == null)
            {
                return NotFound();
            }

            return View(pontoInteresse);
        }

        // GET: PontosInteresse/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PontosInteresse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DescricaoAdicional,Latitude,Longitude,Nome,Tipo")] PontoInteresse pontoInteresse)
        {
            if (ModelState.IsValid)
            {
                await _repository.Save(pontoInteresse);
                return RedirectToAction("Index");
            }
            return View(pontoInteresse);
        }

        // GET: PontosInteresse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresse = await _repository.Get(id.Value);
            if (pontoInteresse == null)
            {
                return NotFound();
            }
            return View(pontoInteresse);
        }

        // POST: PontosInteresse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescricaoAdicional,Latitude,Longitude,Nome,Tipo")] PontoInteresse pontoInteresse)
        {
            if (id != pontoInteresse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(pontoInteresse);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoInteresseExists(pontoInteresse.Id))
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
            return View(pontoInteresse);
        }

        // GET: PontosInteresse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresse = await _repository.Get(id.Value);
            if (pontoInteresse == null)
            {
                return NotFound();
            }

            return View(pontoInteresse);
        }

        // POST: PontosInteresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pontoInteresse = await _repository.Get(id);
            await _repository.Delete(pontoInteresse);
            return RedirectToAction("Index");
        }

        private bool PontoInteresseExists(int id)
        {
            if (_repository.Get(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}
