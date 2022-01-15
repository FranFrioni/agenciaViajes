<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmIniciarSesion.aspx.cs" Inherits="WebApp.FrmIniciarSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <u><h2>Inicio de Sesion</h2></u>
    <br />
    <asp:Label runat="server" Text="Nombre de Usuario: "></asp:Label><asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox><br />
    <br />
    <asp:Label runat="server" Text="Clave: "></asp:Label><asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox><br />
    <br />
    <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" OnClick="BtnIngresar_Click" /><br />
    <br />
    <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
