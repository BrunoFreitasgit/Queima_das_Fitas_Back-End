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
using ImageProcessorCore;

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
            IEnumerable<LocalAtividadeAcademica> locais = await _locaisRepository.FindAll();
            var lista_vm = new List<AtividadeAcademicaViewModel>();


            foreach (AtividadeAcademica a in lista)
            {
                var vm = new AtividadeAcademicaViewModel(a);
                var local = locais.Where(l=> l.Id == vm.SelectedLocalId).Single();
                vm.SelectedLocal = local;
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
            var locais = await _locaisRepository.FindAll();
            AtividadeAcademicaViewModel vm = new AtividadeAcademicaViewModel(atividadeAcademica);

            ViewBag.ImagemPath = vm.ImagemPath;
            ViewBag.Alt = "Não tem imagem associada";

            return View(vm);
        }

        // GET: AtividadesAcademicas/Create
        public async Task<IActionResult> Create()
        {
            var lista_locais = await _locaisRepository.FindAll();

            ViewBag.LocalAtividadeAcademicaId = new SelectList(lista_locais, "Id", "Nome");
            return View();
        }

        // POST: AtividadesAcademicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Descricao,SelectedLocalId,Nome,PontosVenda,Preco")] AtividadeAcademicaViewModel vm, IFormFile Imagem)
        {

            if (ModelState.IsValid && Imagem != null && Imagem.Length > 0 && FilesHelper.VerifyFileSize(Imagem) && FilesHelper.VerifyFileExtension(Imagem.FileName))
            {
                var atividade = new AtividadeAcademica();
                var upload = Path.Combine(_env.WebRootPath, "imagens", "atividades");

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

                atividade.Data = DateTime.Parse(vm.Data);
                atividade.Descricao = vm.Descricao;
                atividade.Nome = vm.Nome;
                atividade.Preco = Convert.ToDecimal(vm.Preco);
                atividade.PontosVenda = vm.PontosVenda;
                atividade.ImagemPath = "\\imagens\\atividades\\" + Imagem.FileName;
                atividade.ImagemUrl = HttpContext.Request.Host.Host + "/imagens/atividades/" + Imagem.FileName;
                var local = await _locaisRepository.Get(vm.SelectedLocalId);

                if (local != null)
                {
                    atividade.LocalAtividadeAcademicaId = vm.SelectedLocalId;
                    atividade.LocalAtividadeAcademica = local;
                }


                await _repository.Save(atividade);
                return RedirectToAction("Index");
            }

            var lista_locais = await _locaisRepository.FindAll();

            ViewBag["LocalAtividadeAcademicaId"] = new SelectList(lista_locais, "Id", "Nome");
            return View(vm);
        }

        // GET: AtividadesAcademicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            var lista_locais = await _locaisRepository.FindAll();

            ViewBag.LocalAtividadeAcademicaId = new SelectList(lista_locais, "Id", "Nome", vm.SelectedLocalId);

            return View(vm);
        }

        // POST: AtividadesAcademicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Descricao,SelectedLocalId,Nome,PontosVenda,Preco,ImagemUrl,ImagemPath")] AtividadeAcademicaViewModel vm, IFormFile Imagem)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }
            var atividade = await _repository.Get(id);
            if (ModelState.IsValid)
            {
                try
                {
                    // editar imagem
                    if (Imagem != null && Imagem.Length > 0 && FilesHelper.VerifyFileSize(Imagem) && FilesHelper.VerifyFileExtension(Imagem.FileName))
                    {
                        var upload = Path.Combine(_env.WebRootPath, "imagens", "atividades");

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
                        var tb_path = _env.WebRootPath + "\\imagens\\atividades\\" + Path.GetFileNameWithoutExtension(atividade.ImagemPath);
                        tb_path += "_tb.jpg";
                        if (System.IO.File.Exists(path) && System.IO.File.Exists(tb_path))
                        {
                            System.IO.File.Delete(path);
                            System.IO.File.Delete(tb_path);
                        }
                        atividade.ImagemPath = "\\imagens\\atividades\\" + Imagem.FileName;
                        atividade.ImagemUrl = HttpContext.Request.Host.Host + "/imagens/atividades/" + Imagem.FileName;
                    }

                    atividade.Data = DateTime.Parse(vm.Data);
                    atividade.Descricao = vm.Descricao;
                    atividade.Nome = vm.Nome;
                    atividade.Preco = Convert.ToDecimal(vm.Preco);
                    atividade.PontosVenda = vm.PontosVenda;
                    var local = await _locaisRepository.Get(vm.SelectedLocalId);

                    if (local != null)
                    {
                        atividade.LocalAtividadeAcademicaId = vm.SelectedLocalId;
                        atividade.LocalAtividadeAcademica = local;
                    }
                    await _repository.Update(atividade);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtividadeAcademicaExists(vm.Id))
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
            var lista_locais = await _locaisRepository.FindAll();
            ViewBag.LocalAtividadeAcademicaId = new SelectList(lista_locais, "Id", "Nome", vm.SelectedLocalId);

            return View(vm);
        }

        // GET: AtividadesAcademicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
            var local = await _locaisRepository.Get(atividadeAcademica.LocalAtividadeAcademicaId);
            vm.SelectedLocal = local;

            return View(vm);
        }

        // POST: AtividadesAcademicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atividade = await _repository.Get(id);
            var path = _env.WebRootPath + atividade.ImagemPath;
            var tb_path = _env.WebRootPath + "\\imagens\\atividades\\" + Path.GetFileNameWithoutExtension(atividade.ImagemPath);
            tb_path += "_tb.jpg";
            if (System.IO.File.Exists(path) && System.IO.File.Exists(tb_path))
            {
                System.IO.File.Delete(path);
                System.IO.File.Delete(tb_path);
            }
            await _repository.Delete(atividade);

            return RedirectToAction("Index");
        }

        private bool AtividadeAcademicaExists(int id)
        {
            if (_repository.Get(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
