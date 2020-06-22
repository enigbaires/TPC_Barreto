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
    public partial class UsuarioDetalle : System.Web.UI.Page
    {
        public UsuarioModelo usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null) Response.Redirect("~/");
            int idItemSelected = Convert.ToInt32(Request.QueryString["id"]);
            Session[Session.SessionID + "idItemSelected"] = idItemSelected;
            if (!IsPostBack)
            {
                DAOUsuario dao = new DAOUsuario();
                usuario = dao.ListarUnUsuarioView(idItemSelected);
                tbNombre.Text = usuario.nombre;
                tbUsuario_code1.Text = usuario.usuario_code1;
                tbEmail.Text = usuario.email;
                tbPassword.Text = usuario.password;
                selectTipoUsuario.Value = Convert.ToString(usuario.usuario_tipo);
            }
        }

        protected void btnModificacion_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                usuario = new UsuarioModelo();
                usuario.id_usuario = Convert.ToInt32(Session[Session.SessionID + "idItemSelected"]);
                usuario.nombre = tbNombre.Text;
                usuario.usuario_code1 = tbUsuario_code1.Text;
                usuario.email = tbEmail.Text;
                usuario.password = tbPassword.Text;
                usuario.usuario_tipo = Convert.ToInt32(selectTipoUsuario.Value);
                usuario.usuario_habilitado = 1;
                DAOUsuario dao = new DAOUsuario();
                if (dao.ModificarUsuario(usuario, "modificacion"))
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
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            DAOUsuario dao = new DAOUsuario();
            usuario = new UsuarioModelo();
            usuario.id_usuario = Convert.ToInt32(Session[Session.SessionID + "idItemSelected"]);
            usuario.nombre = tbNombre.Text;
            usuario.usuario_code1 = tbUsuario_code1.Text;
            usuario.email = tbEmail.Text;
            usuario.password = tbPassword.Text;
            usuario.usuario_tipo = Convert.ToInt32(selectTipoUsuario.Value);
            usuario.usuario_habilitado = 0;
            if (dao.ModificarUsuario(usuario, "baja"))
            {
                confirmacionEstado.CssClass = "text-success";
                confirmacionEstado.Text = "usuario dada de baja correctamente";
            }
            else
            {
                confirmacionEstado.CssClass = "text-danger";
                confirmacionEstado.Text = "usuario NO SE PUDO dar de baja correctamente";
            }
        }
    }
}