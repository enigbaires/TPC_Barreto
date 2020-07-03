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
    public partial class ArticuloListado : System.Web.UI.Page
    {
        public List<ArticuloModelo> listaDeArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) Response.Redirect("Login.aspx");
            String condicion;
            DAOArticulo dao = new DAOArticulo();
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
            listaDeArticulos = dao.ListarArticulo(condicion);
        }
    }
}