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
    [Route("api/Artistas")]
    public class ArtistasController : Controller
    {
        public IGenericRepository<Artista> _repository;

        public ArtistasController(IGenericRepository<Artista> repository)
        {
            _repository = repository;
        }

        // GET: api/Artistas
        [HttpGet]
        public async Task<IEnumerable<ArtistaViewModel>> GetArtistas()
        {
            IEnumerable<Artista> lista = await _repository.FindAll();
            var lista_vm = new List<ArtistaViewModel>();

            foreach (var artista in lista)
            {
                var vm = new ArtistaViewModel(artista);
                lista_vm.Add(vm);
            }
            return lista_vm;
        }

        // GET: api/Artistas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtista([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Artista artista = await _repository.Get(id);
            ArtistaViewModel vm = new ArtistaViewModel(artista);
            if (artista == null)
            {
                return NotFound();
            }

            return Ok(vm);
        }
    }
}
