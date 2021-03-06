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
using Queima.Web.App.Helpers;
using ImageProcessorCore;

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
            ViewBag.FilePath = vm.ImagemPath;
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
            if (ModelState.IsValid && Imagem != null && Imagem.Length > 0 && FilesHelper.VerifyFileSize(Imagem) && FilesHelper.VerifyFileExtension(Imagem.FileName))
            {
                var upload = Path.Combine(_env.WebRootPath, "imagens", "artistas");

                // guardar imagem
                using (var fileStream = new FileStream(Path.Combine(upload, Imagem.FileName), FileMode.Create))
                {
                    await Imagem.CopyToAsync(fileStream);
                }
                // guardar imagem thumbnail
                var thumbnail = Path.GetFileNameWithoutExtension(Path.Combine(upload, Imagem.FileName));
                thumbnail += "_tb";
                using (var stream = new FileStream(Path.Combine(upload, Imagem.FileName), FileMode.Open))
                using (var output = new FileStream(Path.Combine(upload, thumbnail + ".jpg"), FileMode.OpenOrCreate))
                {
                    Image image = new Image(stream);
                    image.Resize(image.Width / 2, image.Height / 2)
                         .Save(output);
                }

                new_artista.Nome = vm.Nome;
                new_artista.Biografia = vm.Biografia;
                new_artista.DataAtuacao = DateTime.Parse(vm.DataAtuacao);
                new_artista.FacebookUrl = vm.FacebookUrl;
                new_artista.TwitterUrl = vm.TwitterUrl;
                new_artista.SpotifyUrl = vm.SpotifyUrl;
                new_artista.Palco = vm.Palco;
                new_artista.ImagemPath = "\\imagens\\artistas\\" + Imagem.FileName;
                new_artista.ImagemUrl = HttpContext.Request.Host.Host + "/imagens/artistas/" + Imagem.FileName;
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Biografia,DataAtuacao,FacebookUrl,Nome,Palco,SpotifyUrl,TwitterUrl,ImagemPath,ImagemUrl")] ArtistaViewModel vm, IFormFile Imagem)
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
                    if (Imagem != null && Imagem.Length > 0 && FilesHelper.VerifyFileSize(Imagem) && FilesHelper.VerifyFileExtension(Imagem.FileName))
                    {
                        var upload = Path.Combine(_env.WebRootPath, "imagens", "artistas");

                        // guardar imagem tamanho normal
                        using (var fileStream = new FileStream(Path.Combine(upload, Imagem.FileName), FileMode.Create))
                        {
                            await Imagem.CopyToAsync(fileStream);
                        }
                        // guardar imagem thumbnail
                        var thumbnail = Path.GetFileNameWithoutExtension(Path.Combine(upload, Imagem.FileName));
                        thumbnail += "_tb";
                        using (var stream = new FileStream(Path.Combine(upload, Imagem.FileName), FileMode.Open))
                        using (var output = new FileStream(Path.Combine(upload, thumbnail + ".jpg"), FileMode.OpenOrCreate))
                        {
                            Image image = new Image(stream);
                            image.Resize(image.Width / 2, image.Height / 2)
                                 .Save(output);
                        }

                        // apagar imagem antiga
                        var path = _env.WebRootPath + vm.ImagemPath;
                        var tb_path = _env.WebRootPath + "\\imagens\\artistas\\" + Path.GetFileNameWithoutExtension(artista.ImagemPath);
                        tb_path += "_tb.jpg";
                        if (System.IO.File.Exists(path) && System.IO.File.Exists(tb_path))
                        {
                            System.IO.File.Delete(path);
                            System.IO.File.Delete(tb_path);
                        }
                        artista.ImagemPath = "\\imagens\\artistas\\" + Imagem.FileName;
                        artista.ImagemUrl = HttpContext.Request.ToString() + "/imagens/artistas/" + Imagem.FileName;
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
            return View(vm);
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
    }
}
