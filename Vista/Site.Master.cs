using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controlador;

namespace Vista
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public List<UsuarioModelo> listaUsuarios { get; set; }
        public List<UsuarioModelo> listaTodosLosUsuarios { get; set; }
        public UsuarioModelo usuario { get; set; }
        public List<MatrizAprobacion> listaMatriz { get; set; }
        public int usuarioTipo { get; set; }
        public List<SolicitudCabeceraModelo> listaCabecera { get; set; }
        public List<SolicitudDetalleModelo> listaDetalle { get; set; }
        public List<EmpresaModelo> listaEmpresaTodas { get; set; }
        public List<RemitoTipoModelo> listaTipoRemito { get; set; }
        public List<ArticuloModelo> listaArticuloTodos { get; set; }
        public List<ArticuloModelo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Session.SessionID + "usuarioLogueado"])==null) { Response.Redirect("Login.aspx");}

            //acá tendría que haber un else para lista usuario

            if (!this.IsPostBack)
            {
                //listo artículos y lo cargo a session
                DAOArticulo daoArticulosTodos = new DAOArticulo();
                listaArticuloTodos = new List<ArticuloModelo>();
                listaArticuloTodos = daoArticulosTodos.ListarArticulo("todos");
                Session[Session.SessionID + "listaArticuloTodos"] = listaArticuloTodos;
                DAOArticulo daoArticulos = new DAOArticulo();
                listaArticulos = new List<ArticuloModelo>();
                listaArticulos = daoArticulos.ListarArticulo("habilitados");
                Session[Session.SessionID + "listaArticulos"] = listaArticulos;

                //listo tipo remito y lo cargo a session
                DAORemitoTipo daoTipoRemito = new DAORemitoTipo();
                listaTipoRemito = new List<RemitoTipoModelo>();
                listaTipoRemito = daoTipoRemito.ListarTodosTipos();
                Session[Session.SessionID + "listaTipoRemito"] = listaTipoRemito;

                //listo empresa y lo cargo a session
                DAOEmpresa daoEmpresa = new DAOEmpresa();
                listaEmpresaTodas = new List<EmpresaModelo>();
                listaEmpresaTodas = daoEmpresa.ListarEmpresas("todas", "todas");
                Session[Session.SessionID + "listaEmpresaTodas"] = listaEmpresaTodas;

                //Listo usuarios y los cargo a session
                DAOUsuario daoUsuario = new DAOUsuario();
                listaUsuarios = new List<UsuarioModelo>();
                listaUsuarios = daoUsuario.ListarUsuarios("habilitados");
                Session[Session.SessionID + "listaUsuarios"] = listaUsuarios;

                //Listo matriz y la cargo a session
                DAOMatrizAprobacion daoMatriz = new DAOMatrizAprobacion();
                listaMatriz = new List<MatrizAprobacion>();
                listaMatriz = daoMatriz.ListarTodo();
                Session[Session.SessionID + "listaMatriz"] = listaMatriz;

                //Listo todos los usuarios y los cargo a session
                DAOUsuario daoUsuarioTodos = new DAOUsuario();
                listaTodosLosUsuarios = new List<UsuarioModelo>();
                listaTodosLosUsuarios = daoUsuarioTodos.ListarUsuarios("todos");
                Session[Session.SessionID + "listaTodosLosUsuarios"] = listaTodosLosUsuarios;

                //Listo cabecera y guardo en session
                DAOSolicitud daosolicitud = new DAOSolicitud();
                listaCabecera = new List<SolicitudCabeceraModelo>();
                listaCabecera = daosolicitud.ListarCabecera(-1);
                Session[Session.SessionID + "listaCabecera"] = listaCabecera;

                //listo detalle y lo cargo en session
                listaDetalle = new List<SolicitudDetalleModelo>();
                listaDetalle = daosolicitud.ListarDetalle();
                Session[Session.SessionID + "listaDetalle"] = listaDetalle;
            }

            usuario = new UsuarioModelo();
            usuario = (UsuarioModelo)Session[Session.SessionID + "usuarioLogueado"];

            lbNombreUsuarioMenu.Text = usuario.nombre;

            usuarioTipo = usuario.usuario_tipo;

        }

    }
}