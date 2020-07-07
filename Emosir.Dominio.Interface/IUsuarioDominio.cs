using Emsoir.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emosir.Dominio.Interface
{
   public interface IUsuarioDominio
    {
        Response<bool> ValidarExistenciaUsuario(string usuario, string password);
    }
}
