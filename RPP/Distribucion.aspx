<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Distribucion.aspx.cs" Inherits="RPP.Distribucion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" />
    <div class="center800">
        <ul class="tabs" data-tab role="tablist">
          <li class="tab-title menu active" role="presentational"><a href="#panel-1" role="tab" tabindex="0" aria-selected="true" controls="panel-1">Inicio</a></li>
          <li class="tab-title menu" role="presentational"><a href="#panel-2" role="tab" tabindex="0" aria-selected="false" controls="panel-2">Perfil Usuario</a></li>
          <li class="tab-title menu" role="presentational"><a href="#panel-3" role="tab" tabindex="0" aria-selected="false" controls="panel-3">Asignar Prelación</a></li>
            <li class="tab-title menu" role="presentational"><a href="#panel-4" role="tab" tabindex="0" aria-selected="false" controls="panel-4">Reportes</a></li>
        </ul>
        <ul class="tabs distribucion">
            <li class="tab-title" ><a href="Recepcion.aspx" tabindex="0" aria-selected="false">Recepción</a></li>
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
                <h2>Asignación de Cargas de Trabajo</h2>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <fieldset>
                            <legend>Sin Asignar</legend>
                            <div class="row">
                                <div class="medium-8 large-8 columns lista">
                                    <label runat="server" id="lblContador"></label>
                                    <label>Prelaciones
                                        <div class="scroll">
                                            <asp:CheckBoxList ID="cbSinAsignar" runat="server" CssClass="lista" OnSelectedIndexChanged="cbSinAsignar_SelectedIndexChanged">
                                            </asp:CheckBoxList>
                                        </div>
                                    </label>
                                </div>
                                <div class="medium-4 large-4 columns lista">
                                    <label>Asignar a:
                                        <div class="scroll users">
                                            <asp:RadioButtonList ID="rbUsuarios" runat="server" RepeatColumns="1" RepeatDirection="Vertical" CssClass="lista" >
                                            </asp:RadioButtonList>
                                        </div>
                                    </label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="medium-9 large-9 columns" ><br /></div>
                                <div class="medium-3 large-3 columns"><asp:Button ID="btAsignar" runat="server" Text="Asignar" CssClass="button" OnClick="btAsignar_Click"/></div>
                            </div>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <fieldset>
                            <legend>Asignadas</legend>
                            <div class="row">
                                <div class="medium-7 large-7 columns">
                                    <label>Usuario:
                                    <asp:DropDownList ID="ddlUsuarios" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUsuarios_SelectedIndexChanged"></asp:DropDownList>
                                    </label>
                                </div>
                            </div>
                            <div class="row">
                                <asp:Button ID="Button3" runat="server" Text="Cargar prelaciones" OnClick="Button3_Click" CssClass="button" />
                            </div>
                            <div class="row">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        Cargando prelaciones...
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imgs/loader3.gif" Height="100px" Width="100px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <div class="row">
                                <div class="medium-8 large-8 columns lista">
                                    <label>Prelaciones
                                        <div class="scroll">
                                            <asp:CheckBoxList ID="cbAsignadas" runat="server" CssClass="lista">
                                            </asp:CheckBoxList>
                                        </div>
                                    </label>
                                </div>
                                <div class="medium-4 large-4 columns lista">
                                    <label>Asignar a:
                                        <div class="scroll users">
                                            <asp:RadioButtonList ID="rbUsuarios2" runat="server" RepeatColumns="1" RepeatDirection="Vertical" CssClass="lista">
                                            </asp:RadioButtonList>
                                        </div>
                                    </label>
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="medium-9 large-9 columns" ><br /></div>
                                <div class="medium-3 large-3 columns"><asp:Button ID="btCambios" runat="server" Text="Guardar Cambios" CssClass="button" OnClick="btCambios_Click"/></div>
                            </div>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                
                
            </section>

            <section role="tabpanel" aria-hidden="true" class="content" id="panel-4">
                <h2>Reportes</h2>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <fieldset>
                            <legend>Asignados</legend>
                            <div class="row">
                                <div class="medium-3 large-3 columns"><label>Fecha Inicio:<asp:TextBox ID="txFechaInicio" runat="server" style="text-align:center" Font-Bold="true" ></asp:TextBox></label></div>
                                <div class="medium-3 large-3 columns"><label>Fecha Fin:<asp:TextBox ID="txFechaFin" runat="server" style="text-align:center" Font-Bold="true" ></asp:TextBox></label></div>
                            </div>
                            <div class="row">
                                <div class="medium-9 large-9 columns" ><br /></div>
                                <div class="medium-3 large-3 columns"><asp:Button ID="Button1" runat="server" Text="Generar" CssClass="button" OnClick="Button1_Click"/></div>
                            </div>                           
                        </fieldset>

                        <fieldset>
                            <legend>Reimprimir Prelación</legend>
                            <div class="row">
                                <div class="medium-3 large-3 columns"><label>Número de prelación:<asp:TextBox ID="txReimprimir" runat="server" style="text-align:center" Font-Bold="true" ></asp:TextBox></label></div>
                            </div>
                            <div class="row">
                                <div class="medium-9 large-9 columns" ><br /></div>
                                <div class="medium-3 large-3 columns"><asp:Button ID="Button2" runat="server" Text="Imprimir" CssClass="button" OnClick="Button2_Click"/></div>
                            </div>
                        </fieldset>

                    </ContentTemplate>
                    <Triggers><asp:PostBackTrigger ControlID="Button1" /></Triggers>
                    <Triggers><asp:PostBackTrigger ControlID="Button2" /></Triggers>
                </asp:UpdatePanel>                
            </section>

        </div>
    </div>
    <script>
        $(document).foundation();
    </script>
</asp:Content>
