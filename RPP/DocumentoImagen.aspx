<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentoImagen.aspx.cs" Inherits="RPP.DocumentoImagen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <asp:Label runat="server" ID="lblError" ClientIDMode="Static">No se ha encontrado el documento electrónico.</asp:Label>
    <form id="form1" runat="server">
        <div class="center800">
            <div class="center">
                <fieldset>
                    <legend>Páginas</legend>
                    <div class="row">
                        <asp:DropDownList ID="ddlPaginas" runat="server" AutoPostBack="True" CausesValidation="True" OnSelectedIndexChanged="ddlPaginas_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </fieldset>
            </div>
            <div class="center">
                <asp:Image ID="Image1" runat="server" Height="50%" Width="50%" />
            </div>
        </div>
    </form>
</body>
</html>
