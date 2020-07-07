using System;
using System.Collections.Generic;
using System.Text;

namespace Emsoir.Dominio.Entity.ViewModels
{
   public class RollMenuViewModels
    {
        public int RolId { get; set; }
        public int MenuId { get; set; }
        public string Nombre { get; set; }

        public string Css { get; set; }
        public string Flag_Menu { get; set; }
    }
}
