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
    public partial class UsuarioAlta : System.Web.UI.Page
    {
        public UsuarioModelo usuarioLogueado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) Response.Redirect("Login.aspx");
            //si no soy administrador, no puedo ver esta página
            usuarioLogueado = new UsuarioModelo();
            usuarioLogueado = (UsuarioModelo)Session[Session.SessionID + "usuarioLogueado"];
            if (usuarioLogueado.usuario_tipo != 2) Response.Redirect("~/");
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                UsuarioModelo usuario = new UsuarioModelo();
                usuario.nombre = tbUsuarioNombre.Text;
                usuario.usuario_code1 = tbUsuarioCode1.Text;
                usuario.email = tbEmail.Text;
                usuario.password = tbPassword.Text;
                usuario.usuario_tipo = Convert.ToInt32(selectTipoUsuario.Value);
                DAOUsuario dao = new DAOUsuario();
                if (dao.agregarUsuarioConSP(usuario))
                {
                    tbUsuarioNombre.Text = "";
                    tbUsuarioCode1.Text = "";
                    tbEmail.Text = "";
                    tbPassword.Text = "";
                    confirmacionAlta.CssClass = "text-success";
                    confirmacionAlta.Text = "usuario agregado correctamente";
                }
                else
                {
                    confirmacionAlta.CssClass = "text-danger";
                    confirmacionAlta.Text = "usuario NO SE PUDO AGREGAR correctamente";
                }
            }
        }
    }
}