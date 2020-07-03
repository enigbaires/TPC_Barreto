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
    public partial class MatrizListado : System.Web.UI.Page
    {
        public UsuarioModelo usuarioSolicitanteModelo { get; set; }
        public UsuarioModelo usuarioAprobadorModelo { get; set; }
        public List<UsuarioIdNombreModelo> listaMatrizActivos { get; set; }
        public UsuarioModelo usuarioLogueado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) Response.Redirect("Login.aspx");
            //si no soy administrador, no puedo ver esta página
            usuarioLogueado = new UsuarioModelo();
            usuarioLogueado = (UsuarioModelo)Session[Session.SessionID + "usuarioLogueado"];
            if (usuarioLogueado.usuario_tipo != 2) Response.Redirect("~/");

            usuarioSolicitanteModelo = new UsuarioModelo();
            usuarioAprobadorModelo = new UsuarioModelo();

            List<MatrizAprobacion> listaMatriz = new List<MatrizAprobacion>();
            DAOMatrizAprobacion dao = new DAOMatrizAprobacion();
            listaMatriz = dao.ListarTodo();

            int usuarioSolicitanteId, usuarioAprobadorId;

            List<UsuarioModelo> listaUsuarios = new List<UsuarioModelo>();

            listaUsuarios = (List<UsuarioModelo>)Session[Session.SessionID + "listaUsuarios"];

            listaMatrizActivos = new List<UsuarioIdNombreModelo>();

            foreach (var item in listaMatriz)
            {
                usuarioSolicitanteId = item.id_usuario_solicitante;
                usuarioAprobadorId = item.id_usuario_aprobador;
                
                usuarioSolicitanteModelo = listaUsuarios.Find(J => J.id_usuario == usuarioSolicitanteId);
                usuarioAprobadorModelo = listaUsuarios.Find(J => J.id_usuario == usuarioAprobadorId);

                if (usuarioSolicitanteModelo!=null && usuarioAprobadorModelo!=null)
                {
                    UsuarioIdNombreModelo aux = new UsuarioIdNombreModelo();
                    aux.id_matriz = item.id_matriz;
                    aux.id_usuario_solicitante = usuarioSolicitanteModelo.id_usuario;
                    aux.nombre_solicitante = usuarioSolicitanteModelo.nombre;
                    aux.id_usuario_aprobador = usuarioAprobadorModelo.id_usuario;
                    aux.nombre_aprobador = usuarioAprobadorModelo.nombre;
                    listaMatrizActivos.Add(aux);
                }

            }



        }
    }
}