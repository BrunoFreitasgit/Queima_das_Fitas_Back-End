using Microsoft.AspNetCore.Mvc;
using Queima.Web.App.Interfaces;
using Queima.Web.App.Models;
using Queima.Web.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Concursos")]
    public class ConcursosController : Controller
    {
        public IGenericRepository<Concurso> _repository;
        public IGenericRepository<Link> _linkRepository;


        public ConcursosController(IGenericRepository<Concurso> repository, IGenericRepository<Link> linkRepository)
        {
            _repository = repository;
            _linkRepository = linkRepository;
        }

        // GET: api/Concursos
        [HttpGet]
        public async Task<IEnumerable<ConcursoViewModel>> GetConcursos()
        {
            IEnumerable<Concurso> lista = await _repository.FindAll();
            IEnumerable<Link> lista_links = await _linkRepository.FindAll();
            var lista_vm = new List<ConcursoViewModel>();

            foreach (var concurso in lista)
            {
                concurso.Link = lista_links.Single(l => l.Id == concurso.LinkId);
                var vm = new ConcursoViewModel(concurso);
                lista_vm.Add(vm);
            }
            return lista_vm;
        }

        // GET: api/Concursos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConcursos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Concurso concurso = await _repository.Get(id);
            Link link = await _linkRepository.Get(concurso.LinkId);
            concurso.Link = link;
            ConcursoViewModel vm = new ConcursoViewModel(concurso);
            if (concurso == null)
            {
                return NotFound();
            }

            return Ok(vm);
        }
    }
}
