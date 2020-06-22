<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticuloAlta.aspx.cs" Inherits="Vista.ArticuloAlta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col p-2">
        <asp:Label runat="server" ID="confirmacionAlta"></asp:Label>
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
            <asp:Button runat="server" cssClass="btn btn-primary" Text="Alta" ID="btnAlta" OnClick="btnAlta_Click" />
        </form>
    </div>
</asp:Content>
