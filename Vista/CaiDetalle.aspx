<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaiDetalle.aspx.cs" Inherits="Vista.CaiDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#MainContent_tbFecha_inicio").datepicker({
                dateFormat: "dd/mm/yy"
            });
        });
    </script>
    <script>
        $(function () {
            $("#MainContent_tbFecha_fin").datepicker({
                dateFormat: "dd/mm/yy"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col p-2">
        <asp:Label runat="server" ID="confirmacionEstado"></asp:Label>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th scope="row">Nro CAI</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbNro_cai" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator CssClass="text-danger" runat="server" ErrorMessage="Nro de CAI requerido" ControlToValidate="tbNro_cai"></asp:RequiredFieldValidator></td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">Punto de Venta</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbPunto_venta" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="PDV requerido" ControlToValidate="tbPunto_venta"></asp:RequiredFieldValidator>
                        <asp:RangeValidator runat="server" ErrorMessage="El Dato debe ser numerico" CssClass="text-danger" ControlToValidate="tbPunto_venta" MaximumValue="100000000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <th scope="row">Fecha Inicio</th>
                    <td colspan="2">
                        <asp:TextBox ID="tbFecha_inicio" runat="server" TextMode="DateTime" CssClass="form-control"></asp:TextBox>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Fecha Requerida" ControlToValidate="tbFecha_inicio"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th scope="row">Fecha Fin</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbFecha_fin" TextMode="DateTime" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Fecha Requerida" ControlToValidate="tbFecha_fin"></asp:RequiredFieldValidator></td>
                </tr>
            </tbody>
        </table>
        <asp:Button runat="server" CssClass="btn btn-primary" Text="Modificación" ID="btnModificacion" OnClick="btnModificacion_Click" />
    </div>
</asp:Content>
