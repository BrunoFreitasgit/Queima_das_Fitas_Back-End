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
using Queima.Web.App.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Queima.Web.App.Controllers
{
    public class ArtistasController : Controller
    {
        public IGenericRepository<Artista> _repository;

        public ArtistasController(IGenericRepository<Artista> repository)
        {
            _repository = repository;
        }

        // GET: Artistas
        public async Task<IActionResult> Index()
        {
            IEnumerable<Artista> lista = await _repository.FindAll();
            var lista_vm = new List<ArtistaViewModel>();

            foreach (Artista a in lista)
            {
                var vm = new ArtistaViewModel(a);
                lista_vm.Add(vm);
            }
            return View(lista_vm);
        }

        // GET: Artistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artista = await _repository.Get(id.Value);
            if (artista == null)
            {
                return NotFound();
            }

            return View(artista);
        }

        // GET: Artistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Biografia,DataAtuacao,FacebookUrl,ImagemPath,Nome,Palco,SpotifyUrl,TwitterUrl")] Artista artista)
        {
            if (ModelState.IsValid)
            {
                await _repository.Save(artista);
                return RedirectToAction("Index");
            }
            return View(artista);
        }

        // GET: Artistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artista = await _repository.Get(id.Value);
            if (artista == null)
            {
                return NotFound();
            }
            return View(artista);
        }

        // POST: Artistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Biografia,DataAtuacao,FacebookUrl,ImagemPath,Nome,Palco,SpotifyUrl,TwitterUrl")] Artista artista)
        {
            if (id != artista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(artista);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistaExists(artista.Id))
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
            return View(artista);
        }

        // GET: Artistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artista = await _repository.Get(id.Value);
            if (artista == null)
            {
                return NotFound();
            }

            return View(artista);
        }

        // POST: Artistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artista = await _repository.Get(id);
            await _repository.Delete(artista);
            
            return RedirectToAction("Index");
        }

        private bool ArtistaExists(int id)
        {
            if(_repository.Get(id) != null)
            {
                return true;
            }
            return false;
        }

        private bool VerifyFileSize(IFormFile file)
        {
            Double fileSize = 0;
            using (var reader = file.OpenReadStream())
            {
                //get filesize in kb
                fileSize = (reader.Length / 1024);
            }

            //filesize less than 1MB => true, else => false
            return (fileSize < 1024) ? true : false;
        }

    }
}
