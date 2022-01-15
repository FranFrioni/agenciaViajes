<%@ Import Namespace="Dominio" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmCatalogoExcursion.aspx.cs" Inherits="WebApp.FrmCatalogoExcursion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><u>Catalogo de Excursiones:</u></h2>
    <br />
	<table class="table">
		<tr><th>Descripcion</th><th>Fecha de Comienzo</th><th></th><tr>
		<% foreach(Excursion excursion in Agencia.Instancia.Excursiones){%>
			<tr>
				<td><%=excursion.Descripcion%></td>
				<td><%=excursion.FechaComienzo.ToShortDateString()%></td>
				<td><a href="/FrmVerExcursion.aspx?CodExc=<%=excursion.Codigo%>">Ver</a></td>
			</tr>
		<%}%>
	</table>
</asp:Content>
