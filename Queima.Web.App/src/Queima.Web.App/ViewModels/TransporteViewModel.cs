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
    public class TransporteViewModel
    {
        // Id do Tranporte
        public int Id { get; set; }
        // Nome do Tipo de Transporte (STCP, Metro ou Taxi)
        [Required]
        public TipoTransporte Nome { get; set; }
        public int LinkId { get; set; }
        // Link para informações adicionais
        public Link Link { get; set; }
        public string Url { get; set; }
        // Descrição do serviço de Transporte
        [Required(ErrorMessage = "É necessário indicar uma descrição do transporte")]
        [Display(Name = "Descrição do Transporte (local, horários, etc)")]
        public string Descricao { get; set; }
        // Imagem descritiva do Transporte
        public string ImagemPath { get; set; }
        public string ImagemUrl { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Imagem do(a) Transporte (jpg, png ou jpeg)")]
        [FileExtensions(Extensions = "jpg,png,jpeg")]
        [JsonIgnore]
        public IFormFile Imagem { get; set; }
        public TransporteViewModel(Transporte t)
        {
            Id = t.Id;
            Nome = t.Nome;
            LinkId = t.LinkId;
            Descricao = t.Descricao;
            ImagemPath = t.ImagemPath;
            ImagemUrl = t.ImagemUrl;
            if (t.Link != null)
            {
                Link = t.Link;
                Url = t.Link.Url;
            }
        }
        public TransporteViewModel()
        {

        }
    }

}
