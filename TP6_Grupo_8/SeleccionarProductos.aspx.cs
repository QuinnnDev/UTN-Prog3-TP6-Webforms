using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tp6intento2;

namespace TP6_Grupo_8
{
	public partial class SeleccionarProductos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		  if(!Page.IsPostBack)
			{
				CargarGridView();
			}
		}
        private void CargarGridView()
        {
            GestionProds gestionProds = new GestionProds();
            gvProductos.DataSource = gestionProds.ObtenerTodosLosDatos();
            gvProductos.DataBind();
        }

        protected void gvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (e.NewSelectedIndex >= 0 && e.NewSelectedIndex < gvProductos.Rows.Count)
            {
                GridViewRow fila = gvProductos.Rows[e.NewSelectedIndex];

                string IdProducto = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_idProducto")).Text;
                string NombreProducto = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_NombreProducto")).Text;
                string IdProveedor = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_IdProveedor")).Text;
                string PrecioUnitario = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_PrecioUnidad")).Text;


                DataTable tabla;
                if (Session["ProductosSeleccionados"] == null)
                {
                    tabla = new DataTable();
                    tabla.Columns.Add("Id");
                    tabla.Columns.Add("Nombre");
                    tabla.Columns.Add("Proveedor");
                    tabla.Columns.Add("Precio");
                }
                else
                {
                    tabla = (DataTable)Session["ProductosSeleccionados"];
                }

                bool repetido = false;
                foreach (DataRow row in tabla.Rows)
                {
                    if (row["Id"].ToString() == IdProducto)
                    {
                        repetido = true;
                        break;
                    }
                }

                if (!repetido)
                {
                    DataRow nuevaFila = tabla.NewRow();
                    nuevaFila["Id"] = IdProducto;
                    nuevaFila["Nombre"] = NombreProducto;
                    nuevaFila["Proveedor"] = IdProveedor;
                    nuevaFila["Precio"] = PrecioUnitario;
                    tabla.Rows.Add(nuevaFila);

                    lblProductoSeleccionado.Text = "Producto agregado: " + NombreProducto;
                }
                else
                {
                    lblProductoSeleccionado.Text = "El producto '" + NombreProducto + "' ya fue agregado.";
                }

                Session["ProductosSeleccionados"] = tabla;

                addedprods.Text = "Productos seleccionados:<br/>";
                foreach (DataRow row in tabla.Rows)
                {
                    addedprods.Text += "- " + row["Nombre"] + "<br/>";
                }

            }
        }
    }
}
