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



        //// GET: Bilheteira/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bilheteiraViewModel = await _context.BilheteiraViewModel.SingleOrDefaultAsync(m => m.Id == id);
        //    if (bilheteiraViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(bilheteiraViewModel);
        //}

        //// POST: Bilheteira/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Condicoes,DataDia1,DataDia2,DataDia3,DataDia4,DataDia5,DataDia6,DataDia7,DataDia8,PrecoIngressoSemanal")] BilheteiraViewModel bilheteiraViewModel)
        //{
        //    if (id != bilheteiraViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(bilheteiraViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BilheteiraViewModelExists(bilheteiraViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(bilheteiraViewModel);
        //}



        //private bool BilheteiraViewModelExists(int id)
        //{
        //    if (_repository.Get(id) != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
