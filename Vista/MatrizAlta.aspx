<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MatrizAlta.aspx.cs" Inherits="Vista.MatrizAlta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col p-2">
        <asp:Label runat="server" ID="confirmacionAlta"></asp:Label>
        <form>
            <div class="form-group">
                <label>Usuario Solicitante</label>
                <asp:DropDownList cssClass="form-control" ID="ddlSolicitante" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Usuario Aprobador</label>
                <asp:DropDownList cssClass="form-control" ID="ddlAprobador" runat="server"></asp:DropDownList>
            </div>
            <asp:Button runat="server" cssClass="btn btn-primary" Text="Alta" ID="btnAlta" OnClick="btnAlta_Click" />
        </form>
    </div>

</asp:Content>
