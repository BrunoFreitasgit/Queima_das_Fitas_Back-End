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
        public List<Link> BilheteiraOnline { get; set; } = new List<Link>();

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 2")]
        public string DataDia2 { get; set; } = string.Empty;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 3")]
        public string DataDia3 { get; set; } = string.Empty;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 4")]
        public string DataDia4 { get; set; } = string.Empty;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 5")]
        public string DataDia5 { get; set; } = string.Empty;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 6")]
        public string DataDia6 { get; set; } = string.Empty;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 7")]
        public string DataDia7 { get; set; } = string.Empty;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dia 8")]
        public string DataDia8 { get; set; } = string.Empty;
        public BilheteiraViewModel()
        {

        }
        public BilheteiraViewModel(Bilheteira b)
        {
            Id = b.Id;
            Bilhetes = b.Bilhetes;
        }
    }
}
