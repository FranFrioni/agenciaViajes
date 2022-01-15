using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace WebApp
{
    public partial class FrmIniciarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Response.Redirect("FrmInicio.aspx");
                }
            }
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            Usuario unUsuario = Agencia.Instancia.BuscarUsuario(TxtUsername.Text, TxtPassword.Text);
            if (unUsuario != null)
            {
                Session["Usuario"] = unUsuario;
                Response.Redirect("FrmInicio.aspx");
            }
            else
            {
                LblMensaje.Text = "Nombre de usuario o clave incorrecta";
            }
        }
    }
}