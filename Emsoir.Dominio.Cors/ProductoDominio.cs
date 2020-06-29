using Emosir.Dominio.Interface;
using Emsoir.Dominio.Entity;
using Emsoir.Dominio.Entity.Models;
using Emsoir.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emsoir.Dominio.Cors
{
   public class ProductoDominio:IProductoDominio
    {

        private readonly Irepository<Producto> _Irepository;
        public ProductoDominio(Irepository<Producto> Irepository)
        {
            _Irepository = Irepository;
        }


        public Response<bool> Add(Producto entity)
        {
            Response<bool> Response = new Response<bool>();
            var Validar = ValidarProducto(entity);
            try
            {
                if (!Validar.IsSuccess)
                {

                    return Validar;
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
                    Response.Mensaje = "Eliminacion exitosa!";
                }

            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Mensaje = ex.Message;
            }
            return Response;
        }

        public Producto GetById(int id)
        {
            return _Irepository.GetById(id);
        }

        public IEnumerable<Producto> GetList()
        {
            return _Irepository.GetList();
        }

        public Response<bool> Update(Producto entity)
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

        public Response<bool> ValidarProducto(Producto obj)
        {
            Response<bool> Response = new Response<bool>();
            if (obj.Codigo== "" || obj.Costo==0 || obj.CantidadMinima==0 || obj.Nombre=="" || obj.Modelo=="")
            {
                Response.Data = false;
                Response.IsSuccess = false;
                Response.Mensaje = "Debe ingresar todos sus datos!";
                return Response;
            }
            else if (_Irepository.GetList().Where(x => x.Codigo == obj.Codigo).Count() > 0)
            {
                Response.IsSuccess = false;
                Response.Mensaje = "Este Registro ya existe";
                return Response;
            }
            else
            {
                Response.IsSuccess = true;
                Response.Mensaje = "ok";
                return Response;
            }



        }
    }
}
