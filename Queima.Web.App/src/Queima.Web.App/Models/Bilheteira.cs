using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class Bilheteira
    {
        public int Id { get; set; }
        public List<Bilhete> Bilhetes { get; set; } = new List<Bilhete>();
        // Condições e informações adicionais
        public string Condicoes { get; set; } = string.Empty;

        // Preço do Ingresso Semanal
        public decimal PrecoIngressoSemanal { get; set; } = 0;

        public Bilheteira()
        {

        }
    }
}
