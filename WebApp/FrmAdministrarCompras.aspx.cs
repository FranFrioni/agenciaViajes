using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace WebApp
{
    public partial class FrmAdministrarCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null || Session["Usuario"] is Cliente)
                {
                    Response.Redirect("FrmInicio.aspx");
                }
            }
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            MostrarComprasEntreFechas();
        }

        private void MostrarComprasEntreFechas()
        {
            string tipo = "";
            float totalGanancia = 0;
            string html = "<table class='table'><tr><th>Apellido</th><th>Nombre</th><th>Exucrsion Comprada(Codigo)</th><th>Descripcion de Excursion</th><th>Tipo de Excursion</th><th>Cantidad Pasajeros</th><th>Precio por Pasajero</th><th>Precio Compra</th></tr>";
            List<Compra> compras = new List<Compra>();
            foreach (Compra compra in Agencia.Instancia.Compras)
            {
                if(CalInicio.SelectedDate <= compra.FechaDeCompra && CalFinal.SelectedDate >= compra.FechaDeCompra)
                {
                    if(compra.ExcursionComprada is Internacionales)
                    {
                        tipo = "Internacional";
                    } else if (compra.ExcursionComprada is Nacionales)
                    {
                        tipo = "Nacional";
                    }
                    totalGanancia += compra.PrecioCompra;
                    html += "<tr><td>" + compra.Usuario.Apellido + "</td><td>" + compra.Usuario.Nombre + "</td><td>" + compra.ExcursionComprada.Codigo + "</td><td>" + compra.ExcursionComprada.Descripcion + "</td><td>" + tipo + "</td><td>" + (compra.PasajesDeMayores + compra.PasajesDeMenores) + "</td><td>$" + (compra.PrecioCompra / (compra.PasajesDeMayores + compra.PasajesDeMenores)) + "</td><td>$" + compra.PrecioCompra + "</td></tr>";
                }

            }
            html += "<tr><td colespan='4'>Total: $"+ totalGanancia +"</td></tr></table>";
            LitCompras.Text = html;
        }
    }
}