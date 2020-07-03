<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SolicitudDetalle.aspx.cs" Inherits="Vista.SolicitudDetalle" %>
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
                    <th scope="row">Estado Actual</th>
                    <td colspan="2">
                        <%--0: pendiente 1: aprobado 2: rehacer 3: rechazado--%>
                        <asp:DropDownList cssClass="form-control" ID="ddlEstadoActual" runat="server">
                            <asp:ListItem Value="0" Text="PENDIENTE" />
                            <asp:ListItem Value="1" Text="APROBADO" />
                            <asp:ListItem Value="2" Text="REHACER" />
                            <asp:ListItem Value="3" Text="RECHAZADO" />
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:Button runat="server" cssClass="btn btn-primary" Text="Cambiar Estado" ID="btnCambiarEstado" OnClick="btnCambiarEstado_Click" Enabled="false"/>
                    </td>
                </tr>
                <tr>
                    <th scope="row">Cliente</th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlCliente" runat="server"></asp:DropDownList>
                    </td>
                    <td colspan="2"></td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">Tipo de Remito</th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlTipoRemito" runat="server"></asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Tipo de remito requerido" ControlToValidate="ddlTipoRemito"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th scope="row">Artículo</th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlArticulo" runat="server"></asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbCantidad" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th scope="row">Transportista</th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlTransportista" runat="server"></asp:DropDownList>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <th scope="row">Observaciones</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbObservaciones" CssClass="form-control" MaxLength="299" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <th scope="row">Archivo</th>
                    <td colspan="2">
                        <asp:HyperLink ID="hlVerArchivo" cssClass="btn btn-primary" runat="server" Text="Ver Archivo"></asp:HyperLink>
                        </td>
                    <td colspan="2">
                        </td>
                </tr>
            </tbody>
        </table>
        
        </div>
</asp:Content>
