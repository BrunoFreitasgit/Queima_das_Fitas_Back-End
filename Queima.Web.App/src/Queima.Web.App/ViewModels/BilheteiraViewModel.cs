using Newtonsoft.Json;
using Queima.Web.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.ViewModels
{
    public class BilheteiraViewModel
    {
        public int Id { get; set; }

        [JsonIgnore]
        public List<Bilhete> Bilhetes { get; set; } = new List<Bilhete>();
        [JsonIgnore]
        public Link Link { get; set; }
        [Required(ErrorMessage = "Tem que indicar um Url")]
        [Display(Name = "Link Bilheteira Online")]
        [Url(ErrorMessage = "Tem que especificar um Url com a indicação do protocolo. i.e.http://www.google.com")]
        public string Url { get; set; }
        [JsonIgnore]
        public int LinkId { get; set; }


        [Required]
        [StringLength(500)]
        [Display(Name = "Condições")]
        public string Condicoes { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço Ingresso Semanal")]
        public string PrecoIngressoSemanal { get; set; } = string.Empty;

        // DIA 1
        [Required(ErrorMessage = "Tem que indicar uma data para o bilhete")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 1")]
        public string DataDia1 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço normal")]
        public string PrecoDia1 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia anterior")]
        public string PrecoDiaAnterior1 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia")]
        public string PrecoNoDia1 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia fora de horas (e.g. depois das 21:30)")]
        public string PrecoNoDiaForaHoras1 { get; set; } = "0.00";

        // DIA 2
        [Required(ErrorMessage = "Tem que indicar uma data para o bilhete")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 2")]
        public string DataDia2 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço normal")]
        public string PrecoDia2 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia anterior")]
        public string PrecoDiaAnterior2 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia")]
        public string PrecoNoDia2 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia fora de horas (e.g. depois das 21:30)")]
        public string PrecoNoDiaForaHoras2 { get; set; } = "0.00";

        // DIA 3
        [Required(ErrorMessage = "Tem que indicar uma data para o bilhete")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 3")]
        public string DataDia3 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço normal")]
        public string PrecoDia3 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia anterior")]
        public string PrecoDiaAnterior3 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia")]
        public string PrecoNoDia3 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia fora de horas (e.g. depois das 21:30)")]
        public string PrecoNoDiaForaHoras3 { get; set; } = "0.00";

        // DIA 4
        [Required(ErrorMessage = "Tem que indicar uma data para o bilhete")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 4")]
        public string DataDia4 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço normal")]
        public string PrecoDia4 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia anterior")]
        public string PrecoDiaAnterior4 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia")]
        public string PrecoNoDia4 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia fora de horas (e.g. depois das 21:30)")]
        public string PrecoNoDiaForaHoras4 { get; set; } = "0.00";

        // DIA 5
        [Required(ErrorMessage = "Tem que indicar uma data para o bilhete")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 5")]
        public string DataDia5 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço normal")]
        public string PrecoDia5 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia anterior")]
        public string PrecoDiaAnterior5 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia")]
        public string PrecoNoDia5 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia fora de horas (e.g. depois das 21:30)")]
        public string PrecoNoDiaForaHoras5 { get; set; } = "0.00";

        // DIA 6
        [Required(ErrorMessage = "Tem que indicar uma data para o bilhete")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 6")]
        public string DataDia6 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço normal")]
        public string PrecoDia6 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia anterior")]
        public string PrecoDiaAnterior6 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia")]
        public string PrecoNoDia6 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia fora de horas (e.g. depois das 21:30)")]
        public string PrecoNoDiaForaHoras6 { get; set; } = "0.00";

        // DIA 7
        [Required(ErrorMessage = "Tem que indicar uma data para o bilhete")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 7")]
        public string DataDia7 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço normal")]
        public string PrecoDia7 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia anterior")]
        public string PrecoDiaAnterior7 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia")]
        public string PrecoNoDia7 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia fora de horas (e.g. depois das 21:30)")]
        public string PrecoNoDiaForaHoras7 { get; set; } = "0.00";

        // DIA 8
        [Required(ErrorMessage = "Tem que indicar uma data para o bilhete")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 8")]
        public string DataDia8 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço normal")]
        public string PrecoDia8 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia anterior")]
        public string PrecoDiaAnterior8 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia")]
        public string PrecoNoDia8 { get; set; } = "0.00";
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço no dia fora de horas (e.g. depois das 21:30)")]
        public string PrecoNoDiaForaHoras8 { get; set; } = "0.00";



        [Required(ErrorMessage = "Tem que indicar um Url")]
        [Display(Name = "Link Bilheteira Online")]
        [Url(ErrorMessage = "Tem que especificar um Url com a indicação do protocolo. i.e.http://www.google.com")]
        public string LinkDia1 { get; set; }
        [Required(ErrorMessage = "Tem que indicar um Url")]
        [Display(Name = "Link Bilheteira Online")]
        [Url(ErrorMessage = "Tem que especificar um Url com a indicação do protocolo. i.e.http://www.google.com")]
        public string LinkDia2 { get; set; }
        [Required(ErrorMessage = "Tem que indicar um Url")]
        [Display(Name = "Link Bilheteira Online")]
        [Url(ErrorMessage = "Tem que especificar um Url com a indicação do protocolo. i.e.http://www.google.com")]
        public string LinkDia3 { get; set; }
        [Required(ErrorMessage = "Tem que indicar um Url")]
        [Display(Name = "Link Bilheteira Online")]
        [Url(ErrorMessage = "Tem que especificar um Url com a indicação do protocolo. i.e.http://www.google.com")]
        public string LinkDia4 { get; set; }
        [Required(ErrorMessage = "Tem que indicar um Url")]
        [Display(Name = "Link Bilheteira Online")]
        [Url(ErrorMessage = "Tem que especificar um Url com a indicação do protocolo. i.e.http://www.google.com")]
        public string LinkDia5 { get; set; }
        [Required(ErrorMessage = "Tem que indicar um Url")]
        [Display(Name = "Link Bilheteira Online")]
        [Url(ErrorMessage = "Tem que especificar um Url com a indicação do protocolo. i.e.http://www.google.com")]
        public string LinkDia6 { get; set; }
        [Required(ErrorMessage = "Tem que indicar um Url")]
        [Display(Name = "Link Bilheteira Online")]
        [Url(ErrorMessage = "Tem que especificar um Url com a indicação do protocolo. i.e.http://www.google.com")]
        public string LinkDia7 { get; set; }
        [Required(ErrorMessage = "Tem que indicar um Url")]
        [Display(Name = "Link Bilheteira Online")]
        [Url(ErrorMessage = "Tem que especificar um Url com a indicação do protocolo. i.e.http://www.google.com")]
        public string LinkDia8 { get; set; }

        public BilheteiraViewModel()
        {

        }
        public BilheteiraViewModel(Bilheteira d)
        {
            Id = d.Id;
            Condicoes = d.Condicoes;
            Link = d.Link;
            Url = d.Link.Url;
            LinkId = d.LinkId.Value;
            PrecoIngressoSemanal = d.PrecoIngressoSemanal.ToString();
            Bilhetes = d.Bilhetes;

            DataDia1 = string.Concat(Bilhetes.ElementAt(0).Data.Day + "/" + Bilhetes.ElementAt(0).Data.Month + "/" + Bilhetes.ElementAt(0).Data.Year);
            PrecoDia1 = Bilhetes.ElementAt(0).PrecoNormal.ToString();
            PrecoDiaAnterior1 = Bilhetes.ElementAt(0).PrecoDiaAnterior.ToString();
            PrecoNoDia1 = Bilhetes.ElementAt(0).PrecoNoDia.ToString();
            PrecoNoDiaForaHoras1 = Bilhetes.ElementAt(0).PrecoNoDiaForaHoras.ToString();
            LinkDia1 = Bilhetes.ElementAt(0).Link.Url;

            DataDia2 = string.Concat(Bilhetes.ElementAt(1).Data.Day + "/" + Bilhetes.ElementAt(1).Data.Month + "/" + Bilhetes.ElementAt(1).Data.Year);
            PrecoDia2 = Bilhetes.ElementAt(1).PrecoNormal.ToString();
            PrecoDiaAnterior2 = Bilhetes.ElementAt(1).PrecoDiaAnterior.ToString();
            PrecoNoDia2 = Bilhetes.ElementAt(1).PrecoNoDia.ToString();
            PrecoNoDiaForaHoras2 = Bilhetes.ElementAt(1).PrecoNoDiaForaHoras.ToString();
            LinkDia2 = Bilhetes.ElementAt(1).Link.Url;

            DataDia3 = string.Concat(Bilhetes.ElementAt(2).Data.Day + "/" + Bilhetes.ElementAt(2).Data.Month + "/" + Bilhetes.ElementAt(2).Data.Year);
            PrecoDia3 = Bilhetes.ElementAt(2).PrecoNormal.ToString();
            PrecoDiaAnterior3 = Bilhetes.ElementAt(2).PrecoDiaAnterior.ToString();
            PrecoNoDia3 = Bilhetes.ElementAt(2).PrecoNoDia.ToString();
            PrecoNoDiaForaHoras3 = Bilhetes.ElementAt(2).PrecoNoDiaForaHoras.ToString();
            LinkDia3 = Bilhetes.ElementAt(2).Link.Url;

            DataDia4 = string.Concat(Bilhetes.ElementAt(3).Data.Day + "/" + Bilhetes.ElementAt(3).Data.Month + "/" + Bilhetes.ElementAt(3).Data.Year);
            PrecoDia4 = Bilhetes.ElementAt(3).PrecoNormal.ToString();
            PrecoDiaAnterior4 = Bilhetes.ElementAt(0).PrecoDiaAnterior.ToString();
            PrecoNoDia4 = Bilhetes.ElementAt(3).PrecoNoDia.ToString();
            PrecoNoDiaForaHoras4 = Bilhetes.ElementAt(3).PrecoNoDiaForaHoras.ToString();
            LinkDia4 = Bilhetes.ElementAt(3).Link.Url;

            DataDia5 = string.Concat(Bilhetes.ElementAt(4).Data.Day + "/" + Bilhetes.ElementAt(4).Data.Month + "/" + Bilhetes.ElementAt(4).Data.Year);
            PrecoDia5 = Bilhetes.ElementAt(4).PrecoNormal.ToString();
            PrecoDiaAnterior5 = Bilhetes.ElementAt(4).PrecoDiaAnterior.ToString();
            PrecoNoDia5 = Bilhetes.ElementAt(4).PrecoNoDia.ToString();
            PrecoNoDiaForaHoras5 = Bilhetes.ElementAt(4).PrecoNoDiaForaHoras.ToString();
            LinkDia5 = Bilhetes.ElementAt(4).Link.Url;

            DataDia6 = string.Concat(Bilhetes.ElementAt(5).Data.Day + "/" + Bilhetes.ElementAt(5).Data.Month + "/" + Bilhetes.ElementAt(5).Data.Year);
            PrecoDia6 = Bilhetes.ElementAt(5).PrecoNormal.ToString();
            PrecoDiaAnterior6 = Bilhetes.ElementAt(5).PrecoDiaAnterior.ToString();
            PrecoNoDia6 = Bilhetes.ElementAt(5).PrecoNoDia.ToString();
            PrecoNoDiaForaHoras6 = Bilhetes.ElementAt(5).PrecoNoDiaForaHoras.ToString();
            LinkDia6 = Bilhetes.ElementAt(5).Link.Url;

            DataDia7 = string.Concat(Bilhetes.ElementAt(6).Data.Day + "/" + Bilhetes.ElementAt(6).Data.Month + "/" + Bilhetes.ElementAt(6).Data.Year);
            PrecoDia7 = Bilhetes.ElementAt(6).PrecoNormal.ToString();
            PrecoDiaAnterior7 = Bilhetes.ElementAt(6).PrecoDiaAnterior.ToString();
            PrecoNoDia7 = Bilhetes.ElementAt(6).PrecoNoDia.ToString();
            PrecoNoDiaForaHoras7 = Bilhetes.ElementAt(6).PrecoNoDiaForaHoras.ToString();
            LinkDia7 = Bilhetes.ElementAt(6).Link.Url;

            DataDia8 = string.Concat(Bilhetes.ElementAt(7).Data.Day + "/" + Bilhetes.ElementAt(7).Data.Month + "/" + Bilhetes.ElementAt(7).Data.Year);
            PrecoDia8 = Bilhetes.ElementAt(7).PrecoNormal.ToString();
            PrecoDiaAnterior8 = Bilhetes.ElementAt(7).PrecoDiaAnterior.ToString();
            PrecoNoDia8 = Bilhetes.ElementAt(7).PrecoNoDia.ToString();
            PrecoNoDiaForaHoras8 = Bilhetes.ElementAt(7).PrecoNoDiaForaHoras.ToString();
            LinkDia8 = Bilhetes.ElementAt(7).Link.Url;
        }
    }
}
