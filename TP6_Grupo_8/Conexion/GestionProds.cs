using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using TP6_Grupo_8.Conexion;
using TP6_Grupo_8;

namespace tp6intento2
{
    public class GestionProds
    {
        public GestionProds()
        {
            //por defecto.
        }

        private DataTable ObtenerTabla (string nombreTabla, string consultaSQL)
        {
            DataSet dataSet = new DataSet();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter sqlDataAdapter = datos.ObtenerAdapdator(consultaSQL);
            sqlDataAdapter.Fill(dataSet, nombreTabla);
            return dataSet.Tables[nombreTabla];
        }

        public DataTable ObtenerTodosLosDatos ()
        {
            return ObtenerTabla("Productos", "SELECT IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad FROM Productos");
        }

        public void ArmarParametrosProductos(ref SqlCommand comando, Productos producto)
        {
            comando.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Int)
            {
                Value = producto.IdProducto
            });
            comando.Parameters.Add(new SqlParameter("@NombreProducto", SqlDbType.NVarChar, 50)
            {
                Value = producto.NombreProducto
            });
            comando.Parameters.Add(new SqlParameter("@CantidadPorUnidad", SqlDbType.NVarChar, 50)
            {
                Value = producto.CantidadPorUnidad
            });
            comando.Parameters.Add(new SqlParameter("@PrecioUnidad", SqlDbType.Money)
            {
                Value = Convert.ToDecimal(producto.PrecioUnidad)
            });
        }

        public void ArmarParametrosEliminar(ref SqlCommand comando, Productos producto)
        {
            comando.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Int)
            {
                Value = producto.IdProducto
            });
        }
        public int EliminarProducto(Productos producto)
        {
            AccesoDatos datos = new AccesoDatos();
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminar(ref comando, producto);

            List<SqlParameter> parametros = comando.Parameters.Cast<SqlParameter>().ToList();

            return datos.EjecutarProcAlmacenado("EliminarProducto", parametros);
        }
    }
}