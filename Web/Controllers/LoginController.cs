using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using AngleSharp.Io;
using Emosir.Dominio.Interface;
using Emsoir.Dominio.Entity;
using Emsoir.Dominio.Entity.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioDominio _Dominio;
        private readonly IUsuarioRollManuDinamicoDominio _DominioMenu;
        public LoginController(IUsuarioDominio Dominio, IUsuarioRollManuDinamicoDominio DominioMenu)
        {
            _Dominio = Dominio;
            _DominioMenu = DominioMenu;
        }
        
    
        public IActionResult Index()
        {
            Usuario obj = new Usuario();
            obj.NombreUsuario = "john";
            obj.Password = "john12";
            //SetObject("Usuario", obj);
            //SetObject("Roll", "omar");
            HttpContext.Session.SetString("gay", JsonConvert.SerializeObject(obj));
           
            
            

            return View();
        }
    

        [HttpPost]
        public IActionResult ValidarUsuario(Usuario request)
        {
           
            Response<bool> respuesta = new Response<bool>();

            //uni.EncriptarPassword.EncriptarPassword(Contraseña);


            respuesta = _Dominio.ValidarExistenciaUsuario(request.NombreUsuario, request.Password);

            if (respuesta.IsSuccess)
            {
               var obj = _DominioMenu.CargarUsuarioRollMenuDinamico(request.NombreUsuario, request.Password);

                 


                return RedirectToAction("Index","PaginaPrincipal");
               

            }
           
            return Json(respuesta);

        }



    }
}