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
    public partial class UsuarioListado : System.Web.UI.Page
    {
        public List<UsuarioModelo> listaDeUsuarios { get; set; }
        public UsuarioModelo usuarioLogueado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) { Response.Redirect("Login.aspx"); }
            //si no soy administrador, no puedo ver esta página
            usuarioLogueado = new UsuarioModelo();
            usuarioLogueado = (UsuarioModelo)Session[Session.SessionID + "usuarioLogueado"];
            if (usuarioLogueado.usuario_tipo != 2) Response.Redirect("~/");

            String condicion;
            DAOUsuario dao = new DAOUsuario();
            if (Request.QueryString["condicion"] == null)
            {
                condicion = "habilitados";
            }
            else
            {
                if (Request.QueryString["condicion"] == "nohabilitados")
                {
                    condicion = "nohabilitados";
                }
                else
                {
                    if (Request.QueryString["condicion"] == "todos")
                    {
                        condicion = "todos";
                    }
                    else
                    {
                        condicion = "habilitados";
                    }
                }
            }
            listaDeUsuarios = dao.ListarUsuarios(condicion);
        }
    }
}