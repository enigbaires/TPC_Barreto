using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class DAORemito : DAOMaster
    {
        public int UltimoRegistroRemito()
        {
            int result = 0;
            DAOMaster datos = new DAOMaster();
            try
            {
                datos.SetearQuery("select max(id_remito) from REMITO");
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    result = datos.lector.GetInt32(0);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
                datos = null;
            }
            return result;
        }

        public void Agregar(RemitoModelo remito)
        {
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("Insert into REMITO values(@id_solicitud, @numero_remito)");

                dao.AgregarParametro("@id_solicitud", remito.id_solicitud);
                dao.AgregarParametro("@numero_remito", remito.numero_remito);
                dao.EjecutarAccion();
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

        public RemitoModelo ListarUnRemito(int id_remito)
        {
            RemitoModelo remito = new RemitoModelo();
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from REMITO where id_remito = @id_remito");
                dao.AgregarParametro("@id_remito", id_remito);
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    remito = new RemitoModelo();
                    remito.id_remito = dao.lector.GetInt32(0);
                    remito.id_solicitud = dao.lector.GetInt32(1);
                    remito.numero_remito = dao.lector.GetInt32(2);
                    return remito;
                }
                return remito;
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

        public int BuscarNroRemito(int id_solicitud)
        {
            int result = 0;
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select id_remito from REMITO where id_solicitud = @id_solicitud");
                dao.AgregarParametro("@id_solicitud", id_solicitud);
                dao.EjecutarLector();
                while (dao.lector.Read())
                {   
                    result = dao.lector.GetInt32(0);
                    return result;
                }
                return result;
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

        public List<RemitoModelo> ListarTodosRemitos()
        {   
            List<RemitoModelo> lista = new List<RemitoModelo>();
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from REMITO");
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    RemitoModelo remito = new RemitoModelo();
                    remito.id_remito = dao.lector.GetInt32(0);
                    remito.id_solicitud = dao.lector.GetInt32(1);
                    remito.numero_remito = dao.lector.GetInt32(2);
                    lista.Add(remito);
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
