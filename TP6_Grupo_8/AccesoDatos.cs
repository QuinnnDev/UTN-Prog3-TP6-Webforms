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

	}
}