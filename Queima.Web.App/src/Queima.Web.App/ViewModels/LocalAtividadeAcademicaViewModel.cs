using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Queima.Web.App.Models;

namespace Queima.Web.App.ViewModels
{
    public class LocalAtividadeAcademicaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário indicar um nome para o local")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessário indicar as coordenadas para o local")]
        [RegularExpression("^[-+]?([1-8]?\\d(\\.\\d+)?|90(\\.0+)?),\\s*[-+]?(180(\\.0+)?|((1[0-7]\\d)|([1-9]?\\d))(\\.\\d+)?)$", ErrorMessage = "Coordenadas Inválidas")]        
        public string Latitude { get; set; }
        [Required(ErrorMessage = "É necessário indicar as coordenadas para o local")]
        [RegularExpression("^[-+]?([1-8]?\\d(\\.\\d+)?|90(\\.0+)?),\\s*[-+]?(180(\\.0+)?|((1[0-7]\\d)|([1-9]?\\d))(\\.\\d+)?)$", ErrorMessage = "Coordenadas Inválidas")]
        public string Longitude { get; set; }

        public LocalAtividadeAcademicaViewModel()
        {

        }
        public LocalAtividadeAcademicaViewModel(LocalAtividadeAcademica pt)
        {
            Id = pt.Id;
            Nome = pt.Nome;
            Latitude = pt.Latitude.ToString();
            Longitude = pt.Longitude.ToString();
        }
    }
}
