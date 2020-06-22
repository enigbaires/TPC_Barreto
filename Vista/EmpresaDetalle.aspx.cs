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
    public partial class EmpresaDetalle : System.Web.UI.Page
    {
        public EmpresaModelo empresa { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null) Response.Redirect("~/");
            int idItemSelected = Convert.ToInt32(Request.QueryString["id"]);
            Session[Session.SessionID + "idItemSelected"] = idItemSelected;
            if (!IsPostBack)
            {
                DAOEmpresa dao = new DAOEmpresa();
                empresa = dao.ListarUnaEmpresa(idItemSelected);
                tbRazonSocial.Text = empresa.razon_social;
                tbCuit.Text = empresa.cuit;
                tbNroSAP.Text = Convert.ToString(empresa.numero_sap_empresa);
                tbDirLegal.Text = empresa.direccion_legal;
                tbDirEntrega.Text = empresa.direccion_entrega;
                tbTelefono.Text = empresa.telefono;
                tbEmail.Text = empresa.email;
                selectTipoEmpresa.Value = Convert.ToString(empresa.tipo_empresa);
            }
        }

        protected void btnModificacion_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                empresa = new EmpresaModelo();
                empresa.id_empresa = Convert.ToInt32(Session[Session.SessionID + "idItemSelected"]);
                empresa.razon_social = tbRazonSocial.Text;
                empresa.cuit = tbCuit.Text;
                empresa.numero_sap_empresa = Convert.ToInt32(tbNroSAP.Text);
                empresa.direccion_legal = tbDirLegal.Text;
                empresa.direccion_entrega = tbDirEntrega.Text;
                empresa.telefono = tbTelefono.Text;
                empresa.email = tbEmail.Text;
                empresa.tipo_empresa = Convert.ToInt32(selectTipoEmpresa.Value);
                empresa.habilitado_empresa = 1;
                DAOEmpresa dao = new DAOEmpresa();
                if (dao.ModificarEmpresa(empresa, "modificacion"))
                {
                    confirmacionEstado.CssClass = "text-success";
                    confirmacionEstado.Text = "Empresa modificada correctamente";
                }
                else
                {
                    confirmacionEstado.CssClass = "text-danger";
                    confirmacionEstado.Text = "Empresa NO SE PUDO modificar correctamente";
                }
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            DAOEmpresa dao = new DAOEmpresa();
            empresa = new EmpresaModelo();
            empresa.id_empresa = Convert.ToInt32(Session[Session.SessionID + "idItemSelected"]);
            empresa.razon_social = tbRazonSocial.Text;
            empresa.cuit = tbCuit.Text;
            empresa.numero_sap_empresa = Convert.ToInt32(tbNroSAP.Text);
            empresa.direccion_legal = tbDirLegal.Text;
            empresa.direccion_entrega = tbDirEntrega.Text;
            empresa.telefono = tbTelefono.Text;
            empresa.email = tbEmail.Text;
            empresa.tipo_empresa = Convert.ToInt32(selectTipoEmpresa.Value);
            empresa.habilitado_empresa = 0;
            if (dao.ModificarEmpresa(empresa, "baja"))
            {
                confirmacionEstado.CssClass = "text-success";
                confirmacionEstado.Text = "Empresa dada de baja correctamente";
            }
            else
            {
                confirmacionEstado.CssClass = "text-danger";
                confirmacionEstado.Text = "Empresa NO SE PUDO dar de baja correctamente";
            }
        }
    }
}