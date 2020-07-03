using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class DAOEmpresa : DAOMaster
    {
        public List<EmpresaModelo> ListarEmpresasConIf(int if1, int if2, int tipo1, int tipo2)
        {
            List<EmpresaModelo> lista = new List<EmpresaModelo>();
            EmpresaModelo aux = new EmpresaModelo();
            DAOMaster datos = new DAOMaster();
            try
            {
                datos.SetearQuery("select * from EMPRESA");
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    if ((if1 == datos.lector.GetInt32(9) || if2 == datos.lector.GetInt32(9)) && (tipo1 == datos.lector.GetInt32(8) || tipo2 == datos.lector.GetInt32(8)))
                    {
                        aux = new EmpresaModelo();
                        aux.id_empresa = datos.lector.GetInt32(0);
                        aux.cuit = datos.lector.GetString(1);
                        aux.razon_social = datos.lector.GetString(2);
                        aux.numero_sap_empresa = datos.lector.GetInt32(3);
                        aux.direccion_legal = datos.lector.GetString(4);
                        aux.direccion_entrega = datos.lector.GetString(5);
                        aux.telefono = datos.lector.GetString(6);
                        aux.email = datos.lector.GetString(7);
                        aux.tipo_empresa = datos.lector.GetInt32(8);
                        aux.habilitado_empresa = datos.lector.GetInt32(9);
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

        public List<EmpresaModelo> ListarEmpresas(String condicion, String tipo)
        {
            List<EmpresaModelo> listadoEmpresas = new List<EmpresaModelo>();
            int if1 = 1, if2 = 1, tipo1 = 1, tipo2 = 1;
            switch (condicion)
            {
                case "habilitadas":
                    if1 = 1;
                    if2 = 1;
                    break;

                case "nohabilitadas":
                    if1 = 0;
                    if2 = 0;
                    break;

                case "todas":
                    if1 = 0;
                    if2 = 1;
                    break;
                default:
                    break;
            }

            switch (tipo)
            {
                case "transportista":
                    tipo1 = 1;
                    tipo2 = 1;
                    break;

                case "cliente":
                    tipo1 = 0;
                    tipo2 = 0;
                    break;

                case "todas":
                    tipo1 = 0;
                    tipo2 = 1;
                    break;
                default:
                    break;
            }
            listadoEmpresas = ListarEmpresasConIf(if1, if2, tipo1, tipo2);
            return listadoEmpresas;
        }

        public bool ModificarEmpresa(EmpresaModelo empresa, string condicion)
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("Update EMPRESA set cuit=@cuit, razon_social=@razonSocial, numero_sap_empresa=@nroSAP, direccion_legal=@dirLegal, direccion_entrega=@dirEntrega, telefono=@telefono, email=@email, tipo_empresa=@tipoEmpresa, habilitado_empresa=@habilitadoEmpresa Where id_empresa=@id_empresa");
                dao.AgregarParametro("@id_empresa", empresa.id_empresa);
                dao.AgregarParametro("@cuit", empresa.cuit);
                dao.AgregarParametro("@razonSocial", empresa.razon_social);
                dao.AgregarParametro("@nroSAP", empresa.numero_sap_empresa);
                dao.AgregarParametro("@dirLegal", empresa.direccion_legal);
                dao.AgregarParametro("@dirEntrega", empresa.direccion_entrega);
                dao.AgregarParametro("@telefono", empresa.telefono);
                dao.AgregarParametro("@email", empresa.email);
                dao.AgregarParametro("@tipoEmpresa", empresa.tipo_empresa);
                if (condicion == "modificacion") { dao.AgregarParametro("@habilitadoEmpresa", 1); } else { dao.AgregarParametro("@habilitadoEmpresa", 0); };
                dao.EjecutarAccion();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool AgregarEmpresa(EmpresaModelo empresa)
        {
            DAOMaster dao = new DAOMaster();
            bool result = false;
            try
            {
                dao.SetearQuery("Insert into EMPRESA values(@cuit, @razonSocial, @nroSAP, @dirLegal, @dirEntrega, @telefono, @email, @tipoEmpresa, @habilitadoEmpresa)");
                dao.AgregarParametro("@cuit", empresa.cuit);
                dao.AgregarParametro("@razonSocial", empresa.razon_social);
                dao.AgregarParametro("@nroSAP", empresa.numero_sap_empresa);
                dao.AgregarParametro("@dirLegal", empresa.direccion_legal);
                dao.AgregarParametro("@dirEntrega", empresa.direccion_entrega);
                dao.AgregarParametro("@telefono", empresa.telefono);
                dao.AgregarParametro("@email", empresa.email);
                dao.AgregarParametro("@tipoEmpresa", empresa.tipo_empresa);
                dao.AgregarParametro("@habilitadoEmpresa", 1);
                dao.EjecutarAccion();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public EmpresaModelo ListarUnaEmpresa(int id)
        {
            EmpresaModelo empresa = new EmpresaModelo();
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select * from EMPRESA where id_empresa = @id_empresa");
                dao.AgregarParametro("@id_empresa", id);
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    empresa = new EmpresaModelo();
                    empresa.id_empresa = dao.lector.GetInt32(0);
                    empresa.cuit = dao.lector.GetString(1);
                    empresa.razon_social = dao.lector.GetString(2);
                    empresa.numero_sap_empresa = dao.lector.GetInt32(3);
                    empresa.direccion_legal = dao.lector.GetString(4);
                    empresa.direccion_entrega = dao.lector.GetString(5);
                    empresa.telefono = dao.lector.GetString(6);
                    empresa.email = dao.lector.GetString(7);
                    empresa.tipo_empresa = dao.lector.GetInt32(8);
                    empresa.habilitado_empresa = dao.lector.GetInt32(9);
                    return empresa;
                }
                return empresa;
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

        public String NombreEmpresa(int id)
        {
            String empresa = "";
            DAOMaster dao = new DAOMaster();
            try
            {
                dao.SetearQuery("select razon_social from EMPRESA where id_empresa = @id_empresa");
                dao.AgregarParametro("@id_empresa", id);
                dao.EjecutarLector();
                while (dao.lector.Read())
                {
                    empresa = dao.lector.GetString(0);
                    return empresa;
                }
                return empresa;
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
