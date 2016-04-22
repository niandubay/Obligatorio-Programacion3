<%@ Page Title="" Language="C#" MasterPageFile="~/AppWeb.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="AppWeb.Pruebas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    Lista las Ubicaciones&nbsp;&nbsp;&nbsp;

    <asp:ListBox ID="lstUbi" runat="server" Height="200px" Width="100%"></asp:ListBox>

    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Lista Los Rango Precio"></asp:Label>
    <br />
    <asp:ListBox ID="lbxRangos" runat="server" Height="200px" Width="100%"></asp:ListBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Listado de los Alojamientos"></asp:Label>
    <br />
    <asp:ListBox ID="lbxAlojamientos" runat="server" Height="200px" Width="100%"></asp:ListBox>
    <br />
    <br />
    Un alojamiento especifico&nbsp;
    <asp:TextBox ID="txtIdAlojamiento" runat="server"></asp:TextBox>
    <br />
    <asp:ListBox ID="lbxUnAlojamiento" runat="server"></asp:ListBox>
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
