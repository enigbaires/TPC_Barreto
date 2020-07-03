<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpresaListado.aspx.cs" Inherits="Vista.EmpresaListado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%if (usuarioLogueado.usuario_tipo == 2)
        {
    %>
    <a href="EmpresaAlta.aspx" class="btn btn-primary btn-user">Dar de alta una Empresa</a>
    <%

        } %>

    <table class="table">
        <thead class="thead-dark">
            <tr>
                <th scope="col">Nro SAP</th>
                <th scope="col">Razón Social</th>
                <th scope="col">Dirección Entrega</th>
                <th scope="col">Teléfono</th>
                <th scope="col">Mail</th>
                <th scope="col">Detalle</th>
            </tr>
        </thead>
        <tbody>
            <%%>
            <%foreach (var item in listaDeEmpresas)
                {%>
            <tr>
                <th scope="row"><% = item.numero_sap_empresa%> </th>
                <td><% = item.razon_social %></td>
                <td><% = item.direccion_entrega %></td>
                <td><% = item.telefono %></td>
                <td><% = item.email %></td>
                <td>
                    <a href="EmpresaDetalle.aspx?id=<% = item.id_empresa %> " class="btn btn-primary btn-user btn-block">Ver 
                    </a>
                </td>
            </tr>
            <%}%>
        </tbody>
    </table>
</asp:Content>
