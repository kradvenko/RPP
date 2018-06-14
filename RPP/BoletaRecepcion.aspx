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
     <div class="boleta">
        <div class="head">
            <img src="Imgs/logo-gobierno.png" width="50" height="50" />
            <div class="gob">
                <p>GOBIERNO DEL ESTADO DE <strong>NAYARIT</strong></p>
                <p>Registro Público de la Propiedad y Comercio</p>
                <p>BOLETA DE INGRESO</p>
            </div>
            <div>
                <p>PRELACIÓN: <asp:Label runat="server" ID="lbPrelacion"> </asp:Label></p>
                <p>Fecha: <asp:Label runat="server" ID="lbFecha"> </asp:Label></p>
                <p>Hora: <asp:Label runat="server" ID="lbHora"> </asp:Label></p>
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
                    </Columns>
                </asp:GridView>
            </div>
            <div class="bien">
                <p>NUEVO TITULAR: <asp:Label runat="server" ID="lbTitular"> </asp:Label></p>
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
            </div>
        </div>
         <div><b>CONTRIBUYENTE</b></div>
    </div>
        <div style="height: 30px;">

        </div>
    <div class="boleta">
        <div class="head">
            <img id="img2" src="Imgs/logo-gobierno.png" width="50" height="50" />
            <div class="gob">
                <p>GOBIERNO DEL ESTADO DE <strong>NAYARIT</strong></p>
                <p>Registro Público de la Propiedad y Comercio</p>
                <p>BOLETA DE INGRESO</p>
            </div>
            <div>
                <p>PRELACIÓN: <asp:Label runat="server" ID="lbPrelacion2"> </asp:Label></p>
                <p>Fecha: <asp:Label runat="server" ID="lbFecha2"> </asp:Label></p>
                <p>Hora: <asp:Label runat="server" ID="lbHora2"> </asp:Label></p>
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
                    </Columns>
                </asp:GridView>
            </div>
            <div class="bien">
                <p>NUEVO TITULAR: <asp:Label runat="server" ID="lbTitular2"> </asp:Label></p>
                <p>DESCRIPCIÓN: <asp:Label runat="server" ID="lbDescripcion2"> </asp:Label></p>
            </div>
            <div class="total">
                <p><strong>TOTAL: $<asp:Label runat="server" ID="lbTotal2"></asp:Label></strong></p>
            </div>
        </div>
        <div><b>REGISTRO PÚBLICO</b></div>
    </div>

    </form>
</body>
</html>
