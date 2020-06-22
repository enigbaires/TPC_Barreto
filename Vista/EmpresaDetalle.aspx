<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpresaDetalle.aspx.cs" Inherits="Vista.EmpresaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col p-2">
        <asp:Label runat="server" ID="confirmacionEstado"></asp:Label>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th scope="row">Razón Social</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbRazonSocial" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator CssClass="text-danger" runat="server" ErrorMessage="Razon Social requerida" ControlToValidate="tbRazonSocial"></asp:RequiredFieldValidator></td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">CUIT</th>
                    <td colspan="2">
                        <small class="form-text text-muted">CUIT sólo los números. Ejemplo: 30710235615</small>
                        <asp:TextBox runat="server" ID="tbCuit" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="CUIT requerido" ControlToValidate="tbCuit"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th scope="row">Nro SAP</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbNroSAP" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Número de SAP requerido" ControlToValidate="tbNroSAP"></asp:RequiredFieldValidator>
                        <asp:RangeValidator runat="server" ErrorMessage="El Dato debe ser numerico" CssClass="text-danger" ControlToValidate="tbNroSAP" MaximumValue="100000000" MinimumValue="1" Type="Integer"></asp:RangeValidator></td>
                </tr>
                <tr>
                    <th scope="row">Dirección Legal</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbDirLegal" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Dirección requerida" ControlToValidate="tbDirLegal"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th scope="row">Dirección Entrega</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbDirEntrega" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Dirección requerida" ControlToValidate="tbDirEntrega"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th scope="row">Teléfono</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbTelefono" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Teléfono requerido" ControlToValidate="tbTelefono"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th scope="row">email</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="email requerido" ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" CssClass="text-danger" ErrorMessage="Tiene que ser un mail válido" ControlToValidate="tbEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <th scope="row">Tipo de Empresa</th>
                    <td colspan="2">
                        <select class="form-control" id="selectTipoEmpresa" runat="server">
                            <option value="0" selected="selected">Cliente </option>
                            <option value="1">Transportista </option>
                        </select></td>
                    <td colspan="2"></td>
                </tr>
            </tbody>
        </table>
        <asp:Button runat="server" CssClass="btn btn-primary" Text="Modificación" ID="btnModificacion" OnClick="btnModificacion_Click" />
        <asp:Button runat="server" CssClass="btn btn-primary" Text="    Baja    " ID="btnBaja" OnClick="btnBaja_Click" />
    </div>
</asp:Content>
