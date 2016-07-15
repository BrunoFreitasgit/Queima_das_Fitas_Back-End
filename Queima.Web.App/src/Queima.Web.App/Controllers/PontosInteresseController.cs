using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Queima.Web.App.DAL;
using Queima.Web.App.ViewModels;
using Queima.Web.App.Interfaces;
using Queima.Web.App.Models;
using Queima.Web.App.Helpers;

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
            IEnumerable<PontoInteresse> lista = await _repository.FindAll();
            var lista_vm = new List<PontoInteresseViewModel>();

            foreach (PontoInteresse pt in lista)
            {
                var vm = new PontoInteresseViewModel(pt);
                lista_vm.Add(vm);
            }
            return View(lista_vm);
        }


        // GET: PontosInteresse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresse = await _repository.Get(id.Value);
            var vm = new PontoInteresseViewModel(pontoInteresse);
            if (vm == null)
            {
                return NotFound();
            }

            return View(vm);
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
        public async Task<IActionResult> Create([Bind("Id,DescricaoAdicional,Latitude,Longitude,Nome,Tipo")] PontoInteresseViewModel pontoInteresseViewModel)
        {
            if (ModelState.IsValid)
            {
                if (IsDecimalFormat(pontoInteresseViewModel.Latitude) && IsDecimalFormat(pontoInteresseViewModel.Longitude))
                {

                    PontoInteresse ponto = new PontoInteresse();
                    ponto.Id = pontoInteresseViewModel.Id;
                    ponto.Latitude = Convert.ToDouble(pontoInteresseViewModel.Latitude);
                    ponto.Latitude = Convert.ToDouble(pontoInteresseViewModel.Longitude);
                    ponto.Nome = pontoInteresseViewModel.Nome;
                    ponto.Tipo = pontoInteresseViewModel.Tipo;

                    await _repository.Save(ponto);
                }

                return RedirectToAction("Index");
            }
            return View(pontoInteresseViewModel);
        }

        private bool IsDecimalFormat(string input)
        {
            decimal dummy;
            return decimal.TryParse(input, out dummy);
        }

        // GET: PontosInteresse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresse = await _repository.Get(id.Value);
            var pontoInteresseViewModel = new PontoInteresseViewModel(pontoInteresse);
            if (pontoInteresseViewModel == null)
            {
                return NotFound();
            }
            return View(pontoInteresseViewModel);
        }

        // POST: PontosInteresse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescricaoAdicional,Latitude,Longitude,Nome,Tipo")] PontoInteresseViewModel pontoInteresseViewModel)
        {
            if (id != pontoInteresseViewModel.Id)
            {
                return NotFound();
            }
            var pontoInteresse = await _repository.Get(pontoInteresseViewModel.Id);


            if (ModelState.IsValid && (IsDecimalFormat(pontoInteresseViewModel.Latitude) && IsDecimalFormat(pontoInteresseViewModel.Longitude)))
            {
                try
                {

                    pontoInteresse.DescricaoAdicional = pontoInteresseViewModel.DescricaoAdicional;
                    pontoInteresse.Latitude = Convert.ToDouble(pontoInteresseViewModel.Latitude);
                    pontoInteresse.Longitude = Convert.ToDouble(pontoInteresseViewModel.Longitude);
                    pontoInteresse.Nome = pontoInteresseViewModel.Nome;
                    pontoInteresse.Tipo = pontoInteresseViewModel.Tipo;

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
            return View(new PontoInteresseViewModel(pontoInteresse));
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

            return View(new PontoInteresseViewModel(pontoInteresse));
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
