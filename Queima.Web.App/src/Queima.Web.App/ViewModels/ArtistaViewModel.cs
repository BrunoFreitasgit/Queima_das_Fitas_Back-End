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
    public class ArtistaViewModel
    {
        // Id do(a) Artista
        public int Id { get; set; }
        // Nome da Banda ou Artista
        [Required]
        public string Nome { get; set; }
        // Biografia do(a) Artista
        [Required]
        [MaxLength(5000)]
        [Display(Name = "Biografia do(a) Artista")]
        public string Biografia { get; set; }
        // Data de atuação do(a) Artista
        [Required]
        [Display(Name = "Dia da atuação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string DataAtuacao { get; set; }
        [Display(Name = "Facebook Url")]
        // Url para Facebook oficial do(a) Artista
        public string FacebookUrl { get; set; }
        [Display(Name = "Twitter Url")]
        // Url para Twitter oficial do(a) Artista
        public string TwitterUrl { get; set; }
        [Display(Name = "Spotify Url")]
        // Url para Spotify oficial do(a) Artista
        public string SpotifyUrl { get; set; }
        // Palco onde o(a) Artista atuará
        [Required]
        public Palco Palco { get; set; }
        // Foto do(a) Artista
        [DataType(DataType.Upload)]
        [Display(Name = "Imagem do(a) Artista (jpg,png ou jpeg)")]
        [FileExtensions(Extensions = "jpg,png,jpeg")]
        [JsonIgnore]
        public IFormFile Imagem { get; set; }
        public string ImagemPath { get; set; }
        public string ImagemUrl { get; set; }
        public ArtistaViewModel(Artista a)
        {
            Id = a.Id;
            Nome = a.Nome;
            Biografia = a.Biografia;
            DataAtuacao = string.Concat(a.DataAtuacao.Day + "/" + a.DataAtuacao.Month + "/" + a.DataAtuacao.Year);
            FacebookUrl = a.FacebookUrl;
            TwitterUrl = a.TwitterUrl;
            SpotifyUrl = a.SpotifyUrl;
            Palco = a.Palco;
            ImagemPath = a.ImagemPath;
            ImagemUrl = a.ImagemUrl;
        }
        public ArtistaViewModel()
        {

        }
    }
}
