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
    public partial class EmpresaListado : System.Web.UI.Page
    {
        public List<EmpresaModelo> listaDeClientes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            String condicion;
            DAOEmpresa dAOEmpresa = new DAOEmpresa();
            if (Request.QueryString["condicion"] == null)
            {
                condicion = "habilitadas";
            }
            else
            {
                if (Request.QueryString["condicion"] == "nohabilitadas")
                {
                    condicion = "nohabilitadas";
                }
                else
                {
                    if (Request.QueryString["condicion"] == "todas")
                    {
                        condicion = "todas";
                    }
                    else
                    {
                        condicion = "habilitadas";
                    }
                }
            }
            listaDeClientes = dAOEmpresa.ListarEmpresas(condicion);
        }
    }
}
