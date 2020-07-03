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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioModelo usuario = new UsuarioModelo();
            DAOUsuario dao = new DAOUsuario();
            usuario = dao.ValidarUsuario(tbEmail.Text, tbPassword.Text);

            if (usuario.id_usuario!=0 && usuario.usuario_habilitado != 0)
            {
                Session[Session.SessionID + "usuarioLogueado"] = usuario;
                Response.Redirect("Default.aspx");
                confirmacionEstado.CssClass = "text-success";
                confirmacionEstado.Text = "usuario Validado correctamente";
            }
            else
            {
                confirmacionEstado.CssClass = "text-danger";
                confirmacionEstado.Text = "usuario NO Validado";
            }
        }
    }
}