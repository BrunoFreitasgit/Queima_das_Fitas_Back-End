using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Queima.Web.App.DAL;
using Queima.Web.App.ViewModels;
using Queima.Web.App.Models;
using Queima.Web.App.Interfaces;

namespace Queima.Web.App.Controllers
{
    public class BilheteiraController : Controller
    {

        public IGenericRepository<Bilheteira> _repository;
        public IGenericRepository<Bilhete> _bilhetesRepository;
        public IGenericRepository<Link> _linksRepository;
        public BilheteiraController(IGenericRepository<Bilheteira> repository, IGenericRepository<Bilhete> bilhetesRepository, IGenericRepository<Link> linksRepository)
        {
            _repository = repository;
            _bilhetesRepository = bilhetesRepository;
            _linksRepository = linksRepository;
        }

        // GET: Bilheteira
        public async Task<IActionResult> Index()
        {
            IEnumerable<Bilheteira> bilheteiras = await _repository.FindAll();
            IEnumerable<Link> links = await _linksRepository.FindAll();
            IEnumerable<Bilhete> bilhetes = await _bilhetesRepository.FindAll();
            Bilheteira bilheteira = bilheteiras.FirstOrDefault();
            BilheteiraViewModel vm = new BilheteiraViewModel(bilheteira);


            return View(vm);
        }

        // GET: Bilheteira/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IEnumerable<Link> links = await _linksRepository.FindAll();
            IEnumerable<Bilhete> bilhetes = await _bilhetesRepository.FindAll();
            var bilheteira = await _repository.Get(id.Value);

            if (bilheteira == null)
            {
                return NotFound();
            }
            var bilheteiraViewModel = new BilheteiraViewModel(bilheteira);


            return View(bilheteiraViewModel);
        }

        // POST: Bilheteira/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("Id,Condicoes,Url,LinkDia1,LinkDia2,LinkDia3,LinkDia4,LinkDia5,LinkDia6,LinkDia7,LinkDia8,Link,LinkId,DataDia1,DataDia2,DataDia3,DataDia4,DataDia5,DataDia6,DataDia7,DataDia8,PrecoDia1,PrecoDiaAnterior1,PrecoNoDia1,PrecoNoDiaForaHoras1,PrecoIngressoSemanal,PrecoDia2,PrecoDiaAnterior2,PrecoNoDia2,PrecoNoDiaForaHoras2,PrecoDia3,PrecoDiaAnterior3,PrecoNoDia3,PrecoNoDiaForaHoras3,PrecoDia4,PrecoDiaAnterior4,PrecoNoDia4,PrecoNoDiaForaHoras4,PrecoDia5,PrecoDiaAnterior5,PrecoNoDia5,PrecoNoDiaForaHoras5,PrecoDia6,PrecoDiaAnterior6,PrecoNoDia6,PrecoNoDiaForaHoras6,PrecoDia7,PrecoDiaAnterior7,PrecoNoDia7,PrecoNoDiaForaHoras7,PrecoDia8,PrecoDiaAnterior8,PrecoNoDia8,PrecoNoDiaForaHoras8,Bilhetes")] BilheteiraViewModel bilheteiraViewModel)
        {
            if (id != bilheteiraViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<Link> links = await _linksRepository.FindAll();
                    IEnumerable<Bilhete> bilhetes = await _bilhetesRepository.FindAll();
                    Bilheteira b = await _repository.Get(id);
                    b.Link.Url = bilheteiraViewModel.Url;
                    b.Bilhetes.ElementAt(0).Data = DateTime.Parse(bilheteiraViewModel.DataDia1);
                    b.Bilhetes.ElementAt(0).PrecoNormal = Convert.ToDecimal(bilheteiraViewModel.PrecoDia1);
                    b.Bilhetes.ElementAt(0).PrecoDiaAnterior = Convert.ToDecimal(bilheteiraViewModel.PrecoDiaAnterior1);
                    b.Bilhetes.ElementAt(0).PrecoNoDia = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDia1);
                    b.Bilhetes.ElementAt(0).PrecoNoDiaForaHoras = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDiaForaHoras1);
                    b.Bilhetes.ElementAt(0).Link.Url = bilheteiraViewModel.LinkDia1;

