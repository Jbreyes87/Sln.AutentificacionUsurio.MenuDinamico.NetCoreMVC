using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Emsoir.Dominio.Entity.Models
{
   public class Articulo
    {

        [Dapper.Contrib.Extensions.Key]
   
        public int ArticuloId { get; set; }
     
        [MaxLength(150)]
        [Required(ErrorMessage ="el nombre es obligatorio")]
        public string Nombre { get; set; }

        [MaxLength(300)]
        [Required(ErrorMessage = "la descripcion es obligatorio")]
        public string Descripcion { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public string FechaCreacion { get; set; }

      
       

        public string UrlImagen { get; set; }

        public int CategoriaId { get; set; }
    }
}
