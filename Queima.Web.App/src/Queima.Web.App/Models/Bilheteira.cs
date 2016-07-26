using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class Bilheteira
    {
        public int Id { get; set; }
        public List<Bilhete> Bilhetes { get; set; }
        // Condições e informações adicionais
        public string Condicoes { get; set; }

        // Lista de Pontos de Venda
        public List<PontoVenda> PontosVenda { get; set; }

        public Bilheteira()
        {
            PontosVenda = new List<PontoVenda>();
        }
    }
}
