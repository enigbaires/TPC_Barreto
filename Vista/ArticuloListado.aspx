<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticuloListado.aspx.cs" Inherits="Vista.ArticuloListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <a href="ArticuloAlta.aspx" class="btn btn-primary btn-user">Dar de alta un Artículo</a>
    <table class="table">
        <thead class="thead-dark">
            <tr>
                <th scope="col">Código de Artículo</th>
                <th scope="col">Descripción</th>
                <th scope="col">Detalle</th>
            </tr>
        </thead>
        <tbody>
            <%%>
            <%foreach (var item in listaDeArticulos)
                {%>
            <tr>
                <th scope="row"><% = item.codigo_articulo%> </th>
                <td><% = item.descripcion_articulo %></td>
                <td>
                    <a href="ArticuloDetalle.aspx?id=<% = item.id_articulo %> " class="btn btn-primary btn-user btn-block">Ver 
                    </a>
                </td>
            </tr>
            <%}%>
        </tbody>
    </table>
</asp:Content>
