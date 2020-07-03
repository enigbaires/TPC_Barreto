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
    public partial class ArticuloAlta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) Response.Redirect("Login.aspx");
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                ArticuloModelo articulo = new ArticuloModelo();
                articulo.codigo_articulo = tbCodigo_articulo.Text;
                articulo.descripcion_articulo = tbDescripcion_articulo.Text;
                articulo.habilitado_articulo = 1;
                DAOArticulo dao = new DAOArticulo();
                if (dao.AgregarArticulo(articulo))
                {
                    tbCodigo_articulo.Text = "";
                    tbDescripcion_articulo.Text = "";
                    confirmacionAlta.CssClass = "text-success";
                    confirmacionAlta.Text = "Articulo agregado correctamente";
                }
                else
                {
                    confirmacionAlta.CssClass = "text-danger";
                    confirmacionAlta.Text = "Articulo NO SE PUDO agregar correctamente";
                }
            }
        }
    }
}