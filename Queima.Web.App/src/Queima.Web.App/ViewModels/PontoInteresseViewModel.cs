using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Queima.Web.App.Models;

namespace Queima.Web.App.ViewModels
{
    public class PontoInteresseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Utilize o '.' como caracter de separação")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Utilize o '.' como caracter de separação")]
        public string Longitude { get; set; }
        [Display(Name = "Descrição adicional do Local")]
        public string DescricaoAdicional { get; set; }
        [Required]
        public TipoLocal Tipo { get; set; }

        public PontoInteresseViewModel()
        {

        }
        public PontoInteresseViewModel(PontoInteresse pt)
        {
            Id = pt.Id;
            Nome = pt.Nome;
            Latitude = pt.Latitude.ToString();
            Longitude = pt.Longitude.ToString();
            Tipo = pt.Tipo;
        }
    }
}
