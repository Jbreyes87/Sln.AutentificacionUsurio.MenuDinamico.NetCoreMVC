using System;
using System.Collections.Generic;
using System.Text;

namespace Emsoir.Dominio.Entity.ViewModels
{
    public class ArticulosViewModel
    {
        
       
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string UrlImagen { get; set; }

        public string NombreCategoria { get; set; }

    }
}
