using Queima.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.Api.DTOs
{
    public class AtividadeAcademicaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Preco { get; set; } = "0.00";
        public string Data { get; set; } = string.Empty;
        public string Local { get; set; }
        public double LocalLatitude { get; set; }
        public double LocalLongitude { get; set; }
        public string ImagemUrl { get; set; } = string.Empty;
        public string PontosVenda { get; set; } = string.Empty;

        public AtividadeAcademicaDTO(AtividadeAcademica a)
        {
            Id = a.Id;
            Nome = a.Nome;
            Descricao = a.Descricao;
            Preco = a.Preco.ToString();
            Data = string.Concat(a.Data.Day + "/" + a.Data.Month + "/" + a.Data.Year);
            Local = a.LocalAtividadeAcademica.Nome;
            LocalLatitude = a.LocalAtividadeAcademica.Latitude;
            LocalLongitude = a.LocalAtividadeAcademica.Longitude;
            ImagemUrl = a.ImagemUrl;
            PontosVenda = a.PontosVenda;
        }
    }
}
