﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AppWeb.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="AppWeb.Pruebas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    Lista las Ubicaciones&nbsp;&nbsp;&nbsp;

    <asp:ListBox ID="lstUbi" runat="server" Height="200px" Width="100%"></asp:ListBox>

    <br />
    buscar ubicacion por ID:
    <asp:TextBox ID="txtUBI" runat="server"></asp:TextBox>
    <asp:Button ID="btnUBI" runat="server" OnClick="btnUBI_Click" Text="Button" />
    <br />
    <asp:Label ID="lblUBI" runat="server"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Lista Los Rango Precio"></asp:Label>
    <br />
    <asp:ListBox ID="lbxRangos" runat="server" Height="200px" Width="100%"></asp:ListBox>
    <br />
    buscar rango precio por ID:
    <asp:TextBox ID="txtRP" runat="server"></asp:TextBox>
    <asp:Button ID="btnBuscarRP" runat="server" OnClick="btnBuscarRP_Click" Text="Button" />
    <br />
    <asp:Label ID="lblRangoPrecio" runat="server"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Listado de los Alojamientos"></asp:Label>
    <br />
    <asp:ListBox ID="lbxAlojamientos" runat="server" Height="200px" Width="100%"></asp:ListBox>
    <br />
    <br />
    Un alojamiento especifico&nbsp;
    <asp:TextBox ID="txtIdAlojamiento" runat="server"></asp:TextBox>
    &nbsp;<asp:Button ID="btnALOID" runat="server" OnClick="btnALOID_Click" Text="Button" />
    <br />
    <asp:Label ID="lblALOXID" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="btnListar" runat="server" OnClick="btnListar_Click" Text="Button" />
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
    <br />
    <br />
    <br />
    <br />

</asp:Content>
