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
    [Route("api/Media")]
    public class MediaController : Controller
    {
        public IGenericRepository<MediaEdicao> _repository;
        public IGenericRepository<Link> _linkRepository;


        public MediaController(IGenericRepository<MediaEdicao> repository, IGenericRepository<Link> linkRepository)
        {
            _repository = repository;
            _linkRepository = linkRepository;
        }

        // GET: api/Media
        [HttpGet]
        public async Task<IEnumerable<MediaViewModel>> GetConcursos()
        {
            IEnumerable<MediaEdicao> lista = await _repository.FindAll();
            IEnumerable<Link> lista_links = await _linkRepository.FindAll();
            var lista_vm = new List<MediaViewModel>();

            foreach (var media in lista)
            {
                media.Link = lista_links.Single(l => l.Id == media.LinkId);
                var vm = new MediaViewModel(media);
                lista_vm.Add(vm);
            }
            return lista_vm;
        }

        // GET: api/Media/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransportes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MediaEdicao media = await _repository.Get(id);
            Link link = await _linkRepository.Get(media.LinkId);
            media.Link = link;
            MediaViewModel vm = new MediaViewModel(media);
            if (media == null)
            {
                return NotFound();
            }

            return Ok(vm);
        }
    }
}
