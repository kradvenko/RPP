<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoletaRecepcion.aspx.cs" Inherits="RPP.BoletaRecepcion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Css/normalize.css" />
    <link rel="stylesheet" href="Css/foundation.min.css" />
    <link rel="stylesheet" href="Css/Main.css" />    

    
    <script src="Js/jquery-2.1.3.min.js"></script>
    <script src="Js/vendor/modernizr.js"></script>
    <script src="Js/foundation.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div style="height: 50px;">
            &nbsp;
        </div>

        <div class="boleta">
        <div class="head">            
            <div class="gob">
                <table style="margin: 0px !important; padding: 0px !important;">                    
                    <tbody>
                        <tr>
                            <td width="30%" rowspan="2">
                                <img src="Imgs/logo2024h.png" width="180" height="180" />
                            </td>
                            <td width="40%" rowspan="2">
                                BOLETA DE INGRESO
                                <strong style="font-size: 1.2em;">PRELACIÓN: <asp:Label runat="server" ID="lbPrelacion2"> </asp:Label>  </strong>
                                <p style="font-size: 1.2em;">Fecha:<asp:Label runat="server" ID="lbCreacion2" Visible="true"> </asp:Label></p>
                            </td>
                            <td width="30%" rowspan="2">
                                <asp:Image runat="server" ID="imgCodeBar" ImageUrl="Imgs/barcode.png" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div>                
            </div>
        </div>
        <div class="row reng">
            <div class="tram">
                <asp:Label runat="server" ID="lbUsuario2"></asp:Label>
                <p><strong>DATOS DEL CONTRIBUYENTE</strong></p>
                <asp:Label runat="server" ID="lbTramitante2"></asp:Label><br />
                <asp:Label runat="server" ID="lbRfc2"></asp:Label><br />
                <asp:Label runat="server" ID="lbDomicilio12"></asp:Label><br />
                <asp:Label runat="server" ID="lbDomicilio22"></asp:Label>
            </div>
            <div class="ante">
                <asp:GridView runat="server" ID="gvAntecedentes2" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField DataField="Libro" ReadOnly="true" HeaderText="Libro" ShowHeader="true"  />
                        <asp:BoundField DataField="Tomo" ReadOnly="true" HeaderText="Tomo" ShowHeader="true"  />
                        <asp:BoundField DataField="Seccion" ReadOnly="true" HeaderText="Seccion" ShowHeader="true" />
                        <asp:BoundField DataField="Serie" ReadOnly="true" HeaderText="Serie" ShowHeader="true" />
                        <asp:BoundField DataField="Semestre" ReadOnly="true" HeaderText="Semestre" ShowHeader="true" />
                        <asp:BoundField DataField="Año" ReadOnly="true" HeaderText="Año" ShowHeader="true" />
                        <asp:BoundField DataField="Partida" ReadOnly="true" HeaderText="Partida" ShowHeader="true"  />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="descripcion"><p><strong>DESCRIPCION DEL TRAMITE / CONCEPTO DE PAGO</strong></p></div>
        <div class="desc">
            <div class="valor"><label><strong>VALOR BASE: $</strong><asp:Label runat="server" ID="lbValorBase2"></asp:Label></label></div>
            <div class="servicios">
                <asp:GridView runat="server" ID="gvServicios2" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField DataField="ClaveActo" ReadOnly="true" HeaderText="Servicio" ShowHeader="true"  />
                        <asp:BoundField DataField="NombreActo" ReadOnly="true" HeaderText="Acto" ShowHeader="true"  />
                        <asp:BoundField DataField="Nombre" ReadOnly="true" HeaderText="Movimiento" ShowHeader="true" />
                        <asp:BoundField DataField="Total" ReadOnly="true" HeaderText="#" ShowHeader="true" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="bien">
                <p>SOLICITANTE: <asp:Label runat="server" ID="lbTitular2"> </asp:Label></p>
                <p>DESCRIPCIÓN: <asp:Label runat="server" ID="lbDescripcion2"> </asp:Label></p>
            </div>
            <div class="total">
                <p><strong>TOTAL: $<asp:Label runat="server" ID="lbTotal2"></asp:Label></strong></p>
                Fecha de impresión de boleta: <asp:Label runat="server" ID="lbFecha2"> </asp:Label>
            </div>
        </div>
        <div><b>REGISTRO PÚBLICO</b></div>
    </div>

        

        <div style="height: 20px;">

        </div>

        <div class="boleta">
            <div class="head">
            <div class="gob">
                <table style="margin: 0px !important; padding: 0px !important;">
                    <thead>
                        <tr>
                            <td rowspan="2">
                                <img src="Imgs/logo2021e.png" width="150" height="150" />
                            </td>
                            <td>
                                GOBIERNO DEL ESTADO DE NAYARIT
                                <br />
                                Registro Público del Estado
                                <p>BOLETA DE INGRESO</p>
                            </td>
                            <td rowspan="2">
                                <strong><h2>Prelación: <asp:Label runat="server" ID="lbPrelacion4"> </asp:Label></h2></strong>
                                <p style="font-size: 1.5em;"><asp:Label runat="server" ID="lbCreacion4" Visible="true"> </asp:Label></p>
                            </td>
                        </tr>
                    </thead>                    
                </table>
            </div>
            <div>                
            </div>
        </div>
        </div>

        <div style="height: 20px;">
            &nbsp;
        </div>

        <div class="boleta">
        <div class="head">
            <div class="gob">
                <table style="margin: 0px !important; padding: 0px !important;">
                    <thead>
                        <tr>
                            <td rowspan="2">
                                <img src="Imgs/logo2021e.png" width="150" height="150" />
                            </td>
                            <td>
                                GOBIERNO DEL ESTADO DE NAYARIT
                                <br />
                                Registro Público del Estado
                                <p>BOLETA DE INGRESO</p>
                            </td>
                            <td rowspan="2">
                                <strong><h2>Prelación: <asp:Label runat="server" ID="lbPrelacion3"> </asp:Label></h2></strong>
                                <p style="font-size: 1.5em;"><asp:Label runat="server" ID="lbCreacion3" Visible="true"> </asp:Label></p>
                            </td>
                        </tr>
                    </thead>                    
                </table>
            </div>
            <div>                
            </div>
        </div>
        </div>    

        <div style="page-break-after: always;">
            &nbsp;
        </div>

        <div style="height: 50px;">
            &nbsp;
        </div>        

        <div class="boleta">
        <div class="head">            
            <div class="gob">
                <table style="margin: 0px !important; padding: 0px !important;">
                    <tbody>
                        <tr>
                            <td width="30%" rowspan="2">
                                <img src="Imgs/logo2024h.png" width="180" height="180" />
                            </td>
                            <td width="40%" rowspan="2">
                                BOLETA DE INGRESO
                                <strong style="font-size: 1.2em;">PRELACIÓN: <asp:Label runat="server" ID="lbPrelacion"> </asp:Label>  </strong>
                                <p style="font-size: 1.2em;">Fecha:<asp:Label runat="server" ID="lbCreacion" Visible="true"> </asp:Label></p>
                            </td>
                            <td width="30%" rowspan="2">
                                <asp:Image runat="server" ID="Image1" ImageUrl="Imgs/barcode.png" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div>
                
            </div>
        </div>
        <div class="row reng">
            <div class="tram">
                <asp:Label runat="server" ID="lbUsuario"></asp:Label>
                <p><strong>DATOS DEL CONTRIBUYENTE</strong></p>
                <asp:Label runat="server" ID="lbTramitante"></asp:Label><br />
                <asp:Label runat="server" ID="lbRfc"></asp:Label><br />
                <asp:Label runat="server" ID="lbDomicilio"></asp:Label><br />
                <asp:Label runat="server" ID="lbDomicilio2"></asp:Label>
            </div>
            <div class="ante">
                <asp:GridView runat="server" ID="gvAntecedentes" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField DataField="Libro" ReadOnly="true" HeaderText="Libro" ShowHeader="true"  />
                        <asp:BoundField DataField="Tomo" ReadOnly="true" HeaderText="Tomo" ShowHeader="true"  />
                        <asp:BoundField DataField="Seccion" ReadOnly="true" HeaderText="Seccion" ShowHeader="true" />
                        <asp:BoundField DataField="Serie" ReadOnly="true" HeaderText="Serie" ShowHeader="true" />
                        <asp:BoundField DataField="Semestre" ReadOnly="true" HeaderText="Semestre" ShowHeader="true" />
                        <asp:BoundField DataField="Año" ReadOnly="true" HeaderText="Año" ShowHeader="true" />
                        <asp:BoundField DataField="Partida" ReadOnly="true" HeaderText="Partida" ShowHeader="true"  />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="descripcion"><p><strong>DESCRIPCION DEL TRAMITE / CONCEPTO DE PAGO</strong></p></div>
        <div class="desc">
            <div class="valor"><label><strong>VALOR BASE: $</strong><asp:Label runat="server" ID="lbValorBase"></asp:Label></label></div>
            <div class="servicios">
                <asp:GridView runat="server" ID="gvServicios" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField DataField="ClaveActo" ReadOnly="true" HeaderText="Servicio" ShowHeader="true"  />
                        <asp:BoundField DataField="NombreActo" ReadOnly="true" HeaderText="Acto" ShowHeader="true"  />
                        <asp:BoundField DataField="Nombre" ReadOnly="true" HeaderText="Movimiento" ShowHeader="true" />
                        <asp:BoundField DataField="Total" ReadOnly="true" HeaderText="#" ShowHeader="true" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="bien">
                <p>SOLICITANTE: <asp:Label runat="server" ID="lbTitular"> </asp:Label></p>
                <p>DESCRIPCIÓN: <asp:Label runat="server" ID="lbDescripcion"> </asp:Label></p>
            </div>
            <div class="costos">
                <asp:GridView runat="server" ID="gvCostos" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField DataField="IdActo" ReadOnly="true" HeaderText="Clave" ShowHeader="true"  />
                        <asp:BoundField DataField="NombreActo" ReadOnly="true" HeaderText="Concepto" ShowHeader="true"  />
                        <asp:BoundField DataField="Cantidad" ReadOnly="true" HeaderText="Cantidad" ShowHeader="true" />
                        <asp:BoundField DataField="Importe" ReadOnly="true" HeaderText="P. Unit" ShowHeader="true"  />
                        <asp:BoundField DataField="Total" ReadOnly="true" HeaderText="Importe" ShowHeader="true" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="total">
                <p><strong>TOTAL: $<asp:Label runat="server" ID="lbTotal"></asp:Label></strong></p>
                Fecha de impresión de boleta: <asp:Label runat="server" ID="lbFecha"> </asp:Label>
            </div>
        </div>
         <div><b>CONTRIBUYENTE</b></div>
    </div>

        

        <!--
        <div class="row reng" style="visibility: collapse;">
            <div class="tram">
                <asp:Label runat="server" ID="lbUsuario3"></asp:Label>
                <p><strong>DATOS DEL CONTRIBUYENTE</strong></p>
                <asp:Label runat="server" ID="lbTramitante3"></asp:Label><br />
                <asp:Label runat="server" ID="lbRfc3"></asp:Label><br />
                <asp:Label runat="server" ID="lbDomicilio13"></asp:Label><br />
                <asp:Label runat="server" ID="lbDomicilio23"></asp:Label>
            </div>
            <div class="ante" style="visibility: collapse;">
                <asp:GridView runat="server" ID="gvAntecedentes3" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField DataField="Libro" ReadOnly="true" HeaderText="Libro" ShowHeader="true"  />
                        <asp:BoundField DataField="Tomo" ReadOnly="true" HeaderText="Tomo" ShowHeader="true"  />
                        <asp:BoundField DataField="Seccion" ReadOnly="true" HeaderText="Seccion" ShowHeader="true" />
                        <asp:BoundField DataField="Serie" ReadOnly="true" HeaderText="Serie" ShowHeader="true" />
                        <asp:BoundField DataField="Semestre" ReadOnly="true" HeaderText="Semestre" ShowHeader="true" />
                        <asp:BoundField DataField="Año" ReadOnly="true" HeaderText="Año" ShowHeader="true" />
                        <asp:BoundField DataField="Partida" ReadOnly="true" HeaderText="Partida" ShowHeader="true"  />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="descripcion" style="visibility: collapse;"><p><strong>DESCRIPCION DEL TRAMITE / CONCEPTO DE PAGO</strong></p></div>
        <div class="desc" style="visibility: collapse;">
            <div class="valor"><label><strong>VALOR BASE: $</strong><asp:Label runat="server" ID="lbValorBase3"></asp:Label></label></div>
            <div class="servicios">
                <asp:GridView runat="server" ID="gvServicios3" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField DataField="ClaveActo" ReadOnly="true" HeaderText="Servicio" ShowHeader="true"  />
                        <asp:BoundField DataField="NombreActo" ReadOnly="true" HeaderText="Acto" ShowHeader="true"  />
                        <asp:BoundField DataField="Nombre" ReadOnly="true" HeaderText="Movimiento" ShowHeader="true" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="bien">
                <p>SOLICITANTE: <asp:Label runat="server" ID="lbTitular3"> </asp:Label></p>
                <p>DESCRIPCIÓN: <asp:Label runat="server" ID="lbDescripcion3"> </asp:Label></p>
            </div>
            <div class="total">
                <p><strong>TOTAL: $<asp:Label runat="server" ID="lbTotal3"></asp:Label></strong></p>
                Fecha de impresión de boleta: <asp:Label runat="server" ID="lbFecha3"> </asp:Label>
            </div>
        </div>
        <div style="visibility: collapse;"><b>REGISTRO PÚBLICO</b></div>
        
    </div>
        -->
    </form>
</body>
</html>
