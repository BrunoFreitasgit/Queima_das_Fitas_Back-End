using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class Artista
    {
        // Id do(a) Artista
        public int Id { get; set; }
        // Nome da Banda ou Artista
        [Required]
        public string Nome { get; set; }
        // Biografia do(a) Artista
        public string  Biografia { get; set; }
        // Data de atuação do(a) Artista
        public DateTime DataAtuacao { get; set; }
        // Url para Facebook oficial do(a) Artista
        public string FacebookUrl { get; set; }
        // Url para Twitter oficial do(a) Artista
        public string  TwitterUrl { get; set; }
        // Url para Spotify oficial do(a) Artista
        public string SpotifyUrl { get; set; }
        // Palco onde o(a) Artista atuará
        [Required]
        public Palco Palco { get; set; }
        // Foto do(a) Artista
        [Required]
        public string ImagemPath { get; set; }

    }

    // Palcos existentes
    public enum Palco
    {
        PalcoPrincipal,
        Disoteca
    }
}
