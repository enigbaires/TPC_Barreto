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
    public partial class EmpresaAlta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            
            if (IsValid)
            {
                EmpresaModelo empresa = new EmpresaModelo();
                empresa.razon_social = tbRazonSocial.Text;
                empresa.cuit = tbCuit.Text;
                empresa.numero_sap_empresa = Convert.ToInt32(tbNroSAP.Text);
                empresa.direccion_legal = tbDirLegal.Text;
                empresa.direccion_entrega = tbDirEntrega.Text;
                empresa.telefono = tbTelefono.Text;
                empresa.email = tbEmail.Text;
                empresa.tipo_empresa = Convert.ToInt32(selectTipoEmpresa.Value);
                DAOEmpresa dao = new DAOEmpresa();
                if (dao.AgregarEmpresa(empresa))
                {
                    tbRazonSocial.Text = "";
                    tbCuit.Text = "";
                    tbNroSAP.Text = "";
                    tbDirLegal.Text = "";
                    tbDirEntrega.Text = "";
                    tbTelefono.Text = "";
                    tbEmail.Text = "";
                    confirmacionAlta.CssClass = "text-success";
                    confirmacionAlta.Text = "Empresa agregada correctamente";
                }
                else
                {
                    confirmacionAlta.CssClass = "text-danger";
                    confirmacionAlta.Text = "Empresa NO SE PUDO agregar correctamente";
                }
            }
        }
    }
}