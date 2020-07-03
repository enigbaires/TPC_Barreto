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
    public partial class ArticuloDetalle : System.Web.UI.Page
    {
        public ArticuloModelo articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) Response.Redirect("Login.aspx");
            if (Request.QueryString["id"] == null) Response.Redirect("~/");
            int idItemSelected = Convert.ToInt32(Request.QueryString["id"]);
            Session[Session.SessionID + "idItemSelected"] = idItemSelected;
            if (!IsPostBack)
            {
                DAOArticulo dao = new DAOArticulo();
                articulo = dao.ListarUnArticulo(idItemSelected);
                tbCodigo_articulo.Text = articulo.codigo_articulo;
                tbDescripcion_articulo.Text = articulo.descripcion_articulo;
            }
        }
        protected void btnModificacion_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                ArticuloModelo articulo = new ArticuloModelo();
                articulo.id_articulo = Convert.ToInt32(Session[Session.SessionID + "idItemSelected"]);
                articulo.codigo_articulo = tbCodigo_articulo.Text;
                articulo.descripcion_articulo = tbDescripcion_articulo.Text;
                articulo.habilitado_articulo = 1;
                DAOArticulo dao = new DAOArticulo();
                if (dao.ModificarArticulo(articulo))
                {
                    confirmacionEstado.CssClass = "text-success";
                    confirmacionEstado.Text = "Articulo modificado correctamente";
                }
                else
                {
                    confirmacionEstado.CssClass = "text-danger";
                    confirmacionEstado.Text = "Articulo NO SE PUDO modificar correctamente";
                }
            }
        }
        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                ArticuloModelo articulo = new ArticuloModelo();
                articulo.id_articulo = Convert.ToInt32(Session[Session.SessionID + "idItemSelected"]);
                articulo.codigo_articulo = tbCodigo_articulo.Text;
                articulo.descripcion_articulo = tbDescripcion_articulo.Text;
                articulo.habilitado_articulo = 0;
                DAOArticulo dao = new DAOArticulo();
                if (dao.ModificarArticulo(articulo))
                {   
                    confirmacionEstado.CssClass = "text-success";
                    confirmacionEstado.Text = "Articulo dado de baja correctamente";
                }
                else
                {
                    confirmacionEstado.CssClass = "text-danger";
                    confirmacionEstado.Text = "Articulo NO SE PUDO dar de baja correctamente";
                }
            }
        }
    }
}