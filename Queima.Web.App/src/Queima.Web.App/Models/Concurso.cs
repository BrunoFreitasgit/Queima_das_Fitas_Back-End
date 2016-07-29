using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class Concurso
    {
        // Id do Concurso
        public int Id { get; set; }
        // Tipo de Concurso
        public TipoConcurso TipoConcurso { get; set; }
        // Data de início do Concurso
        [Required]
        public DateTime DataInicio { get; set; }
        // Data de término do Concurso
        [Required]
        public DateTime DataFim { get; set; }
        // Descrição do Concurso (condições, informações, etc)
        [Required]
        public string Descricao { get; set; }
        // Imagem do Concurso
        [Required]
        public string ImagemPath { get; set; }
        public string ImagemUrl { get; set; }
        // Url do Concurso
        public int LinkId { get; set; }
        public Link Link { get; set; }
    }

    public enum TipoConcurso
    {
        Cartaz,
        DJ,
        Bandas,
        Passatempo
    }
}
