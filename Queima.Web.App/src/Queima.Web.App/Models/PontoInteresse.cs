using Queima.Web.App.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Queima.Web.App.Models
{
    public class PontoInteresse
    {
        // Id do Local
        public int Id { get; set; }
        // Nome/Rua do local
        [Required]
        public string Nome { get; set; }
        // Coordenada Latitude do Local
        [Required(ErrorMessage = "Utilize o '.' como caracter de separação")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "Utilize o '.' como caracter de separação")]
        // Coordenada Longitude do Local
        public double Longitude { get; set; }
        // Nome da rua completa ou outro texto descritivo do local
        [Display(Name = "Descrição adicional do Local")]
        public string DescricaoAdicional { get; set; }
        public TipoLocal Tipo { get; set; }

        public PontoInteresse()
        {

        }

    }

    public enum TipoLocal
    {
        [Display(Name = "Local Simples")]
        LocalSimples,
        [Display(Name = "Ponto de Venda")]
        PontoDeVenda,
        [Display(Name = "Barraca")]
        Barraca,
        [Display(Name = "Atividade Académica")]
        AtividadeAcademica
    }
}
