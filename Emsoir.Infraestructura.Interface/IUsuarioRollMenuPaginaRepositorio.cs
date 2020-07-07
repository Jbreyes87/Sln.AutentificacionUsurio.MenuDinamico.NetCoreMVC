using Emsoir.Dominio.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emsoir.Infraestructura.Interface
{
   public interface IUsuarioRollMenuPaginaRepositorio
    {
        UsuarioMenuViewModels CargarUsuarioRollMenuDinamico(string nombre, string contraseña);
    }
}
