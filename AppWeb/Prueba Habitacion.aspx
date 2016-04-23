<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba Habitacion.aspx.cs" Inherits="AppWeb.Prueba_Habitacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblServicios" runat="server" Text="Servicios"></asp:Label>
        <asp:ListBox ID="lstServicios" runat="server"></asp:ListBox><br />
        <asp:Button ID="btnServicios" runat="server" Text="Cargar Servicios" OnClick="btnServicios_Click" />
        <br />
        <br />
        <asp:Label ID="lblHabitaciones" runat="server" Text="Habitaciones"></asp:Label>
        <asp:ListBox ID="lstHabitaciones" runat="server"></asp:ListBox><br />
        <asp:Button ID="btnHabitaciones" runat="server" Text="Listar Habitaciones" OnClick="btnHabitaciones_Click" />
        <br />
        <br />
        <asp:Label ID="lblMostrarHabitacion" runat="server" Text="Mostrar Habitacion"></asp:Label>
        <asp:TextBox ID="txtMostrarHabitacion" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnMostrarHabitacion" runat="server" Text="Mostrar Habitacion" OnClick="btnMostrarHabitacion_Click" /><br />
        <asp:Label ID="lblSalidaMostrarHabitacion" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
