using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_Grupo_8.Conexion;
using tp6intento2;


namespace TP6_Grupo_8
{
	public partial class ejercicio1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Page.IsPostBack == false)
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
		protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{

			gvProductos.PageIndex = e.NewPageIndex;
			CargarGridView();
		}

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
			string idProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_it_idProducto")).Text;
        
			Productos productos = new Productos(Convert.ToInt32(idProducto));
			
			GestionProds gestionProds = new GestionProds();
			gestionProds.EliminarProducto(productos);

			CargarGridView();
		}

        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
			gvProductos.EditIndex = e.NewEditIndex;
			CargarGridView();
        }

        protected void gvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
			gvProductos.EditIndex = -1;
			CargarGridView();
        }

        protected void gvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
			string idProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("id_eit_Producto")).Text;
			string nombreProducto = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_nombreProducto")).Text;
			string cantidadxUnidad = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_cxunidad")).Text;
			string precioUnidad = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_precioUnidad")).Text;

			Productos producto = new Productos(Convert.ToInt32(idProducto), nombreProducto, cantidadxUnidad, Convert.ToDecimal(precioUnidad));
			GestionProds gestionProds = new GestionProds();
			gestionProds.ActualizarProducto(producto);
			gvProductos.EditIndex = -1;
			CargarGridView();
		}
    }

	
}

