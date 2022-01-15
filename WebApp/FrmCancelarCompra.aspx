<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmCancelarCompra.aspx.cs" Inherits="WebApp.FrmCancelarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>¿Seguro quiere cancelar su compra?</h3>
    <br />
    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" /><asp:Button ID="BtnVolver" runat="server" Text="Volver" OnClick="BtnVolver_Click" /> <br />
    <br />
    <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
