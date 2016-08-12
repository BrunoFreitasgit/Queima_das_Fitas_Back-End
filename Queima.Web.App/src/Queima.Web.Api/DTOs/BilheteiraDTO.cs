using Queima.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.Api.DTOs
{
    public class BilheteiraDTO
    {
        public int Id { get; set; }
        public List<BilheteDTO> Bilhetes { get; set; } = new List<BilheteDTO>();
        public string Condicoes { get; set; }
        public string PrecoIngressoSemanal { get; set; }
        public string IngressoSemanalUrl { get; set; }

        public BilheteiraDTO(Bilheteira bilheteira)
        {
            Id = bilheteira.Id;
            if(bilheteira.Bilhetes != null)
            {
                foreach (var bilhete in bilheteira.Bilhetes)
                {
                    Bilhetes.Add(new BilheteDTO(bilhete));
                }
            }
            Condicoes = bilheteira.Condicoes;
            PrecoIngressoSemanal = bilheteira.PrecoIngressoSemanal.ToString();
            IngressoSemanalUrl = bilheteira.Link.Url;
        }
    }

    public class BilheteDTO
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string PrecoNormal { get; set; }
        public string PrecoDiaAnterior { get; set; }
        public string PrecoNoDia { get; set; }
        public string PrecoNoDiaForaHoras { get; set; }
        public string BilheteiraOnlineUrl { get; set; }

        public BilheteDTO(Bilhete bilhete)
        {
            Id = bilhete.Id;
            Data = string.Concat(bilhete.Data.Day + "/" + bilhete.Data.Month + "/" + bilhete.Data.Year);
            PrecoNormal = bilhete.PrecoNormal.ToString();
            PrecoDiaAnterior = bilhete.PrecoDiaAnterior.ToString();
            PrecoNoDia = bilhete.PrecoNoDia.ToString();
            PrecoNoDiaForaHoras = bilhete.PrecoNoDiaForaHoras.ToString();
            BilheteiraOnlineUrl = bilhete.Link.Url;
        }
    }
}
