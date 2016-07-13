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
        private PontosInteresseRepository _repo;

        public PontosInteresseController(QueimaDbContext context)
        {
            _repo = new PontosInteresseRepository(context);
        }

        // GET: PontosInteresse
        public IActionResult Index()
        {
            return View(_repo.GetAll().ToList());
        }

        // GET: PontosInteresse/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresse = _repo.GetById(id.Value);
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
        public ActionResult Create([Bind("PontoInteresseID,DescricaoAdicional,Latitude,Longitude,Nome,Tipo")] PontoInteresse pontoInteresse)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(pontoInteresse);
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

            var pontoInteresse = _repo.GetById(id.Value);
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
        public ActionResult Edit(int id, [Bind("PontoInteresseID,DescricaoAdicional,Latitude,Longitude,Nome,Tipo")] PontoInteresse pontoInteresse)
        {
            if (id != pontoInteresse.PontoInteresseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(pontoInteresse);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoInteresseExists(pontoInteresse.PontoInteresseID))
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

            var pontoInteresse = _repo.GetById(id.Value);
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
            var pontoInteresse = _repo.GetById(id);
            _repo.Delete(pontoInteresse);
            return RedirectToAction("Index");
        }

        private bool PontoInteresseExists(int id)
        {
            if (_repo.GetById(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
