<%@ Import Namespace="Dominio" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmVerExcursion.aspx.cs" Inherits="WebApp.FrmVerExcursion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
    <h2><u>Informacion especifica de Excursion</u></h2>
    <br />
    <asp:Label runat="server" Text="Descripcion: "></asp:Label><asp:TextBox ID="TxtDescripcion" runat="server" ReadOnly="true"></asp:TextBox><br />
    <br />
    <asp:Label runat="server" Text="Fecha de Comienzo: "></asp:Label><asp:TextBox ID="TxtFechaComienzo" runat="server" ReadOnly="true"></asp:TextBox><br />
    <br />
    <asp:Label runat="server" Text="Destinos: "></asp:Label>
    <asp:Literal ID="LitDestinos" runat="server"></asp:Literal><br />
    <br />
    <asp:Label runat="server" Text="Dias Totales: "></asp:Label><asp:TextBox ID="TxtDiasTotales" runat="server" ReadOnly="true"></asp:TextBox><br />
    <br />
    <asp:Label runat="server" Text="Stock Restante: "></asp:Label><asp:TextBox ID="TxtStock" runat="server" ReadOnly="true"></asp:TextBox><br />
    <br />
    <asp:Label runat="server" Text="Identificador: "></asp:Label><asp:TextBox ID="TxtIdentificador" runat="server" ReadOnly="true"></asp:TextBox><br />
    <br />
    <%          int CodExc = Convert.ToInt32(Request.QueryString["CodExc"]);
        Excursion excursion = Agencia.Instancia.BuscarExcursionPorCodigo(CodExc);
        if (excursion is Internacionales)
        {
        %>
    <h3>Compañia Aerea: </h3>
        <asp:Label runat="server" Text="Codigo:"></asp:Label></asp:Label><asp:TextBox ID="TxtCodCompañia" runat="server" ReadOnly="true"></asp:TextBox><br />
        <br />
        <asp:Label runat="server" Text="Pais:"></asp:Label></asp:Label><asp:TextBox ID="TxtPaisCompañia" runat="server" ReadOnly="true"></asp:TextBox><br />
        <br />
    <% }
    else
    {%>
        <asp:Label runat="server" Text="Interes Nacional:"></asp:Label></asp:Label><asp:TextBox ID="TxtInteres" runat="server" ReadOnly="true"></asp:TextBox><br />
        <br />
    <% } %>
     <h2><u>Comprar lugares en Excursion</u></h2>
    <br />
    <asp:Label runat="server" Text="Cuantos Mayores: "></asp:Label><asp:TextBox ID="TxtMayores" runat="server"></asp:TextBox><br />
    <br />
    <asp:Label runat="server" Text="Cuantos Menores: "></asp:Label><asp:TextBox ID="TxtMenores" runat="server"></asp:TextBox><br />
    <br />
    <asp:Button ID="BtnComprar" runat="server" Text="Comprar" OnClick="BtnComprar_Click" />
    <asp:Button ID="BtnVolver" runat="server" Text="Volver" OnClick="BtnVolver_Click" /><br />
    <br />
</asp:Content>
