<%@ Import Namespace="Dominio" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmVisualizarClientes.aspx.cs" Inherits="WebApp.FrmVisualizarClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><u>Tabla de Clientes</u></h2>
    <table class="table">
        <tr>
            <th>Apellido</th><th>Nombre</th><th>Cedula</th>
        </tr>
        <% foreach(Usuario usuario in Agencia.Instancia.Usuarios){
                if (usuario is Cliente)
                {%>
			<tr>
				<td><%=usuario.Apellido%></td>
				<td><%=usuario.Nombre%></td>
				<td><%=usuario.NombreUsuario%></td>
			</tr>
		        <%}
            }%>
    </table>
</asp:Content>
