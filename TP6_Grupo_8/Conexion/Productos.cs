using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_Grupo_8.Conexion
{
    public class Productos
    {
        private int _idProductos;
        private string _nombreProducto;
        private int _idProvedor;
        private int _idCategoria;
        private int _cantidadPorUnidad;
        private double _precioUnidad;
        private int _unidadesEnExistencia;
        private int _unidadesEnPedido;
        private int _nivelNuevoPedido;
        private bool _suspedido;


        public Productos() {
            //clase por defecto
        }

        public Productos(int idProductos, string nombreProducto, int idProvedor,
            int idCategoria, int cantidadPorUnidad, double precioUnidad, int unidadesEnExistencia,
            int unidadesEnPedido, int nivelNuevoPedido, bool suspendido)
        {
            _idProductos = idProductos;
            _nombreProducto = nombreProducto;
            _idProvedor = idProvedor;
            _idCategoria = idCategoria;
            _cantidadPorUnidad = cantidadPorUnidad;
            _precioUnidad = precioUnidad;
            _unidadesEnExistencia = unidadesEnExistencia;
            _unidadesEnPedido = unidadesEnPedido;
            _unidadesEnPedido = unidadesEnPedido;
            _nivelNuevoPedido = nivelNuevoPedido;
            _suspedido = suspendido;
        }


    }
}