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
    [Route("api/AtividadesAcademicas")]
    public class AtividadesAcademicasController : Controller
    {
        public IGenericRepository<AtividadeAcademica> _repository;
        public IGenericRepository<LocalAtividadeAcademica> _locaisRepository;

        public AtividadesAcademicasController(IGenericRepository<AtividadeAcademica> repository, IGenericRepository<LocalAtividadeAcademica> locaisRepository)
        {
            _repository = repository;
            _locaisRepository = locaisRepository;
        }

        // GET: api/AtividadesAcademicas
        [HttpGet]
        public async Task<IEnumerable<AtividadeAcademicaViewModel>> GetConcursos()
        {
            IEnumerable<AtividadeAcademica> lista = await _repository.FindAll();
            IEnumerable<LocalAtividadeAcademica> lista_locais = await _locaisRepository.FindAll();
            var lista_vm = new List<AtividadeAcademicaViewModel>();

            foreach (var atividade in lista)
            {
                atividade.LocalAtividadeAcademica = lista_locais.Single(l => l.Id == atividade.LocalAtividadeAcademicaId);
                var vm = new AtividadeAcademicaViewModel(atividade);
                lista_vm.Add(vm);
            }
            return lista_vm;
        }

    }
}
