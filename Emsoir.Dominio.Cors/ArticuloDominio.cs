using Emosir.Dominio.Interface;
using Emsoir.Dominio.Entity;
using Emsoir.Dominio.Entity.Models;
using Emsoir.Dominio.Entity.ViewModels;
using Emsoir.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emsoir.Dominio.Cors
{
   public class ArticuloDominio:IArticuloDominio
    {

        private readonly Irepository<Articulo> _Irepository;
        private readonly IArticuloRepositorio _IArticulo;
        public ArticuloDominio(Irepository<Articulo> Irepository, IArticuloRepositorio IArticulo)
        {
            _Irepository = Irepository;
            _IArticulo = IArticulo;
        }


        public Response<bool> Add(Articulo entity)
        {
            Response<bool> Response = new Response<bool>();
            var Validar = ValidarArticulo(entity);
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

        public Articulo GetById(int id)
        {
            return _Irepository.GetById(id);
        }

        public IEnumerable<Articulo> GetList()
        {
            return _Irepository.GetList();
        }

        public List<ArticulosViewModel> GetListArticulos()
        {
            return _IArticulo.GetListArticulos();
        }

        public Response<bool> Update(Articulo entity)
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

        public Response<bool> ValidarArticulo(Articulo obj)
        {
            Response<bool> Response = new Response<bool>();
            if ( obj.Nombre=="")
            {
                Response.Data = false;
                Response.IsSuccess = false;
                Response.Mensaje = "Debe ingresar todos sus datos!";
                return Response;
            }
       
            else if (_Irepository.GetList().Where(x => x.Nombre == obj.Nombre).Count() > 0)
            {
                Response.Data = false;
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
