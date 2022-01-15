<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmAdministrarCompras.aspx.cs" Inherits="WebApp.FrmAdministrarCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Seleccionar dos fechas para visualizar compras entre ellas</h2>
    <br />
    <div class="container">
    <div class="row">
        <asp:Calendar ID="CalInicio" runat="server" CssClass="col-md-6"></asp:Calendar>
        <asp:Calendar ID="CalFinal" runat="server" CssClass="col-md-6"></asp:Calendar>
    </div>
    </div>
    <br />
    <asp:Button ID="BtnIngresar" runat="server" Text="Confirmar" OnClick="BtnIngresar_Click" />
    <br />
    <br />
    <asp:Literal ID="LitCompras" runat="server"></asp:Literal>
</asp:Content>
