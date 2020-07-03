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
    public partial class SolicitudAlta : System.Web.UI.Page
    {
        public UsuarioModelo usuario { get; set; }
        public List<MatrizAprobacion> listaMatriz { get; set; }
        public List<EmpresaModelo> listaClientes { get; set; }
        public List<EmpresaModelo> listaTransportistas { get; set; }
        public List<RemitoTipoModelo> listaTipoRemito { get; set; }
        public List<ArticuloModelo> listaArticulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) { Response.Redirect("Login.aspx"); }
            if (Session[Session.SessionID + "usuarioSolicitante"] == null) { Response.Redirect("Default.aspx"); }

            if (!this.IsPostBack)
            {
                //obtengo el usuario de session
                usuario = new UsuarioModelo();
                usuario = (UsuarioModelo)Session[Session.SessionID + "usuarioLogueado"];
                
                //obtengo la matriz de session
                listaMatriz = new List<MatrizAprobacion>();
                listaMatriz = (List<MatrizAprobacion>)Session[Session.SessionID + "listaMatriz"];

                //si no encuentro el usuario en la lista de la matriz como solicitante, redirect listado
                MatrizAprobacion itemListSelected = new MatrizAprobacion();
                itemListSelected = listaMatriz.Find(J => J.id_usuario_solicitante == usuario.id_usuario);
                if (itemListSelected == null)
                {
                    Response.Redirect("Default.aspx");
                }

                //Lista de clientes y transportistas y los coloco en el drop
                listaClientes = new List<EmpresaModelo>();
                DAOEmpresa daoCliente = new DAOEmpresa();
                listaClientes = daoCliente.ListarEmpresas("habilitadas", "cliente");
                listaTransportistas = new List<EmpresaModelo>();
                DAOEmpresa daoTransportista = new DAOEmpresa();
                listaTransportistas = daoTransportista.ListarEmpresas("habilitadas", "transportista");

                ddlCliente.DataSource = listaClientes;
                ddlCliente.DataTextField = "razon_social";
                ddlCliente.DataValueField = "id_empresa";
                ddlCliente.DataBind();

                ddlTransportista.DataSource = listaTransportistas;
                ddlTransportista.DataTextField = "razon_social";
                ddlTransportista.DataValueField = "id_empresa";
                ddlTransportista.DataBind();

                //lista tipos de remito y los coloco en el drop
                listaTipoRemito = new List<RemitoTipoModelo>();
                DAORemitoTipo daoRemitoTipo = new DAORemitoTipo();
                listaTipoRemito = daoRemitoTipo.ListarTodosTipos();
                ddlTipoRemito.DataSource = listaTipoRemito;
                ddlTipoRemito.DataTextField = "descripcion_remito";
                ddlTipoRemito.DataValueField = "id_tipo_remito";
                ddlTipoRemito.DataBind();

                //lista articulos
                listaArticulo = new List<ArticuloModelo>();
                DAOArticulo daoArticulo = new DAOArticulo();
                listaArticulo = daoArticulo.ListarArticulo("habilitados");
                ddlArticulo.DataSource = listaArticulo;
                ddlArticulo.DataTextField = "descripcion_articulo";
                ddlArticulo.DataValueField = "id_articulo";
                ddlArticulo.DataBind();

            }
            
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //SOLICITUD_CABECERA
                SolicitudCabeceraModelo cabecera = new SolicitudCabeceraModelo();
                DAOSolicitud daoCabecera = new DAOSolicitud();
                
                //int id_solicitud
                cabecera.id_solicitud = daoCabecera.UltimoRegistroSolicitud() + 1;

                //int id_usuario_solicitante
                usuario = new UsuarioModelo();
                usuario = (UsuarioModelo)Session[Session.SessionID + "usuarioLogueado"];
                cabecera.id_usuario_solicitante = usuario.id_usuario;

                //int id_usuario_aprobador
                listaMatriz = new List<MatrizAprobacion>();
                listaMatriz = (List<MatrizAprobacion>)Session[Session.SessionID + "listaMatriz"];
                MatrizAprobacion itemListSelected = new MatrizAprobacion();
                itemListSelected = listaMatriz.Find(J => J.id_usuario_solicitante == usuario.id_usuario);
                cabecera.id_usuario_aprobador = itemListSelected.id_usuario_aprobador;

                //int punto_venta
                cabecera.punto_venta = 204;

                //int cantidad_items
                cabecera.cantidad_items = Convert.ToInt32(tbCantidad.Text);

                //int cantidad_bultos
                cabecera.cantidad_bultos = cabecera.cantidad_items;

                //DateTime fecha_solicitud
                cabecera.fecha_solicitud = DateTime.Now;

                //int id_cliente
                cabecera.id_cliente = Convert.ToInt32(ddlCliente.SelectedValue);

                //int id_transportista
                if (ddlTransportista.SelectedValue == "")
                {
                    cabecera.id_transportista = 5;
                }
                else
                {
                    cabecera.id_transportista = Convert.ToInt32(ddlTransportista.SelectedValue);
                }

                //int id_tipo_remito
                cabecera.id_tipo_remito = Convert.ToInt32(ddlTipoRemito.SelectedValue);

                //String observacion_solicitud
                cabecera.observacion_solicitud = tbObservaciones.Text;

                //int estado_solicitud
                //0: pendiente 1: aprobado 2: rehacer 3: rechazado
                cabecera.estado_solicitud = 0;

                //SOLICITUD_DETALLE
                List<SolicitudDetalleModelo> ListaDetalle = new List<SolicitudDetalleModelo>();
                SolicitudDetalleModelo detalle = new SolicitudDetalleModelo();

                //int id_solicitud
                detalle.id_solicitud = cabecera.id_solicitud;

                //int id_articulo
                detalle.id_articulo = Convert.ToInt32(ddlArticulo.SelectedValue);

                //int cantidad
                detalle.cantidad = Convert.ToInt32(tbCantidad.Text);

                //Agrego a la lista
                ListaDetalle.Add(detalle);

                //ARCHIVO_ADJUNTO
                ArchivoAdjuntoModelo archivo = new ArchivoAdjuntoModelo();

                //int id_solicitud
                archivo.id_solicitud = cabecera.id_solicitud;

                //String descripcion_archivo
                archivo.descripcion_archivo = DateTime.Now.Year.ToString() + archivo.id_solicitud + fileArchivo.PostedFile.FileName;

                //DateTime fecha_upload
                archivo.fecha_upload = DateTime.Now;

                DAOSolicitud dao_solicitud = new DAOSolicitud();

                if (dao_solicitud.AgregarSolicitud(cabecera, ListaDetalle, archivo))
                {
                    fileArchivo.PostedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + WebConfigurationManager.AppSettings["FileFolder"] + DateTime.Now.Year.ToString() + archivo.id_solicitud + fileArchivo.PostedFile.FileName);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    confirmacionEstado.CssClass = "text-danger";
                    confirmacionEstado.Text = "usuario NO SE PUDO AGREGAR correctamente";
                }

            }
        }
    }
}