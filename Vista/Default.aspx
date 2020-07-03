<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vista.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if (usuarioSolicitante)
        { %>
            <a href="SolicitudAlta.aspx" class="btn btn-primary btn-user">Dar de alta una Solicitud</a>
      <%  } %>    
    
    <table class="table">
        <thead class="thead-dark">
            <tr>
                <th scope="col">Nro Solicitud</th>
                <th scope="col">Cliente</th>
                <th scope="col">Solicitante</th>
                <th scope="col">Fecha</th>
                <th scope="col">Estado</th>
                <th scope="col">Detalle</th>
            </tr>
        </thead>
        <tbody>
            <%%>
            <%foreach (var item in cabecera)
                {%>
            <tr>
                <th scope="row"><% = item.id_solicitud %> </th>
                <td><% = daoEmpresa.NombreEmpresa(item.id_cliente) %></td>
                <td><% = daoUsuario.NombreUsuario(item.id_usuario_solicitante) %></td>
                <td><% = item.fecha_solicitud.ToShortDateString() %></td>
                <%--0: pendiente 1: aprobado 2: rehacer 3: rechazado--%>
                <%switch (item.estado_solicitud)
                    {
                        case 0:
                            %><td>PENDIENTE</td><%
                            break;
                        case 1:
                            %><td>APROBADO</td><%
                            break;
                        case 2:
                            %><td>REHACER</td><%
                            break;
                        case 3:
                            %><td>RECHAZADO</td><%
                            break;
                        default:
                            break;
                    }
                    %>
                <td>
                    <a href="SolicitudDetalle.aspx?id=<% = item.id_solicitud %> " class="btn btn-primary btn-user btn-block">Ver </a>
                </td>
            </tr>
            <%}%>
        </tbody>
    </table>
</asp:Content>
