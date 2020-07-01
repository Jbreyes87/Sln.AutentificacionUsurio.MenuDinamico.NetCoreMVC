using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emosir.Dominio.Interface;
using Emsoir.Infraestructura.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Productos.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly IArticuloDominio _Dominio;
      
   
        public ArticulosController(IArticuloDominio Dominio)
        {
            //_DominioArtciculo = DominioArtciculo;
            _Dominio = Dominio;
        }


        public IActionResult Index()
        {
           
           

            return View();
        }



        #region WebApi

        [HttpGet]
        public IActionResult GetList()
        {

            var lis = _Dominio.GetListArticulos();

            return Json(new { data = _Dominio.GetListArticulos()});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            

            return Json(_Dominio.Delete(id));
        }

     

        #endregion



    }
}