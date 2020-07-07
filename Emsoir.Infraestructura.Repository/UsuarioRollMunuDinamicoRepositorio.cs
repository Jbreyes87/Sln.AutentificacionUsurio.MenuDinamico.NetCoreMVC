using Emsoir.Dominio.Entity.ViewModels;
using Emsoir.Infraestructura.Interface;
using Emsoir.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Emsoir.Infraestructura.Repository
{
    public class UsuarioRollMunuDinamicoRepositorio : IUsuarioRollMenuPaginaRepositorio
    {

        private IConectionFactory _ConectionFactory;
        public UsuarioRollMunuDinamicoRepositorio(IConectionFactory ConectionFactory)
        {
            _ConectionFactory = ConectionFactory;
        }
        public UsuarioMenuViewModels CargarUsuarioRollMenuDinamico(string nombre, string password)
        {
            UsuarioMenuViewModels obj = new UsuarioMenuViewModels();

            using (SqlConnection conn = _ConectionFactory.GetConection)
            {
                using (SqlCommand cmd = new SqlCommand("[Sp_MenuDinamico]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = nombre;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                    var Ds = new DataSet();
                    var Da = new SqlDataAdapter(cmd);
                    Da.Fill(Ds);


                    var dtUsuario = Ds.Tables[0];
                    var dtRoles = Ds.Tables[1];
                    var dtMenu = Ds.Tables[2];
                    var dtPaginas = Ds.Tables[3];

                    for (int i = 0; i < dtUsuario.Rows.Count; i++)
                    {
                        obj.Usuario.NombreUsuario = dtUsuario.Rows[i]["NombreUsuario"].ToString();
                        obj.Usuario.Correo = dtUsuario.Rows[i]["Correo"].ToString();
                    }

                    for (int i = 0; i < dtRoles.Rows.Count; i++)
                    {
                        obj.Roll.RolId = Convert.ToInt32(dtRoles.Rows[i]["RolId"]);
                        obj.Roll.Nombre = dtRoles.Rows[i]["Nombre"].ToString();
                    }

                    for (int i = 0; i < dtMenu.Rows.Count; i++)
                    {
                        var RolMenu = new RollMenuViewModels();
                        obj.RollMenu = new List<RollMenuViewModels>();

                        RolMenu.RolId = Convert.ToInt32(dtMenu.Rows[i]["RolId"]);
                        RolMenu.MenuId = Convert.ToInt32(dtMenu.Rows[i]["MenuId"]);
                        RolMenu.Nombre = dtMenu.Rows[i]["Nombre"].ToString();
                        RolMenu.Css = dtMenu.Rows[i]["Css"].ToString();
                        RolMenu.Flag_Menu = dtMenu.Rows[i]["Flag_Menu"].ToString();

                        obj.RollMenu.Add(RolMenu);

                    }
                    //obj.RollMenu = obj.RollMenu;

                    for (int i = 0; i < dtPaginas.Rows.Count; i++)
                    {
                        var Pagina = new MenuPaginaViewModels();
                        obj.MenuPagina = new List<MenuPaginaViewModels>();

                        Pagina.MenuId = Convert.ToInt32(dtPaginas.Rows[i]["MenuId"]);
                        Pagina.PaginaId = Convert.ToInt32(dtPaginas.Rows[i]["PaginaId"]);
                        Pagina.Nombre = dtPaginas.Rows[i]["Nombre"].ToString();
                        Pagina.UrlPagina = dtPaginas.Rows[i]["UrlPagina"].ToString();
                        Pagina.Css = dtPaginas.Rows[i]["Css"].ToString();

                        obj.MenuPagina.Add(Pagina);

                    }
                    //obj.MenuPagina = obj.MenuPagina;

                }



            }
            return obj;
        }
    }
}

