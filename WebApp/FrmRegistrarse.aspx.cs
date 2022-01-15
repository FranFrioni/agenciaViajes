using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace WebApp
{
    public partial class FrmRegistrarse : System.Web.UI.Page
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

        protected void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            int ced = 0;
            if(!Int32.TryParse(TxtCedula.Text, out ced) || TxtCedula.Text.Length < 7 || TxtCedula.Text.Length > 9 || TxtNombre.Text.Length < 2 || TxtApellido.Text.Length < 2 || TxtClave.Text.Length < 6 || !TestPassword())
            {
                TxtMensaje.Text = "Necesita ingresar opciones validas.";
            } else
            {
                Cliente unUsuario = new Cliente(TxtCedula.Text, TxtNombre.Text, TxtApellido.Text, TxtClave.Text);
                if (Agencia.Instancia.AgregarUsuario(unUsuario))
                {
                    Session["Usuario"] = unUsuario;
                    Response.Redirect("FrmInicio.aspx");
                }
            }

        }

        private bool TestPassword()
        {
            bool oneDigit = false;
            bool oneUpper = false;
            bool oneLower = false;
            for (int i = 0; i < TxtClave.Text.Length; i++)
            {
                if (Char.IsDigit(TxtClave.Text[i]))
                {
                    oneDigit = true;
                } else if (Char.IsUpper(TxtClave.Text[i]))
                {
                    oneUpper = true;
                } else if (Char.IsLower(TxtClave.Text[i]))
                {
                    oneLower = true;
                }
            }
            if (oneDigit && oneUpper && oneLower)
            {
                return true;
            }
            return false;
        }
    }
}