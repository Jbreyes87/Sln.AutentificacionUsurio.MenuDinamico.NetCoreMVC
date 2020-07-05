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
            obj.Articulo.FechaCreacion = DateTime.Now.ToString();
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



            obj.ListaCategorias = _DominioCategoria.GetList();
           
            return View(obj);
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
            string RutaPrincipal = _IWebHostEnvironment.WebRootPath;
            string RutaArchivoBD = _Dominio.GetById(id).UrlImagen;
            string RutaImagenBD = Path.Combine(RutaPrincipal, RutaArchivoBD.TrimStart('\\'));

            var resul = _Dominio.Delete(id);
            //si el caso es true
            if (resul.IsSuccess)
            {
                System.IO.File.Delete(RutaImagenBD);
                return Json(resul);
            }
            //si el caso es false
            return Json(resul);
        }


       

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //buscar el articulo en la base de datos
            ArticulosViewModelCreate obj = new ArticulosViewModelCreate()
            {
                Articulo = _Dominio.GetById(id),
                ListaCategorias = _DominioCategoria.GetList()
            };


            //enviar articulo a la vista para mostrar

            return View(obj);
        }


        [HttpPost]
        public IActionResult Edit(ArticulosViewModelCreate valores)
        {
            string RutaPrincipal = _IWebHostEnvironment.WebRootPath;
            Response<bool> Response = new Response<bool>();

            //buscar el articulo en la base de datos
            Articulo articulo = _Dominio.GetById(valores.Articulo.ArticuloId);

             //obteniendo request del formulario edit
            int CategoriaId =Convert.ToInt32(HttpContext.Request.Form["CategoriaId"].ToString());
            var Archivo = HttpContext.Request.Form.Files;
            
            
           
            
            // caso cuando se actualiza

            if (Archivo.Count()>0)
            {
                var NombreArchivo = Guid.NewGuid().ToString();
                var RurtaArchivoSubidas = Path.Combine(RutaPrincipal, @"imagenes\articulos");
                var NuevaExtension = Path.GetExtension(Archivo[0].FileName);

                string RutaImagenBD = Path.Combine(RutaPrincipal, articulo.UrlImagen.TrimStart('\\'));
                if (System.IO.File.Exists(RutaImagenBD))
                {
                    System.IO.File.Delete(RutaImagenBD);

                    using (FileStream FileStream = new FileStream(Path.Combine(RurtaArchivoSubidas, NombreArchivo + NuevaExtension), FileMode.Create))
                    {
                        Archivo[0].CopyTo(FileStream);
                    }
                    valores.Articulo.FechaCreacion = articulo.FechaCreacion;
                    valores.Articulo.CategoriaId = CategoriaId;
                    valores.Articulo.UrlImagen = @"imagenes\articulos\" + NombreArchivo + NuevaExtension;
                   _Dominio.Update(valores.Articulo);

                    return RedirectToAction("Index");

                }

             }
            else
            {
                valores.Articulo.CategoriaId = CategoriaId;
                valores.Articulo.UrlImagen = articulo.UrlImagen;

                _Dominio.Update(valores.Articulo);
                return RedirectToAction("Index");

            }
       

            return View(valores);
        }
       #endregion



    }
}