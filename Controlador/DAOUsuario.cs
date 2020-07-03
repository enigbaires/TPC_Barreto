using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class DAOUsuario : DAOMaster
    {
        public UsuarioModelo ValidarUsuario(String email, String password)
        {
            UsuarioModelo usuario = new UsuarioModelo();
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from usuarioListarView where password = @password and @email = email");
                dao.AgregarParametro("@email", email);
                dao.AgregarParametro("@password", password);
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    usuario = new UsuarioModelo();
                    usuario.id_usuario = dao.lector.GetInt32(0);
                    usuario.nombre = dao.lector.GetString(1);
                    usuario.usuario_code1 = dao.lector.GetString(2);
                    usuario.email = dao.lector.GetString(3);
                    usuario.password = dao.lector.GetString(4);
                    usuario.usuario_tipo = dao.lector.GetInt32(5);
                    usuario.usuario_habilitado = dao.lector.GetInt32(6);
                    return usuario;
                }
                return usuario;
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

        public List<UsuarioModelo> ListarUsuariosViewIf(int if1, int if2)
        {
            List<UsuarioModelo> lista = new List<UsuarioModelo>();
            UsuarioModelo aux = new UsuarioModelo();
            DAOMaster datos = new DAOMaster();
            try
            {
                datos.SetearQuery("select * from usuarioListarView");
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    if (if1 == datos.lector.GetInt32(6) || if2 == datos.lector.GetInt32(6))
                    {
                        aux = new UsuarioModelo();
                        aux.id_usuario = datos.lector.GetInt32(0);
                        aux.nombre = datos.lector.GetString(1);
                        aux.usuario_code1 = datos.lector.GetString(2);
                        aux.email = datos.lector.GetString(3);
                        aux.password = datos.lector.GetString(4);
                        aux.usuario_tipo = datos.lector.GetInt32(5);
                        aux.usuario_habilitado = datos.lector.GetInt32(6);
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

        public List<UsuarioModelo> ListarUsuarios(String condicion)
        {
            List<UsuarioModelo> listadoUsuarios = new List<UsuarioModelo>();
            switch (condicion)
            {
                case "habilitados":
                    listadoUsuarios = ListarUsuariosViewIf(1, 1);
                    break;

                case "nohabilitados":
                    listadoUsuarios = ListarUsuariosViewIf(0, 0);
                    break;

                case "todos":
                    listadoUsuarios = ListarUsuariosViewIf(0, 1);
                    break;
                default:
                    break;
            }
            return listadoUsuarios;
        }

        public bool agregarUsuarioConSP(UsuarioModelo usuario)
        {
            //para poder usar este metodo, primero hay que hacer esto en la DB:
            //create procedure spAltaUsuario
            //@nombre varchar(150),
            //@usuario_code1  varchar(50),
            //@email varchar(50),
            //@password varchar(150),
            //@usuario_tipo int
            //as
            //insert into USUARIO values(@nombre, @usuario_code1, @email, @password, @usuario_tipo, 1)

            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearSP("spAltaUsuario");
                dao.AgregarParametro("@nombre", usuario.nombre);
                dao.AgregarParametro("@usuario_code1", usuario.usuario_code1);
                dao.AgregarParametro("@email", usuario.email);
                dao.AgregarParametro("@password", usuario.password);
                dao.AgregarParametro("@usuario_tipo", usuario.usuario_tipo);
                dao.EjecutarAccion();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public UsuarioModelo ListarUnUsuarioView(int id)
        {   
            UsuarioModelo usuario = new UsuarioModelo();
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from usuarioListarView where id_usuario = @id_usuario");
                dao.AgregarParametro("@id_usuario", id);
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    usuario = new UsuarioModelo();
                    usuario.id_usuario = dao.lector.GetInt32(0);
                    usuario.nombre = dao.lector.GetString(1);
                    usuario.usuario_code1 = dao.lector.GetString(2);
                    usuario.email = dao.lector.GetString(3);
                    usuario.password = dao.lector.GetString(4);
                    usuario.usuario_tipo = dao.lector.GetInt32(5);
                    usuario.usuario_habilitado = dao.lector.GetInt32(6);
                    return usuario;
                }
                return usuario;
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

        public String NombreUsuario(int id)
        {
            String nombre = "";
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select nombre from usuarioListarView where id_usuario = @id_usuario");
                dao.AgregarParametro("@id_usuario", id);
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    nombre = dao.lector.GetString(0);
                    return nombre;
                }
                return nombre;
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
        public bool ModificarUsuario(UsuarioModelo usuario, string condicion)
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("Update USUARIO set nombre=@nombre, usuario_code1=@usuario_code1, email=@email, password=@password, usuario_tipo=@usuario_tipo, usuario_habilitado=@usuario_habilitado  Where id_usuario=@id_usuario");
                dao.AgregarParametro("@id_usuario", usuario.id_usuario);
                dao.AgregarParametro("@nombre", usuario.nombre);
                dao.AgregarParametro("@usuario_code1", usuario.usuario_code1);
                dao.AgregarParametro("@email", usuario.email);
                dao.AgregarParametro("@password", usuario.password);
                dao.AgregarParametro("@usuario_tipo", usuario.usuario_tipo);
                if (condicion == "modificacion") { dao.AgregarParametro("@usuario_habilitado", 1); } else { dao.AgregarParametro("@usuario_habilitado", 0); };
                dao.EjecutarAccion();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
