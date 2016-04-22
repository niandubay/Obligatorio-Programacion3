<%@ Page Title="" Language="C#" MasterPageFile="~/AppWeb.Master" AutoEventWireup="true" CodeBehind="AltaAlojamiento.aspx.cs" Inherits="AppWeb.AltaAlojamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    Seleccione el tipo de alojamiento&nbsp;
    <asp:DropDownList ID="drpTipo" runat="server" >
            <asp:ListItem Selected="True">Hotel</asp:ListItem>
            <asp:ListItem>Casa</asp:ListItem>
            <asp:ListItem>Rancho</asp:ListItem>
            <asp:ListItem>Hostel</asp:ListItem>
            <asp:ListItem>Posada</asp:ListItem>
        </asp:DropDownList>
    <br />
    <br />
    Ingrese una ubicacion<br />
    Ciudad
    <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
    <br />
    <br />
    Barrio
    <asp:TextBox ID="txtBarrio" runat="server"></asp:TextBox>
    <br />
    Direccion Linea 1
    <asp:TextBox ID="txtDirL1" runat="server"></asp:TextBox>
    <br />
    <br />
    Direccion Linea 2<asp:TextBox ID="txtDirL2" runat="server"></asp:TextBox>
    <br />
    <br />
    Rango Precio<br />
    Fecha Inicio<asp:Calendar ID="calFechaIni" runat="server"></asp:Calendar>
    <br />
    Rango Precio<br />
    Fecha Fin<br />
    <asp:Calendar ID="calFechaFin" runat="server"></asp:Calendar>
    <br />
    <br />
    Precio <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
    .<br />
    <br />
    <br />
    <asp:Button ID="btnAltaAlojamiento" runat="server" OnClick="btnAltaAlojamiento_Click" Text="Button" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:ListBox ID="lbxListado" runat="server"></asp:ListBox>
   
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
   
</asp:Content>
