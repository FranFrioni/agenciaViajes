using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace WebApp
{
    public partial class FrmCancelarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null || Session["Usuario"] is Administrador || Request.QueryString["CompraCli"] == null)
                {
                    Response.Redirect("FrmInicio.aspx");
                }
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            double numDias = 0;
            DateTime hoy = DateTime.Today;
            int i = Convert.ToInt32(Request.QueryString["CompraCli"]);
            List<Compra> compras = new List<Compra>();
            foreach (Compra compra in Agencia.Instancia.Compras)
            {
                if (compra.Usuario == Session["Usuario"])
                {
                    compras.Add(compra);
                }
            }
            int h = Agencia.Instancia.Compras.IndexOf(compras[i]);
            DateTime FechaInicioCompra = Agencia.Instancia.Compras[h].ExcursionComprada.FechaComienzo;
            TimeSpan tiempo = FechaInicioCompra.Date - hoy.Date;
            numDias = tiempo.TotalDays;
            if (numDias > 10)
            {
                Agencia.Instancia.Compras.RemoveAt(h);
                Response.Redirect("FrmCarrito.aspx");
            } else
            {
                LblMensaje.Text = "Lo sentimos, pero ya es muy tarde como para cancelar esta compra.";
            }
            
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmCarrito.aspx");
        }
    }
}