using Emsoir.Dominio.Entity;
using Emsoir.Dominio.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emosir.Dominio.Interface
{
    public interface IProductoDominio
    {
        IEnumerable<Producto> GetList();
        Response<bool> Add(Producto entity);

        Producto GetById(int id);
        Response<bool> Update(Producto entity);
        Response<bool> Delete(int id);

        Response<bool> ValidarProducto(Producto entity);

    }
}
