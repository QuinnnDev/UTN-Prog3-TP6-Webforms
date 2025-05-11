using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
	}

	
}

