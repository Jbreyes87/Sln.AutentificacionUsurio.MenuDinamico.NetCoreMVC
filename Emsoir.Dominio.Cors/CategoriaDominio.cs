using Emosir.Dominio.Interface;
using Emsoir.Dominio.Entity;
using Emsoir.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emsoir.Dominio.Cors
{
   public class CategoriaDominio: ICategoriaDominio
    {
        private readonly Irepository<Categoria> _Irepository;
        public CategoriaDominio(Irepository<Categoria> Irepository)
        {
            _Irepository = Irepository;
        }


        public Response<bool> Add(Categoria entity)
        {
            Response<bool> Response = new Response<bool>();
            var cantidad = _Irepository.GetList().Where(x => x.Descripcion == entity.Descripcion).Count();
            try
            {
                if (cantidad > 0)
                {
                    Response.IsSuccess = false;
                    Response.Mensaje = "Este Registro ya existe";
                    return Response;
                }
                Response.Data = _Irepository.Add(entity);
                if (Response.Data)
                {
                    Response.IsSuccess = true;
                    Response.Mensaje = "Registro exito!";
                }

            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Mensaje = ex.Message;
            }
            return Response;

        }

        public Response<bool> Delete(int id)
        {
            Response<bool> Response = new Response<bool>();
            var categoria = _Irepository.GetById(id);
            try
            {


                Response.Data = _Irepository.Delete(categoria);
                if (Response.Data)
                {
                    Response.IsSuccess = true;
                    Response.Mensaje = "Eliminacion exito!";
                }

            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Mensaje = ex.Message;
            }
            return Response;
        }

        public Categoria GetById(int id)
        {
            return _Irepository.GetById(id);
        }

        public IEnumerable<Categoria> GetList()
        {
            return _Irepository.GetList();
        }

        public Response<bool> Update(Categoria entity)
        {
            Response<bool> Response = new Response<bool>();

            try
            {

                Response.Data = _Irepository.Update(entity);
                if (Response.Data)
                {
                    Response.IsSuccess = true;
                    Response.Mensaje = "Actualizacion exitosa!";
                }

            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Mensaje = ex.Message;
            }
            return Response;
        }
    }
}
