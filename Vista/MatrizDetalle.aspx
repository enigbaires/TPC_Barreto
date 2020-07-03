<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MatrizDetalle.aspx.cs" Inherits="Vista.MatrizDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col p-2">
        <asp:Label runat="server" ID="confirmacionEstado"></asp:Label>
        <form>
            <div class="form-group">
                <label>Usuario Solicitante</label>
                <asp:DropDownList cssClass="form-control" ID="ddlSolicitante" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Usuario Aprobador</label>
                <asp:DropDownList cssClass="form-control" ID="ddlAprobador" runat="server"></asp:DropDownList>
            </div>
            <asp:Button runat="server" cssClass="btn btn-primary" Text="Modificacion" ID="btnModificacion" OnClick="btnModificacion_Click" />
            <asp:Button runat="server" cssClass="btn btn-primary" Text="Baja        " ID="btnBaja" OnClick="btnBaja_Click" />
        </form>
    </div>

</asp:Content>
