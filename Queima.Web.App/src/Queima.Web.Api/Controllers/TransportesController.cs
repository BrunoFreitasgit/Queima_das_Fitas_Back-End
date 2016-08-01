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
    [Route("api/Transportes")]
    public class TransportesController : Controller
    {
        public IGenericRepository<Transporte> _repository;
        public IGenericRepository<Link> _linkRepository;


        public TransportesController(IGenericRepository<Transporte> repository, IGenericRepository<Link> linkRepository)
        {
            _repository = repository;
            _linkRepository = linkRepository;
        }

        // GET: api/Transportes
        [HttpGet]
        public async Task<IEnumerable<TransporteViewModel>> GetConcursos()
        {
            IEnumerable<Transporte> lista = await _repository.FindAll();
            IEnumerable<Link> lista_links = await _linkRepository.FindAll();
            var lista_vm = new List<TransporteViewModel>();

            foreach (var concurso in lista)
            {
                concurso.Link = lista_links.Single(l => l.Id == concurso.LinkId);
                var vm = new TransporteViewModel(concurso);
                lista_vm.Add(vm);
            }
            return lista_vm;
        }

        // GET: api/Transportes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransportes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Transporte transporte = await _repository.Get(id);
            Link link = await _linkRepository.Get(transporte.LinkId);
            transporte.Link = link;
            TransporteViewModel vm = new TransporteViewModel(transporte);
            if (transporte == null)
            {
                return NotFound();
            }

            return Ok(vm);
        }
    }
}
