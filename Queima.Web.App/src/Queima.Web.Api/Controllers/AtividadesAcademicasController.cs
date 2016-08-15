using Microsoft.AspNetCore.Mvc;
using Queima.Web.Api.DTOs;
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
        public async Task<IEnumerable<AtividadeAcademicaDTO>> GetAtividadesAcademicas()
        {
            IEnumerable<AtividadeAcademica> lista = await _repository.FindAll();
            IEnumerable<LocalAtividadeAcademica> lista_locais = await _locaisRepository.FindAll();
            var lista_dto = new List<AtividadeAcademicaDTO>();

            foreach (var atividade in lista)
            {
                atividade.LocalAtividadeAcademica = lista_locais.Single(l => l.Id == atividade.LocalAtividadeAcademicaId);
                var vm = new AtividadeAcademicaDTO(atividade);
                lista_dto.Add(vm);
            }
            return lista_dto;
        }

    }
}
