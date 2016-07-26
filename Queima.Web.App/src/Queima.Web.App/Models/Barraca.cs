using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class Barraca
    {
        // Id da Barraca
        public int Id { get; set; }
        // Nome da Barraca
        [Required]
        public string Nome { get; set; }
        // Evento do Facebook associado à barraca
        public string FacebookEventUrl { get; set; }
        // Foto da Barraca
        // Imagem teste
        [Required]
        public string ImagemPath { get; set; }

        // Posição da Barraca
        public int PontoInteresseId { get; set; }
        public PontoInteresse PontoInteresse { get; set; }
    }
}
