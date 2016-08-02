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
    public class MediaEdicoesController : Controller
    {
        public IGenericRepository<MediaEdicao> _repository;
        public IGenericRepository<Link> _linkRepository;

        public MediaEdicoesController(IGenericRepository<MediaEdicao> repository, IGenericRepository<Link> linkRepo)
        {
            _repository = repository;
            _linkRepository = linkRepo;
        }

        // GET: MediaEdicoes
        public async Task<IActionResult> Index()
        {
            IEnumerable<MediaEdicao> lista = await _repository.FindAll();
            IEnumerable<Link> listaLinks = await _linkRepository.FindAll();
            var lista_vm = new List<MediaViewModel>();


            foreach (MediaEdicao m in lista)
            {
                var link = listaLinks.Single(l => l.Id == m.LinkId);
                m.Link = link;
                var vm = new MediaViewModel(m);
                lista_vm.Add(vm);
            }
            return View(lista_vm);
        }

        // GET: MediaEdicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var media = await _repository.Get(id.Value);
            if (media == null)
            {
                return NotFound();
            }
            media.Link = await _linkRepository.Get(media.LinkId);
            MediaViewModel vm = new MediaViewModel(media);

            return View(vm);
        }

        // GET: MediaEdicoes/Create
        public IActionResult Create()
        {
            MediaViewModel vm = new MediaViewModel();
            return View(vm);
        }

        // POST: MediaEdicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ano,TipoMedia,Titulo,Url")]  MediaViewModel vm)
        {
            if (ModelState.IsValid && vm.Url.Length > 0)
            {
                MediaEdicao media = new MediaEdicao();
                media.Ano = vm.Ano;
                media.TipoMedia = vm.TipoMedia;
                media.Titulo = vm.Titulo;

                Link link = new Link { Categoria = Categoria.Media, Descricao = vm.Titulo, Url = vm.Url };
                await _linkRepository.Save(link);
                media.Link = link;
                media.LinkId = link.Id;


                await _repository.Save(media);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: MediaEdicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _repository.Get(id.Value);

            if (media == null)
            {
                return NotFound();
            }
            media.Link = await _linkRepository.Get(media.LinkId);
            MediaViewModel vm = new MediaViewModel(media);

            return View(vm);
        }

        // POST: MediaEdicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ano,LinkId,TipoMedia,Titulo,Url")] MediaViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    MediaEdicao edicao = await _repository.Get(id);
                    edicao.Ano = vm.Ano;
                    edicao.TipoMedia = vm.TipoMedia;
                    edicao.Titulo = vm.Titulo;

                    if (vm.Url != null)
                    {
                        Link link = await _linkRepository.Get(edicao.LinkId);
                        link.Descricao = vm.Titulo;
                        link.Url = vm.Url;

                        await _linkRepository.Update(link);

                    }
                    await _repository.Update(edicao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaEdicaoExists(vm.Id))
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

        // GET: MediaEdicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _repository.Get(id.Value);

            if (media == null)
            {
                return NotFound();
            }
            var link = await _linkRepository.Get(media.LinkId);
            media.Link = link;
            var vm = new MediaViewModel(media);
            ViewBag.Url = vm.Url;
            return View(vm);
        }

        // POST: MediaEdicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaEdicao = await _repository.Get(id);
            var link = await _linkRepository.Get(mediaEdicao.LinkId);
            await _repository.Delete(mediaEdicao);
            await _linkRepository.Delete(link);
            return RedirectToAction("Index");
        }

        private bool MediaEdicaoExists(int id)
        {
            if (_repository.Get(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
