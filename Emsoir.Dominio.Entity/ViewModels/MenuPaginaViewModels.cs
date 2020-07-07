using System;
using System.Collections.Generic;
using System.Text;

namespace Emsoir.Dominio.Entity.ViewModels
{
   public class MenuPaginaViewModels
    {
        public int MenuId { get; set; }

        public int PaginaId { get; set; }

        public string Nombre { get; set; }
        public string UrlPagina { get; set; }
        public string Css { get; set; }
    }
}
