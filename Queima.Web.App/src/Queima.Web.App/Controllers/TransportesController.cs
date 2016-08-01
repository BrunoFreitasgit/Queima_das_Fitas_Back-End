using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Queima.Web.App.DAL;
using Queima.Web.App.Models;
using Microsoft.AspNetCore.Hosting;
using Queima.Web.App.Interfaces;
using Queima.Web.App.ViewModels;
using Microsoft.AspNetCore.Http;
using Queima.Web.App.Helpers;
using System.IO;

namespace Queima.Web.App.Controllers
{
    public class TransportesController : Controller
    {
        public IGenericRepository<Transporte> _repository;
        public IGenericRepository<Link> _linkRepository;
        private IHostingEnvironment _env;

        public TransportesController(IGenericRepository<Transporte> repository, IGenericRepository<Link> linkRepo, IHostingEnvironment env)
        {
            _repository = repository;
            _linkRepository = linkRepo;
            _env = env;
        }

        // GET: Transportes
        public async Task<IActionResult> Index()
        {
            IEnumerable<Transporte> lista = await _repository.FindAll();
            var lista_vm = new List<TransporteViewModel>();


            foreach (Transporte t in lista)
            {
                var vm = new TransporteViewModel(t);
                lista_vm.Add(vm);
            }
            return View(lista_vm);
        }

        // GET: Transportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trasnporte = await _repository.Get(id.Value);
            if (trasnporte == null)
            {
                return NotFound();
            }
            trasnporte.Link = await _linkRepository.Get(trasnporte.LinkId);
            TransporteViewModel vm = new TransporteViewModel(trasnporte);

            ViewBag.ImagemPath = vm.ImagemPath;
            ViewBag.Alt = "Não tem imagem associada";
            return View(vm);
        }

        // GET: Transportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transportes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Nome,Url")]  TransporteViewModel vm, IFormFile Imagem)
        {
            Transporte transporte = new Transporte();

            if (ModelState.IsValid && Imagem != null && Imagem.Length > 0 && FilesHelper.VerifyFileSize(Imagem) && FilesHelper.VerifyFileExtension(Imagem.FileName))
            {
                var upload = Path.Combine(_env.WebRootPath, "imagens", "transportes");

                // guardar imagem
                using (var fileStream = new FileStream(Path.Combine(upload, Imagem.FileName), FileMode.Create))
                {
                    await Imagem.CopyToAsync(fileStream);
                }

                transporte.Nome = vm.Nome;
                transporte.Descricao = vm.Descricao;
                transporte.ImagemPath = "\\imagens\\transportes\\" + Imagem.FileName;
                transporte.ImagemUrl = HttpContext.Request.Host.Host + "/imagens/transportes/" + Imagem.FileName;

                // guardar link
                if (vm.Url != null)
                {
                    Link link = new Link { Categoria = Categoria.Transporte, Descricao = vm.Descricao, Url = vm.Url };
                    await _linkRepository.Save(link);
                    transporte.Link = link;
                    transporte.LinkId = link.Id;
                }

                await _repository.Save(transporte);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Transportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporte = await _repository.Get(id.Value);

            if (transporte == null)
            {
                return NotFound();
            }
            transporte.Link = await _linkRepository.Get(transporte.LinkId);
            TransporteViewModel vm = new TransporteViewModel(transporte);

            return View(vm);
        }

        // POST: Transportes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,ImagemPath,ImagemUrl,LinkId,Nome,Url")] TransporteViewModel vm, IFormFile Imagem)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }
            Transporte transporte = await _repository.Get(id);
            if (ModelState.IsValid)
            {
                try
                {
                    // editar imagem
                    if (Imagem != null && Imagem.Length > 0 && FilesHelper.VerifyFileSize(Imagem) && FilesHelper.VerifyFileExtension(Imagem.FileName))
                    {
                        var upload = Path.Combine(_env.WebRootPath, "imagens", "transportes");

                        // guardar imagem tamanho normal
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
                        transporte.ImagemPath = "\\imagens\\transportes\\" + Imagem.FileName;
                        transporte.ImagemUrl = HttpContext.Request.Host.Host + "/imagens/transportes/" + Imagem.FileName;
                    }

                    transporte.Nome = vm.Nome;
                    transporte.Descricao = vm.Descricao;
                    if (vm.Url != null)
                    {
                        Link link = await _linkRepository.Get(transporte.LinkId);
                        link.Descricao = vm.Descricao;
                        link.Url = vm.Url;

                        await _linkRepository.Update(link);

                    }
                    await _repository.Update(transporte);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransporteExists(transporte.Id))
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

        // GET: Transportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporte = await _repository.Get(id.Value);
            if (transporte == null)
            {
                return NotFound();
            }
            var vm = new TransporteViewModel(transporte);
            Link link = await _linkRepository.Get(transporte.LinkId);
            vm.Link = link;
            vm.LinkId = link.Id;

            return View(vm);
        }

        // POST: Transportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transporte = await _repository.Get(id);
            var path = _env.WebRootPath + transporte.ImagemPath;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            await _repository.Delete(transporte);
            Link link = await _linkRepository.Get(transporte.LinkId);
            await _linkRepository.Delete(link);

            return RedirectToAction("Index");
        }

        private bool TransporteExists(int id)
        {
            if (_repository.Get(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
