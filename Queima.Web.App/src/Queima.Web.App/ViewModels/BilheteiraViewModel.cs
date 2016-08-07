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

        public List<Bilhete> Bilhetes { get; set; } = new List<Bilhete>();

        [Required]
        [StringLength(500)]
        [Display(Name = "Condições")]
        public string Condicoes { get; set; } = string.Empty;

        [RegularExpression("^[0-9][0-9]?([,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço Ingresso Semanal")]
        public string PrecoIngressoSemanal { get; set; } = string.Empty;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 1")]
        public string DataDia1 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([.,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço")]
        public string PrecoDia1 { get; set; } = "0.00";

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 2")]
        public string DataDia2 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([.,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço")]
        public string PrecoDia2 { get; set; } = "0.00";

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 3")]
        public string DataDia3 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([.,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço")]
        public string PrecoDia3 { get; set; } = "0.00";

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 4")]
        public string DataDia4 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([.,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço")]
        public string PrecoDia4 { get; set; } = "0.00";

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 5")]
        public string DataDia5 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([.,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço")]
        public string PrecoDia5 { get; set; } = "0.00";

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 6")]
        public string DataDia6 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([.,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço")]
        public string PrecoDia6 { get; set; } = "0.00";

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 7")]
        public string DataDia7 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([.,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço")]
        public string PrecoDia7 { get; set; } = "0.00";

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 8")]
        public string DataDia8 { get; set; } = string.Empty;
        [Required(ErrorMessage = "Tem que indicar um preço para o bilhete")]
        [RegularExpression("^[0-9][0-9]?([.,][0-9]{1,3})?$", ErrorMessage = "Preço tem que estar compreendido entre 0€ e 99€")]
        [Display(Name = "Preço")]
        public string PrecoDia8 { get; set; } = "0.00";



        public BilheteiraViewModel()
        {

        }
        public BilheteiraViewModel(Bilheteira d)
        {
            Id = d.Id;
            Condicoes = d.Condicoes;
            PrecoIngressoSemanal = d.PrecoIngressoSemanal.ToString();
            Bilhetes = d.Bilhetes;

            DataDia1 = string.Concat(Bilhetes.ElementAt(0).Data.Day + "/" + Bilhetes.ElementAt(0).Data.Month + "/" + Bilhetes.ElementAt(0).Data.Year);
            PrecoDia1 = Bilhetes.ElementAt(0).PrecoNormal.ToString();

            DataDia2 = string.Concat(Bilhetes.ElementAt(1).Data.Day + "/" + Bilhetes.ElementAt(1).Data.Month + "/" + Bilhetes.ElementAt(1).Data.Year);
            PrecoDia2 = Bilhetes.ElementAt(1).PrecoNormal.ToString();

            DataDia3 = string.Concat(Bilhetes.ElementAt(2).Data.Day + "/" + Bilhetes.ElementAt(2).Data.Month + "/" + Bilhetes.ElementAt(2).Data.Year);
            PrecoDia3 = Bilhetes.ElementAt(2).PrecoNormal.ToString();

            DataDia4 = string.Concat(Bilhetes.ElementAt(3).Data.Day + "/" + Bilhetes.ElementAt(3).Data.Month + "/" + Bilhetes.ElementAt(3).Data.Year);
            PrecoDia4 = Bilhetes.ElementAt(3).PrecoNormal.ToString();

            DataDia5 = string.Concat(Bilhetes.ElementAt(4).Data.Day + "/" + Bilhetes.ElementAt(4).Data.Month + "/" + Bilhetes.ElementAt(4).Data.Year);
            PrecoDia5 = Bilhetes.ElementAt(4).PrecoNormal.ToString();

            DataDia6 = string.Concat(Bilhetes.ElementAt(5).Data.Day + "/" + Bilhetes.ElementAt(5).Data.Month + "/" + Bilhetes.ElementAt(5).Data.Year);
            PrecoDia6 = Bilhetes.ElementAt(5).PrecoNormal.ToString();

            DataDia7 = string.Concat(Bilhetes.ElementAt(6).Data.Day + "/" + Bilhetes.ElementAt(6).Data.Month + "/" + Bilhetes.ElementAt(6).Data.Year);
            PrecoDia7 = Bilhetes.ElementAt(6).PrecoNormal.ToString();

            DataDia8 = string.Concat(Bilhetes.ElementAt(7).Data.Day + "/" + Bilhetes.ElementAt(7).Data.Month + "/" + Bilhetes.ElementAt(7).Data.Year);
            PrecoDia8 = Bilhetes.ElementAt(7).PrecoNormal.ToString();


        }
    }
}
