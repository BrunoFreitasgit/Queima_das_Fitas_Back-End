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
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using System.IO;

namespace Queima.Web.App.Controllers
{
    public class ArtistasController : Controller
    {
        public IGenericRepository<Artista> _repository;
        private IHostingEnvironment _env;

        public ArtistasController(IGenericRepository<Artista> repository, IHostingEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        // GET: Artistas
        public async Task<IActionResult> Index()
        {
            IEnumerable<Artista> lista = await _repository.FindAll();
            var lista_vm = new List<ArtistaViewModel>();
            // TODO Adicionar URL ao viewmodel para a API
            var s = HttpContext.Request.ToString();
            //**************
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
            ArtistaViewModel vm = new ArtistaViewModel(artista);
            ViewBag.FilePath = vm.FilePath;
            ViewBag.Alt = vm.Nome;
            return View(vm);
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
        public async Task<IActionResult> Create([Bind("Id,Biografia,DataAtuacao,FacebookUrl,Nome,Palco,SpotifyUrl,TwitterUrl,FilePath")] ArtistaViewModel vm, IFormFile Imagem)
        {
            Artista new_artista = new Artista();
            if (ModelState.IsValid && Imagem != null && Imagem.Length > 0 && VerifyFileSize(Imagem) && VerifyFileExtension(Imagem.FileName))
            {
                var upload = Path.Combine(_env.WebRootPath, "imagens", "artistas");

                // guardar imagem
                using (var fileStream = new FileStream(Path.Combine(upload, Imagem.FileName), FileMode.Create))
                {
                    await Imagem.CopyToAsync(fileStream);
                }

                new_artista.Nome = vm.Nome;
                new_artista.Biografia = vm.Biografia;
                new_artista.DataAtuacao = DateTime.Parse(vm.DataAtuacao);
                new_artista.FacebookUrl = vm.FacebookUrl;
                new_artista.TwitterUrl = vm.TwitterUrl;
                new_artista.SpotifyUrl = vm.SpotifyUrl;
                new_artista.Palco = vm.Palco;
                new_artista.ImagemPath = "\\imagens\\artistas\\" + Imagem.FileName;
                await _repository.Save(new_artista);

                return RedirectToAction("Index");
            }
            return View(vm);
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

            var vm = new ArtistaViewModel(artista);

            return View(vm);
        }

        // POST: Artistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Biografia,DataAtuacao,FacebookUrl,Nome,Palco,SpotifyUrl,TwitterUrl,FilePath")] ArtistaViewModel vm, IFormFile Imagem)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }
            Artista artista = await _repository.Get(id);
            if (ModelState.IsValid)
            {
                try
                {
                    // editar imagem
                    if (Imagem != null && Imagem.Length > 0 && VerifyFileSize(Imagem) && VerifyFileExtension(Imagem.FileName))
                    {
                        var upload = Path.Combine(_env.WebRootPath, "imagens", "artistas");

                        // guardar imagem
                        using (var fileStream = new FileStream(Path.Combine(upload, Imagem.FileName), FileMode.Create))
                        {
                            await Imagem.CopyToAsync(fileStream);
                        }
                        // apagar imagem antiga
                        var path = _env.WebRootPath + vm.FilePath;
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        artista.ImagemPath = "\\imagens\\artistas\\" + Imagem.FileName;
                    }



                    artista.Nome = vm.Nome;
                    artista.Biografia = vm.Biografia;
                    artista.DataAtuacao = DateTime.Parse(vm.DataAtuacao);
                    artista.FacebookUrl = vm.FacebookUrl;
                    artista.TwitterUrl = vm.TwitterUrl;
                    artista.SpotifyUrl = vm.SpotifyUrl;
                    artista.Palco = vm.Palco;

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
            var vm = new ArtistaViewModel(artista);

            return View(vm);
        }

        // POST: Artistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artista = await _repository.Get(id);
            var path = _env.WebRootPath + artista.ImagemPath;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            await _repository.Delete(artista);

            return RedirectToAction("Index");
        }

        private bool ArtistaExists(int id)
        {
            if (_repository.Get(id) != null)
            {
                return true;
            }
            return false;
        }


        // TODO MUDAR DE SITIO
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
        private bool VerifyFileExtension(string path)
        {
            var AllowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
            return AllowedExtensions.Contains(Path.GetExtension(path));
        }

    }
}
