using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Queima.Web.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.ViewModels
{
    public class MediaViewModel
    {
        // Id do objeto de conteúdos media
        public int Id { get; set; }
        // Ano da edição
        [Required]
        public int Ano { get; set; }
        // Url para Facebook da FAP
        [JsonIgnore]
        public int LinkId { get; set; }
        [JsonIgnore]
        public Link Link { get; set; }
        [Required(ErrorMessage = "Tem que indicar um Url")]
        [Display(Name = "Link para o Álbum de fotos ou vídeo")]
        [Url(ErrorMessage = "Tem que especificar um Url com a indicação do protocolo. i.e.http://www.google.com")]
        public string Url { get; set; }
        // Título
        [Display(Name = "Título do albúm ou video")]
        [StringLength(40)]
        public string Titulo { get; set; }
        // Tipo de media do conteúdo
        [Required]
        public TipoMedia TipoMedia { get; set; }
        [Display(Name = "Ano da Edição")]
        [JsonIgnore]
        public SelectList Edicao { get; set; }
        public MediaViewModel(MediaEdicao m)
        {
            Id = m.Id;
            Ano = m.Ano;
            LinkId = m.LinkId;
            if (m.Link != null)
            {
                Link = m.Link;
                Url = m.Link.Url;
            }
            Titulo = m.Titulo;
            TipoMedia = m.TipoMedia;
            Edicao = new SelectList(Enumerable.Range(2015, DateTime.Now.Year - 2014).Reverse());

        }
        public MediaViewModel()
        {
            Edicao = new SelectList(Enumerable.Range(2015, DateTime.Now.Year - 2014).Reverse());
        }
    }
}
