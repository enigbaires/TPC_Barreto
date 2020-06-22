<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioListado.aspx.cs" Inherits="Vista.UsuarioListado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <a href="UsuarioAlta.aspx" class="btn btn-primary btn-user">Dar de alta un Usuario</a>
    <table class="table">
        <thead class="thead-dark">
            <tr>
                <th scope="col">Nombre</th>
                <th scope="col">CODE1</th>
                <th scope="col">Mail</th>
                <th scope="col">Tipo de usuario</th>
                <th scope="col">Detalle</th>
            </tr>
        </thead>
        <tbody>
            <%%>
            <%foreach (var item in listaDeUsuarios)
                {%>
            <tr>
                <th scope="row"><% = item.nombre%> </th>
                <td><% = item.usuario_code1 %></td>
                <td><% = item.email %></td>
                <td>
                    <%
                        if (item.usuario_tipo == 0)
                        {
                    %>
                            Usuario
                            <%
                                }
                                else
                                {
                                    if (item.usuario_tipo == 1)
                                    {
                            %>
                                Aprobador
                                <%
                                    }
                                    else
                                    {
                                %>
                                Administrador
                                <%
                                        }
                                    }
                                %>
                </td>
                <td>
                    <a href="UsuarioDetalle.aspx?id=<% = item.id_usuario %> " class="btn btn-primary btn-user btn-block">Ver </a>
                </td>
            </tr>
            <%}%>
        </tbody>
    </table>
</asp:Content>
