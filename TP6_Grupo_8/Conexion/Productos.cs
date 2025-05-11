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
        private string _cantidadPorUnidad;
        private decimal _precioUnidad;
        private int _unidadesEnExistencia;
        private int _unidadesEnPedido;
        private int _nivelNuevoPedido;
        private bool _suspedido;


        // Getters y setters
        public int IdProducto { get => _idProductos; set => _idProductos = value; }
        public string NombreProducto { get => _nombreProducto; set => _nombreProducto = value; }
        public string CantidadPorUnidad { get => _cantidadPorUnidad; set => _cantidadPorUnidad = value; }
        public decimal PrecioUnidad { get => _precioUnidad; set => _precioUnidad = value; }



        public Productos() {
            //constructor por defecto
        }

        public Productos(int idProductos)
        {
            _idProductos = idProductos;
        }

        public Productos (int idProductos, string nombreProducto, string cantidadPorUnidad, decimal precioUnidad)
        {
            _idProductos = idProductos;
            _nombreProducto = nombreProducto;
            _cantidadPorUnidad = cantidadPorUnidad;
            _precioUnidad = precioUnidad;

        }
        public Productos(int idProductos, string nombreProducto, int idProvedor,
            int idCategoria, string cantidadPorUnidad, decimal precioUnidad, int unidadesEnExistencia,
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