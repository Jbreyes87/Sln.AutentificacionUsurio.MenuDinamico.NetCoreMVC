using System;
using System.Collections.Generic;
using System.Text;

namespace Emsoir.Dominio.Entity.Models
{
   public class Pagina
    {
        [Dapper.Contrib.Extensions.Key]
        public int PaginaId { get; set; }
        public string Nombre { get; set; }
        public string UrlPagina { get; set; }
        public string Css { get; set; }
    }
}
