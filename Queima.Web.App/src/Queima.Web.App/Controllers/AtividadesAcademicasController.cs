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
using Microsoft.AspNetCore.Hosting;
using Queima.Web.App.ViewModels;

namespace Queima.Web.App.Controllers
{
    public class AtividadesAcademicasController : Controller
    {
        public IGenericRepository<AtividadeAcademica> _repository;
        public IGenericRepository<LocalAtividadeAcademica> _locaisRepository;
        private IHostingEnvironment _env;

        public AtividadesAcademicasController(IGenericRepository<AtividadeAcademica> repository, IGenericRepository<LocalAtividadeAcademica> localRepo, IHostingEnvironment env)
        {
            _repository = repository;
            _locaisRepository = localRepo;
            _env = env;
        }

        // GET: AtividadesAcademicas
        public async Task<IActionResult> Index()
        {
            IEnumerable<AtividadeAcademica> lista = await _repository.FindAll();
            var lista_vm = new List<AtividadeAcademicaViewModel>();


            foreach (AtividadeAcademica a in lista)
            {
                var vm = new AtividadeAcademicaViewModel(a);
                var local = await _locaisRepository.Get(vm.SelectedLocalId);
                vm.SelectedLocal = local;
                lista_vm.Add(vm);
            }
            return View(lista_vm);
        }

        //// GET: AtividadesAcademicas/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var atividadeAcademica = await _context.Atividades.SingleOrDefaultAsync(m => m.Id == id);
        //    if (atividadeAcademica == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(atividadeAcademica);
        //}

        //// GET: AtividadesAcademicas/Create
        //public IActionResult Create()
        //{
        //    ViewData["LocalAtividadeAcademicaId"] = new SelectList(_context.LocaisAtividades, "Id", "Nome");
        //    return View();
        //}

        //// POST: AtividadesAcademicas/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Data,Descricao,ImagemPath,ImagemUrl,LocalAtividadeAcademicaId,Nome,PontosVenda,Preco")] AtividadeAcademica atividadeAcademica)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(atividadeAcademica);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewData["LocalAtividadeAcademicaId"] = new SelectList(_context.LocaisAtividades, "Id", "Nome", atividadeAcademica.LocalAtividadeAcademicaId);
        //    return View(atividadeAcademica);
        //}

        //// GET: AtividadesAcademicas/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var atividadeAcademica = await _context.Atividades.SingleOrDefaultAsync(m => m.Id == id);
        //    if (atividadeAcademica == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["LocalAtividadeAcademicaId"] = new SelectList(_context.LocaisAtividades, "Id", "Nome", atividadeAcademica.LocalAtividadeAcademicaId);
        //    return View(atividadeAcademica);
        //}

        //// POST: AtividadesAcademicas/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Descricao,ImagemPath,ImagemUrl,LocalAtividadeAcademicaId,Nome,PontosVenda,Preco")] AtividadeAcademica atividadeAcademica)
        //{
        //    if (id != atividadeAcademica.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(atividadeAcademica);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AtividadeAcademicaExists(atividadeAcademica.Id))
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
        //    ViewData["LocalAtividadeAcademicaId"] = new SelectList(_context.LocaisAtividades, "Id", "Nome", atividadeAcademica.LocalAtividadeAcademicaId);
        //    return View(atividadeAcademica);
        //}

        //// GET: AtividadesAcademicas/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var atividadeAcademica = await _context.Atividades.SingleOrDefaultAsync(m => m.Id == id);
        //    if (atividadeAcademica == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(atividadeAcademica);
        //}

        //// POST: AtividadesAcademicas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var atividadeAcademica = await _context.Atividades.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Atividades.Remove(atividadeAcademica);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //private bool AtividadeAcademicaExists(int id)
        //{
        //    return _context.Atividades.Any(e => e.Id == id);
        //}
    }
}
