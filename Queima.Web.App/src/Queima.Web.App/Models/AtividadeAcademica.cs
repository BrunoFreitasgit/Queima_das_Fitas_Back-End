﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class AtividadeAcademica
    {
        // Id da Atividade Académica
        public int AtividadeAcademicaId { get; set; }
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
        public virtual Imagem Imagem { get; set; }

        // Local da Atividade Académica
        public virtual Local Local { get; set; }
        // Lista de pontos de venda
        public List<PontoVenda> PontosDeVenda { get; set; }

    }
}