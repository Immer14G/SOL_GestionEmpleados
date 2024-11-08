using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjGestionEmpleados.Datos
{
     public class D_Empleados
    {
        public DataTable Listar_Empleados(string cBusqueda)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_EMPLEADOS",sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

             

                comando.Parameters.Add("@cBusqueda", SqlDbType.VarChar).Value = cBusqueda;
                sqlCon.Open();
                resultado = comando.ExecuteReader();
               
                tabla.Load(resultado);

                return tabla;


            }
            catch (Exception ex)
            {

                MessageBox.Show (ex.Message);
                throw ex;
            }

            finally
            {
                if(sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }
    }
}
