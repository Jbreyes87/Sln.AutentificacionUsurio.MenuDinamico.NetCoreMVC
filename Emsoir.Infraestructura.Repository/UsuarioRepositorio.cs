using Emsoir.Infraestructura.Interface;
using Emsoir.Transversal.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Emsoir.Dominio.Entity.Models;

namespace Emsoir.Infraestructura.Repository
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private IConectionFactory _ConectionFactory;
        public UsuarioRepositorio(IConectionFactory ConectionFactory)
        {
            _ConectionFactory = ConectionFactory;
        }


        public int ValidarExistenciaUsuario(string usuario, string password)
        {


            string sql = @"select * from Tbl_Usuarios";

            using (var conn = _ConectionFactory.GetConection)
            {

                var Cantidad = conn.Query<Usuario>(sql).ToList().Where(x => x.NombreUsuario==usuario && x.Password==password).Count();
                return Cantidad;
            }
        }
    }
}
