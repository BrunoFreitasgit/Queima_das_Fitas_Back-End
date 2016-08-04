using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessária uma descrição textual da Atividade Académica")]
        [Display(Name = "Descrição da atividade")]
        public string Descricao { get; set; }

        [Range(0.00, 100.00, ErrorMessage = "Preço tem que estar compreendido entre 0€ e 100€")]
        public decimal Preco { get; set; }

        [Display(Name = "Data de realização da Atividade Académica")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O ficheiro não é válido")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg,png,jpeg")]
        public IFormFile Imagem { get; set; }


        public int SelectedLocalId { get; set; }
        [Display(Name = "Local de realização da Atividade Académica")]
        public LocalAtividadeAcademica SelectedLocal { get; set; }

        [Display(Name = "Pontos de Venda")]
        public int[] SelectedPontosVenda { get; set; }

        public List<LocalAtividadeAcademica> PontosInteresse { get; set; }

        public AtividadeAcademicaViewModel()
        {

        }
        public AtividadeAcademicaViewModel(AtividadeAcademica atividade)
        {
            Id = atividade.Id;
            Nome = atividade.Nome;
            Descricao = atividade.Descricao;
            Preco = atividade.Preco;
            Data = atividade.Data;
            SelectedLocalId = atividade.LocalAtividadeAcademicaId;

            if (atividade.LocalAtividadeAcademica != null)
            {
                SelectedLocal = atividade.LocalAtividadeAcademica;
            }
        }
    }
}
