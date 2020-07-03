<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RemitoListado.aspx.cs" Inherits="Vista.RemitoListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label CssClass="alert alert-danger" ID="lbAlertaCai" runat="server" Text="Los remitos no pueden ser impresos por no haber CAI vigente"></asp:Label>

    <table class="table">
        <thead class="thead-dark">
            <tr>
                <th scope="col">Nro Remito</th>
                <th scope="col">Nro Solicitud</th>
                <th scope="col">Cliente</th>
                <th scope="col">Fecha</th>
                <th scope="col">Detalle</th>
            </tr>
        </thead>
        <tbody>
            
            <%foreach (var item in cabecera)
                {
                    if (daoRemito.BuscarNroRemito(item.id_solicitud) != 0) { 
                    %>
            <tr>
                <th scope="row"><% = daoRemito.BuscarNroRemito(item.id_solicitud) %> </th>
                <td><% = item.id_solicitud %></td>
                <td><% = daoEmpresa.NombreEmpresa(item.id_cliente) %></td>
                <td><% = item.fecha_solicitud.ToShortDateString() %></td>
                <td>
                    <a href="RemitoDetalle.aspx?id=<% = item.id_solicitud %> " class="btn btn-primary btn-user btn-block">Ver </a>
                </td>
            </tr>
            <%}
                
                }%>
        </tbody>
    </table>
</asp:Content>
