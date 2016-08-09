using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Queima.Web.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.ViewModels
{
    public class ConcursoViewModel
    {
        // Id do Concurso
        public int Id { get; set; }
        // Tipo de Concurso
        [Display(Name = "Tipo de Concurso")]
        public TipoConcurso TipoConcurso { get; set; }
        // Data de início do Concurso
        [Required(ErrorMessage = "É necessário indicar uma data de início")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de início do concurso")]
        public string DataInicio { get; set; }
        // Data de término do Concurso
        [Required(ErrorMessage = "É necessário indicar uma data de fim")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de fim do concurso")]
        public string DataFim { get; set; }
        // Descrição do Concurso (condições, informações, etc)
        [Required(ErrorMessage = "É necessário indicar uma descrição do concurso")]
        [Display(Name = "Descrição do Concurso")]
        public string Descricao { get; set; }
        // Imagem do Concurso
        public string ImagemPath { get; set; }
        public string ImagemUrl { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Imagem do Concurso (jpg, png ou jpeg)")]
        [FileExtensions(Extensions = "jpg,png,jpeg")]
        [JsonIgnore]
        public IFormFile Imagem { get; set; }

        // Url do Concurso
        public int LinkId { get; set; }
        public Link Link { get; set; }
        [Display(Name = "Url do concurso (Facebook Link)")]
        public string Url { get; set; }


        public ConcursoViewModel(Concurso c)
        {
            Id = c.Id;
            TipoConcurso = c.TipoConcurso;
            DataInicio = string.Concat(c.DataInicio.Day + "/" + c.DataInicio.Month + "/" + c.DataInicio.Year);
            DataFim = string.Concat(c.DataFim.Day + "/" + c.DataFim.Month + "/" + c.DataFim.Year);
            Descricao = c.Descricao;
            ImagemPath = c.ImagemPath;
            ImagemUrl = c.ImagemUrl;
            LinkId = c.LinkId;
            if (c.Link != null)
            {
                Link = c.Link;
                Url = c.Link.Url;
            }

        }
        public ConcursoViewModel()
        {

        }
    }

}
