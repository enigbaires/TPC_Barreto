<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioDetalle.aspx.cs" Inherits="Vista.UsuarioDetalle" %>

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
                    <th scope="row">Nombre</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbNombre" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator CssClass="text-danger" runat="server" ErrorMessage="Nombre requerido" ControlToValidate="tbNombre"></asp:RequiredFieldValidator></td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">CODE1</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbUsuario_code1" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Número de usuario requerido" ControlToValidate="tbUsuario_code1"></asp:RequiredFieldValidator></td>
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
                    <th scope="row">Password</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbPassword" CssClass="form-control"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Password requerido" ControlToValidate="tbPassword"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th scope="row">Tipo de Usuario</th>
                    <td colspan="2">
                        <select class="form-control" id="selectTipoUsuario" runat="server">
                            <option value="0">Usuario </option>
                            <option value="1">Aprobador </option>
                            <option value="2">Administrador </option>
                        </select></td>
                    <td colspan="2"></td>
                </tr>
            </tbody>
        </table>
        <asp:Button runat="server" CssClass="btn btn-primary" Text="Modificación" ID="btnModificacion" OnClick="btnModificacion_Click" />
        <asp:Button runat="server" CssClass="btn btn-primary" Text="    Baja    " ID="btnBaja" OnClick="btnBaja_Click" />
    </div>
</asp:Content>
