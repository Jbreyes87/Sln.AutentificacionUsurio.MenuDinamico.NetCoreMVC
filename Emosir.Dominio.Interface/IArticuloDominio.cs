using Emsoir.Dominio.Entity;
using Emsoir.Dominio.Entity.Models;
using Emsoir.Dominio.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emosir.Dominio.Interface
{
    public interface IArticuloDominio
    {
        IEnumerable<Articulo> GetList();
        Response<bool> Add(Articulo entity);

        Articulo GetById(int id);
        Response<bool> Update(Articulo entity);
        Response<bool> Delete(int id);

        Response<bool> ValidarArticulo(Articulo entity);

        List<ArticulosViewModel> GetListArticulos();

    }
}
