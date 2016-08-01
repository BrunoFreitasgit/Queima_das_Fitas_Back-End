using Microsoft.AspNetCore.Http;
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
        public int Id { get; set; }
        // Nome do Tipo de Transporte (STCP, Metro ou Taxi)
        [Required]
        public TipoTransporte Nome { get; set; }
        public int LinkId { get; set; }
        // Link para informações adicionais
        public Link Link { get; set; }
        // Descrição do serviço de Transporte
        public string Descricao { get; set; }
        // Imagem descritiva do Transporte
        [Required]
        public string ImagemPath { get; set; }
        public string ImagemUrl { get; set; }
        public Transporte()
        {

        }
    }

    // Tipos de Transporte 
    public enum TipoTransporte
    {
        STCP,
        Metro,
        Taxi
    }
}
