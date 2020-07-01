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
        private readonly IArticuloRepositorio _DominioArtciculo;
   
        public ArticulosController(IArticuloDominio Dominio, IArticuloRepositorio DominioArtciculo)
        {
            _DominioArtciculo = DominioArtciculo;
            _Dominio = Dominio;
        }


        public IActionResult Index()
        {
            var lista = _DominioArtciculo.GetListArticulos();
            return View();
        }
    }
}