using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class PontoVenda
    {
        // Id do Ponto de Venda
        public int PontoVendaId { get; set; }
        // Nome do Ponto de Venda
        [Required]
        public string Nome { get; set; }
        // Descrição do Ponto de Venda (Horário, como chegar, etc)
        public string Descricao { get; set; }

        // Local do Ponto de Venda
        public virtual Local Local { get; set; }
    }
}
