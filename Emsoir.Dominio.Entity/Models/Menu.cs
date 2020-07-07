using System;
using System.Collections.Generic;
using System.Text;

namespace Emsoir.Dominio.Entity.Models
{
    public class Menu
    {
        [Dapper.Contrib.Extensions.Key]
        public int MenuId { get; set; }
        public string Nombre { get; set; }
        public string Css { get; set; }
        public string Flag_Menu { get; set; }
    }
}
