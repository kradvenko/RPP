<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Revision.aspx.cs" Inherits="RPP.Revision" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" />
        <div class="center800">
            <ul class="tabs" data-tab role="tablist">
                <li class="tab-title menu active" role="presentational"><a href="#panel-1" role="tab" tabindex="0" aria-selected="true" controls="panel-1">Inicio</a></li>
                <li class="tab-title menu" role="presentational"><a href="#panel-2" role="tab" tabindex="0" aria-selected="false" controls="panel-2">Perfil Usuario</a></li>
                <li class="tab-title menu" role="presentational"><a href="#panel-3" role="tab" tabindex="0" aria-selected="false" controls="panel-3">Revisar Prelación</a></li>
            </ul>
            <ul class="tabs consulta">
                <li class="tab-title" ><a href="Consulta.aspx" target="_blank" tabindex="0" aria-selected="false">Consulta</a></li>
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
                                        <div class="medium-4 large-4 columns"><label>Nombre:<asp:TextBox ID="txNombre" runat="server" ></asp:TextBox></label></div>
                                        <div class="medium-4 large-4 columns"><label>Apellido Paterno:<asp:TextBox ID="txAPaterno" runat="server" ></asp:TextBox></label></div>
                                        <div class="medium-4 large-4 columns"><label>Apellido Materno:<asp:TextBox ID="txAMaterno" runat="server" ></asp:TextBox></label></div>
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
                                        <div class="medium-4 large-4 columns"><label>Calle y Número:<asp:TextBox ID="txCalleU" runat="server"></asp:TextBox></label></div>
                                        <div class="medium-4 large-4 columns"><label>Colonia:<asp:TextBox ID="txColoniaU" runat="server"></asp:TextBox></label></div>
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
                    <asp:updatepanel runat="server">
                        <ContentTemplate>
                            <div class="center">
                                <fieldset>
                                    <legend>Prelaciones por revisar</legend>
                                    <div class="row">
                                        <asp:GridView ID="gvPrelaciones" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPrelaciones_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="gvPrelaciones_PageIndexChanged" PageSize="10" OnPageIndexChanging="gvPrelaciones_PageIndexChanging">
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                            <SortedDescendingHeaderStyle BackColor="#820000" />
                                            <Columns>
                                                <asp:BoundField DataField="IdPrelacion" HeaderText="Prelación" />
                                                <asp:BoundField DataField="Folio" HeaderText="Folio" />
                                                <asp:BoundField DataField="NombreTitular" HeaderText="Titular" />
                                                <asp:BoundField DataField="DescripcionBien" HeaderText="Descripción bien" ItemStyle-Width="300" />
                                                <asp:CommandField ShowSelectButton="True" />
                                            </Columns>
                                        </asp:GridView>                          
                                    </div>
                                </fieldset>
                            </div>
                            <div class="center" data-abide>
                                <fieldset>
                                    <legend>Datos de Prelación</legend>
                                        <div class="row">
                                            <div class="medium-3 large-3 columns"><label>Fecha:<asp:Label runat="server" ID="lbFecha"></asp:Label></label></div>
                                            <div class="medium-4 large-4 columns"><label>Folio:<asp:Label runat="server" ID="lbFolio"></asp:Label></label></div>
                                            <div class="medium-5 large-5 columns"><label>Tramitante:<asp:Label runat="server" ID="lbTramitante"></asp:Label></label></div>
                                        </div><br />
                                        <div class="row">
                                            <div class="medium-3 large-3 columns"><label>Escritura:<asp:Label runat="server" ID="lbNumEscritura"></asp:Label></label></div>
                                            <div class="medium-4 large-4 columns"><label>Descripción del Bien:<asp:Label runat="server" ID="lbDescripcion"></asp:Label></label></div>
                                            <div class="medium-5 large-5 columns"><label>Nuevo Titular:<asp:Label runat="server" ID="lbTitular"></asp:Label></label></div>
                                
                                        </div><br />
                                        <div class="row">
                                            <div class="medium-6 large-6 columns">
                                                <label>Antecedentes:</label>
                                                <asp:GridView runat="server" ID="gvAntecedentes" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvAntecedentes_SelectedIndexChanged">
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
                                        </div>
                                </fieldset>
                            </div>
                            <div class="center" data-abide>
                                <fieldset>
                                    <legend>Movimientos</legend>
                                        <div class="row">
                                            <asp:GridView ID="gvMovimientos" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvMovimientos_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:BoundField DataField="Clave" ReadOnly="true" HeaderText="Clave" ShowHeader="true"  />
                                                    <asp:BoundField DataField="Nombre" ReadOnly="true" HeaderText="Movimiento" ShowHeader="true"  />
                                                    <asp:BoundField DataField="EstadoMovimiento" ReadOnly="true" HeaderText="Estado" ShowHeader="true"  />
                                                    <asp:BoundField DataField="Importe" ReadOnly="true" HeaderText="Importe" ShowHeader="true"  />
                                                    <asp:CommandField ShowSelectButton="True" />
                                                </Columns>
                                            </asp:GridView>
                                        </div><br />
                                </fieldset>
                                <div class="row">
                                    <div class="medium-6 large-6 columns">
                                        <fieldset>
                                            <legend>Otorgantes</legend>
                                            <div class="row">
                                                    <asp:GridView ID="gvOtorgantes" runat="server" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="Nombre" ReadOnly="true" HeaderText="Nombre" ShowHeader="true"  />
                                                            <asp:BoundField DataField="Paterno" ReadOnly="true" HeaderText="Apellido Paterno" ShowHeader="true"  />
                                                            <asp:BoundField DataField="Materno" ReadOnly="true" HeaderText="Apellido Materno" ShowHeader="true"  />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div><br />
                                        </fieldset>
                                    </div>
                                    <div class="medium-6 large-6 columns">
                                        <fieldset>
                                            <legend>Adquirientes</legend>
                                            <div class="row">
                                                    <asp:GridView ID="gvAdquirientes" runat="server" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="Nombre" ReadOnly="true" HeaderText="Nombre" ShowHeader="true"  />
                                                            <asp:BoundField DataField="Paterno" ReadOnly="true" HeaderText="Apellido Paterno" ShowHeader="true"  />
                                                            <asp:BoundField DataField="Materno" ReadOnly="true" HeaderText="Apellido Materno" ShowHeader="true"  />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div><br />
                                        </fieldset>
                                    </div>
                                </div>
                                <fieldset runat="server" id="datosI">
                                    <legend>Datos del Inmueble</legend>
                                    <div class="row">
                                        <div class="medium-3 large-3 columns"><label runat="server" id="tipopredio">Tipo de Predio:<asp:TextBox runat="server" ID="txTipoPredio"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                        <div class="medium-3 large-3 columns "><label runat="server" id="superficie">Superficie:<asp:TextBox runat="server" ID="txSuperficie"></asp:TextBox></label><small class="error">Campo Requerido.</small></div>
                                        <div class="medium-3 large-3 columns"><label runat="server" id="unidadsuperficie">Unidad Superficie:<asp:TextBox runat="server" ID="txUnidadSuperficie"></asp:TextBox></label></div>
                                        <div class="medium-3 large-3 columns end"><label runat="server" id="clavecatastral">Clave Catastral:<asp:TextBox runat="server" ID="txClaveCat"></asp:TextBox></label></div>
                                    </div>
                                </fieldset>
                                <fieldset>
                                    <legend>Ubicación del Inmuble</legend>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="medium-3 large-3 columns"><label>Municipio:<asp:TextBox runat="server" ID="txMunicipio" ></asp:TextBox></label></div>
                                                <div class="medium-3 large-3 columns"><label>Poblacion:<asp:TextBox runat="server" ID="txPoblacion" ></asp:TextBox></label></div>
                                                <div class="medium-3 large-3 columns">
                                                    <label runat="server" id="idcolonia" style="display:none">Colonia:
                                                        <a onclick="return colonia();">no encontrada</a>
                                
                                                    </label>
                                                    <label runat="server" id="texcolonia" >Colonia:
                                                        <asp:TextBox runat="server" ID="txColonia"></asp:TextBox>
                                                    </label>
                                                </div>
                                                <div class="medium-3 large-3 columns">
                                                    <label runat="server" id="idcalle" style="display:none">Calle:
                                                        <a onclick="return calle();">no encontrada</a>
                                
                                                    </label>
                                                    <label runat="server" id="texcalle">Calle:
                                                        <asp:TextBox runat="server" ID="txCalle"></asp:TextBox>
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="medium-3 large-3 columns ">
                                                    <label runat="server" id="idnumero" style="display:none">Numero:
                                                        <a onclick="return numero();">no encontrado</a>
                                                        <asp:DropDownList runat="server" ID="ddlNum"></asp:DropDownList>
                                                    </label>
                                                </div>
                                                <div class="medium-3 large-3 columns "><label runat="server" id="numinterior">Numero Int:<asp:TextBox runat="server" ID="txInterior"></asp:TextBox></label></div>
                                                <div class="medium-3 large-3 columns "><label runat="server" id="numexterior">Numero Ext:<asp:TextBox runat="server" ID="txExterior"></asp:TextBox></label></div>
                                                <div class="medium-3 large-3 columns "><label runat="server" id="manzana">Manzana:<asp:TextBox runat="server" ID="txManzana"></asp:TextBox></label></div>
                                                <div class="medium-3 large-3 columns end"><label runat="server" id="lote">Lote:<asp:TextBox runat="server" ID="txLote"></asp:TextBox></label></div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </fieldset>
                                <fieldset runat="server" id="descripcion">
                                    <legend>Descripcion del Inmueble</legend>
                                    <div>
                                        <label>Colindancias:</label>
                                        <div class="row"><div class="medium-12 large-12 columns"><label>Norte:<asp:TextBox runat="server" ID="txNorte"></asp:TextBox></label></div></div>
                                        <div class="row"><div class="medium-12 large-12 columns"><label>Sur:<asp:TextBox runat="server" ID="txSur"></asp:TextBox></label></div></div>
                                        <div class="row"><div class="medium-12 large-12 columns"><label>Este:<asp:TextBox runat="server" ID="txEste"></asp:TextBox></label></div></div>
                                        <div class="row"><div class="medium-12 large-12 columns"><label>Oeste:<asp:TextBox runat="server" ID="txOeste"></asp:TextBox></label></div></div>
                                        <div class="row"><div class="medium-12 large-12 columns"><label>Noreste:<asp:TextBox runat="server" ID="txNoreste"></asp:TextBox></label></div></div>
                                        <div class="row"><div class="medium-12 large-12 columns"><label>Noroeste:<asp:TextBox runat="server" ID="txNoroeste"></asp:TextBox></label></div></div>
                                        <div class="row"><div class="medium-12 large-12 columns"><label>Sureste:<asp:TextBox runat="server" ID="txSureste"></asp:TextBox></label></div></div>
                                        <div class="row"><div class="medium-12 large-12 columns"><label>Suroeste:<asp:TextBox runat="server" ID="txSuroeste"></asp:TextBox></label></div></div>
                                    </div>
                                </fieldset>
                            </div>
                            <fieldset>
                                <legend>Registro Actual</legend>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="medium-2 large-2 columns"><label>Libro:<asp:TextBox runat="server" ID="txLibroR" MaxLength="50"></asp:TextBox></label></div>
                                            <div class="medium-2 large-2 columns"><label id="lbSeccionR" runat="server">Seccion:
                                                <asp:TextBox ID="txSeccionR" runat="server"></asp:TextBox>
                                                </label></div>
                                            <div class="medium-2 large-2 columns"><label id="lbSerie" runat="server">Serie:
                                                <asp:TextBox ID="txSerieR" runat="server"></asp:TextBox>
                                                </label></div>
                                            <div class="medium-2 large-2 columns end "><label>Partida:<asp:TextBox ID="txPartidaR" runat="server" MaxLength="50"></asp:TextBox></label></div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </fieldset>
                            <fieldset runat="server" id="anotaciones">
                        <legend>Anotaciones Marginales</legend>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                    <div class="row">
                                        <asp:GridView ID="gvAnotacionesMarginales" runat="server"></asp:GridView>
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </fieldset>
                            <fieldset>
                                <legend>Observaciones</legend>
                                <div class="row"><div class="medium-12 large-12 columns"><label>Observaciones:<asp:TextBox runat="server" ID="txObservaciones"></asp:TextBox></label></div></div>
                            </fieldset>
                            <div class="row">
                                <div class="medium-4 large-4 columns"><asp:Button runat="server" CssClass="button" ID="btGuardarRegistro" Text="Enviar a entrega" OnClick="btGuardarRegistro_Click" /></div>
                                <div class="medium-4 large-4 columns"><asp:Button runat="server" CssClass="button" ID="btRechazar" Text="Regresar a registro" OnClick="btRechazar_Click" /></div>
                            </div>
                        </ContentTemplate>
                    </asp:updatepanel>
                </section>
            </div>
        </div>
    <script>
        $(document).foundation();
    </script>
</asp:Content>
