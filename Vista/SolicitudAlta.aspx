<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SolicitudAlta.aspx.cs" Inherits="Vista.SolicitudAlta" %>
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
                    <th scope="row">Cliente</th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlCliente" runat="server" AppendDataBoundItems ="true">
                            <asp:ListItem Text=""></asp:ListItem>
                        </asp:DropDownList>
                    <td colspan="2">
                        <asp:RequiredFieldValidator CssClass="text-danger" runat="server" ErrorMessage="Cliente requerido" ControlToValidate="ddlCliente"></asp:RequiredFieldValidator></td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">Tipo de Remito</th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlTipoRemito" runat="server" AppendDataBoundItems ="true">
                            <asp:ListItem Text=""></asp:ListItem>
                        </asp:DropDownList>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Tipo de remito requerido" ControlToValidate="ddlTipoRemito"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th scope="row">Artículo</th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlArticulo" runat="server" AppendDataBoundItems ="true">
                            <asp:ListItem Text=""></asp:ListItem>
                        </asp:DropDownList>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbCantidad" TextMode="Number" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Artículo requerido" ControlToValidate="ddlArticulo"></asp:RequiredFieldValidator>
                        <asp:RangeValidator runat="server" ErrorMessage="Cantidad Positiva" ControlToValidate="tbCantidad" CssClass="text-danger" MaximumValue="1000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Cantidad requerida" ControlToValidate="tbCantidad"></asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <th scope="row">Transportista</th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlTransportista" runat="server" AppendDataBoundItems ="true">
                            <asp:ListItem Text=""></asp:ListItem>
                        </asp:DropDownList>
                    <td colspan="2">
                        </td>
                </tr>
                <tr>
                    <th scope="row">Observaciones</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbObservaciones" CssClass="form-control" MaxLength="299" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Observaciones requeridas" ControlToValidate="tbObservaciones"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th scope="row">Adjuntar Archivo</th>
                    <td colspan="2">
                        <label for="fileArchivo">Seleccionar archivo</label>
                        <input type="file" class="form-control-file" id="fileArchivo" runat="server">
                        </td>
                    <td colspan="2">
                        </td>
                </tr>
            </tbody>
        </table>
        <asp:Button runat="server" cssClass="btn btn-primary" Text="Alta" ID="btnAlta" OnClick="btnAlta_Click" />
        </div>
</asp:Content>
