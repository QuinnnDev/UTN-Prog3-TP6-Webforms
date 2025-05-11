using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP6_Grupo_8
{
	public class AccesoDatos
	{

		string stringConexion = @"Data Source=localhost\sqlexpress;Initial Catalog = Neptuno; Integrated Security = True";
		//string stringConexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=False";

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

        public int EjecutarProcAlmacenado(SqlCommand comandoSQL, string nombreProcedimientoAlmacenado)
        {
			int filasModificadas;
			SqlConnection sqlConnection = ObtenerConexion();
			SqlCommand sqlCommand = new SqlCommand();
            sqlCommand = comandoSQL;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = nombreProcedimientoAlmacenado;
            filasModificadas = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return filasModificadas;
        }

    }
}