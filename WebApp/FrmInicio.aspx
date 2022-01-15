<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmInicio.aspx.cs" Inherits="WebApp.FrmInicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><u>Bienvenido a la Agencia Frioni</u></h1>
        <h2>Acciones que puedes realizar sin tener una cuenta:</h2>
        <ul>
            <li>Iniciar Sesion</li>
            <li>Registrarte</li>
            <li>Visualizar todas las Excursiones</li>
        </ul>
        <h2>Acciones que puedes realizar si eres un cliente:</h2>
        <ul>
            <li>Realizar una compra en una excursion</li>
        </ul>
        <h2>Acciones que puedes realizar si eres administrador:</h2>
        <ul>
            <li>Administrar Compras</li>
            <li>Visualizar Clientes</li>
            <li>Ver estadisticas generales</li>
        </ul>
    </div>
    
</asp:Content>
