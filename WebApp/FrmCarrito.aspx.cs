using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace WebApp
{
    public partial class FrmCarrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null || Session["Usuario"] is Administrador)
                {
                    Response.Redirect("FrmInicio.aspx");
                }
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}