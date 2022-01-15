<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmRegistrarse.aspx.cs" Inherits="WebApp.FrmRegistrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><u>Registrarse como Cliente: </u></h2>
    <br />
    <asp:Label runat="server" Text="Cedula: "></asp:Label><asp:TextBox ID="TxtCedula" runat="server"></asp:TextBox><br />
    <br />
    <asp:Label runat="server" Text="Nombre: "></asp:Label><asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox><br />
    <br />
    <asp:Label runat="server" Text="Apellido: "></asp:Label><asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox><br />
    <br />
    <asp:Label runat="server" Text="Clave: "></asp:Label><asp:TextBox ID="TxtClave" runat="server"></asp:TextBox><br />
    <br />
    <asp:Button ID="BtnRegistrarse" runat="server" Text="Registrarse" OnClick="BtnRegistrarse_Click" /><br />
    <br />
    <asp:Label ID="TxtMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
