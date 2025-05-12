<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarProductos.aspx.cs" Inherits="TP6_Grupo_8.SeleccionarProductos" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 512px;
        }
        .auto-style3 {
            width: 512px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Id Producto">
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre Producto">
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Id Proveedor">
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio Unitario">
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:HyperLink ID="inicio" runat="server" NavigateUrl="~/Ejercicio2.aspx">Volver al Inicio</asp:HyperLink>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="addedprods" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </form>
</body>
</html>
