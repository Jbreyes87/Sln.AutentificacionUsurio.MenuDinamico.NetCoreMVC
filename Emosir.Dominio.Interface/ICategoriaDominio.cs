using Emsoir.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emosir.Dominio.Interface
{
   public interface ICategoriaDominio
    {
        IEnumerable<Categoria> GetList();
        Response<bool> Add(Categoria entity);

        Categoria GetById(int id);
        Response<bool> Update(Categoria entity);
        Response<bool> Delete(int id);

        Response<bool> ValidarCategoria(Categoria entity);
    }
}
