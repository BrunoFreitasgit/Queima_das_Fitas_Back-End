using Microsoft.AspNetCore.Http;
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
        [Display(Name = "Biografia do(a) Artista")]
        public string Biografia { get; set; }
        // Data de atuação do(a) Artista
        [Required]
        [Display(Name = "Dia da atuação")]
        public DateTime DataAtuacao { get; set; }
        [Display(Name = "Link para a página de Facebook do artista")]
        // Url para Facebook oficial do(a) Artista
        public string FacebookUrl { get; set; }
        [Display(Name = "Link para a página do Twitter do artista")]
        // Url para Twitter oficial do(a) Artista
        public string TwitterUrl { get; set; }
        [Display(Name = "Link para a página do Spotify do artista")]
        // Url para Spotify oficial do(a) Artista
        public string SpotifyUrl { get; set; }
        // Palco onde o(a) Artista atuará
        [Required]
        public Palco Palco { get; set; }
        // Foto do(a) Artista
        [Required]
        public IFormFile Imagem { get; set; }
        public string FilePath { get; set; }

        public ArtistaViewModel(Artista a)
        {
            Id = a.Id;
            Nome = a.Nome;
            Biografia = a.Biografia;
            DataAtuacao = a.DataAtuacao;
            FacebookUrl = a.FacebookUrl;
            TwitterUrl = a.TwitterUrl;
            SpotifyUrl = a.SpotifyUrl;
            Palco = a.Palco;
            FilePath = a.ImagemPath;
        }
    }
}
