<%@ Import Namespace="Dominio" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmCarrito.aspx.cs" Inherits="WebApp.FrmCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><u>Carrito de Compras</u></h2>
    <table class="table">
        <tr>
            <th>Descripcion de Excursion</th><th>Dias totales</th><th>Cantidad de Mayores</th><th>Cantidad de Menores</th><th></th>
        </tr>
            <%  int i = 0;
                foreach (Compra compra in Agencia.Instancia.Compras) {
                if (compra.Usuario == Session["Usuario"])
                {
                %>
                <tr><td><%=compra.ExcursionComprada.Descripcion%></td><td><%=compra.ExcursionComprada.DiasTotales%></td><td><%=compra.PasajesDeMayores%></td><td><%=compra.PasajesDeMenores%></td><td><a href="/FrmCancelarCompra.aspx?CompraCli=<%=i%>">Cancelar</a></td></tr>
                <%} i++;
        }  %>
    </table>
    <asp:Literal ID="LitCompras" runat="server"></asp:Literal>
</asp:Content>
