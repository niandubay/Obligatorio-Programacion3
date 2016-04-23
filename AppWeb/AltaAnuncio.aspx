<%@ Page Title="" Language="C#" MasterPageFile="~/AppWeb.Master" AutoEventWireup="true" CodeBehind="AltaAnuncio.aspx.cs" Inherits="AppWeb.AltaAnuncio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:label runat="server" text="Ingrese el nombre " ID="lblNombre"></asp:label>
    <asp:textbox runat="server" ID="txtNombre"></asp:textbox>
    <br />
    <br />

    <asp:label runat="server" text="Ingrese la descripcion" ID="lblDescripcion"></asp:label>
    <asp:textbox runat="server" ID="txtDescripcion"></asp:textbox><br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Suba las fotos"></asp:Label>
    <br />

    <asp:fileupload runat="server" ID="fupFotos"></asp:fileupload><asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
    
    <br />
    
    <asp:ListBox ID="lstFotos" runat="server"></asp:ListBox>
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar> 
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
    

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:ListBox ID="lstRangos" runat="server"></asp:ListBox>
    <br />
    <br />
    

    <asp:label runat="server" text="Seleccione habitacion" ID="lblHabitaciones"></asp:label>
    <br />
    <asp:listbox runat="server" ID="lstHabitacion" DataSourceID="id"></asp:listbox><br />
    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
    <br />
    <asp:ListBox ID="lstHabitacionesSeleccionadas" runat="server"></asp:ListBox>
    <br />
    <br />
    <asp:Button ID="btnAlta" runat="server" OnClick="btnAlta_Click" Text="Alta Anuncio" />
    <br />

    <asp:label runat="server" text="Label"></asp:label>
    


</asp:Content>
