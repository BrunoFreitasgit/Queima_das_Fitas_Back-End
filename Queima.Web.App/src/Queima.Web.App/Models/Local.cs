using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class Local
    {
        // Id do Local
        public int LocalId { get; set; }
        // Nome/Rua do local
        [Required]
        public string Nome { get; set; }
        // Coordenada Latitude do Local
        public double Latitude { get; set; }
        // Coordenada Longitude do Local
        public double Longitude { get; set; }
    }
}
