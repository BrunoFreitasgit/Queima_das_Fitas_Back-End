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
    public class AtividadeAcademicasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AtividadeAcademica> _repository;

       // public AtividadeAcademicasController()
        //{
         //   _unitOfWork = new UnitOfWork();
          //  _repository = _unitOfWork.AtividadesAcademicasRepository;
       // }
         public AtividadeAcademicasController(IUnitOfWork unitOfWork)
         {
            _unitOfWork = unitOfWork;
           _repository = _unitOfWork.AtividadesAcademicasRepository;
        }

        // GET: AtividadeAcademicas
        public async Task<IActionResult> Index()
        {
            var atividades = _repository.GetAll();
            if (atividades == null)
            {
                return View();
            }
            return View(atividades.ToList());
        }

        //    // GET: AtividadeAcademicas/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var atividadeAcademica = await _repository.SingleOrDefaultAsync(m => m.AtividadeAcademicaId == id);
        //        if (atividadeAcademica == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(atividadeAcademica);
        //    }

        //    // GET: AtividadeAcademicas/Create
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: AtividadeAcademicas/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("AtividadeAcademicaId,Data,Descricao,Nome,Preco")] AtividadeAcademica atividadeAcademica)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(atividadeAcademica);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction("Index");
        //        }
        //        return View(atividadeAcademica);
        //    }

        //    // GET: AtividadeAcademicas/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var atividadeAcademica = await _context.Atividades.SingleOrDefaultAsync(m => m.AtividadeAcademicaId == id);
        //        if (atividadeAcademica == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(atividadeAcademica);
        //    }

        //    // POST: AtividadeAcademicas/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("AtividadeAcademicaId,Data,Descricao,Nome,Preco")] AtividadeAcademica atividadeAcademica)
        //    {
        //        if (id != atividadeAcademica.AtividadeAcademicaId)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(atividadeAcademica);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!AtividadeAcademicaExists(atividadeAcademica.AtividadeAcademicaId))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction("Index");
        //        }
        //        return View(atividadeAcademica);
        //    }

        //    // GET: AtividadeAcademicas/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var atividadeAcademica = await _context.Atividades.SingleOrDefaultAsync(m => m.AtividadeAcademicaId == id);
        //        if (atividadeAcademica == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(atividadeAcademica);
        //    }

        //    // POST: AtividadeAcademicas/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var atividadeAcademica = await _context.Atividades.SingleOrDefaultAsync(m => m.AtividadeAcademicaId == id);
        //        _context.Atividades.Remove(atividadeAcademica);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    private bool AtividadeAcademicaExists(int id)
        //    {
        //        return _context.Atividades.Any(e => e.AtividadeAcademicaId == id);
        //    }
    }
}
