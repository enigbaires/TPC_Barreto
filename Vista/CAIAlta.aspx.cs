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
    public partial class CAIAlta : System.Web.UI.Page
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
                CAIModelo cai = new CAIModelo();
                cai.nro_cai = Convert.ToInt64(tbNro_cai.Text);
                cai.punto_venta = Convert.ToInt32(tbPunto_venta.Text);
                cai.fecha_inicio = Convert.ToDateTime(tbFecha_inicio.Text);
                cai.fecha_fin = Convert.ToDateTime(tbFecha_fin.Text);
                DAOCai dao = new DAOCai();
                if (dao.AgregarCai(cai))
                {
                    tbNro_cai.Text = "";
                    tbPunto_venta.Text = "";
                    tbFecha_inicio.Text = "";
                    tbFecha_fin.Text = "";
                    confirmacionEstado.CssClass = "text-success";
                    confirmacionEstado.Text = "CAI agregado correctamente";
                }
                else
                {
                    confirmacionEstado.CssClass = "text-danger";
                    confirmacionEstado.Text = "CAI NO SE PUDO AGREGAR correctamente";
                }
            }
        }
    }
}