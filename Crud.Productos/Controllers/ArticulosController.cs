using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Emosir.Dominio.Interface;
using Emsoir.Dominio.Entity;
using Emsoir.Dominio.Entity.Models;
using Emsoir.Dominio.Entity.ViewModels;
using Emsoir.Infraestructura.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Productos.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly IArticuloDominio _Dominio;
        private readonly ICategoriaDominio _DominioCategoria;
        private readonly IWebHostEnvironment _IWebHostEnvironment;


        public ArticulosController(IArticuloDominio Dominio,
            ICategoriaDominio DominioCategoria,
            IWebHostEnvironment IWebHostEnvironment)
        {
            _DominioCategoria = DominioCategoria;
            _Dominio = Dominio;
            _IWebHostEnvironment = IWebHostEnvironment;
        }


        public IActionResult Index()
        {
           
           

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ArticulosViewModelCreate obj = new ArticulosViewModelCreate()
            {
                Articulo = new Articulo(),
                ListaCategorias = _DominioCategoria.GetList()
            };
           

          return View(obj);
        }

        [HttpPost]
        public IActionResult Create(ArticulosViewModelCreate obj) {
            Response<bool> Response = new Response<bool>();
            string RutaPrincipal = _IWebHostEnvironment.WebRootPath;
            var Archivo = HttpContext.Request.Form.Files;
            var Categoria = HttpContext.Request.Form["CategoriaId"].ToString();

            var NombreArchivo = Guid.NewGuid().ToString();
            var RurtaArchivo = Path.Combine(RutaPrincipal, @"imagenes\articulos");
            var Extension = Path.GetExtension(Archivo[0].FileName);


            obj.Articulo.CategoriaId = Convert.ToInt32(Categoria);
            obj.Articulo.FechaCreacion = DateTime.Now;
            obj.Articulo.UrlImagen = @"imagenes\articulos\" + NombreArchivo + Extension;

           
                Response = _Dominio.Add(obj.Articulo);

                if (Response.IsSuccess)
                {


                    if (Directory.Exists(RurtaArchivo))
                    {
                        using (FileStream FileStream = new FileStream(Path.Combine(RurtaArchivo, NombreArchivo + Extension), FileMode.Create))
                        {
                            Archivo[0].CopyTo(FileStream);
                        }

                    }
                    else
                    {
                        Directory.CreateDirectory(RurtaArchivo);
                        using (FileStream FileStream = new FileStream(Path.Combine(RurtaArchivo, NombreArchivo + Extension), FileMode.Create))
                        {
                            Archivo[0].CopyTo(FileStream);
                        }
                    }

                    return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Respuesta = Response;
            }

                
            
         


            return RedirectToAction("Create");
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