using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Queima.Web.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.ViewModels
{
    public class AtividadeAcademicaViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome/Título da Atividade Académica")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "É necessária uma descrição da Atividade Académica")]
        [Display(Name = "Descrição da Atividade")]
        [StringLength(400)]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^[0-9][0-9]?([.,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço")]
        public string Preco { get; set; } = "0.00";

        [Required(ErrorMessage = "É necessário indicar uma data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de realização")]
        public string Data { get; set; } = string.Empty;

        [DataType(DataType.Upload)]
        [Display(Name = "Imagem do Concurso (jpg, png ou jpeg)")]
        [FileExtensions(Extensions = "jpg,png,jpeg")]
        [JsonIgnore]
        public IFormFile Imagem { get; set; }


        public int SelectedLocalId { get; set; }
        [Display(Name = "Local de realização da Atividade Académica")]
        public LocalAtividadeAcademica SelectedLocal { get; set; }

        public string ImagemPath { get; set; }
        public string ImagemUrl { get; set; }

        public List<LocalAtividadeAcademica> PontosInteresse { get; set; }

        public AtividadeAcademicaViewModel()
        {

        }

        public AtividadeAcademicaViewModel(AtividadeAcademica atividade)
        {
            Id = atividade.Id;
            Nome = atividade.Nome;
            Descricao = atividade.Descricao;
            Preco = atividade.Preco.ToString();
            Data = string.Concat(atividade.Data.Day + "/" + atividade.Data.Month + "/" + atividade.Data.Year);
            SelectedLocalId = atividade.LocalAtividadeAcademicaId;

            if (atividade.LocalAtividadeAcademica != null)
            {
                SelectedLocal = atividade.LocalAtividadeAcademica;
            }
        }
    }
}
