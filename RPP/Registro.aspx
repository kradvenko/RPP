<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="RPP.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" />
    <div class="center800">
        <ul class="tabs" data-tab role="tablist">
          <li class="tab-title menu active" role="presentational"><a href="#panel-1" role="tab" tabindex="0" aria-selected="true" controls="panel-1">Inicio</a></li>
          <li class="tab-title menu" role="presentational"><a href="#panel-2" role="tab" tabindex="0" aria-selected="false" controls="panel-2">Perfil Usuario</a></li>
          <li class="tab-title menu" role="presentational"><a href="#panel-3" role="tab" tabindex="0" aria-selected="false" controls="panel-3">Registrar Prelación</a></li>
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
                <h2>Registro de Prelaciones</h2>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="medium-6 large-6 columns prel">
                                <fieldset>
                                    <legend>Sin Registrar</legend>
                                    <div class="scroll registro">
                                        <asp:RadioButtonList ID="rbSinRegistrar" runat="server" CssClass="lista" OnSelectedIndexChanged="rbl_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:RadioButtonList>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="medium-6 large-6 columns prel">
                                <fieldset>
                                    <legend>Con Observaciones</legend>
                                    <div class="scroll registro">
                                        <asp:RadioButtonList ID="rbObservaciones" runat="server" CssClass="lista" OnSelectedIndexChanged="rbl_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:RadioButtonList>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <fieldset runat="server" id="fsObservaciones" visible="false">
                            <legend>Observaciones de Verificador</legend>
                            <textarea runat="server" id="txObservaciones"></textarea>
                        </fieldset>
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
                                    <asp:GridView runat="server" ID="gvAntecedentes" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                        <Columns>
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
                                <div class="medium-8 large-8 columns ">
                                    <asp:ListBox ID="lbMovimientos" runat="server" CssClass="lista" Height="100px"></asp:ListBox>
                                </div>
                                <div class="medium-2 large-2 columns end ">
                                    <asp:Button runat="server" CssClass="button" Text="Registrar "   OnClick="Unnamed_Click"/>
                                </div>
                            </div>
                        </fieldset>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>
        </div>
    </div>
    <script>
        $(document).foundation();
    </script>
</asp:Content>
