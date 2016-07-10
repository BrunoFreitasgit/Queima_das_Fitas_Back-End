using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Models
{
    public class MediaEdicao
    {
        // Id do objeto de conteúdos media
        public int MediaEdicaoId { get; set; }
        // Ano da edição
        [Required]
        public int Ano { get; set; }
        // Url para Facebook da FAP
        [Required]
        public string Url { get; set; }
        // Tipo de media do conteúdo
        [Required]
        public TipoMedia TipoMedia { get; set; }
    }

    public enum TipoMedia
    {
        Foto,
        Video
    }
}
