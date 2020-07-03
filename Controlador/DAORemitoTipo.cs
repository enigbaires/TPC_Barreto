using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class DAORemitoTipo : DAOMaster
    {
        public List<RemitoTipoModelo> ListarTodosTipos()
        {
            List<RemitoTipoModelo> lista = new List<RemitoTipoModelo>();
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from REMITO_TIPO");
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    RemitoTipoModelo remitoTipo = new RemitoTipoModelo();
                    remitoTipo.id_tipo_remito = dao.lector.GetInt32(0);
                    remitoTipo.descripcion_remito = dao.lector.GetString(1);
                    lista.Add(remitoTipo);
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
