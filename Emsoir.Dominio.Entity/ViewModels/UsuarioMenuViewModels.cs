using Emsoir.Dominio.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emsoir.Dominio.Entity.ViewModels
{
   public class UsuarioMenuViewModels
    {

        public Usuario Usuario { get; set; } = new Usuario();
        public Roll Roll { get; set; } = new Roll();

        public List<RollMenuViewModels> RollMenu { get; set; }

        public List<MenuPaginaViewModels> MenuPagina { get; set; }



    }
}
