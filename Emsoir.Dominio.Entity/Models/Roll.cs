using System;
using System.Collections.Generic;
using System.Text;

namespace Emsoir.Dominio.Entity.Models
{
   public class Roll
    {
        [Dapper.Contrib.Extensions.Key]
        public int RolId { get; set; }
        public string Nombre { get; set; }
    }
}
