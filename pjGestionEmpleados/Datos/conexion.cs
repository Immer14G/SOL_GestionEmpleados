using System;
using System.Data.SqlClient;

namespace pjGestionEmpleados.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private static Conexion con = null;

        // Constructor de la clase 
        private Conexion()
        {
            this.Servidor = "IMMER\\SQLEXPRESS";
            this.Base = "bd_gestion_empleados";
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();

            try
            {
                Cadena.ConnectionString = $"Server={this.Servidor}; Database={this.Base}; Integrated Security=True;";
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }

            return Cadena;
        }

        public static Conexion crearInstancia()
        {
            if (con == null)
            {
                con = new Conexion();
            }
            return con;
        }
    }
}
