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
    public partial class CaiDetalle : System.Web.UI.Page
    {
        public CAIModelo cai { get; set; }
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
            if (!IsPostBack)
            {
                DAOCai dao = new DAOCai();
                cai = dao.ListarUnCAI(idItemSelected);
                tbNro_cai.Text = cai.nro_cai.ToString();
                tbPunto_venta.Text = cai.punto_venta.ToString();
                tbFecha_inicio.Text = cai.fecha_inicio.ToShortDateString();
                tbFecha_fin.Text = cai.fecha_fin.ToShortDateString();
            }
        }

        protected void btnModificacion_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                cai = new CAIModelo();
                cai.id_cai = Convert.ToInt32(Session[Session.SessionID + "idItemSelected"]);
                cai.nro_cai = Convert.ToInt64(tbNro_cai.Text);
                cai.punto_venta = Convert.ToInt32(tbPunto_venta.Text);
                cai.fecha_inicio = Convert.ToDateTime(tbFecha_inicio.Text);
                cai.fecha_fin = Convert.ToDateTime(tbFecha_fin.Text);
                DAOCai dao = new DAOCai();
                if (dao.ModificarCai(cai))
                {
                    confirmacionEstado.CssClass = "text-success";
                    confirmacionEstado.Text = "CAI modificada correctamente";
                }
                else
                {
                    confirmacionEstado.CssClass = "text-danger";
                    confirmacionEstado.Text = "CAI NO SE PUDO modificar correctamente";
                }
            }
        }
    }
}