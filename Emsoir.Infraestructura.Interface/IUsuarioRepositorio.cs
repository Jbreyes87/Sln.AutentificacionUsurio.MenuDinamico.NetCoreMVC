using System;
using System.Collections.Generic;
using System.Text;

namespace Emsoir.Infraestructura.Interface
{
    public  interface IUsuarioRepositorio
    {
        int ValidarExistenciaUsuario(string usuario,string password);
    }
}
