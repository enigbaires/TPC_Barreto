<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RemitoDetalle.aspx.cs" Inherits="Vista.RemitoDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>

    <link href="css/all.min.css" rel="stylesheet" type="text/css">
    <link href="css/sb-admin-2.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col p-2">
        <asp:Label runat="server" ID="confirmacionEstado"></asp:Label>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th scope="row">Nro Remito</th>
                    <td colspan="2">
                        <asp:Label cssClass="form-control" ID="lbNroRemito" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:Button runat="server" cssClass="btn btn-primary" Text="Imprimir Solicitud" ID="btnImprimir" OnClick="btnImprimir_Click" Enabled="false"/>
                    </td>
                </tr>
                <tr>
                    <th scope="row">Cliente</th>
                    <td colspan="2">
                        <asp:Label cssClass="form-control" ID="lbCliente" runat="server"></asp:Label>
                    </td>
                    <td colspan="2"></td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">Tipo de Remito</th>
                    <td colspan="2">
                        <asp:Label cssClass="form-control" ID="lbTipoRemito" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <th scope="row">Artículo</th>
                    <td colspan="2">
                        <asp:Label cssClass="form-control" ID="lbArticulo" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:Label cssClass="form-control" ID="lbCantidad" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="row">Transportista</th>
                    <td colspan="2">
                        <asp:Label cssClass="form-control" ID="lbTransportista" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
            </tbody>
        </table>
        </div>
</asp:Content>
