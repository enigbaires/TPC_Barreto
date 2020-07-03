using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class DAOSolicitud : DAOMaster
    {
        public int UltimoRegistroSolicitud()
        {
            int result = 0;
            DAOMaster datos = new DAOMaster();
            try
            {
                datos.SetearQuery("select max(id_solicitud) from SOLICITUD_CABECERA");
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    result = datos.lector.GetInt32(0);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return result;
                //throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return result;
        }

        public bool ModificarSolicitud(SolicitudCabeceraModelo solicitud_cabecera, List<SolicitudDetalleModelo> solicitud_detalle, ArchivoAdjuntoModelo archivo)
        {
            DAOMaster dao_cabecera = new DAOMaster();
            bool result_cabecera = false, result_detalle=false;
            try
            {
                dao_cabecera.SetearQuery("Update SOLICITUD_CABECERA set id_usuario_solicitante=@id_usuario_solicitante, id_usuario_aprobador=@id_usuario_aprobador, punto_venta=@punto_venta, cantidad_items=@cantidad_items, cantidad_bultos=@cantidad_bultos, fecha_solicitud=@fecha_solicitud, id_cliente=@id_cliente, id_transportista=@id_transportista, id_tipo_remito=@id_tipo_remito, observacion_solicitud=@observacion_solicitud, estado_solicitud=@estado_solicitud, Where id_solicitud=@id_solicitud");
                dao_cabecera.AgregarParametro("@id_solicitud", solicitud_cabecera.id_solicitud);
                dao_cabecera.AgregarParametro("@id_usuario_solicitante", solicitud_cabecera.id_usuario_solicitante);
                dao_cabecera.AgregarParametro("@id_usuario_aprobador", solicitud_cabecera.id_usuario_aprobador);
                dao_cabecera.AgregarParametro("@punto_venta", solicitud_cabecera.punto_venta);
                dao_cabecera.AgregarParametro("@cantidad_items", solicitud_cabecera.cantidad_items);
                dao_cabecera.AgregarParametro("@cantidad_bultos", solicitud_cabecera.cantidad_bultos);
                dao_cabecera.AgregarParametro("@fecha_solicitud", solicitud_cabecera.fecha_solicitud);
                dao_cabecera.AgregarParametro("@id_cliente", solicitud_cabecera.id_cliente);
                dao_cabecera.AgregarParametro("@id_transportista", solicitud_cabecera.id_transportista);
                dao_cabecera.AgregarParametro("@id_tipo_remito", solicitud_cabecera.id_tipo_remito);
                dao_cabecera.AgregarParametro("@observacion_solicitud", solicitud_cabecera.observacion_solicitud);
                dao_cabecera.AgregarParametro("@estado_solicitud", solicitud_cabecera.estado_solicitud);
                dao_cabecera.EjecutarAccion();
                result_cabecera = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dao_cabecera.CerrarConexion();
            }

            DAOMaster dao_detalle = new DAOMaster();
            //viene una lista de detalle
            try
            {
                dao_detalle.SetearQuery("Update SOLICITUD_DETALLE set id_articulo=@id_articulo, cantidad=@cantidad Where id_solicitud=@id_solicitud");
                
                foreach (var item in solicitud_detalle)
                {
                    dao_detalle.AgregarParametro("@id_solicitud", item.id_solicitud);
                    dao_detalle.AgregarParametro("@id_articulo", item.id_articulo);
                    dao_detalle.AgregarParametro("@cantidad", item.cantidad);
                    dao_detalle.EjecutarAccion();
                }
                result_detalle = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dao_detalle.CerrarConexion();
            }

            DAOArchivoAdjunto dao_archivo = new DAOArchivoAdjunto();
            bool result_archivo;
            result_archivo = dao_archivo.Agregar(archivo);

            if (result_cabecera && result_detalle && result_archivo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarEstado(int id_solicitud, int estado_solicitud)
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("Update SOLICITUD_CABECERA set estado_solicitud=@estado_solicitud Where id_solicitud=@id_solicitud");
                dao.AgregarParametro("@id_solicitud", id_solicitud);
                dao.AgregarParametro("@estado_solicitud", estado_solicitud);
                dao.EjecutarAccion();
                result = true;

                if (estado_solicitud == 1)
                {
                    DAORemito daoUltimoRegistroRemito = new DAORemito();
                    int nroRemito = daoUltimoRegistroRemito.UltimoRegistroRemito() + 1;
                    RemitoModelo remito = new RemitoModelo();
                    remito.id_remito = nroRemito;
                    remito.numero_remito = nroRemito;
                    remito.id_solicitud = id_solicitud;
                    DAORemito daoRemito = new DAORemito();
                    daoRemito.Agregar(remito);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dao.CerrarConexion();
            }

            





            return result;
        }
        
        public bool AgregarSolicitud(SolicitudCabeceraModelo solicitud_cabecera, List<SolicitudDetalleModelo> solicitud_detalle, ArchivoAdjuntoModelo archivo)
        {   
            DAOMaster dao_cabecera = new DAOMaster();
            bool result_cabecera = false, result_detalle = false;
            try
            {
                dao_cabecera.SetearQuery("Insert into SOLICITUD_CABECERA values(@id_usuario_solicitante, @id_usuario_aprobador, @punto_venta, @cantidad_items, @cantidad_bultos, @fecha_solicitud, @id_cliente, @id_transportista, @id_tipo_remito, @observacion_solicitud, @estado_solicitud)");
                dao_cabecera.AgregarParametro("@id_usuario_solicitante", solicitud_cabecera.id_usuario_solicitante);
                dao_cabecera.AgregarParametro("@id_usuario_aprobador", solicitud_cabecera.id_usuario_aprobador);
                dao_cabecera.AgregarParametro("@punto_venta", solicitud_cabecera.punto_venta);
                dao_cabecera.AgregarParametro("@cantidad_items", solicitud_cabecera.cantidad_items);
                dao_cabecera.AgregarParametro("@cantidad_bultos", solicitud_cabecera.cantidad_bultos);
                dao_cabecera.AgregarParametro("@fecha_solicitud", solicitud_cabecera.fecha_solicitud);
                dao_cabecera.AgregarParametro("@id_cliente", solicitud_cabecera.id_cliente);
                dao_cabecera.AgregarParametro("@id_transportista", solicitud_cabecera.id_transportista);
                dao_cabecera.AgregarParametro("@id_tipo_remito", solicitud_cabecera.id_tipo_remito);
                dao_cabecera.AgregarParametro("@observacion_solicitud", solicitud_cabecera.observacion_solicitud);
                dao_cabecera.AgregarParametro("@estado_solicitud", solicitud_cabecera.estado_solicitud);
                dao_cabecera.EjecutarAccion();
                result_cabecera = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dao_cabecera.CerrarConexion();
            }
            
            DAOMaster dao_detalle = new DAOMaster();
            //viene una lista de detalle
            try
            {
                dao_detalle.SetearQuery("Insert into SOLICITUD_DETALLE values(@id_solicitud, @id_articulo, @cantidad)");

                foreach (var item in solicitud_detalle)
                {
                    dao_detalle.AgregarParametro("@id_solicitud", item.id_solicitud);
                    dao_detalle.AgregarParametro("@id_articulo", item.id_articulo);
                    dao_detalle.AgregarParametro("@cantidad", item.cantidad);
                    dao_detalle.EjecutarAccion();
                }
                result_detalle = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dao_detalle.CerrarConexion();
            }

            DAOArchivoAdjunto dao_archivo = new DAOArchivoAdjunto();
            bool result_archivo;
            result_archivo = dao_archivo.Agregar(archivo);

            if (result_cabecera && result_detalle && result_archivo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SolicitudCabeceraModelo ListarUnaSolicitudCabecera(int id)
        {
            SolicitudCabeceraModelo solicitud = new SolicitudCabeceraModelo();
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from SOLICITUD_CABECERA where id_solicitud = @id_solicitud");
                dao.AgregarParametro("@id_solicitud", id);
                dao.EjecutarLector();
                while (dao.lector.Read())
                {   
                    solicitud.id_solicitud = dao.lector.GetInt32(0);
                    solicitud.id_usuario_solicitante = dao.lector.GetInt32(1);
                    solicitud.id_usuario_aprobador = dao.lector.GetInt32(2);
                    solicitud.punto_venta = dao.lector.GetInt32(3);
                    solicitud.cantidad_items = dao.lector.GetInt32(4);
                    solicitud.cantidad_bultos = dao.lector.GetInt32(5);
                    solicitud.fecha_solicitud = dao.lector.GetDateTime(6);
                    solicitud.id_cliente = dao.lector.GetInt32(7);
                    solicitud.id_transportista = dao.lector.GetInt32(8);
                    solicitud.id_tipo_remito = dao.lector.GetInt32(9);
                    solicitud.observacion_solicitud = dao.lector.GetString(10);
                    solicitud.estado_solicitud = dao.lector.GetInt32(11);
                    return solicitud;
                }
                return solicitud;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dao.CerrarConexion();
                dao = null;
            }
        }
        
        public List<SolicitudCabeceraModelo> ListarCabecera(int filtro)
        {
            List<SolicitudCabeceraModelo> lista = new List<SolicitudCabeceraModelo>();
            DAOMaster dao = new DAOMaster();
            try
            {
                switch (filtro)
                {
                    case -1:
                        dao.SetearQuery("select * from SOLICITUD_CABECERA");
                        break;
                    case 0:
                        dao.SetearQuery("select * from SOLICITUD_CABECERA Where estado_solicitud=0");
                        break;
                    case 1:
                        dao.SetearQuery("select * from SOLICITUD_CABECERA Where estado_solicitud=1");
                        break;
                    case 2:
                        dao.SetearQuery("select * from SOLICITUD_CABECERA Where estado_solicitud=2");
                        break;
                    case 3:
                        dao.SetearQuery("select * from SOLICITUD_CABECERA Where estado_solicitud=3");
                        break;
                    default:
                        break;
                }
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    SolicitudCabeceraModelo solicitud = new SolicitudCabeceraModelo();
                    solicitud.id_solicitud = dao.lector.GetInt32(0);
                    solicitud.id_usuario_solicitante = dao.lector.GetInt32(1);
                    solicitud.id_usuario_aprobador = dao.lector.GetInt32(2);
                    solicitud.punto_venta = dao.lector.GetInt32(3);
                    solicitud.cantidad_items = dao.lector.GetInt32(4);
                    solicitud.cantidad_bultos = dao.lector.GetInt32(5);
                    solicitud.fecha_solicitud = dao.lector.GetDateTime(6);
                    solicitud.id_cliente = dao.lector.GetInt32(7);
                    solicitud.id_transportista = dao.lector.GetInt32(8);
                    solicitud.id_tipo_remito = dao.lector.GetInt32(9);
                    solicitud.observacion_solicitud = dao.lector.GetString(10);
                    solicitud.estado_solicitud = dao.lector.GetInt32(11);
                    lista.Add(solicitud);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dao.CerrarConexion();
            }
        }

        public List<SolicitudDetalleModelo> ListarUnaSolicitudDetalle(int id)
        {
            List<SolicitudDetalleModelo> lista = new List<SolicitudDetalleModelo>();
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from SOLICITUD_CABECERA where id_solicitud = @id_solicitud");
                dao.AgregarParametro("@id_solicitud", id);
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    SolicitudDetalleModelo solicitud = new SolicitudDetalleModelo();
                    solicitud.id_solicitud = dao.lector.GetInt32(0);
                    solicitud.id_articulo = dao.lector.GetInt32(1);
                    solicitud.cantidad = dao.lector.GetInt32(2);
                    lista.Add(solicitud);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dao.CerrarConexion();
                dao = null;
            }
        }
        
        public List<SolicitudDetalleModelo> ListarDetalle()
        {
            List<SolicitudDetalleModelo> lista = new List<SolicitudDetalleModelo>();
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from SOLICITUD_CABECERA");
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    SolicitudDetalleModelo solicitud = new SolicitudDetalleModelo();
                    solicitud.id_solicitud = dao.lector.GetInt32(0);
                    solicitud.id_articulo = dao.lector.GetInt32(1);
                    solicitud.cantidad = dao.lector.GetInt32(2);
                    lista.Add(solicitud);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dao.CerrarConexion();
                dao = null;
            }
        }

    }
}
