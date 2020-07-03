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
    public partial class MatrizDetalle : System.Web.UI.Page
    {
        public UsuarioIdNombreModelo usuario { get; set; }
        public List<UsuarioModelo> listaDeUsuarios { get; set; }
        public UsuarioModelo usuarioLogueado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) Response.Redirect("Login.aspx");
            //si no soy administrador, no puedo ver esta página
            usuarioLogueado = new UsuarioModelo();
            usuarioLogueado = (UsuarioModelo)Session[Session.SessionID + "usuarioLogueado"];
            if (usuarioLogueado.usuario_tipo != 2) Response.Redirect("~/");

            if (Request.QueryString["id"] == null) Response.Redirect("~/");
            int idItemSelected = Convert.ToInt32(Request.QueryString["id"]);
            Session[Session.SessionID + "idItemSelected"] = idItemSelected;
            DAOMatrizAprobacion dao = new DAOMatrizAprobacion();
            usuario = dao.ListarUnaMatriz(idItemSelected);
            if (!IsPostBack)
            {
                listaDeUsuarios = (List<UsuarioModelo>)(Session[Session.SessionID + "listaUsuarios"]);
                ddlSolicitante.DataSource = listaDeUsuarios;
                ddlSolicitante.DataTextField = "nombre";
                ddlSolicitante.DataValueField = "id_usuario";
                ddlSolicitante.SelectedValue = Convert.ToString(usuario.id_usuario_solicitante);
                try
                {
                    ddlSolicitante.DataBind();
                }
                catch (Exception)
                {
                    Response.Redirect("~/MatrizListado.aspx");
                }
                ddlAprobador.DataSource = listaDeUsuarios;
                ddlAprobador.DataTextField = "nombre";
                ddlAprobador.DataValueField = "id_usuario";
                ddlAprobador.SelectedValue = Convert.ToString(usuario.id_usuario_aprobador);
                try
                {
                    ddlAprobador.DataBind();
                }
                catch (Exception)
                {
                    Response.Redirect("~/MatrizListado.aspx");
                }
            }
        }

        protected void btnModificacion_Click(object sender, EventArgs e)
        {
            int idSolicitante = Convert.ToInt32(ddlSolicitante.SelectedValue);
            int idAprobador = int.Parse(ddlAprobador.SelectedItem.Value);
            MatrizAprobacion matriz = new MatrizAprobacion();
            matriz.id_matriz = Convert.ToInt32(Session[Session.SessionID + "idItemSelected"]);
            matriz.id_usuario_solicitante = idSolicitante;
            matriz.id_usuario_aprobador = idAprobador;

            DAOMatrizAprobacion dao = new DAOMatrizAprobacion();
                if (dao.Modificar(matriz))
                {
                    confirmacionEstado.CssClass = "text-success";
                    confirmacionEstado.Text = "usuario modificada correctamente";
                }
                else
                {
                    confirmacionEstado.CssClass = "text-danger";
                    confirmacionEstado.Text = "usuario NO SE PUDO modificar correctamente";
                }
            
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            DAOMatrizAprobacion dao = new DAOMatrizAprobacion();
            int id_matriz = Convert.ToInt32(Session[Session.SessionID + "idItemSelected"]);
            
            if (dao.Eliminar(id_matriz))
            {
                Response.Redirect("~/MatrizListado.aspx");
            }
            else
            {
                confirmacionEstado.CssClass = "text-danger";
                confirmacionEstado.Text = "usuario NO SE PUDO dar de baja correctamente";
            }
        }
    }
}