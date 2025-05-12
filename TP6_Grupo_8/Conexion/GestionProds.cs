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
            return ObtenerTabla("Productos", "SELECT IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad, IdProveedor FROM Productos");
        }

        public void ArmarParametrosProductos(ref SqlCommand comando, Productos producto)
        {


            SqlParameter sqlParametros = new SqlParameter();

            sqlParametros = comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            sqlParametros.Value = producto.IdProducto;

            sqlParametros = comando.Parameters.Add("@NombreProducto", SqlDbType.NVarChar, 50);
            sqlParametros.Value = producto.NombreProducto;

            sqlParametros = comando.Parameters.Add("@CantidadPorUnidad", SqlDbType.NVarChar, 50);
            sqlParametros.Value = producto.CantidadPorUnidad;

            sqlParametros = comando.Parameters.Add("@PrecioUnidad", SqlDbType.Money);
            sqlParametros.Value = producto.PrecioUnidad;
        }

        public void ArmarParametrosEliminar(ref SqlCommand comando, Productos producto)
        {
            comando.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Int)
            {
                Value = producto.IdProducto
            });
        }
        public bool EliminarProducto(Productos producto)
        {
            SqlCommand sqlCommand = new SqlCommand();
            ArmarParametrosEliminar(ref sqlCommand, producto);
            AccesoDatos accesoDatos = new AccesoDatos();
            int filasModificadas = accesoDatos.EjecutarProcAlmacenado(sqlCommand, "spEliminarProducto");
            if (filasModificadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ActualizarProducto(Productos producto)
        {
            SqlCommand sqlCommand = new SqlCommand();
            ArmarParametrosProductos(ref sqlCommand, producto);
            AccesoDatos accesoDatos = new AccesoDatos();
            int FilasInsertadas = accesoDatos.EjecutarProcAlmacenado(sqlCommand, "spActualizarProducto");
            if (FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}