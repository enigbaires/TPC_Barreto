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
    public partial class Default : System.Web.UI.Page
    {
        public List<SolicitudCabeceraModelo> cabecera { get; set; }
        public DAOEmpresa daoEmpresa { get; set; }
        public DAOUsuario daoUsuario { get; set; }
        public bool usuarioAprobador { get; set; }
        public bool usuarioSolicitante { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) { Response.Redirect("Login.aspx"); }
            daoEmpresa = new DAOEmpresa();
            daoUsuario = new DAOUsuario();

            int filtro=-1;
            if (Request.QueryString["condicion"] == null)
            {
                filtro = -1;
            }
            else
            {
                if (Request.QueryString["condicion"] != "aprobadas" && Request.QueryString["condicion"] != "pendientes" && Request.QueryString["condicion"] != "rechazadas")
                {
                    filtro = -1;
                }
                else
                {
                    String condicion = Request.QueryString["condicion"];
                    switch (condicion)
                    {
                        case "todas":
                            filtro = -1;
                            break;
                        case "pendientes":
                            filtro = 0;
                            break;
                        case "aprobadas":
                            filtro = 1;
                            break;
                        case "rehacer":
                            filtro = 2;
                            break;
                        case "rechazadas":
                            filtro = 3;
                            break;
                        default:
                            break;
                    }
                }
            }

            DAOSolicitud dao = new DAOSolicitud();
            cabecera = dao.ListarCabecera(filtro);

            if (!this.IsPostBack)
            {
                //veo que tipo de usuario es y lo cargo en session
                DAOMatrizAprobacion daoAprobador = new DAOMatrizAprobacion();
                UsuarioModelo usuarioLogueado = new UsuarioModelo();
                usuarioLogueado = (UsuarioModelo)Session[Session.SessionID + "usuarioLogueado"];
                usuarioAprobador = daoAprobador.BuscarTipoUsuario(usuarioLogueado.id_usuario, "aprobador");
                Session[Session.SessionID + "usuarioAprobador"] = usuarioAprobador;
                DAOMatrizAprobacion daoSolicitante = new DAOMatrizAprobacion();
                usuarioSolicitante = daoSolicitante.BuscarTipoUsuario(usuarioLogueado.id_usuario, "solicitante");
                Session[Session.SessionID + "usuarioSolicitante"] = usuarioSolicitante;
            }
        }
    }
}