using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emosir.Dominio.Interface;
using Emsoir.Dominio.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Productos.Controllers
{
    public class CategoriaController : Controller
    {
       
        private readonly ICategoriaDominio _Dominio;

        public CategoriaController( ICategoriaDominio Dominio)
        {
            
            _Dominio = Dominio;
        }

        public IActionResult Index()
        {
            var ListaDecategorias = _Dominio.GetList();

            return View(ListaDecategorias);
        }

        public ActionResult Crear()
        {


            return View();
        }
       [HttpPost]
        public ActionResult Crear(Categoria obj)
        {
           

                if (ModelState.IsValid)
                {
                    var respuesta= _Dominio.Add(obj);
                     if(respuesta.IsSuccess)
                       {
                           return RedirectToAction("Index");
                       }
                      else
                       {
                            ViewBag.Respuesta = respuesta;
                       }
                
                  }
           
           
            return View("Crear");
        }

        public IActionResult Editar(int id)
        {
            

            return View();
        }

        [HttpDelete]
        public JsonResult Eliminar(int id)
        {

            var Response = _Dominio.Delete(id);
           
            return Json(Response);
        }
    }
}