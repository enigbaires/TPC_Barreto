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
    public partial class ImpresionRemito : System.Web.UI.Page
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
        public UsuarioModelo usuarioLogueado { get; set; }
        public DAORemito daoRemito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {   
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) Response.Redirect("Login.aspx");
            if ((Session[Session.SessionID + "idItemSelected"]) == null) Response.Redirect("RemitoListado.aspx");
            idItemSelected = (int)Session[Session.SessionID + "idItemSelected"];
            //si el CAI no está vigente, no dejo ver la página
            DAOCai daoCai = new DAOCai();
            if (!daoCai.ValidarImpresionCai()) Response.Redirect("RemitoListado.aspx");

            if (!IsPostBack)
            {
                //buscarCabecera, detalle y remito
                listaCabecera = new List<SolicitudCabeceraModelo>();
                listaCabecera = (List<SolicitudCabeceraModelo>)Session[Session.SessionID + "listaCabecera"];
                cabecera = new SolicitudCabeceraModelo();
                cabecera = listaCabecera.Find(J => J.id_solicitud == idItemSelected);
                Session[Session.SessionID + "cabecera"] = cabecera;
                daoRemito = new DAORemito();
                DAOSolicitud daoDetalle = new DAOSolicitud();
                listaDetalleDeUno = new List<SolicitudDetalleModelo>();
                listaDetalleDeUno = daoDetalle.ListarUnaSolicitudDetalle(idItemSelected);

                //buscar cliente y transportista y conectarlo al label
                listaEmpresaTodas = new List<EmpresaModelo>();
                listaEmpresaTodas = (List<EmpresaModelo>)Session[Session.SessionID + "listaEmpresaTodas"];
                cliente = new EmpresaModelo();
                cliente = listaEmpresaTodas.Find(J => J.id_empresa == cabecera.id_cliente);
                transportista = new EmpresaModelo();
                transportista = listaEmpresaTodas.Find(J => J.id_empresa == cabecera.id_transportista);
                lbCliente.Text = cliente.razon_social;
                lbTransportista.Text = transportista.razon_social;

                //buscar articulo y conectarlo al label
                listaArticuloTodos = new List<ArticuloModelo>();
                listaArticuloTodos = (List<ArticuloModelo>)Session[Session.SessionID + "listaArticuloTodos"];
                articulo = new ArticuloModelo();
                articulo = listaArticuloTodos.Find(J => J.id_articulo == listaDetalleDeUno[0].id_articulo);
                lbArticulo.Text = articulo.descripcion_articulo;
                lbCodigoArticulo.Text = articulo.codigo_articulo;

                //conectar labels
                lbCantidad.Text = Convert.ToString(listaDetalleDeUno[0].cantidad);
                lbTotal.Text = Convert.ToString(listaDetalleDeUno[0].cantidad);
                lbNroRemito.Text = Convert.ToString(daoRemito.BuscarNroRemito(cabecera.id_solicitud));

                //busco CAI vigente
                DAOCai daoCaiVigente = new DAOCai();
                long caiVigente = daoCaiVigente.BuscarCaiVigente();
                lbCAI.Text = Convert.ToString(caiVigente);
            }
        }
    }
}