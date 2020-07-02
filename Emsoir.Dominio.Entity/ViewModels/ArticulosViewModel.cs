using Emsoir.Dominio.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Emsoir.Dominio.Entity.ViewModels
{
    public class ArticulosViewModel
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string UrlImagen { get; set; }

        public string NombreCategoria { get; set; }

    }

    public class ArticulosViewModelCreate
    {

        public Articulo Articulo { get; set; }

        public IEnumerable<Categoria> ListaCategorias { get; set; }

    }
}
