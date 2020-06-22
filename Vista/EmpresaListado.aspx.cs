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
        public List<EmpresaModelo> listaDeEmpresas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            String condicion;
            String tipo;
            DAOEmpresa dAOEmpresa = new DAOEmpresa();
            if (Request.QueryString["condicion"] == null || Request.QueryString["tipo"] == null)
            {
                condicion = "habilitadas";
                tipo = "cliente";
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
                if (Request.QueryString["tipo"] == "cliente")
                {
                    tipo = "cliente";
                }
                else
                {
                    if (Request.QueryString["tipo"] == "transportista")
                    {
                        tipo = "transportista";
                    }
                    else
                    {
                        tipo = "todas";
                    }
                }
            }
            listaDeEmpresas = dAOEmpresa.ListarEmpresas(condicion, tipo);
        }
    }
}
