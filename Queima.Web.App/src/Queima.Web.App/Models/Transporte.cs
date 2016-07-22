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
        // Lista de links para informações adicionais
        public List<Link> Links { get; set; }
        // Descrição do serviço de Transporte
        public string Descricao { get; set; }
        // Imagem descritiva do Transporte
        [Required]
        public string ImagemPath { get; set; }
        public Transporte()
        {
            Links = new List<Link>();
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
// Imagem teste
//[Required(ErrorMessage = "Please Upload a Valid Image File")]
//[DataType(DataType.Upload)]
//[FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp,svg")]
//public IFormFile ImagemTransporte { get; set; }