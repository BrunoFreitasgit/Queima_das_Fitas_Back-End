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
    [Route("api/Bilheteira")]
    public class BilheteiraController : Controller
    {
        public IGenericRepository<Bilheteira> _repository;
        public IGenericRepository<Link> _linksRepository;
        public IGenericRepository<Bilhete> _bilhetesRepository;

        public BilheteiraController(IGenericRepository<Bilheteira> repository, IGenericRepository<Link> linkRepository, IGenericRepository<Bilhete> bilhetesRepository)
        {
            _repository = repository;
            _linksRepository = linkRepository;
            _bilhetesRepository = bilhetesRepository;
        }

        // GET: api/Bilheteira
        [HttpGet]
        public async Task<BilheteiraViewModel> GetBilheteira()
        {
            IEnumerable<Bilheteira> bilheteiras = await _repository.FindAll();
            IEnumerable<Link> links = await _linksRepository.FindAll();
            IEnumerable<Bilhete> bilhetes = await _bilhetesRepository.FindAll();
            Bilheteira bilheteira = bilheteiras.FirstOrDefault();
            BilheteiraViewModel b = new BilheteiraViewModel(bilheteira);

            return b;
        }
    }
}
