using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class DAOArticulo : DAOMaster
    {
        
        public List<ArticuloModelo> ListarArticuloConIf(int if1, int if2)
        {
            List<ArticuloModelo> lista = new List<ArticuloModelo>();
            ArticuloModelo aux = new ArticuloModelo();
            DAOMaster datos = new DAOMaster();
            try
            {
                datos.SetearQuery("select * from ARTICULO");
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    if (if1 == datos.lector.GetInt32(3) || if2 == datos.lector.GetInt32(3))
                    {
                        aux = new ArticuloModelo();
                        aux.id_articulo = datos.lector.GetInt32(0);
                        aux.codigo_articulo = datos.lector.GetString(1);
                        aux.descripcion_articulo = datos.lector.GetString(2);
                        aux.habilitado_articulo = datos.lector.GetInt32(3);                        
                        lista.Add(aux);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
                datos = null;
            }
        }

        public List<ArticuloModelo> ListarArticulo(String condicion)
        {
            List<ArticuloModelo> lista = new List<ArticuloModelo>();
            int if1 = 1, if2 = 1;
            switch (condicion)
            {
                case "habilitados":
                    if1 = 1;
                    if2 = 1;
                    break;

                case "nohabilitados":
                    if1 = 0;
                    if2 = 0;
                    break;

                case "todos":
                    if1 = 0;
                    if2 = 1;
                    break;
                default:
                    break;
            }

            lista = ListarArticuloConIf(if1, if2);
            return lista;
        }

        public bool ModificarArticulo(ArticuloModelo articulo)
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("Update ARTICULO set codigo_articulo=@codigo_articulo, descripcion_articulo=@descripcion_articulo, habilitado_articulo=@habilitado_articulo Where id_articulo=@id_articulo");
                dao.AgregarParametro("@id_articulo", articulo.id_articulo);
                dao.AgregarParametro("@codigo_articulo", articulo.codigo_articulo);
                dao.AgregarParametro("@descripcion_articulo", articulo.descripcion_articulo);
                dao.AgregarParametro("@habilitado_articulo", articulo.habilitado_articulo);
                dao.EjecutarAccion();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool AgregarArticulo(ArticuloModelo articulo)
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("Insert into ARTICULO values(@codigo_articulo, @descripcion_articulo, @habilitado_articulo)");
                
                dao.AgregarParametro("@codigo_articulo", articulo.codigo_articulo);
                dao.AgregarParametro("@descripcion_articulo", articulo.descripcion_articulo);
                dao.AgregarParametro("@habilitado_articulo", 1);
                dao.EjecutarAccion();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public ArticuloModelo ListarUnArticulo(int id)
        {
            ArticuloModelo articulo = new ArticuloModelo();
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from ARTICULO where id_articulo = @id_articulo");
                dao.AgregarParametro("@id_articulo", id);
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    articulo = new ArticuloModelo();
                    articulo.id_articulo = dao.lector.GetInt32(0);
                    articulo.codigo_articulo = dao.lector.GetString(1);
                    articulo.descripcion_articulo = dao.lector.GetString(2);
                    articulo.habilitado_articulo = dao.lector.GetInt32(3);
                    return articulo;
                }
                return articulo;
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
