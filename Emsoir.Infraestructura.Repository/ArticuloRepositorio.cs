using Dapper;
using Emsoir.Dominio.Entity.ViewModels;
using Emsoir.Infraestructura.Interface;
using Emsoir.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emsoir.Infraestructura.Repository
{
    public class ArticuloRepositorio : IArticuloRepositorio
    {
        private IConectionFactory _ConectionFactory;
        public ArticuloRepositorio(IConectionFactory ConectionFactory)
        {
            _ConectionFactory = ConectionFactory;
        }


        public List<ArticulosViewModel> GetListArticulos()
        {
            string sql= @"select b.ArticuloId as Id, b.Nombre,b.Descripcion,b.FechaCreacion,b.UrlImagen,a.Descripcion as NombreCategoria from Categorias a 
                         join Articulos b on a.CategoriaId = b.CategoriaId";

            using (var conn = _ConectionFactory.GetConection)
            {
                var Articulos = conn.Query<ArticulosViewModel>(sql).ToList();
                return Articulos;
            }
        }
    }
}
