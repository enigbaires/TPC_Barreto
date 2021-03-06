﻿using System;
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
    public partial class RemitoDetalle : System.Web.UI.Page
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
            if (Request.QueryString["id"] == null) Response.Redirect("~/");
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) Response.Redirect("Login.aspx");
            idItemSelected = Convert.ToInt32(Request.QueryString["id"]);
            Session[Session.SessionID + "idItemSelected"] = idItemSelected;

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

                //si el CAI está vigente, habilito el botón
                DAOCai daoCai = new DAOCai();
                if (daoCai.ValidarImpresionCai())
                {
                    btnImprimir.Enabled = true;
                }

                //buscar cliente y transportista y conectarlo al label
                listaEmpresaTodas = new List<EmpresaModelo>();
                listaEmpresaTodas = (List<EmpresaModelo>)Session[Session.SessionID + "listaEmpresaTodas"];
                cliente = new EmpresaModelo();
                cliente = listaEmpresaTodas.Find(J => J.id_empresa == cabecera.id_cliente);
                transportista = new EmpresaModelo();
                transportista = listaEmpresaTodas.Find(J => J.id_empresa == cabecera.id_transportista);
                lbCliente.Text = cliente.razon_social;
                lbTransportista.Text = transportista.razon_social;

                //buscar tipo de remito y conectarlo al label
                listaTipoRemito = new List<RemitoTipoModelo>();
                listaTipoRemito = (List<RemitoTipoModelo>)Session[Session.SessionID + "listaTipoRemito"];
                tipoRemito = new RemitoTipoModelo();
                tipoRemito = listaTipoRemito.Find(J => J.id_tipo_remito == cabecera.id_tipo_remito);
                lbTipoRemito.Text = tipoRemito.descripcion_remito;
                
                //buscar articulo y conectarlo al label
                listaArticuloTodos = new List<ArticuloModelo>();
                listaArticuloTodos = (List<ArticuloModelo>)Session[Session.SessionID + "listaArticuloTodos"];
                articulo = new ArticuloModelo();
                articulo = listaArticuloTodos.Find(J => J.id_articulo == listaDetalleDeUno[0].id_articulo);
                lbArticulo.Text = articulo.descripcion_articulo;
                
                //conectar textbox
                lbCantidad.Text = Convert.ToString(listaDetalleDeUno[0].cantidad);
                lbNroRemito.Text = Convert.ToString(daoRemito.BuscarNroRemito(cabecera.id_solicitud));

            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImpresionRemito.aspx");
        }
    }
}