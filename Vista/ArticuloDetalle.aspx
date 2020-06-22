<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticuloDetalle.aspx.cs" Inherits="Vista.ArticuloDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col p-2">
        <asp:Label runat="server" ID="confirmacionEstado"></asp:Label>
        <form>
            <div class="form-group">
                <label>Código de Artículo</label>
                <asp:TextBox runat="server" ID="tbCodigo_articulo" cssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator cssClass="text-danger" runat="server" ErrorMessage="Artículo requerido" ControlToValidate="tbCodigo_articulo"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>Descripción</label>
                <asp:TextBox runat="server" ID="tbDescripcion_articulo" cssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" cssClass="text-danger" ErrorMessage="Descripción requerida" ControlToValidate="tbDescripcion_articulo"></asp:RequiredFieldValidator>
            </div>
            <asp:Button runat="server" cssClass="btn btn-primary" Text="Modificación" ID="btnModificacion" OnClick="btnModificacion_Click" />
            <asp:Button runat="server" cssClass="btn btn-primary" Text="Baja" ID="btnBaja" OnClick="btnBaja_Click" />
        </form>
    </div>
</asp:Content>
