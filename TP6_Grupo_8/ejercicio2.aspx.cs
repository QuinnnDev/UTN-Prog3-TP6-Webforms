using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_Grupo_8
{
	public partial class ejercicio2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                lblMensaje.Text = "";
            }
		}

        protected void btnEliminarSeleccionados_Click(object sender, EventArgs e)
        {
            Session["ProductosSeleccionados"] = null;
            lblMensaje.Text = "¡Se eliminaron los productos seleccionados!";
        }
    }
}