using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP6_Grupo_8
{
	public class AccesoDatos
	{

		string stringConexion = @"Data Source=localhost\sqlexpress;Initial Catalog = Neptuno; Integrated Security = True";

		public SqlConnection ObtenerConexion()
		{
			SqlConnection sqlConnection = new SqlConnection(stringConexion);
			try
			{
				sqlConnection.Open();
				return sqlConnection;
			}
			catch (Exception ex) {
				return null;
			}
		}

		public SqlDataAdapter ObtenerAdapdator(string consultaSQL)
		{
			SqlDataAdapter sqlAdapter;
			try
			{
				sqlAdapter = new SqlDataAdapter(consultaSQL, ObtenerConexion());
				return sqlAdapter;
			}
			catch (Exception exception)
			{
				return null;
			}
		}

        public int EjecutarProcAlmacenado(string nombreProcedimiento, List<SqlParameter> parametros)
        {
			SqlConnection conexion = ObtenerConexion();
            try
            {
                SqlCommand comando = new SqlCommand(nombreProcedimiento, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        comando.Parameters.Add(parametro);
                    }
                }

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

    }
}