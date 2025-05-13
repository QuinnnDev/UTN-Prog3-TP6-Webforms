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
    public partial class MostrarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                cargarGridView();
            }
        }

        private void cargarGridView()
        {
            GestionProds gestionProductos = new GestionProds();
            gvProductos.DataSource = gestionProductos.ObtenerTodosLosDatos();
            gvProductos.DataBind();
        }
    }
}