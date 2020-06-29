using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Emsoir.Dominio.Entity.Models
{
   public class Producto
    {

        [Key]
        [Required]
        [Display(Name = "Producto Id")]
        public int ProductoId { get; set; }
        [MaxLength(30)]
        [Required]
       
        public string Codigo { get; set; }
        [MaxLength(150)]
        [Required]
      
        public string Nombre { get; set; }
        [MaxLength(150)]
        [Required]
       
        public string Modelo { get; set; }
        [Required]
   
        public decimal Costo { get; set; }
        [Required]
        [Display(Name = "Precio Venta")]
        public decimal PrecioVenta { get; set; }

        [Display(Name = "Cantidad Minima")]
        public int? CantidadMinima { get; set; }

        [Display(Name = "Stock")]
        public int? Stock { get; set; }
        [MaxLength]
        public byte[] Imgen { get; set; }

        public bool? Estado { get; set; }
        [Required]
    
        public int CategoriaId { get; set; }
    }
}
