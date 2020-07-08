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
            
           
           
            return View();
        }

        public ActionResult CerrarSession()
        {
            HttpContext.Session.SetString("Usuario","");
            HttpContext.Session.SetString("Roll", "");
            HttpContext.Session.SetString("Menus", "");
            HttpContext.Session.SetString("Paginas", "");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ValidarUsuario(Usuario request)
        {
           
            Response<bool> respuesta = new Response<bool>();

            //uni.EncriptarPassword.EncriptarPassword(Contraseña);


            respuesta = _Dominio.ValidarExistenciaUsuario(request.NombreUsuario, request.Password);

            if (respuesta.IsSuccess)
            {
               var obj = _DominioMenu.CargarUsuarioRollMenuDinamico(request.NombreUsuario, request.Password);

                HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(obj.Usuario));
                HttpContext.Session.SetString("Roll", JsonConvert.SerializeObject(obj.Roll));
                HttpContext.Session.SetString("Menus", JsonConvert.SerializeObject(obj.RollMenu));
                HttpContext.Session.SetString("Paginas", JsonConvert.SerializeObject(obj.MenuPagina));

                return Json(respuesta); 
               

            }
           
            return Json(respuesta);

        }



    }
}