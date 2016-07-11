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
        public int ConcursoId { get; set; }
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
        public virtual Imagem Imagem { get; set; }
        // Url do Concurso
        public virtual Link WebLink { get; set; }
    }

    public enum TipoConcurso
    {
        Cartaz,
        DJ,
        Bandas,
        Passatempo
    }
}
