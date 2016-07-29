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
using Microsoft.AspNetCore.Http;
using Queima.Web.App.Helpers;
using System.IO;

namespace Queima.Web.App.Controllers
{
    public class ConcursosController : Controller
    {
        public IGenericRepository<Concurso> _repository;
        public IGenericRepository<Link> _linkRepository;
        private IHostingEnvironment _env;

        public ConcursosController(IGenericRepository<Concurso> repository, IGenericRepository<Link> linkRepo, IHostingEnvironment env)
        {
            _repository = repository;
            _linkRepository = linkRepo;
            _env = env;
        }

        // GET: Concursos
        public async Task<IActionResult> Index()
        {
            IEnumerable<Concurso> lista = await _repository.FindAll();
            var lista_vm = new List<ConcursoViewModel>();

            // TODO Adicionar URL ao viewmodel para a API
            //var s = HttpContext.Request.ToString();
            //**************
            foreach (Concurso c in lista)
            {
                var vm = new ConcursoViewModel(c);
                lista_vm.Add(vm);
            }
            return View(lista_vm);
        }

        // GET: Concursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concurso = await _repository.Get(id.Value);
            if (concurso == null)
            {
                return NotFound();
            }
            concurso.Link = await _linkRepository.Get(concurso.LinkId);
            ConcursoViewModel vm = new ConcursoViewModel(concurso);
            
            ViewBag.ImagemPath = vm.ImagemPath;
            ViewBag.Alt = "Não tem imagem associada";
            return View(vm);
        }

        // GET: Concursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Concursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataFim,DataInicio,Descricao,TipoConcurso,Url")] ConcursoViewModel vm, IFormFile Imagem)
        {
            Concurso concurso = new Concurso();

            // Só pode existir um concurso de cada tipo na base de dados
            var query = await _repository.FindAll();
            foreach (Concurso c in query)
            {
                if (c.TipoConcurso == vm.TipoConcurso && vm.TipoConcurso != TipoConcurso.Passatempo)
                {
                    return Content("Só pode existir uma gravação de concursos dos tipos: DJ, Cartaz e Bandas)");
                }
            }
            /*************************************************************/

            if (ModelState.IsValid && Imagem != null && Imagem.Length > 0 && FilesHelper.VerifyFileSize(Imagem) && FilesHelper.VerifyFileExtension(Imagem.FileName))
            {
                var upload = Path.Combine(_env.WebRootPath, "imagens", "concursos");

                // guardar imagem
                using (var fileStream = new FileStream(Path.Combine(upload, Imagem.FileName), FileMode.Create))
                {
                    await Imagem.CopyToAsync(fileStream);
                }
                concurso.TipoConcurso = vm.TipoConcurso;
                concurso.Descricao = vm.Descricao;
                concurso.DataInicio = DateTime.Parse(vm.DataInicio);
                concurso.DataFim = DateTime.Parse(vm.DataFim);
                concurso.ImagemPath = "\\imagens\\concursos\\" + Imagem.FileName;
                concurso.ImagemUrl = HttpContext.Request.Host.Host + "/imagens/concursos/" + Imagem.FileName;
                Link link = new Link { Categoria = Categoria.Concurso, Descricao = vm.Descricao, Url = vm.Url };
                await _linkRepository.Save(link);

                // guardar link
                concurso.Link = link;
                concurso.LinkId = link.Id;


                await _repository.Save(concurso);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Concursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concurso = await _repository.Get(id.Value);

            if (concurso == null)
            {
                return NotFound();
            }
            concurso.Link = await _linkRepository.Get(concurso.LinkId);
            ConcursoViewModel vm = new ConcursoViewModel(concurso);

            return View(vm);
        }

        // POST: Concursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataFim,DataInicio,Descricao,ImagemUrl,ImagemPath,TipoConcurso,Url")] ConcursoViewModel vm, IFormFile Imagem)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }
            Concurso concurso = await _repository.Get(id);
            // Só pode existir um concurso de cada tipo na base de dados
            var query = await _repository.FindAll();
            foreach (Concurso c in query)
            {
                if (c.TipoConcurso == vm.TipoConcurso && vm.TipoConcurso != TipoConcurso.Passatempo)
                {
                    return Content("Só pode existir uma gravação de concursos dos tipos: DJ, Cartaz e Bandas)");
                }
            }
            /*************************************************************/
            if (ModelState.IsValid)
            {
                try
                {
                    // editar imagem
                    if (Imagem != null && Imagem.Length > 0 && FilesHelper.VerifyFileSize(Imagem) && FilesHelper.VerifyFileExtension(Imagem.FileName))
                    {
                        var upload = Path.Combine(_env.WebRootPath, "imagens", "concursos");

                        // guardar imagem
                        using (var fileStream = new FileStream(Path.Combine(upload, Imagem.FileName), FileMode.Create))
                        {
                            await Imagem.CopyToAsync(fileStream);
                        }
                        // apagar imagem antiga
                        var path = _env.WebRootPath + vm.ImagemPath;
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        concurso.ImagemPath = "\\imagens\\concursos\\" + Imagem.FileName;
                        concurso.ImagemUrl = HttpContext.Request.ToString() + "/imagens/concursos/" + Imagem.FileName;
                    }

                    concurso.TipoConcurso = vm.TipoConcurso;
                    concurso.Descricao = vm.Descricao;
                    concurso.DataInicio = DateTime.Parse(vm.DataInicio);
                    concurso.DataFim = DateTime.Parse(vm.DataFim);
                    Link link = await _linkRepository.Get(vm.LinkId);
                    link.Descricao = vm.Descricao;
                    link.Url = vm.Url;

                    await _linkRepository.Update(link);
                    await _repository.Update(concurso);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcursoExists(concurso.Id))
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

            return View(vm);
        }

        // GET: Concursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concurso = await _repository.Get(id.Value);
            if (concurso == null)
            {
                return NotFound();
            }
            var vm = new ConcursoViewModel(concurso);
            Link link = await _linkRepository.Get(concurso.LinkId);
            vm.Link = link;
            vm.LinkId = link.Id;

            return View(vm);
        }

        // POST: Concursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concurso = await _repository.Get(id);
            var path = _env.WebRootPath + concurso.ImagemPath;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            await _repository.Delete(concurso);
            Link link = await _linkRepository.Get(concurso.LinkId);
            await _linkRepository.Delete(link);

            return RedirectToAction("Index");
        }

        private bool ConcursoExists(int id)
        {
            if (_repository.Get(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
