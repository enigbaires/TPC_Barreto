<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpresaAlta.aspx.cs" Inherits="Vista.EmpresaAlta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col p-2">

        <asp:Label runat="server" ID="confirmacionAlta"></asp:Label>

        <form>
            <div class="form-group">
                <label>Razón Social</label>
                <asp:TextBox runat="server" ID="tbRazonSocial" cssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator cssClass="text-danger" runat="server" ErrorMessage="Razon Social requerida" ControlToValidate="tbRazonSocial"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>CUIT</label>
                <small id="emailHelp" class="form-text text-muted">Sólo los números. Ejemplo: 30710235615</small>
                <asp:TextBox runat="server" ID="tbCuit" cssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" cssClass="text-danger" ErrorMessage="CUIT requerido" ControlToValidate="tbCuit"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>Número de SAP</label>
                <asp:TextBox runat="server" ID="tbNroSAP" cssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" cssClass="text-danger" ErrorMessage="Número de SAP requerido" ControlToValidate="tbNroSAP"></asp:RequiredFieldValidator>
                <asp:RangeValidator runat="server" ErrorMessage="El Dato debe ser numerico" cssClass="text-danger" ControlToValidate="tbNroSAP" MaximumValue="100000000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
            </div>
            <div class="form-group">
                <label>Dirección Legal</label>
                <asp:TextBox runat="server" ID="tbDirLegal" cssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" cssClass="text-danger" ErrorMessage="Dirección requerida" ControlToValidate="tbDirLegal"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>Dirección de Entrega</label>
                <asp:TextBox runat="server" ID="tbDirEntrega" cssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" cssClass="text-danger" ErrorMessage="Dirección requerida" ControlToValidate="tbDirEntrega"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>Telefono</label>
                <asp:TextBox runat="server" ID="tbTelefono" cssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" cssClass="text-danger" ErrorMessage="Teléfono requerido" ControlToValidate="tbTelefono"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label>email</label>
                <asp:TextBox runat="server" ID="tbEmail" cssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" cssClass="text-danger" ErrorMessage="email requerido" ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" cssClass="text-danger" ErrorMessage="Tiene que ser un mail válido" ControlToValidate="tbEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label>Tipo de Empresa</label>
                <select class="form-control" id="selectTipoEmpresa" runat="server">
                    <option value="0" selected="selected"> Cliente </option>
                    <option value="1"> Transportista </option>
                </select>
                
            </div>
            <asp:Button runat="server" cssClass="btn btn-primary" Text="Alta" ID="btnAlta" OnClick="btnAlta_Click" />
        </form>
    </div>
</asp:Content>
