using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class DAOArchivoAdjunto : DAOMaster
    {
        public bool Agregar(ArchivoAdjuntoModelo archivo)
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("Insert into ARCHIVO_ADJUNTO values(@id_solicitud, @descripcion_archivo, @fecha_upload)");

                dao.AgregarParametro("@id_solicitud", archivo.id_solicitud);
                dao.AgregarParametro("@descripcion_archivo", archivo.descripcion_archivo);
                dao.AgregarParametro("@fecha_upload", archivo.fecha_upload);
                dao.EjecutarAccion();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public ArchivoAdjuntoModelo ListarUnArchivo(int id_solicitud)
        {
            ArchivoAdjuntoModelo archivo = new ArchivoAdjuntoModelo();
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from ARCHIVO_ADJUNTO where id_solicitud = @id_solicitud");
                dao.AgregarParametro("@id_solicitud", id_solicitud);
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    archivo = new ArchivoAdjuntoModelo();
                    archivo.id_solicitud = dao.lector.GetInt32(0);
                    archivo.descripcion_archivo = dao.lector.GetString(1);
                    archivo.fecha_upload = dao.lector.GetDateTime(2);
                    return archivo;
                }
                return archivo;
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