                    b.Bilhetes.ElementAt(1).Data = DateTime.Parse(bilheteiraViewModel.DataDia2);
                    b.Bilhetes.ElementAt(1).PrecoNormal = Convert.ToDecimal(bilheteiraViewModel.PrecoDia2);
                    b.Bilhetes.ElementAt(1).PrecoDiaAnterior = Convert.ToDecimal(bilheteiraViewModel.PrecoDiaAnterior2);
                    b.Bilhetes.ElementAt(1).PrecoNoDia = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDia2);
                    b.Bilhetes.ElementAt(1).PrecoNoDiaForaHoras = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDiaForaHoras2);
                    b.Bilhetes.ElementAt(1).Link.Url = bilheteiraViewModel.LinkDia2;

                    b.Bilhetes.ElementAt(2).Data = DateTime.Parse(bilheteiraViewModel.DataDia3);
                    b.Bilhetes.ElementAt(2).PrecoNormal = Convert.ToDecimal(bilheteiraViewModel.PrecoDia3);
                    b.Bilhetes.ElementAt(2).PrecoDiaAnterior = Convert.ToDecimal(bilheteiraViewModel.PrecoDiaAnterior3);
                    b.Bilhetes.ElementAt(2).PrecoNoDia = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDia3);
                    b.Bilhetes.ElementAt(2).PrecoNoDiaForaHoras = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDiaForaHoras3);
                    b.Bilhetes.ElementAt(2).Link.Url = bilheteiraViewModel.LinkDia3;

                    b.Bilhetes.ElementAt(3).Data = DateTime.Parse(bilheteiraViewModel.DataDia4);
                    b.Bilhetes.ElementAt(3).PrecoNormal = Convert.ToDecimal(bilheteiraViewModel.PrecoDia4);
                    b.Bilhetes.ElementAt(3).PrecoDiaAnterior = Convert.ToDecimal(bilheteiraViewModel.PrecoDiaAnterior4);
                    b.Bilhetes.ElementAt(3).PrecoNoDia = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDia4);
                    b.Bilhetes.ElementAt(3).PrecoNoDiaForaHoras = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDiaForaHoras4);
                    b.Bilhetes.ElementAt(3).Link.Url = bilheteiraViewModel.LinkDia4;

                    b.Bilhetes.ElementAt(4).Data = DateTime.Parse(bilheteiraViewModel.DataDia5);
                    b.Bilhetes.ElementAt(4).PrecoNormal = Convert.ToDecimal(bilheteiraViewModel.PrecoDia5);
                    b.Bilhetes.ElementAt(4).PrecoDiaAnterior = Convert.ToDecimal(bilheteiraViewModel.PrecoDiaAnterior5);
                    b.Bilhetes.ElementAt(4).PrecoNoDia = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDia5);
                    b.Bilhetes.ElementAt(4).PrecoNoDiaForaHoras = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDiaForaHoras5);
                    b.Bilhetes.ElementAt(4).Link.Url = bilheteiraViewModel.LinkDia5;

                    b.Bilhetes.ElementAt(5).Data = DateTime.Parse(bilheteiraViewModel.DataDia6);
                    b.Bilhetes.ElementAt(5).PrecoNormal = Convert.ToDecimal(bilheteiraViewModel.PrecoDia6);
                    b.Bilhetes.ElementAt(5).PrecoDiaAnterior = Convert.ToDecimal(bilheteiraViewModel.PrecoDiaAnterior6);
                    b.Bilhetes.ElementAt(5).PrecoNoDia = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDia1);
                    b.Bilhetes.ElementAt(5).PrecoNoDiaForaHoras = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDiaForaHoras6);
                    b.Bilhetes.ElementAt(5).Link.Url = bilheteiraViewModel.LinkDia6;

                    b.Bilhetes.ElementAt(6).Data = DateTime.Parse(bilheteiraViewModel.DataDia7);
                    b.Bilhetes.ElementAt(6).PrecoNormal = Convert.ToDecimal(bilheteiraViewModel.PrecoDia7);
                    b.Bilhetes.ElementAt(6).PrecoDiaAnterior = Convert.ToDecimal(bilheteiraViewModel.PrecoDiaAnterior7);
                    b.Bilhetes.ElementAt(6).PrecoNoDia = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDia7);
                    b.Bilhetes.ElementAt(6).PrecoNoDiaForaHoras = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDiaForaHoras7);
                    b.Bilhetes.ElementAt(6).Link.Url = bilheteiraViewModel.LinkDia7;

                    b.Bilhetes.ElementAt(7).Data = DateTime.Parse(bilheteiraViewModel.DataDia8);
                    b.Bilhetes.ElementAt(7).PrecoNormal = Convert.ToDecimal(bilheteiraViewModel.PrecoDia8);
                    b.Bilhetes.ElementAt(7).PrecoDiaAnterior = Convert.ToDecimal(bilheteiraViewModel.PrecoDiaAnterior8);
                    b.Bilhetes.ElementAt(7).PrecoNoDia = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDia8);
                    b.Bilhetes.ElementAt(7).PrecoNoDiaForaHoras = Convert.ToDecimal(bilheteiraViewModel.PrecoNoDiaForaHoras8);
                    b.Bilhetes.ElementAt(7).Link.Url = bilheteiraViewModel.LinkDia8;

                    await _repository.Update(b);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BilheteiraViewModelExists(bilheteiraViewModel.Id))
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
            return View(bilheteiraViewModel);
        }



        private bool BilheteiraViewModelExists(int id)
        {
            if (_repository.Get(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
