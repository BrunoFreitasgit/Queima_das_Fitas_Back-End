using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class AtividadeAcademica
    {
        // Id da Atividade Académica
        public int Id { get; set; }
        // Nome da Atividade Académica
        public string Nome { get; set; } = string.Empty;
        // Descrição da Atividade Académica
        public string Descricao { get; set; } = string.Empty;
        // Preço da Atividade Académica
        public decimal Preco { get; set; } = decimal.Zero;
        // Data de realização da Atividade Académica
        public DateTime Data { get; set; }
        // Url da imagem
        public string ImagemUrl { get; set; } = string.Empty;
        // Imagem da Atividade Académica
        public string ImagemPath { get; set; } = string.Empty;
        // Id do Local de realização da Atividade Académica
        public int LocalAtividadeAcademicaId { get; set; }
        // Local da Atividade Académica
        public LocalAtividadeAcademica LocalAtividadeAcademica { get; set; }

        // Lista de pontos de venda
        public string PontosVenda { get; set; } = string.Empty;

        public AtividadeAcademica()
        {

        }
    }
}
