<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImpresionRemito.aspx.cs" Inherits="Vista.ImpresionRemito" %>

<!DOCTYPE html>

<html lang="en"">
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Sistema de Remitos</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom fonts for this template -->

    <link href="https://fonts.googleapis.com/css?family=Catamaran:100,200,300,400,500,600,700,800,900" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i" rel="stylesheet">


</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
          
            <%--Encabezado--%>
            
            <div class="row p-2">
            <div class="col">
                <p>Filipo SA</p>
                <img src="img/espias.png" width="100px" alt="Logo de la Empresa" />
            </div>
            <div class="col text-center">
                <h1>X</h1>
            </div>
                <div class="col">
                    <asp:Label ID="lbNroRemito" runat="server"></asp:Label>
            </div>
          </div>
            <hr>

            <%--Datos del Cliente--%>

            <div class="row">
            <div class="col">
              Cliente
            </div>
            <div class="col">
              Dirección
            </div>
          </div>
            <div class="row">
            <div class="col">
              <asp:Label ID="lbCliente" runat="server"></asp:Label>
            </div>
            <div class="col">
              <asp:Label ID="lbDireccion" runat="server"></asp:Label>
            </div>
          </div>
            <hr>

            <%-- artículos--%>

          <div class="row">
            <div class="col">
              Código
            </div>
            <div class="col">
              Descripción
            </div>
            <div class="col">
              Cantidad
            </div>
          </div>
            <hr>
            <div class="row">
            <div class="col">
              <asp:Label ID="lbCodigoArticulo" runat="server"></asp:Label>
            </div>
            <div class="col">
             <asp:Label ID="lbArticulo" runat="server"></asp:Label>
            </div>
            <div class="col">
              <asp:Label ID="lbCantidad" runat="server"></asp:Label>
            </div>
          </div>
            <div class="row">
            <div class="col">
            </div>
            <div class="col">
            </div>
            <div class="col">
            </div>
          </div>
            <hr>

            <%--Totales--%>
            <div class="row">
            <div class="col">
            </div>
            <div class="col">
              Total:
            </div>
            <div class="col">
              <asp:Label ID="lbTotal" runat="server"></asp:Label>
            </div>
          </div>

            <hr>
            <hr>

            <%--Datos del transportista--%>

            <div class="row">
            <div class="col">
              Transportista
            </div>
            <div class="col">
              Recibido
            </div>
          </div>
            <div class="row">
            <div class="col">
              <asp:Label ID="lbTransportista" runat="server"></asp:Label>
            </div>
            <div class="col">
              Firma:
            </div>
          </div>
            <div class="row">
            <div class="col">
            </div>
            <div class="col text-right">
              CAI: 
            </div>
            <div class="col">
              <asp:Label ID="lbCAI" runat="server"></asp:Label>
            </div>
          </div>
        </div>

        <!-- Bootstrap core JavaScript -->
        <script src="js/jquery.min.js"></script>
        <script src="js/bootstrap.bundle.min.js"></script>

    </form>
</body>
</html>
