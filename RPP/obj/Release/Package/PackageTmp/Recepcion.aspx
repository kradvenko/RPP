<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Recepcion.aspx.cs" Inherits="RPP.Recepcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function mostrar() {
            document.getElementById('<%=dNuevoTram.ClientID %>').style.display = "block";
            $('[required]').attr('required', false);
        }
        function ocultar() {
            document.getElementById('<%=dNuevoTram.ClientID %>').style.display = "none";
            $('[required]').attr('required', true);
        }
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
        function valid() {
            $('[required]').attr('required', false);
        }
        function validy() {
            $('[required]').attr('required', true);
        }
    </script>
        
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" />
    <div class="center800">
        <ul class="tabs" data-tab role="tablist">
          <li class="tab-title menu active" role="presentational"><a href="#panel-1" role="tab" tabindex="0" aria-selected="true" controls="panel-1">Inicio</a></li>
          <li class="tab-title menu" role="presentational"><a href="#panel-2" role="tab" tabindex="0" aria-selected="false" controls="panel-2">Perfil Usuario</a></li>
          <li class="tab-title menu" role="presentational"><a href="#panel-3" role="tab" tabindex="0" aria-selected="false" controls="panel-3">Nueva Prelación</a></li>
          <li class="tab-title menu" role="presentational"><a href="#panel-4" role="tab" tabindex="0" aria-selected="false" controls="panel-4">Buscar Prelación</a></li>
        </ul>
        <ul class="tabs distribucion">
            <li class="tab-title" ><a href="Distribucion.aspx" tabindex="0" aria-selected="false">Distribución</a></li>
        </ul>
        <ul class="tabs salir">
            <li class="tab-title" ><a href="Login.aspx" tabindex="0" aria-selected="false">Salir</a></li>
        </ul>
        <div class="tabs-content">
            <section role="tabpanel" aria-hidden="false" class="content active" id="panel-1">
                <asp:Image runat="server" Width="400" ImageUrl="~/Imgs/RPP.jpg"/>
            </section>
            <section role="tabpanel" aria-hidden="true" class="content" id="panel-2">
                <h2>Datos de Usuario</h2>
                <div data-abide>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <fieldset>
                                <legend>Datos de Usuario</legend>
                                <div class="row">
                                    <div class="medium-4 large-4 columns"><label>Tipo de Usuario:<asp:TextBox runat="server" ID="txTipoUsuario" Enabled="false"></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns end"><label>Usuario:<asp:TextBox ID="txUsuario" runat="server" Enabled="false"></asp:TextBox></label></div>
                                </div>
                               <div class="row">
                                    <div class="medium-4 large-4 columns"><label>Nueva Contraseña:<asp:TextBox ID="txPass1" runat="server" TextMode="Password"></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns"><label>Repite Contraseña:<asp:TextBox ID="txPass2" runat="server" TextMode="Password"></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns"><asp:Button runat="server" CssClass="button" ID="btCambiarPass" Text="Cambiar Contraseña" OnClick="btCambiarPass_Click" OnClientClick="return valid();" /></div>
                                </div>
                            </fieldset>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div data-abide>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <fieldset>
                                <legend>Generales</legend>
                                <div class="row">
                                    <div class="medium-4 large-4 columns"><label>Nombre:<asp:TextBox ID="txNombre" runat="server" required></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns"><label>Apellido Paterno:<asp:TextBox ID="txAPaterno" runat="server" required></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns"><label>Apellido Materno:<asp:TextBox ID="txAMaterno" runat="server" required></asp:TextBox></label></div>
                                </div>
                                <div class="row">
                                    <div class="medium-4 large-4 columns"><label>Fecha Nacimiento:<asp:TextBox ID="txNacimiento" runat="server" TextMode="Date"></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns"><label>CURP:<asp:TextBox ID="txCURP" runat="server"></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns"><label>RFC:<asp:TextBox ID="txRFC" runat="server"></asp:TextBox></label></div>
                                </div>
                                <div class="row">
                                    <div class="medium-4 large-4 columns"><label>Telefono1:<asp:TextBox ID="txTelefono1" runat="server"></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns"><label>Telefono2:<asp:TextBox ID="txTelefono2" runat="server"></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns"><label>Num Control:<asp:TextBox ID="txControl" runat="server"></asp:TextBox></label></div>
                                </div>
                            </fieldset>
                            <fieldset>
                                <legend>Domicilio</legend>
                                <div class="row">
                                    <div class="medium-4 large-4 columns"><label>Calle y Número:<asp:TextBox ID="txCalle" runat="server"></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns"><label>Colonia:<asp:TextBox ID="txColonia" runat="server"></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns"><label>Código Postal:<asp:TextBox ID="txCodigoPostal" runat="server"></asp:TextBox></label></div>
                                </div>
                                <div class="row">
                                    <div class="medium-4 large-4 columns"><label>Municipio:
                                        <asp:DropDownList ID="ddlMunicipiosU" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipiosU_SelectedIndexChanged"></asp:DropDownList></label></div>
                                    <div class="medium-4 large-4 columns"><label>Poblacion:
                                        <asp:DropDownList ID="ddlPoblacionesU" runat="server" AutoPostBack="True"></asp:DropDownList></label></div>
                                    <div class="medium-4 large-4 columns"><asp:Button runat="server" ID="btGuardarCambios" CssClass="button" Text="Guardar Cambios" OnClick="btGuardarCambios_Click" OnClientClick="return valid();" /></div>
                                </div>
                            </fieldset>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                 </div>
            </section>
            <section role="tabpanel" aria-hidden="true" class="content" id="panel-3">
                <h2>Captura de Nueva Prelación</h2>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div data-abide >
                            <fieldset>
                                <legend>Datos de la Solicitud</legend>
                                <div class="row">
                                    <div class="medium-3 large-3 columns"><label>Fecha:<asp:TextBox ID="txFecha" runat="server" Enabled="false" style="text-align:center" Font-Bold="true"></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns"><label>Folio de Propiedad:<asp:TextBox ID="txFolio" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="medium-8 large-8 columns"><label>Tramitante:
                                                <asp:DropDownList ID="ddlTramitantes" runat="server" AppendDataBoundItems="true"  ><asp:ListItem Value>Listado de Tramitantes</asp:ListItem></asp:DropDownList></label></div>
                                            <div class="medium-1 large-1 columns end"><a class="button tiny radius mas" onclick="return mostrar();">+</a></div>
                                            <div class="medium-1 large-1 columns end"><a class="button tiny radius mas" onclick="return ocultar();">-</a></div>
                                        </div>
                                        <div runat="server" id="dNuevoTram" style="display:none">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <fieldset class="marco">
                                                    <legend>Agregar Tramitante</legend>
                                                    <fieldset>
                                                        <legend>Generales</legend>
                                                        <div class="row">
                                                            <div class="medium-4 large-4 columns"><label>Nombre:<asp:TextBox ID="txNombreT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                            <div class="medium-4 large-4 columns"><label>Apellido Paterno:<asp:TextBox ID="txAPaternoT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                            <div class="medium-4 large-4 columns"><label>Apellido Materno:<asp:TextBox ID="txAMaternoT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="medium-4 large-4 columns"><label>Razon Social:<asp:TextBox ID="txRazonSocialT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                            <div class="medium-4 large-4 columns"><label>CURP:<asp:TextBox ID="txCurpT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                            <div class="medium-4 large-4 columns"><label>RFC:<asp:TextBox ID="txRfcT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                        </div>
                                                    </fieldset>
                                                    <fieldset>
                                                        <legend>Domicilio</legend>
                                                        <div class="row">
                                                            <div class="medium-4 large-4 columns"><label>Calle:<asp:TextBox ID="txCalleT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                            <div class="medium-2 large-2 columns"><label>Número:<asp:TextBox ID="txNumeroT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                            <div class="medium-4 large-4 columns"><label>Colonia:<asp:TextBox ID="txColoniaT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                            <div class="medium-2 large-2 columns"><label>CP:<asp:TextBox ID="txCodigoT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="medium-4 large-4 columns"><label>Municipio:
                                                                <asp:DropDownList ID="ddlMunicipioT" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipioT_SelectedIndexChanged"></asp:DropDownList></label></div>
                                                            <div class="medium-6 large-6 columns"><label>Poblacion:
                                                                <asp:DropDownList ID="ddlPoblacionT" runat="server"></asp:DropDownList></label></div>
                                                            <div class="medium-2 large-2 columns"><label>Estado:<asp:TextBox ID="txEstadoT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                        </div>
                                                    </fieldset>
                                                    <fieldset>
                                                        <legend>Datos de Tramitante</legend>
                                                        <div class="row">
                                                            <div class="medium-4 large-4 columns"><label>L Notaria:<asp:TextBox ID="txLNotariaT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                            <div class="medium-4 large-4 columns"><label>No. Notaria:<asp:TextBox ID="txNotariaT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                            <div class="medium-4 large-4 columns"><label>Tipo de Tramitante:<asp:TextBox ID="txTipoT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="medium-4 large-4 columns"><label>Telefono:<asp:TextBox ID="txTelefonoT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                            <div class="medium-4 large-4 columns"><label>Fax:<asp:TextBox ID="txFaxT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                            <div class="medium-4 large-4 columns"><label>Extensión:<asp:TextBox ID="txExtensionT" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                                        </div>
                                                    </fieldset>
                                                    <asp:Button runat="server" CssClass="button" ID="btGuardarT" Text="Guardar" OnClick="btGuardarT_Click" />
                                                </fieldset>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="row">
                                    <div class="medium-8 large-8 columns"><label>Nuevo Titular:<asp:TextBox ID="txNombreTitular" runat="server" MaxLength="150"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                </div>
                                <div class="row">
                                    <div class="medium-6 large-6 columns"><label>Escritura:<asp:TextBox id="txNumeroEscritura" runat="server" MaxLength="50" ></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                    <div class="medium-6 large-6 columns"><label>Descripción del Bien:<asp:TextBox ID="txDescripcion" runat="server" MaxLength="200"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                </div>
                                <div class="row">
                                    <div class="medium-3 large-3 columns"><label>Tipo Documento:<asp:TextBox runat="server" ID="txTipoDocto" MaxLength="100"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                    <div class="medium-3 large-3 columns"><label>Fecha Otorgamiento:<asp:TextBox runat="server" ID="txFechaOtorg" ></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                    <div class="medium-3 large-3 columns end"><label>Lugar Otorgamiento:<asp:TextBox runat="server" ID="txLugarOtorg" MaxLength="100"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                </div>
                            </fieldset>
                            <fieldset>
                                <legend>Antecedentes</legend>
                                <div class="row">
                                    <div class="medium-2 large-2 columns"><label>Libro/Tomo/Sem:
                                        <asp:DropDownList ID="ddlLTS" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlLTS_SelectedIndexChanged">
                                            <asp:ListItem Value="Libro">Libro</asp:ListItem>
                                            <asp:ListItem Value="Tomo">Tomo</asp:ListItem>
                                            <asp:ListItem Value="Semestre">Semestre</asp:ListItem>
                                        </asp:DropDownList></label></div>
                                    <div class="medium-2 large-2 columns" style="padding-top:20px"> <asp:TextBox ID="txLT" runat="server"  pattern="[0-9]+" MaxLength="50"> </asp:TextBox><small class="error">Campo Requerido.</small>
                                        <asp:DropDownList ID="ddlSemestre" runat="server" AppendDataBoundItems="true" Visible="false" >
                                            <asp:ListItem Value>Elige Semestre</asp:ListItem>
                                            <asp:ListItem Value="1">Primer</asp:ListItem>
                                            <asp:ListItem Value="2">Segundo</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="medium-2 large-2 columns"><label id="lbASem" runat="server" visible="false">Año Semestre:<asp:TextBox ID="txASem" runat="server" Visible="false"  pattern="[0-9]+" MaxLength="50"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                    <div class="medium-2 large-2 columns"><label id="lbSeccion" runat="server">Seccion:
                                        <asp:DropDownList ID="ddlSeccion" runat="server" AppendDataBoundItems="true" >
                                            <asp:ListItem Value>Elige Seccion</asp:ListItem>
                                            <asp:ListItem Value="1">I</asp:ListItem>
                                            <asp:ListItem Value="2">II</asp:ListItem>
                                            <asp:ListItem Value="3">III</asp:ListItem>
                                            <asp:ListItem Value="4">IV</asp:ListItem>
                                            <asp:ListItem Value="5">V</asp:ListItem>
                                        </asp:DropDownList></label></div>
                                    <div class="medium-2 large-2 columns"><label id="lbSerie" runat="server">Serie:
                                        <asp:DropDownList ID="ddlSerie" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0">Elige Serie</asp:ListItem>
                                            <asp:ListItem Value="SIN SERIE">Sin serie</asp:ListItem>
                                            <asp:ListItem Value="A">A</asp:ListItem>
                                            <asp:ListItem Value="B">B</asp:ListItem>
                                            <asp:ListItem Value="C">C</asp:ListItem>
                                        </asp:DropDownList></label></div>
                                    <div class="medium-2 large-2 columns "><label>Partida:<asp:TextBox ID="txPartida" runat="server" pattern="[0-9]+" MaxLength="50"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                    <div class="medium-2 large-2 columns end">
                                        <label>Folio:<asp:TextBox runat="server" ID="txFolioA" MaxLength="50" ></asp:TextBox></label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="medium-1 large-1 columns end"><asp:Button runat="server" ID="btAgregarAntecedente" Cssclass="button tiny radius mas" Text="+" OnClick="btAgregarAntecedente_Click" /></div>
                                    <div class="medium-11 large-11 columns">
                                        <asp:GridView runat="server" ID="gvAntecedentes" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="Id"
                                                OnRowDeleting="gvAntecedentes_RowDeleting" >
                                            <Columns>
                                                <asp:CommandField ShowDeleteButton="true" HeaderText="Eliminar" />
                                                <asp:BoundField DataField="Id" ReadOnly="true" HeaderText="Id" ShowHeader="true" Visible="false" />
                                                <asp:BoundField DataField="Folio" ReadOnly="true" HeaderText="Folio" ShowHeader="true"  />
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
                            </fieldset>
                            <fieldset>
                                <legend>Movimientos</legend>
                                <div class="row">
                                    <div class="medium-5 large-5 columns"><label>Acto:
                                        <asp:DropDownList ID="ddlActos" runat="server" OnSelectedIndexChanged="ddlActos_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"><asp:ListItem Value="0">Listado de Actos</asp:ListItem></asp:DropDownList>
                                    </label></div>
                                    <div class="medium-5 large-5 columns"><label>Movimiento:
                                        <asp:DropDownList ID="ddlMovimientos" runat="server" AppendDataBoundItems="true"><asp:ListItem Value="0">Listado de Movimientos</asp:ListItem></asp:DropDownList>
                                    </label> </div>
                                    <div class="medium-2 large-2 columns"><label>Valor Base:<asp:TextBox ID="txValorBase" runat="server" Text="0.00" required pattern="[0-9]+(\.[0-9][0-9]?)?" ></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                    <div class="medium-2 large-2 columns"><label>Repetir Acto:<asp:TextBox ID="txRepetir" runat="server" Text="1" pattern="[0-9]?[0-9]" ></asp:TextBox></label></div>
                                </div>
                                <div class="row">
                                    <div class="medium-1 large-1 columns end"><asp:Button runat="server" ID="btAgregarMovimiento" Cssclass="button tiny radius mas" Text="+" OnClick="btAgregarMovimiento_Click" ></asp:Button></div>
                                    <div class="medium-11 large-11 columns">
                                        <asp:GridView runat="server" ID="gvMovimientos" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="Id"
                                             OnRowDeleting="gvMovimientos_RowDeleting" >
                                            <Columns>
                                                <asp:CommandField ShowDeleteButton="true" HeaderText="Eliminar" />
                                                <asp:BoundField DataField="Id" ReadOnly="true" HeaderText="Id" ShowHeader="true" Visible="false" />
                                                <asp:BoundField DataField="Acto" ReadOnly="true" HeaderText="Acto" ShowHeader="true" Visible="false" />
                                                <asp:BoundField DataField="Movimiento" ReadOnly="true" HeaderText="Movimiento" ShowHeader="true" Visible="false" />
                                                <asp:BoundField DataField="Descripcion" ReadOnly="true" HeaderText="Descripcion" ShowHeader="true" ItemStyle-Width="500px" />
                                                <asp:BoundField DataField="ValorBase" ReadOnly="true" HeaderText="ValorBase" ShowHeader="true" />
                                                <asp:BoundField DataField="Cantidad" ReadOnly="true" HeaderText="Cantidad" ShowHeader="true" />
                                                <asp:BoundField DataField="Descuento" ReadOnly="true" HeaderText="Descuento" ShowHeader="true" />
                                                <asp:BoundField DataField="Subtotal" ReadOnly="true" HeaderText="Subtotal" ShowHeader="true" ItemStyle-Width="200px" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="medium-6 large-6 columns" ><br /></div>
                                    <div class="medium-3 large-3 columns"><label>Tipo de Moneda:<asp:TextBox runat="server" ID="txMoneda" Text="Pesos" MaxLength="50"></asp:TextBox></label></div>
                                    <div class="medium-3 large-3 columns"><label>Total:<asp:TextBox ID="txTotal" runat="server" Enabled="false" Text="$0.00"></asp:TextBox></label></div>
                                </div>
                            </fieldset>
                            <div class="row">
                                <div class="medium-4 large-4 columns"> <asp:Button runat="server" CssClass="button" ID="btGuardarTramite" Text="Guardar Trámite" OnClick="btGuardarTramite_Click"/></div>
                                <div class="medium-4 large-4 columns"><a href="Recepcion.aspx" class="button">Cancelar Tramite</a></div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers><asp:PostBackTrigger ControlID="btGuardarTramite" /></Triggers>
                </asp:UpdatePanel>
            </section>


            <section role="tabpanel" aria-hidden="true" class="content" id="panel-4">
                <h2>Búsqueda de Prelación</h2>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <fieldset>
                            <legend>Número de Prelación</legend>
                            <div class="row">
                                <div class="medium-3 large-3 columns"><label>Número de prelación:<asp:TextBox ID="txBuscarPrelacion" runat="server" style="text-align:center" Font-Bold="true" ></asp:TextBox></label></div>
                            </div>
                            <div class="row">
                                <div class="medium-9 large-9 columns" ><br /></div>
                                <div class="medium-3 large-3 columns"><asp:Button ID="Button5" runat="server" Text="Buscar" CssClass="button" OnClick="Button5_Click"/></div>
                            </div>
                        </fieldset>


                        <div data-abide >
                            <fieldset>
                                <legend>Datos de la Solicitud</legend>
                                <div class="row">
                                    <div class="medium-3 large-3 columns"><label>Fecha:<asp:TextBox ID="txBFecha" runat="server" Enabled="false" style="text-align:center" Font-Bold="true"></asp:TextBox></label></div>
                                    <div class="medium-4 large-4 columns"><label>Folio de Propiedad:<asp:TextBox ID="txBFolio" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="medium-8 large-8 columns"><label>Tramitante:
                                                <asp:DropDownList ID="ddlBTramitante" runat="server" AppendDataBoundItems="true" ><asp:ListItem Value>Listado de Tramitantes</asp:ListItem></asp:DropDownList></label></div>
                                        </div>                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="row">
                                    <div class="medium-8 large-8 columns"><label>Nuevo Titular:<asp:TextBox ID="txBNuevoTitular" runat="server" MaxLength="150"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                </div>
                                <div class="row">
                                    <div class="medium-6 large-6 columns"><label>Escritura:<asp:TextBox id="txBEscritura" runat="server" MaxLength="50" ></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                    <div class="medium-6 large-6 columns"><label>Descripción del Bien:<asp:TextBox ID="txBDescripcion" runat="server" MaxLength="200"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                </div>
                                <div class="row">
                                    <div class="medium-3 large-3 columns"><label>Tipo Documento:<asp:TextBox runat="server" ID="txBTipoDocumento" MaxLength="100"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                    <div class="medium-3 large-3 columns"><label>Fecha Otorgamiento:<asp:TextBox runat="server" ID="txBFechaOtorgamiento" ></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                    <div class="medium-3 large-3 columns end"><label>Lugar Otorgamiento:<asp:TextBox runat="server" ID="txBLugarOtorgamiento" MaxLength="100"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                </div>
                            </fieldset>
                            <fieldset>
                                <legend>Antecedentes</legend>
                                <div class="row">
                                    <div class="medium-2 large-2 columns"><label>Libro/Tomo/Sem:
                                        <asp:DropDownList ID="ddlBLTS" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlLTS_SelectedIndexChanged">
                                            <asp:ListItem Value="Libro">Libro</asp:ListItem>
                                            <asp:ListItem Value="Tomo">Tomo</asp:ListItem>
                                            <asp:ListItem Value="Semestre">Semestre</asp:ListItem>
                                        </asp:DropDownList></label></div>
                                    <div class="medium-2 large-2 columns" style="padding-top:20px"> <asp:TextBox ID="txBLibro" runat="server"  pattern="[0-9]+" MaxLength="50"> </asp:TextBox><small class="error">Campo Requerido.</small>
                                        <asp:DropDownList ID="ddlBSemestre" runat="server" AppendDataBoundItems="true" Visible="false" >
                                            <asp:ListItem Value>Elige Semestre</asp:ListItem>
                                            <asp:ListItem Value="1">Primer</asp:ListItem>
                                            <asp:ListItem Value="2">Segundo</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="medium-2 large-2 columns"><label id="Label1" runat="server" visible="false">Año Semestre:<asp:TextBox ID="txBASem" runat="server" Visible="false"  pattern="[0-9]+" MaxLength="50"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                    <div class="medium-2 large-2 columns"><label id="Label2" runat="server">Seccion:
                                        <asp:DropDownList ID="ddlBSeccion" runat="server" AppendDataBoundItems="true" >
                                            <asp:ListItem Value>Elige Seccion</asp:ListItem>
                                            <asp:ListItem Value="1">I</asp:ListItem>
                                            <asp:ListItem Value="2">II</asp:ListItem>
                                            <asp:ListItem Value="3">III</asp:ListItem>
                                            <asp:ListItem Value="4">IV</asp:ListItem>
                                            <asp:ListItem Value="5">V</asp:ListItem>
                                        </asp:DropDownList></label></div>
                                    <div class="medium-2 large-2 columns"><label id="Label3" runat="server">Serie:
                                        <asp:DropDownList ID="ddlBSerie" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0">Elige Serie</asp:ListItem>
                                            <asp:ListItem Value="SIN SERIE">Sin serie</asp:ListItem>
                                            <asp:ListItem Value="A">A</asp:ListItem>
                                            <asp:ListItem Value="B">B</asp:ListItem>
                                            <asp:ListItem Value="C">C</asp:ListItem>
                                        </asp:DropDownList></label></div>
                                    <div class="medium-2 large-2 columns "><label>Partida:<asp:TextBox ID="txBPartida" runat="server" pattern="[0-9]+" MaxLength="50"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                    <div class="medium-2 large-2 columns end">
                                        <label>Folio:<asp:TextBox runat="server" ID="txBFolioA" MaxLength="50" ></asp:TextBox></label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="medium-1 large-1 columns end"><asp:Button runat="server" ID="Button2" Cssclass="button tiny radius mas" Text="+" OnClick="Button2_Click" /></div>
                                    <div class="medium-11 large-11 columns">
                                        <asp:GridView runat="server" ID="gvBAntecedentes" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="Id"
                                               OnRowDeleting="gvBAntecedentes_RowDeleting" >
                                            <Columns>
                                                <asp:CommandField ShowDeleteButton="true" HeaderText="Eliminar" />
                                                <asp:BoundField DataField="Id" ReadOnly="true" HeaderText="Id" ShowHeader="true" Visible="false" />
                                                <asp:BoundField DataField="Folio" ReadOnly="true" HeaderText="Folio" ShowHeader="true"  />
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
                            </fieldset>                            
                            <div class="row">
                                <div class="medium-4 large-4 columns"> <asp:Button runat="server" CssClass="button" ID="Button4" Text="Guardar Trámite" OnClick="Button4_Click" CausesValidation="False" /></div>
                                <div class="medium-4 large-4 columns"> <asp:Button runat="server" CssClass="button" ID="Button1" Text="Cancelar Trámite" OnClick="Button1_Click" CausesValidation="False" /></div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers><asp:PostBackTrigger ControlID="btGuardarTramite" /></Triggers>
                    <Triggers><asp:PostBackTrigger ControlID="Button4" /></Triggers>
                    <Triggers><asp:PostBackTrigger ControlID="Button1" /></Triggers>
                </asp:UpdatePanel>
            </section>



        </div>
    </div>
    <script>
        $(document).foundation();
    </script>
</asp:Content>
