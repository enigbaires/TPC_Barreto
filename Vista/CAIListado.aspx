<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CAIListado.aspx.cs" Inherits="Vista.CAIListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <a href="CAIAlta.aspx" class="btn btn-primary btn-user">Dar de alta un CAI</a>
    <table class="table">
        <thead class="thead-dark">
            <tr>
                <th scope="col">Nro CAI</th>
                <th scope="col">Punto de Venta</th>
                <th scope="col">Fecha de Inicio</th>
                <th scope="col">Fecha Fin</th>
                <th scope="col">Detalle</th>
            </tr>
        </thead>
        <tbody>
            <%%>
            <%foreach (var item in caiListado)
                {%>
            <tr>
                <th scope="row"><% = item.nro_cai%> </th>
                <td><% = item.punto_venta %></td>
                <td><% = item.fecha_inicio.ToShortDateString() %></td>
                <td><% = item.fecha_fin.ToShortDateString() %></td>
                <td>
                    <a href="CaiDetalle.aspx?id=<% = item.id_cai %> " class="btn btn-primary btn-user btn-block">Ver </a>
                </td>
            </tr>
            <%}%>
        </tbody>
    </table>
</asp:Content>
