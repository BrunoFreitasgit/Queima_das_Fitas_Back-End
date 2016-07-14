using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class Link
    {
        // Id do Link
        public int Id { get; set; }
        // Url do link
        [Required]
        public string Url { get; set; }
        // Descricao do link
        [Required]
        public string Descricao { get; set; }
        // Categoria do Link
        [Required]
        public Categoria Categoria { get; set; }
    }

    public enum Categoria
    {
        Bilheteira,
        Informacao,
        Transporte,
        Social,
        Media,
        Concurso,
        Cartaz,
    }
}
