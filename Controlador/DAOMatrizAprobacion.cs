using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class DAOMatrizAprobacion : DAOMaster
    {
        public bool Agregar(int idSolicitante, int idAprobador)
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("Insert into MATRIZ_APROBACION values(@id_usuario_solicitante, @id_usuario_aprobador)");
                dao.AgregarParametro("@id_usuario_solicitante", idSolicitante);
                dao.AgregarParametro("@id_usuario_aprobador", idAprobador);
                dao.EjecutarAccion();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public bool Modificar(MatrizAprobacion matriz)
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("Update MATRIZ_APROBACION set id_usuario_solicitante=@id_usuario_solicitante, id_usuario_aprobador=@id_usuario_aprobador Where id_matriz=@id_matriz");
                dao.AgregarParametro("@id_usuario_solicitante", matriz.id_usuario_solicitante);
                dao.AgregarParametro("@id_usuario_aprobador", matriz.id_usuario_aprobador);
                dao.AgregarParametro("@id_matriz", matriz.id_matriz);
                dao.EjecutarAccion();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public bool Eliminar(int id_matriz)
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("DELETE MATRIZ_APROBACION Where id_matriz=@id_matriz");
                dao.AgregarParametro("@id_matriz", id_matriz);
                dao.EjecutarAccion();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public List<MatrizAprobacion> ListarTodo()
        {
            List<MatrizAprobacion> lista = new List<MatrizAprobacion>();
            MatrizAprobacion aux = new MatrizAprobacion();
            DAOMaster datos = new DAOMaster();
            try
            {
                datos.SetearQuery("select * from MATRIZ_APROBACION");
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    aux = new MatrizAprobacion();
                    aux.id_matriz = datos.lector.GetInt32(0);
                    aux.id_usuario_solicitante = datos.lector.GetInt32(1);
                    aux.id_usuario_aprobador = datos.lector.GetInt32(2);
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
                datos.CerrarConexion();
                datos = null;
            }
        }
        public UsuarioIdNombreModelo ListarUnaMatriz(int id_matriz)
        {   
            DAOMaster daoMatriz = new DAOMaster();
            UsuarioIdNombreModelo usuarioIdNombreModelo = new UsuarioIdNombreModelo();

            try
            {
                daoMatriz.SetearQuery("select * from MATRIZ_APROBACION where id_matriz = @id_matriz");
                daoMatriz.AgregarParametro("@id_matriz", id_matriz);
                daoMatriz.EjecutarLector();
                while (daoMatriz.lector.Read())
                {
                    
                    usuarioIdNombreModelo.id_matriz = daoMatriz.lector.GetInt32(0);
                    usuarioIdNombreModelo.id_usuario_solicitante = daoMatriz.lector.GetInt32(1);
                    usuarioIdNombreModelo.id_usuario_aprobador = daoMatriz.lector.GetInt32(2);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                daoMatriz.CerrarConexion();
            }

            DAOMaster daoSolicitante = new DAOMaster();
            try
            {
                daoSolicitante.SetearQuery("select nombre from USUARIO where id_usuario = @id_usuario");
                daoSolicitante.AgregarParametro("@id_usuario", usuarioIdNombreModelo.id_usuario_solicitante);
                daoSolicitante.EjecutarLector();
                while (daoSolicitante.lector.Read())
                {   
                    usuarioIdNombreModelo.nombre_solicitante = daoSolicitante.lector.GetString(0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                daoSolicitante.CerrarConexion();
            }

            DAOMaster daoAprobador = new DAOMaster();
            try
            {
                daoAprobador.SetearQuery("select nombre from USUARIO where id_usuario = @id_usuario");
                daoAprobador.AgregarParametro("@id_usuario", usuarioIdNombreModelo.id_usuario_aprobador);
                daoAprobador.EjecutarLector();
                while (daoAprobador.lector.Read())
                {
                    usuarioIdNombreModelo.nombre_aprobador = daoAprobador.lector.GetString(0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                daoAprobador.CerrarConexion();
            }
            return usuarioIdNombreModelo;
        }
        public bool BuscarTipoUsuario(int id_usuario, String tipoBuscado)
        {
            DAOMaster daoMatriz = new DAOMaster();
            try
            {
                if (tipoBuscado=="aprobador")
                {
                    daoMatriz.SetearQuery("select * from MATRIZ_APROBACION where id_usuario_aprobador = @id_usuario_aprobador");
                    daoMatriz.AgregarParametro("@id_usuario_aprobador", id_usuario);
                }
                else
                {
                    daoMatriz.SetearQuery("select * from MATRIZ_APROBACION where id_usuario_solicitante = @id_usuario_solicitante");
                    daoMatriz.AgregarParametro("@id_usuario_solicitante", id_usuario);
                }
                daoMatriz.EjecutarLector();
                while (daoMatriz.lector.Read())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                daoMatriz.CerrarConexion();
            }
            return false;
        }
    }
}
