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
        public int Id { get; set; }
        // Nome do Ponto de Venda
        public string Nome { get; set; }
        // Coordenada Latitude do Local
        [Required(ErrorMessage = "Utilize o '.' como caracter de separação")]
        public double Latitude { get; set; }
        // Coordenada Longitude do Local
        [Required(ErrorMessage = "Utilize o '.' como caracter de separação")]
        public double Longitude { get; set; }
        public string Horário { get; set; }
        [Display(Name = "Descrição adicional do Local")]
        public string DescricaoAdicional { get; set; }

        public PontoVenda()
        {

        }
    }
}
