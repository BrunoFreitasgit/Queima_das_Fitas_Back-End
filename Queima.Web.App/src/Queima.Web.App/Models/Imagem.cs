using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class Imagem
    {
        // Id da Imagem
        public int ImagemId { get; set; }
        // URL da Imagem
        public string URL { get; set; }
        // Array de bytes para guardar a Imagem
        public byte[] ImagemData { get; set; }
        // Descrição da Imagem
        public string Descricao { get; set; }
    }
}
