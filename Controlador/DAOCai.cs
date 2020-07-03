using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class DAOCai : DAOMaster
    {
        public List<CAIModelo> ListarCAI()
        {
            List<CAIModelo> lista = new List<CAIModelo>();
            CAIModelo aux;
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from CAI");
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    aux = new CAIModelo();
                    aux.id_cai = dao.lector.GetInt32(0);
                    aux.nro_cai = Convert.ToInt64(dao.lector.GetInt64(1));
                    aux.punto_venta = dao.lector.GetInt32(2);
                    aux.fecha_inicio = Convert.ToDateTime(dao.lector.GetDateTime(3));
                    aux.fecha_fin = Convert.ToDateTime(dao.lector.GetDateTime(4));
                    lista.Add(aux);
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

        public CAIModelo ListarUnCAI(int id)
        {   
            CAIModelo cai = new CAIModelo();
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from CAI Where id_cai=@id_cai");
                dao.AgregarParametro("@id_cai", id);
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    
                    cai.id_cai = dao.lector.GetInt32(0);
                    cai.nro_cai = Convert.ToInt64(dao.lector.GetInt64(1));
                    cai.punto_venta = dao.lector.GetInt32(2);
                    cai.fecha_inicio = Convert.ToDateTime(dao.lector.GetDateTime(3));
                    cai.fecha_fin = Convert.ToDateTime(dao.lector.GetDateTime(4));
                    return cai;
                }
                return cai;
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

        public bool AgregarCai(CAIModelo cai)
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("Insert into CAI values(@nro_cai, @punto_venta, @fecha_inicio, @fecha_fin)");
                dao.AgregarParametro("@nro_cai", cai.nro_cai);
                dao.AgregarParametro("@punto_venta", cai.punto_venta);
                dao.AgregarParametro("@fecha_inicio", cai.fecha_inicio);
                dao.AgregarParametro("@fecha_fin", cai.fecha_fin);
                dao.EjecutarAccion();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool ModificarCai(CAIModelo cai)
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("Update CAI set nro_cai=@nro_cai, punto_venta=@punto_venta, fecha_inicio=@fecha_inicio, fecha_fin=@fecha_fin Where id_cai=@id_cai");
                dao.AgregarParametro("@id_cai", cai.id_cai);
                dao.AgregarParametro("@nro_cai", cai.nro_cai);
                dao.AgregarParametro("@punto_venta", cai.punto_venta);
                dao.AgregarParametro("@fecha_inicio", cai.fecha_inicio);
                dao.AgregarParametro("@fecha_fin", cai.fecha_fin);
                dao.EjecutarAccion();
                result = true;
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

        public bool ValidarImpresionCai()
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("select max(fecha_fin) from CAI");
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    DateTime fechaCai = dao.lector.GetDateTime(0);
                    DateTime ahora = DateTime.Now;
                    if (ahora < fechaCai)
                    {
                        result = true;
                    }
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

        public long BuscarCaiVigente()
        {
            DateTime cai;
            DAOMaster dao = new DAOMaster();
            long result = 0;
            try
            {
                dao.SetearQuery("select * from CAI");
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    cai = dao.lector.GetDateTime(4);
                    if (cai > DateTime.Now )
                    {
                        result = dao.lector.GetInt64(1);
                        return result;
                    }
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
    }
}
