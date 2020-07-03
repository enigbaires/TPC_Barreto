using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Modelo;

namespace Vista
{
    public partial class MatrizAlta : System.Web.UI.Page
    {
        public DAOUsuario dao { get; set; }
        public List<UsuarioModelo> listaDeUsuarios { get; set; }
        int idSolicitante { get; set; }
        public UsuarioModelo usuarioLogueado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) Response.Redirect("Login.aspx");
            //si no soy administrador, no puedo ver esta página
            usuarioLogueado = new UsuarioModelo();
            usuarioLogueado = (UsuarioModelo)Session[Session.SessionID + "usuarioLogueado"];
            if (usuarioLogueado.usuario_tipo != 2) Response.Redirect("~/");

            if (!this.IsPostBack)
            {
                listaDeUsuarios = (List<UsuarioModelo>)(Session[Session.SessionID + "listaUsuarios"]);
                ddlSolicitante.DataSource = listaDeUsuarios;
                ddlSolicitante.DataTextField = "nombre";
                ddlSolicitante.DataValueField = "id_usuario";
                ddlSolicitante.DataBind();
                ddlAprobador.DataSource = listaDeUsuarios;
                ddlAprobador.DataTextField = "nombre";
                ddlAprobador.DataValueField = "id_usuario";
                ddlAprobador.DataBind();
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {   
            idSolicitante = Convert.ToInt32(ddlSolicitante.SelectedValue);

            int idAprobador = int.Parse(ddlAprobador.SelectedItem.Value);

            DAOMatrizAprobacion dao = new DAOMatrizAprobacion();

            if (dao.Agregar(idSolicitante, idAprobador))
            {
                confirmacionAlta.CssClass = "text-success";
                confirmacionAlta.Text = "matriz agregada correctamente";
            }
            else
            {
                confirmacionAlta.CssClass = "text-danger";
                confirmacionAlta.Text = "matriz NO SE PUDO AGREGAR correctamente";
            }

        }
    }
}