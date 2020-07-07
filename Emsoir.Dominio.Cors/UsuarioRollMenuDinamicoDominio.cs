using Emosir.Dominio.Interface;
using Emsoir.Dominio.Entity.ViewModels;
using Emsoir.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emsoir.Dominio.Cors
{
    public class UsuarioRollMenuDinamicoDominio : IUsuarioRollManuDinamicoDominio
    {
     
        private readonly IUsuarioRollMenuPaginaRepositorio _IUsuarioRollMenuPagina;
        public UsuarioRollMenuDinamicoDominio(IUsuarioRollMenuPaginaRepositorio IUsuarioRollMenuPagina)
        {

            _IUsuarioRollMenuPagina = IUsuarioRollMenuPagina;
        }
        public UsuarioMenuViewModels CargarUsuarioRollMenuDinamico(string nombre, string contraseña)
        {
            return _IUsuarioRollMenuPagina.CargarUsuarioRollMenuDinamico(nombre,contraseña); 
        }
    }
}
