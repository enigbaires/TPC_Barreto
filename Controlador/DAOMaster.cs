using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class DAOMaster
    {
        public SqlDataReader lector { get; set; }
        public SqlConnection conexion { get; }
        public SqlCommand comando { get; set; }

        public DAOMaster()
        {
            conexion = new SqlConnection("data source = YY118297\\SQLEXPRESS; initial catalog = BARRETO_DB; integrated security = sspi;");
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        public void SetearQuery(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        // setear un stored procedure
        public void SetearSP(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void AgregarParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void EjecutarLector()
        {
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // conexion.Close();
            }
        }

        public void CerrarConexion()
        {
            conexion.Close();
        }

        internal bool EjecutarAccion()
        {
            bool result = false;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return result;
        }
    }
}
