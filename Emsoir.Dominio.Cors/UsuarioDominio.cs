using Emosir.Dominio.Interface;
using Emsoir.Dominio.Entity;
using Emsoir.Dominio.Entity.Models;
using Emsoir.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emsoir.Dominio.Cors
{
    public class UsuarioDominio : IUsuarioDominio
    {

        private readonly IUsuarioRepositorio _Irepositorio;
        public UsuarioDominio(IUsuarioRepositorio Irepositorio)
        {
            _Irepositorio = Irepositorio;
         
        }


        public Response<bool> ValidarExistenciaUsuario(string usuario, string password)
        {
            var usu = new Usuario();
            usu.NombreUsuario = usuario;
            usu.Password = password;
            Response<bool> Response = new Response<bool>();

            var Validar = ValidarCampos(usu);
            try
            {
                if (!Validar.IsSuccess)
                {

                    return Validar;
                }
                int cantidad = _Irepositorio.ValidarExistenciaUsuario(usuario,password);
                if (cantidad > 0)
                {
                    Response.IsSuccess = true;
                    Response.Mensaje = "ok!";
                }

            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Mensaje = ex.Message;
            }
            return Response;


        }

        public Response<bool> ValidarCampos(Usuario obj)
        {
            Response<bool> Response = new Response<bool>();
            if (obj.NombreUsuario == "" || obj.Password=="")
            {
                Response.Data = false;
                Response.IsSuccess = false;
                Response.Mensaje = "Debe ingresar todos sus datos!";
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
