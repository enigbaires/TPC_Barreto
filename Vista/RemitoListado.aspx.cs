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
    public partial class RemitoListado : System.Web.UI.Page
    {
        public List<SolicitudCabeceraModelo> cabecera { get; set; }
        public DAOEmpresa daoEmpresa { get; set; }
        public DAOUsuario daoUsuario { get; set; }
        public DAORemito daoRemito { get; set; }
        public RemitoModelo remito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) Response.Redirect("Login.aspx");
            daoEmpresa = new DAOEmpresa();
            daoUsuario = new DAOUsuario();
            daoRemito = new DAORemito();
            DAOSolicitud daoCabecera = new DAOSolicitud();
            cabecera = daoCabecera.ListarCabecera(-1);

            DAOCai daoCai = new DAOCai();
            if (daoCai.ValidarImpresionCai())
            {
                lbAlertaCai.Visible = false;
            }

            if (!this.IsPostBack)
            {
                
            }

        }
    }
}