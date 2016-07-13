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
        public int AtividadeAcademicaId { get; set; }
        [Required]
        [DisplayName("Nome/Título da Atividade Académica")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessária uma descrição textual da Atividade Académica")]
        [DisplayName("Descrição da atividade")]
        public string Descricao { get; set; }
        [Range(0.00, 100.00, ErrorMessage = "Preço tem que estar compreendido entre 0€ e 100€")]
        public decimal Preco { get; set; }
        [Display(Name = "Data de realização da Atividade Académica")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        [Required]
        [DisplayName("Url da imagem")]
        [Url]
        public string ImagemUrl { get; set; }
        [Required]
        [DisplayName("Breve descrição da imagem")]
        public string DescricaoImagem { get; set; }
        [ScaffoldColumn(false)]
        public int ImagemId { get; set; }
        [DisplayName("Local de realização da Atividade Académica")]
        public PontoInteresse Local { get; set; }
        [DisplayName("Pontos de Venda")]
        public List<PontoInteresse> PontosVendaId { get; set; }


        public AtividadeAcademicaViewModel()
        {

        }
    }
}
