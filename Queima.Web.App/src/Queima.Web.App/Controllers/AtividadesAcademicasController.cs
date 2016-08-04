using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Queima.Web.App.Models;
using Queima.Web.App.Interfaces;
using Queima.Web.App.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace Queima.Web.App.Controllers
{
    public class AtividadesAcademicasController : Controller
    {
        public IGenericRepository<AtividadeAcademica> _repository;
        public IGenericRepository<LocalAtividadeAcademica> _pontosRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AtividadesAcademicasController(IGenericRepository<AtividadeAcademica> repository,
            IGenericRepository<LocalAtividadeAcademica> pontosRepository,
            IHostingEnvironment hostingEnvironment)
        {
            _repository = repository;
            _pontosRepository = pontosRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: AtividadesAcademicas
        public async Task<IActionResult> Index()
        {
            IEnumerable<AtividadeAcademica> lista = await _repository.FindAll();
            var lista_vm = new List<AtividadeAcademicaViewModel>();

            foreach (AtividadeAcademica a in lista)
            {
                var vm = new AtividadeAcademicaViewModel(a);
                if (vm.SelectedLocalId != -1 )
                {
                    var local = _pontosRepository.Get(vm.SelectedLocalId);
                    vm.SelectedLocal = await local;
                }
                lista_vm.Add(vm);
            }
            return View(lista_vm);
        }

        // GET: AtividadesAcademicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividadeAcademica = await _repository.Get(id.Value);
            if (atividadeAcademica == null)
            {
                return NotFound();
            }

            var vm = new AtividadeAcademicaViewModel(atividadeAcademica);
            if (vm.SelectedLocalId != -1)
            {
                var local = _pontosRepository.Get(vm.SelectedLocalId);
                vm.SelectedLocal = await local;
            }

            return View(vm);
        }

        // GET: AtividadesAcademicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AtividadesAcademicas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco,Data,Imagem, SelectedLocalId, SelectedPontosVenda,")] AtividadeAcademicaViewModel atividadeAcademicaViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(atividadeAcademicaViewModel);
        }

        // GET: AtividadesAcademicas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AtividadesAcademicas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AtividadesAcademicas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AtividadesAcademicas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}