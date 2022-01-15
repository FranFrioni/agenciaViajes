<%@ Import Namespace="Dominio" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmEstadisticas.aspx.cs" Inherits="WebApp.FrmEstadisticas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><u>Estadisticas</u></h2>
    <br />
    <h3>Buscar excursiones por destino:</h3>
    <br />
    <asp:DropDownList ID="DdlDestinos" runat="server" OnSelectedIndexChanged="DdlDestinos_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
    <br />
    <asp:Literal ID="LitExcursiones" runat="server"></asp:Literal>
    <br />
    <h3>Destino/s que se incluye/n en mas excursiones:</h3>
    <br />
    <table class="table">
        <tr>
            <th>Ciudad</th><th>Pais</th><th>Cantidad de Dias</th><th>Coste Diario</th>
            <% List<Destino> destinos = Agencia.Instancia.DestinosMasUsado();
                foreach(Destino destino in destinos){%>
			<tr>
				<td><%=destino.Ciudad%></td>
				<td><%=destino.Pais%></td>
                <td><%=destino.CantidadDias%></td>
                <td>$<%=destino.CosteDiario%></td>
			</tr>
		    <%}%>
        </tr>
    </table>
</asp:Content>
