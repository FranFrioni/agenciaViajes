using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace WebApp
{
    public partial class FrmEstadisticas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    if (Session["Usuario"] == null || Session["Usuario"] is Cliente)
                    {
                        Response.Redirect("FrmInicio.aspx");
                    }
                }
                CargarDDLDestinos();
            }
        }

        private void CargarDDLDestinos()
        {
            int i = 0;
            foreach (Destino destino in Agencia.Instancia.Destinos)
            {
                ListItem des = new ListItem();
                des.Text = destino.Ciudad + "-" + destino.Pais;
                des.Value = Convert.ToString(i);
                DdlDestinos.Items.Add(des);
                i++;
            }
            
        }
        protected void DdlDestinos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string html = "<table class='table'><tr><th>Codigo</th><th>Descripcion</th><th>Fecha de Comienzo</th><th>Dias Totales</th><th>Stock</th><th>Identificador</th></tr>";
            List<Excursion> excursiones = Agencia.Instancia.BuscarExcursionesPorDestino(Convert.ToInt32(DdlDestinos.SelectedValue));
            foreach (Excursion excursion in excursiones)
            {
                html += "<tr><td>" + excursion.Codigo + "</td><td>" + excursion.Descripcion + "</td><td>" + excursion.FechaComienzo.ToShortDateString() + "</td><td>" + excursion.DiasTotales + "</td><td>" + excursion.Stock + "</td><td>" + excursion.Identificador + "</tr>";
            }
            html += "</table>";
            LitExcursiones.Text = html;
        }
    }
}
