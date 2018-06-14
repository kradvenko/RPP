<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentoControles.aspx.cs" Inherits="RPP.DocumentoControles" %>
<!DOCTYPE html>
<HTML>
       <HEAD>

             <title>DocumentoControles</title>
             <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
             <meta content="C#" name="CODE_LANGUAGE">
             <meta content="JavaScript" name="vs_defaultClientScript">
             <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
             <script language="javascript">
                 //<!--
                 function ZoomIn(factor) {
                     img = window.parent.frames[0].document.all[4];
                     img.width *= factor;
                 }

                 function ZoomOut(factor) {
                     img = window.parent.frames[0].document.all[4];
                     img.width /= factor;
                 }

                 function ZoomPage() {
                     img = window.parent.frames[0].document.all[4];
                     img.width = window.parent.frames[0].document.body.clientWidth - 50;
                 }

                 function Zoom(width) {
                     img = window.parent.frames[0].document.all[4];
                     if (width == 0)
                         return img.width;
                     else
                         img.width = width;
                 }

                 function imprimirDocumento() {
                     Zoom(650);
                     window.parent.frames[0].focus();
                     window.parent.frames[0].print();
                 }
                 //-->
             </script>
       </HEAD>
       <body bottomMargin="5" bgColor="gainsboro" leftMargin="5" topMargin="5" onload="ZoomPage();" rightMargin="5">
             <form id="Form1" method="post" runat="server">

                    <TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">

                           <TR>

                                  <TD><INPUT style="WIDTH: 88px; HEIGHT: 24px" type="button" value="Acercar (+)" onclick="ZoomIn(1.2);">&nbsp;<INPUT style="WIDTH: 88px; HEIGHT: 24px" type="button" value="Alejar (-)" onclick="    ZoomOut(1.2);">&nbsp;<INPUT style="WIDTH: 120px; HEIGHT: 24px" type="button" value="Página Completa" onclick="    ZoomPage();"></TD>

                                  <TD align="right"><INPUT style="WIDTH: 80px; HEIGHT: 24px" onclick="imprimirDocumento();" type="button"

                                               value="Imprimir">&nbsp;<INPUT style="WIDTH: 72px; HEIGHT: 24px" onclick="window.parent.close();" type="button"

                                               value="Cerrar"></TD>

                           </TR>

                    </TABLE>

             </form>
       </body>

</HTML>
