using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emsoir.Dominio.Entity.Models;
using Emsoir.Dominio.Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class PaginaPrincipalController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario"));
            ViewBag.Roll = JsonConvert.DeserializeObject<Roll>(HttpContext.Session.GetString("Roll"));
            ViewBag.Menu = JsonConvert.DeserializeObject<List<RollMenuViewModels>>(HttpContext.Session.GetString("Menus"));
            ViewBag.Paginas = JsonConvert.DeserializeObject<List<MenuPaginaViewModels>>(HttpContext.Session.GetString("Paginas"));
            ViewBag.vacio = null;

            if (ViewBag.usuario.NombreUsuario == null)
            {

                return RedirectToAction("Index", "Login");

            }

            return View();
        }
    }
}