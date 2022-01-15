using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace WebApp
{
    public partial class FrmVerExcursion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    if (Session["Usuario"] is Administrador || Request.QueryString["CodExc"] == null)
                    {
                        Response.Redirect("FrmInicio.aspx");
                    }
                }
                MostrarDatosEspecificos();
            }
        }
        private void MostrarDatosEspecificos()
        {
            string html = "<table class='table'><tr><th>Ciudad</th><th>Pais</th><th>Cantidad de Dias</th><th>Coste Diario (Dolares)</th></tr>";
            if (Request.QueryString["CodExc"] == null)
            {
                //Redireccionar a pagina not found
            }
            else
            {
                int CodExc = Convert.ToInt32(Request.QueryString["CodExc"]);
                Excursion excursion = Agencia.Instancia.BuscarExcursionPorCodigo(CodExc);
                foreach (Destino destino in excursion.Destinos)
                {
                    html += "<tr><td>"+ destino.Ciudad +"</td><td>" + destino.Pais + "</td><td>" + destino.CantidadDias + "</td><td>$" + destino.CosteDiario + "</td></tr>";
                }
                html += "</table>";
                LitDestinos.Text = html;
                TxtDescripcion.Text = excursion.Descripcion;
                TxtFechaComienzo.Text = excursion.FechaComienzo.ToShortDateString();
                TxtDiasTotales.Text = Convert.ToString(excursion.DiasTotales);
                TxtStock.Text = Convert.ToString(excursion.Stock);
                TxtIdentificador.Text = Convert.ToString(excursion.Identificador);
                if (excursion is Internacionales)
                {
                    Internacionales exc = (Internacionales)excursion;
                    TxtCodCompañia.Text = Convert.ToString(exc.CompañiaAerea.Codigo);
                    TxtPaisCompañia.Text = exc.CompañiaAerea.Pais;
                } else if (excursion is Nacionales)
                {
                    Nacionales exc = (Nacionales)excursion;
                    if (exc.InteresNacional)
                    {
                        TxtInteres.Text = "Si";
                    } else
                    {
                        TxtInteres.Text = "No";
                    }
                }
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmCatalogoExcursion.aspx");
        }

        protected void BtnComprar_Click(object sender, EventArgs e)
        {
            int num = 0;
            if(Session["Usuario"] != null)
            {
                if(TxtMayores.Text == "" || TxtMenores.Text == "" || !Int32.TryParse(TxtMayores.Text, out num) || !Int32.TryParse(TxtMenores.Text, out num))
                {
                    LblMensaje.Text = "Se produjo un error, se debe ingresar un valor valido";
                } else
                {
                    int CodExc = Convert.ToInt32(Request.QueryString["CodExc"]);
                    Excursion excursion = Agencia.Instancia.BuscarExcursionPorCodigo(CodExc);
                    int stock = excursion.Stock;
                    int mayores = Convert.ToInt32(TxtMayores.Text);
                    int menores = Convert.ToInt32(TxtMenores.Text);
                    if (stock - (mayores + menores) >= 0)
                    {
                        Compra compra = new Compra(excursion, mayores, menores, (Usuario)Session["Usuario"]);
                        excursion.Stock -= mayores + menores;
                        Agencia.Instancia.Compras.Add(compra);
                        LblMensaje.Text = "La compra fue un exito!";
                    } else
                    {
                        LblMensaje.Text = "No existe suficiente stock para realizar la compra";
                    }
                }
            } else
            {
                LblMensaje.Text = "No se puede hacer una compra sin ingresar primero";
            }
        }
    }
}