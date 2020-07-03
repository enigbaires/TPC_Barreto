using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controlador;
using System.Web.Configuration;

namespace Vista
{
    public partial class SolicitudDetalle : System.Web.UI.Page
    {
        public List<SolicitudCabeceraModelo> listaCabecera { get; set; }
        public SolicitudCabeceraModelo cabecera { get; set; }
        public List<SolicitudDetalleModelo> listaDetalle { get; set; }
        public List<SolicitudDetalleModelo> listaDetalleDeUno { get; set; }
        public List<EmpresaModelo> listaEmpresaTodas { get; set; }
        public EmpresaModelo cliente { get; set; }
        public EmpresaModelo transportista { get; set; }
        public int idItemSelected { get; set; }
        public List<RemitoTipoModelo> listaTipoRemito { get; set; }
        public RemitoTipoModelo tipoRemito { get; set; }
        public List<ArticuloModelo> listaArticuloTodos { get; set; }
        public ArticuloModelo articulo { get; set; }
        public ArchivoAdjuntoModelo archivo { get; set; }
        public UsuarioModelo usuarioLogueado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null) Response.Redirect("~/");
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) { Response.Redirect("Login.aspx"); }
            idItemSelected = Convert.ToInt32(Request.QueryString["id"]);
            Session[Session.SessionID + "idItemSelected"] = idItemSelected;

            if (!IsPostBack)
            {
                //buscarCabecera, detalle y archivo
                listaCabecera = new List<SolicitudCabeceraModelo>();
                listaCabecera = (List<SolicitudCabeceraModelo>)Session[Session.SessionID + "listaCabecera"];
                cabecera = new SolicitudCabeceraModelo();
                cabecera = listaCabecera.Find(J => J.id_solicitud == idItemSelected);
                Session[Session.SessionID + "cabecera"] = cabecera;
                DAOSolicitud daoDetalle = new DAOSolicitud();
                listaDetalleDeUno = new List<SolicitudDetalleModelo>();
                listaDetalleDeUno = daoDetalle.ListarUnaSolicitudDetalle(idItemSelected);

                //si el usuario no tiene permiso de aprobar la solicitud, deshabilito el botón
                usuarioLogueado = new UsuarioModelo();
                usuarioLogueado = (UsuarioModelo)Session[Session.SessionID + "usuarioLogueado"];
                if (usuarioLogueado.id_usuario == cabecera.id_usuario_aprobador)
                {
                    btnCambiarEstado.Enabled = true;
                }

                //buscar cliente y transportista y conectarlo al ddl
                listaEmpresaTodas = new List<EmpresaModelo>();
                listaEmpresaTodas = (List<EmpresaModelo>)Session[Session.SessionID + "listaEmpresaTodas"];
                cliente = new EmpresaModelo();
                cliente = listaEmpresaTodas.Find(J => J.id_empresa == cabecera.id_cliente);
                transportista = new EmpresaModelo();
                transportista = listaEmpresaTodas.Find(J => J.id_empresa == cabecera.id_transportista);
                ddlCliente.DataSource = listaEmpresaTodas;
                ddlCliente.DataTextField = "razon_social";
                ddlCliente.DataValueField = "id_empresa";
                ddlCliente.SelectedValue = Convert.ToString(cliente.id_empresa);
                ddlCliente.DataBind();
                ddlTransportista.DataSource = listaEmpresaTodas;
                ddlTransportista.DataTextField = "razon_social";
                ddlTransportista.DataValueField = "id_empresa";
                ddlTransportista.SelectedValue = Convert.ToString(transportista.id_empresa);
                ddlTransportista.DataBind();

                //buscar tipo de remito y conectarlo al ddl
                listaTipoRemito = new List<RemitoTipoModelo>();
                listaTipoRemito = (List<RemitoTipoModelo>)Session[Session.SessionID + "listaTipoRemito"];
                tipoRemito = new RemitoTipoModelo();
                tipoRemito = listaTipoRemito.Find(J => J.id_tipo_remito == cabecera.id_tipo_remito);
                ddlTipoRemito.DataSource = listaTipoRemito;
                ddlTipoRemito.DataTextField = "descripcion_remito";
                ddlTipoRemito.DataValueField = "id_tipo_remito";
                ddlTipoRemito.SelectedValue = Convert.ToString(tipoRemito.id_tipo_remito);
                ddlTipoRemito.DataBind();

                //buscar articulo y conectarlo al ddl
                listaArticuloTodos = new List<ArticuloModelo>();
                listaArticuloTodos = (List<ArticuloModelo>)Session[Session.SessionID + "listaArticuloTodos"];
                articulo = new ArticuloModelo();
                articulo = listaArticuloTodos.Find(J => J.id_articulo == listaDetalleDeUno[0].id_articulo);
                ddlArticulo.DataSource = listaArticuloTodos;
                ddlArticulo.DataTextField = "descripcion_articulo";
                ddlArticulo.DataValueField = "id_articulo";
                ddlArticulo.SelectedValue = Convert.ToString(articulo.id_articulo);
                ddlArticulo.DataBind();

                //conectar textbox
                tbCantidad.Text = Convert.ToString(listaDetalleDeUno[0].cantidad);
                tbObservaciones.Text = cabecera.observacion_solicitud;

                //estado actual
                ddlEstadoActual.SelectedValue = Convert.ToString(cabecera.estado_solicitud);

                //archivo adjunto
                idItemSelected = (int)Session[Session.SessionID + "idItemSelected"];
                DAOArchivoAdjunto daoArchivo = new DAOArchivoAdjunto();
                archivo = new ArchivoAdjuntoModelo();
                archivo = daoArchivo.ListarUnArchivo(idItemSelected);
                String url = WebConfigurationManager.AppSettings["FileFolder"] + archivo.descripcion_archivo;
                hlVerArchivo.NavigateUrl = url;

                //si ya está aprobado, no dejo que se cambie el estado
                if (cabecera.estado_solicitud == 1)
                {
                    btnCambiarEstado.Visible = false;
                }
            }
        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            cabecera = new SolicitudCabeceraModelo();
            cabecera = (SolicitudCabeceraModelo)Session[Session.SessionID + "cabecera"];
            DAOSolicitud dao = new DAOSolicitud();
            if (dao.ModificarEstado(cabecera.id_solicitud, Convert.ToInt32(ddlEstadoActual.SelectedValue)))
            {
                confirmacionEstado.CssClass = "text-success";
                confirmacionEstado.Text = "Estado modificado correctamente";
            }
            else
            {
                confirmacionEstado.CssClass = "text-danger";
                confirmacionEstado.Text = "No se pudo modificar el Estado";
            }
            
        }
    }
}