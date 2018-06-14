<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Entrega.aspx.cs" Inherits="RPP.Entrega" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" />
    <div class="center800">
        <ul class="tabs" data-tab role="tablist">
          <li class="tab-title menu active" role="presentational"><a href="#panel-1" role="tab" tabindex="0" aria-selected="true" controls="panel-1">Inicio</a></li>
          <li class="tab-title menu" role="presentational"><a href="#panel-2" role="tab" tabindex="0" aria-selected="false" controls="panel-2">Perfil Usuario</a></li>
          <li class="tab-title menu" role="presentational"><a href="#panel-3" role="tab" tabindex="0" aria-selected="false" controls="panel-3">Entregar Prelación</a></li>
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
                <div data-abide>H
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
                <h2>Entrega de Prelaciones</h2>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="center">
                            <fieldset>
                                <legend>Prelaciones por entregar</legend>
                                <asp:TextBox ID="txbFiltroEntrega" runat="server" AutoPostBack="True" OnTextChanged="txbFiltroEntrega_TextChanged"></asp:TextBox>
                                <div class="row">
                                    <asp:GridView ID="gvPrelaciones" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPrelaciones_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="5" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                        <SortedDescendingHeaderStyle BackColor="#820000" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="IdPrelacion" HeaderText="Prelación" />
                                            <asp:BoundField DataField="Folio" HeaderText="Folio" />
                                            <asp:BoundField DataField="NombreTitular" HeaderText="Titular" />
                                            <asp:BoundField DataField="DescripcionBien" HeaderText="Descripción bien" />
                                            <asp:BoundField DataField="Usuario" HeaderText="Registrador" />
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </fieldset>
                            <fieldset>
                                <legend>Lista de prelaciones que se van a entregar</legend>
                                <div class="row">
                                    <asp:GridView ID="gvEntrega" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvEntrega_SelectedIndexChanged" >
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="IdPrelacion" HeaderText="Prelación" />
                                            <asp:BoundField DataField="Folio" HeaderText="Folio" />
                                            <asp:BoundField DataField="NombreTitular" HeaderText="Titular" />
                                            <asp:BoundField DataField="DescripcionBien" HeaderText="Descripción bien" />
                                            <asp:BoundField DataField="Usuario" HeaderText="Registrador" />                                            
                                            <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
                                            
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </fieldset>
                            <fieldset>
                                <legend>Información de persona que recoge la prelación</legend>
                                <div class="row">
                                    <div class="medium-6 large-6 columns "><label>Nombre:<asp:TextBox runat="server" ID="txNombreRecibe" Enabled="true" MaxLength="150"></asp:TextBox></label></div>
                                    <div class="medium-3 large-3 columns "><label>Tipo identificación:<asp:DropDownList ID="ddlTipoIdentificacion" runat="server">
                                        <asp:ListItem>Credencial</asp:ListItem>
                                        <asp:ListItem>Licencia</asp:ListItem>
                                        <asp:ListItem>Pasaporte</asp:ListItem>
                                        </asp:DropDownList></label></div>
                                    <div class="medium-3 large-3 columns "><label>Clave identificación:<asp:TextBox runat="server" ID="txClave" Enabled="true" MaxLength="50"></asp:TextBox></label></div>
                                </div>
                            </fieldset>
                            <div class="row">
                                <div class="medium-12 large-12 columns"><asp:Button runat="server" CssClass="button" ID="btGuardarRegistro" Text="Entregar" OnClick="btGuardarRegistro_Click" /></div>                    
                            </div>
                        </div>
                        
                    </ContentTemplate>
                    <Triggers><asp:PostBackTrigger ControlID="btGuardarRegistro" /></Triggers>
                </asp:UpdatePanel>
            </section>
        </div>
    </div>
    <script>
        $(document).foundation();
    </script>
</asp:Content>
