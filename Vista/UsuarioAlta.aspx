<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioAlta.aspx.cs" Inherits="Vista.UsuarioAlta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col p-2">
        <asp:Label runat="server" ID="confirmacionAlta"></asp:Label>
        <form>
            <div class="form-group">
                <label>Nombre usuario</label>
                <asp:TextBox runat="server" ID="tbUsuarioNombre" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="text-danger" runat="server" ErrorMessage="Nombre requerido" ControlToValidate="tbUsuarioNombre"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>CODE1</label>
                <asp:TextBox runat="server" ID="tbUsuarioCode1" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="CODE1 requerido" ControlToValidate="tbUsuarioCode1"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>email</label>
                <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="email requerido" ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" CssClass="text-danger" ErrorMessage="Tiene que ser un mail válido" ControlToValidate="tbEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label>Password</label>
                <asp:TextBox runat="server" type="password" ID="tbPassword" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Password requerido" ControlToValidate="tbPassword"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>Tipo de Usuario</label>
                <select class="form-control" id="selectTipoUsuario" runat="server">
                    <option value="0" selected="selected">Usuario </option>
                    <option value="1">Aprobador </option>
                    <option value="2">Administrador </option>
                </select>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Alta" ID="btnAlta" OnClick="btnAlta_Click" />
        </form>
    </div>
</asp:Content>
