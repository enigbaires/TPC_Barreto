<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MatrizListado.aspx.cs" Inherits="Vista.MatrizListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <a href="MatrizAlta.aspx" class="btn btn-primary btn-user">Dar de alta una Matriz</a>
    <table class="table">
        <thead class="thead-dark">
            <tr>
                <th scope="col">Usuario Solicitante</th>
                <th scope="col">Usuario Aprobador</th>                
                <th scope="col">Detalle</th>
            </tr>
        </thead>
        <tbody>
            <%%>
            <%foreach (var item in listaMatrizActivos)
                {%>
            <tr>
                <th scope="row"><% = item.nombre_solicitante%> </th>
                <td><% = item.nombre_aprobador %></td>
                <td>
                    <a href="MatrizDetalle.aspx?id=<% = item.id_matriz %> " class="btn btn-primary btn-user btn-block">Ver </a>
                </td>
            </tr>
            <%}%>
        </tbody>
    </table>

</asp:Content>
