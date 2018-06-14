<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="RPP.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        
        function valid() {
            $('[required]').attr('required', false);
        }
        function validy() {
            $('[required]').attr('required', true);
        }
    </script>
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" />
    <div class="center800 registrar" data-abide>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <a href="Registro.aspx"><- Ir a Registro</a>
                <fieldset>
                    <legend>Movimientos</legend>
                    <asp:UpdatePanel runat="server" ID="panelMovimientos">
                        <ContentTemplate>
                            <div class="row space">
                                <div class="medium-3 large-3 columns"><label>Número Prelacion:<asp:TextBox runat="server" ID="txIdPrelacion" Enabled="false"></asp:TextBox></label></div>
                                <div class="medium-3 large-3 columns"><label>Fecha Registro:<asp:TextBox runat="server" ID="txFechaReg" Enabled="false"></asp:TextBox></label></div>
                                <div class="medium-3 large-3 columns end"><label>Folio Prelación:<asp:TextBox runat="server" ID="txFolio" Enabled="false" MaxLength="50"></asp:TextBox></label></div>
                            </div>
                            <div class="row">
                                <div class="medium-6 large-6 columns ">
                                    <asp:RadioButtonList ID="radbMovimientos" runat="server" CssClass="lista" RepeatColumns="1" OnSelectedIndexChanged="radbMovimientos_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:RadioButtonList>
                                </div>
                                <div class="medium-3 large-3 columns ">
                                    <asp:DropDownList runat="server" ID="ddlSeccion" AppendDataBoundItems="true"><asp:ListItem>Elige Seccion:</asp:ListItem></asp:DropDownList>
                                </div>
                                <div class="medium-2 large-2 columns end ">
                                    <asp:Button ID="btRegistrar" runat="server" CssClass="button" Text="Registrar "   OnClick="btRegistrar_Click"/>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
                <fieldset>
                    <legend>Antecedentes</legend>
                    <asp:UpdatePanel runat="server" ID="panelAntecedentes">
                        <ContentTemplate>
                            <div class="row space">
                                
                            </div>
                            <div class="row">
                                <asp:GridView ID="gvAntecedentes" runat="server" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvAntecedentes_SelectedIndexChanged">
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#E3EAEB" />
                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                                    <Columns>
                                        <asp:BoundField DataField="Folio" ReadOnly="true" HeaderText="Folio" ShowHeader="true"  />
                                        <asp:BoundField DataField="Libro" ReadOnly="true" HeaderText="Libro" ShowHeader="true"  />
                                        <asp:BoundField DataField="Tomo" ReadOnly="true" HeaderText="Tomo" ShowHeader="true"  />
                                        <asp:BoundField DataField="Seccion" ReadOnly="true" HeaderText="Seccion" ShowHeader="true" />
                                        <asp:BoundField DataField="Serie" ReadOnly="true" HeaderText="Serie" ShowHeader="true" />
                                        <asp:BoundField DataField="Semestre" ReadOnly="true" HeaderText="Semestre" ShowHeader="true" />
                                        <asp:BoundField DataField="Año" ReadOnly="true" HeaderText="Año" ShowHeader="true" />
                                        <asp:BoundField DataField="Partida" ReadOnly="true" HeaderText="Partida" ShowHeader="true"  />
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </fieldset>
                <div runat="server" id="formularioRegistro" visible="false">
                    <fieldset>
                        <legend id="legOtorgante" runat="server">Otorgante(s) / Acreedor(es)</legend>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="medium-3 large-3 columns"><label id="labelNombreO" runat="server">Nombre:</label><asp:TextBox runat="server" ID="txNombreO" MaxLength="150"></asp:TextBox></div>
                                    <div class="medium-3 large-3 columns"><label id="labelAPaternoO" runat="server">Apellido Paterno:<asp:TextBox runat="server" ID="txPaternoO" MaxLength="50"></asp:TextBox></label></div>
                                    <div class="medium-3 large-3 columns"><label id="labelAMaternoO" runat="server">Apellido Materno:<asp:TextBox runat="server" ID="txMaternoO" MaxLength="50"></asp:TextBox></label></div>
                                    <div class="medium-3 large-3 columns"><asp:Button runat="server" ID="btAddOtorgante" Cssclass="button tiny radius mas" Text="+" OnClick="btAddOtorgante_Click" OnClientClick=" return valid();" /></div>
                                </div>
                                <div class="row">
                                    <asp:GridView runat="server" ID="gvOtorgantes" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" DataKeyNames="IdPersona"
                                            OnRowDeleting="gvOtorgantes_RowDeleting" >
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="true" HeaderText="Eliminar" />
                                            <asp:BoundField DataField="IdPersona" ReadOnly="true" HeaderText="Id" ShowHeader="true" Visible="False" />
                                            <asp:BoundField DataField="Nombre" ReadOnly="true" HeaderText="Nombre" ShowHeader="true"  />
                                            <asp:BoundField DataField="Paterno" ReadOnly="true" HeaderText="Apellido Paterno" ShowHeader="true"  />
                                            <asp:BoundField DataField="Materno" ReadOnly="true" HeaderText="Apellido Materno" ShowHeader="true"  />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </fieldset>
                    <fieldset runat="server" id="adquirientes">
                        <legend id="legAdquirientes" runat="server">Adquiriente(s) / Deudor(es)</legend>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="medium-3 large-3 columns"><label id="labelNombreA" runat="server">Nombre:</label><asp:TextBox runat="server" ID="txNombreA"  MaxLength="50"></asp:TextBox></div>
                                    <div class="medium-3 large-3 columns"><label>Apellido Paterno:<asp:TextBox runat="server" ID="txPaternoA" MaxLength="50"></asp:TextBox></label></div>
                                    <div class="medium-3 large-3 columns"><label>Apellido Materno:<asp:TextBox runat="server" ID="txMaternoA" MaxLength="50"></asp:TextBox></label></div>
                                    <div class="medium-3 large-3 columns"><asp:Button runat="server" ID="btAddAdquiriente" Cssclass="button tiny radius mas" Text="+" OnClick="btAddAdquiriente_Click" OnClientClick=" return valid();" /></div>
                                </div>
                                <div class="row">
                                    <asp:GridView runat="server" ID="gvAdquirientes" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" DataKeyNames="IdPersona"
                                            OnRowDeleting="gvAdquirientes_RowDeleting" >
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="true" HeaderText="Eliminar" />
                                            <asp:BoundField DataField="IdPersona" ReadOnly="true" HeaderText="Id" ShowHeader="true" Visible="false" />
                                            <asp:BoundField DataField="Nombre" ReadOnly="true" HeaderText="Nombre" ShowHeader="true"  />
                                            <asp:BoundField DataField="Paterno" ReadOnly="true" HeaderText="Apellido Paterno" ShowHeader="true"  />
                                            <asp:BoundField DataField="Materno" ReadOnly="true" HeaderText="Apellido Materno" ShowHeader="true"  />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </fieldset>
                    <fieldset runat="server" id="datosI">
                        <legend>Datos del Inmueble</legend>
                        <div class="row">
                            <div class="medium-3 large-3 columns"><label runat="server" id="tipopredio">Tipo de Predio:<asp:TextBox runat="server" ID="txTipoPredio" required MaxLength="50"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                            <div class="medium-3 large-3 columns "><label runat="server" id="superficie">Superficie:<asp:TextBox runat="server" ID="txSuperficie" MaxLength="50" ></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                            <div class="medium-3 large-3 columns"><label runat="server" id="unidadsuperficie">Unidad Superficie:<asp:DropDownList runat="server" ID="ddlUnidadSup"><asp:ListItem Value="Metros Cuadrados">Metros Cuadrados</asp:ListItem><asp:ListItem Value="Hectáreas">Hectáreas</asp:ListItem></asp:DropDownList></label></div>
                            <div class="medium-3 large-3 columns end"><label runat="server" id="clavecatastral">Clave Catastral:<asp:TextBox runat="server" ID="txClaveCat" MaxLength="50"></asp:TextBox></label></div>
                        </div>
                    </fieldset>
                    <fieldset runat="server" id="ubicacionI">
                        <legend>Ubicación del Inmueble</legend>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="medium-3 large-3 columns"><label>Municipio:<asp:DropDownList runat="server" ID="ddlMunicipios" OnSelectedIndexChanged="ddlMunicipios_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></label></div>
                                    <div class="medium-3 large-3 columns"><label>Poblacion:<asp:DropDownList runat="server" ID="ddlPoblaciones"></asp:DropDownList></label></div>
                                    <div class="medium-3 large-3 columns">
                                        <label runat="server" id="idcolonia" >Colonia:
                                            <asp:DropDownList runat="server" ID="ddlColonia" OnSelectedIndexChanged="ddlColonia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            <asp:TextBox runat="server" ID="txColonia" MaxLength="150"></asp:TextBox>
                                        </label>
                                    </div>
                                    <div class="medium-3 large-3 columns">
                                        <label runat="server" id="idcalle" >Calle:
                                            <asp:DropDownList runat="server" ID="ddlCalle" OnSelectedIndexChanged="ddlCalle_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            <asp:TextBox runat="server" ID="txCalle" MaxLength="150"></asp:TextBox>
                                        </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="medium-3 large-3 columns ">
                                        <label runat="server" id="idnumero">Numero:
                                            <asp:DropDownList runat="server" ID="ddlNum"></asp:DropDownList>
                                        </label>
                                        <label runat="server" id="numinterior">Numero Int:<asp:TextBox runat="server" ID="txInterior" MaxLength="50"></asp:TextBox></label></div>
                                    <div class="medium-3 large-3 columns "><br /><br /><label runat="server" id="numexterior">Numero Ext:<asp:TextBox runat="server" ID="txExterior" MaxLength="50"></asp:TextBox></label></div>
                                    <div class="medium-3 large-3 columns "><label runat="server" id="manzana">Manzana:<asp:TextBox runat="server" ID="txManzana" MaxLength="50"></asp:TextBox></label></div>
                                    <div class="medium-3 large-3 columns end"><label runat="server" id="lote">Lote:<asp:TextBox runat="server" ID="txLote" MaxLength="50"></asp:TextBox></label></div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
            
                    </fieldset>
                    <fieldset runat="server" id="descripcion">
                        <legend id="legDescripcion" runat="server">Descripcion del Inmueble</legend>
                        <div>
                            <label runat="server" id="lblColindancias">Colindancias:</label>
                            <div class="row" runat="server" id="rowNorte"><div class="medium-12 large-12 columns"><label runat="server" id="lblNorte">Norte:</label><asp:TextBox runat="server" ID="txNorte" MaxLength="250"></asp:TextBox></div></div>
                            <div class="row" runat="server" id="rowSur"><div class="medium-12 large-12 columns"><label runat="server" id="lblSur">Sur:</label><asp:TextBox runat="server" ID="txSur" MaxLength="250"></asp:TextBox></div></div>
                            <div class="row" runat="server" id="rowEste"><div class="medium-12 large-12 columns"><label runat="server" id="lblEste">Este (Oriente):</label><asp:TextBox runat="server" ID="txEste" MaxLength="250"></asp:TextBox></div></div>
                            <div class="row" runat="server" id="rowOeste"><div class="medium-12 large-12 columns"><label runat="server" id="lblOeste">Oeste (Poniente):</label><asp:TextBox runat="server" ID="txOeste" MaxLength="250"></asp:TextBox></div></div>
                            <div class="row" runat="server" id="rowNoreste"><div class="medium-12 large-12 columns"><label runat="server" id="lblNoreste">Noreste (NorOriente):</label><asp:TextBox runat="server" ID="txNoreste" MaxLength="250"></asp:TextBox></div></div>
                            <div class="row" runat="server" id="rowNoroeste"><div class="medium-12 large-12 columns"><label runat="server" id="lblNoroeste">Noroeste (NorPoniente):</label><asp:TextBox runat="server" ID="txNoroeste" MaxLength="250"></asp:TextBox></div></div>
                            <div class="row" runat="server" id="rowSureste"><div class="medium-12 large-12 columns"><label runat="server" id="lblSureste">Sureste (SurOriente):</label><asp:TextBox runat="server" ID="txSureste" MaxLength="250"></asp:TextBox></div></div>
                            <div class="row" runat="server" id="rowSuroeste"><div class="medium-12 large-12 columns"><label runat="server" id="lblSuroeste">Suroeste (SurPoniente):</label><asp:TextBox runat="server" ID="txSuroeste" MaxLength="250"></asp:TextBox></div></div>
                        </div>
                    </fieldset>
                    <fieldset>
                        <legend>Registro Actual</legend>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="medium-2 large-2 columns"><label>Libro:<asp:TextBox runat="server" ID="txLibroR" required pattern="[0-9]+" MaxLength="50"></asp:TextBox></label></div>
                                    <div class="medium-2 large-2 columns"><label id="lbSeccionR" runat="server">Seccion:
                                        <asp:DropDownList ID="ddlSeccionR" runat="server" AppendDataBoundItems="true" required >
                                            <asp:ListItem Value>Elige Seccion</asp:ListItem>
                                            <asp:ListItem Value="1">I</asp:ListItem>
                                            <asp:ListItem Value="2">II</asp:ListItem>
                                            <asp:ListItem Value="3">III</asp:ListItem>
                                            <asp:ListItem Value="4">IV</asp:ListItem>
                                            <asp:ListItem Value="5">V</asp:ListItem>
                                            <asp:ListItem Value="6">Libro de legajo</asp:ListItem>
                                        </asp:DropDownList></label></div>
                                    <div class="medium-2 large-2 columns"><label id="lbSerie" runat="server">Serie:
                                        <asp:DropDownList ID="ddlSerie" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0">Elige Serie</asp:ListItem>
                                            <asp:ListItem Value="SIN SERIE">Sin serie</asp:ListItem>
                                            <asp:ListItem Value="A">A</asp:ListItem>
                                            <asp:ListItem Value="B">B</asp:ListItem>
                                            <asp:ListItem Value="C">C</asp:ListItem>
                                        </asp:DropDownList></label></div>
                                    <div class="medium-2 large-2 columns end "><label>Partida:<asp:TextBox ID="txPartidaR" runat="server" required pattern="[0-9]+" MaxLength="50"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </fieldset>
                    <fieldset runat="server" id="anotaciones">
                        <legend>Anotaciones Marginales</legend>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="medium-2 large-2 columns"><label>Libro/Tomo/Semestre:
                                        <asp:DropDownList ID="ddlLTSM" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlLTSR_SelectedIndexChanged">
                                            <asp:ListItem Value="Libro">Libro</asp:ListItem>
                                            <asp:ListItem Value="Tomo">Tomo</asp:ListItem>
                                            <asp:ListItem Value="Semestre">Semestre</asp:ListItem>
                                        </asp:DropDownList></label></div>
                                    <div class="medium-2 large-2 columns" style="padding-top:20px"> <asp:TextBox ID="txLTM" runat="server" pattern="[0-9]+" MaxLength="50"></asp:TextBox>
                                        <asp:DropDownList ID="ddlSemestreM" runat="server" AppendDataBoundItems="true" Visible="false"  >
                                            <asp:ListItem Value>Elige Semestre</asp:ListItem>
                                            <asp:ListItem Value="1">Primer</asp:ListItem>
                                            <asp:ListItem Value="2">Segundo</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="medium-2 large-2 columns"><label id="lbASemM" runat="server" visible="false">Año Semestre:<asp:TextBox ID="txASemM" runat="server" MaxLength="50" Visible="false" required pattern="[0-9]+"></asp:TextBox></label></div>
                                    <div class="medium-2 large-2 columns"><label id="lbSeccionM" runat="server">Seccion:
                                        <asp:DropDownList ID="ddlSeccionM" runat="server" AppendDataBoundItems="true"  >
                                            <asp:ListItem Value>Elige Seccion</asp:ListItem>
                                            <asp:ListItem Value="1">I</asp:ListItem>
                                            <asp:ListItem Value="2">II</asp:ListItem>
                                            <asp:ListItem Value="3">III</asp:ListItem>
                                            <asp:ListItem Value="4">IV</asp:ListItem>
                                            <asp:ListItem Value="5">V</asp:ListItem>
                                        </asp:DropDownList></label></div>
                                    <div class="medium-2 large-2 columns"><label id="lbSerieM" runat="server">Serie:
                                        <asp:DropDownList ID="ddlSerieM" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0">Elige Serie</asp:ListItem>
                                            <asp:ListItem Value="SIN SERIE">Sin serie</asp:ListItem>
                                            <asp:ListItem Value="A">A</asp:ListItem>
                                            <asp:ListItem Value="B">B</asp:ListItem>
                                            <asp:ListItem Value="C">C</asp:ListItem>
                                        </asp:DropDownList></label></div>
                                    <div class="medium-2 large-2 columns end"><label>Partida:<asp:TextBox ID="txPartidaM" runat="server"  pattern="[0-9]+" MaxLength="50"></asp:TextBox></label></div>
                                </div>
                                <div class="row">
                                    <div class="medium-1 large-1 columns end"><asp:Button runat="server" ID="btAgregarAnotacion" Cssclass="button tiny radius mas" Text="+" OnClick="btAgregarAnotacion_Click" /></div>
                                    <div class="medium-11 large-11 columns">
                                        <asp:GridView runat="server" ID="gvAnotaciones" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="Id"
                                                OnRowDeleting="gvAnotaciones_RowDeleting" >
                                            <Columns>
                                                <asp:CommandField ShowDeleteButton="true" HeaderText="Eliminar" />
                                                <asp:BoundField DataField="Id" ReadOnly="true" HeaderText="Id" ShowHeader="true" Visible="false" />
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
                                <div class="row">
                                    <div class="medium-12 large-12 columns">
                                        <label>Observaciones (Anotaciones)<asp:TextBox runat="server" ID="txObservacionesM" MaxLength="250"></asp:TextBox></label>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </fieldset>
                    <fieldset>
                        <legend>ESCRIBA LA INFORMACION DEL SELLO QUE SE ADJUNTARA EN EL ANTECEDENTE</legend>
                        <div class="row">
                            <div class="medium-12 large-12 columns"><textarea runat="server" id="txAnotacionActualizada" maxlength="500"></textarea></div>
                        </div>
                    </fieldset>
                    <fieldset>
                        <legend>Observaciones</legend>
                        <div class="row">
                            <div class="medium-12 large-12 columns"><textarea runat="server" id="txObservaciones" maxlength="500"></textarea></div>
                        </div>
                    </fieldset>
                    <div class="row">
                        <div class="medium-4 large-4 columns"><asp:Button runat="server" CssClass="button" ID="btGuardarRegistro" Text="Guardar Registro" OnClick="btGuardarRegistro_Click" OnClientClick=" return validy();" /></div>
                        <div class="medium-4 large-4 columns"><asp:Button runat="server" CssClass="button" ID="btCancelarRegistro" Text="Cancelar Registro" OnClick="btCancelarRegistro_Click" OnClientClick="valid();" /></div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script>
        $(document).foundation();
    </script>
</asp:Content>
