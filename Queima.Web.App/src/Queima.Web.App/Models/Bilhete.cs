using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class Bilhete
    {
        // Id do Bilhete
        public int BilheteId { get; set; }
        // Dia do evento para qual o bilhete é destinado
        [Required]
        public DateTime Data { get; set; }
        // Preço nos dias que antecedem o evento
        [Required]
        public decimal PrecoNormal { get; set; }
        // Preço no dia anterior ao evento
        [Required]
        public decimal PrecoDiaAnterior { get; set; }
        // Preço no dia do evento
        [Required]
        public decimal PrecoNoDia { get; set; }
        // Preço no dia após certa hora (e.g após as 2:00h da manhã)
        [Required]
        public decimal PrecoNoDiaForaHoras { get; set; }
        // Link para bilheteira online 
        public Link LinkBilheteira { get; set; }
        // Condições e informações adicionais
        public string Condicoes { get; set; }
    }
}
