using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class Transporte
    {
        // Id do Tranporte
        public int TransporteId { get; set; }
        // Nome do Tipo de Transporte (STCP, Metro ou Taxi)
        [Required]
        public TipoTransporte Nome { get; set; }
        // Lista de links para informações adicionais
        public List<Link> Links { get; set; }
        // Descrição do serviço de Transporte
        public string Descricao { get; set; }
        // Imagem descritiva do Transporte
        public virtual Imagem Imagem { get; set; }
    }

    // Tipos de Transporte 
    public enum TipoTransporte
    {
        STCP,
        Metro,
        Taxi
    }
}
