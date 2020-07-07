using Emsoir.Dominio.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emosir.Dominio.Interface
{
   public interface IUsuarioRollManuDinamicoDominio
    {
        UsuarioMenuViewModels CargarUsuarioRollMenuDinamico(string nombre, string contraseña);
    }
}
