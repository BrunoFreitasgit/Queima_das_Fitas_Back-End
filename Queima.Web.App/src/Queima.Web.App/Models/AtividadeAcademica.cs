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
        [Required]
        public string Nome { get; set; }
        // Descrição da Atividade Académica
        [Required]
        public string Descricao { get; set; }
        // Preço da Atividade Académica
        public decimal Preco { get; set; }
        // Data de realização da Atividade Académica
        public DateTime Data { get; set; }
        // Imagem da Atividade Académica
        [Required]
        public string ImagemPath { get; set; }
        // Id do Local de realização da Atividade Académica
        public int PontoInteresseId { get; set; }
        // Local da Atividade Académica
        public PontoInteresse PontoInteresse { get; set; }
        // Lista de pontos de venda

        public List<PontoVenda> PontosVenda { get; set; }

        public AtividadeAcademica()
        {
            PontosVenda = new List<PontoVenda>();
        }
        // Imagem da Atividade Académica
        //public virtual Imagem Imagem { get; set; }

    }
}
