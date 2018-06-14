<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="RPP.Consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" />
        <div class="center800">
        <ul class="tabs" data-tab role="tablist">
          <li class="tab-title menu active" role="presentational"><a href="#panel-1" role="tab" tabindex="0" aria-selected="true" controls="panel-1">Inicio</a></li>
          <li class="tab-title menu" role="presentational"><a href="#panel-2" role="tab" tabindex="0" aria-selected="false" controls="panel-2">Perfil Usuario</a></li>
          <li class="tab-title menu" role="presentational"><a href="#panel-3" role="tab" tabindex="0" aria-selected="false" controls="panel-3">Búsqueda</a></li>
        </ul>
        <ul class="tabs salir">
            <li class="tab-title" ><a href="Login.aspx" tabindex="0" aria-selected="false">Salir</a></li>
        </ul>
        <div class="tabs-content">
            <section role="tabpanel" aria-hidden="false" class="content active" id="panel-1">
                <asp:Image runat="server" Width="400" ImageUrl="~/Imgs/RPP.jpg"/>                
            </section>
            
            <section role="tabpanel" aria-hidden="true" class="content" id="panel-3">
                <h2>Búsqueda de documentos</h2>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="center">
                            <fieldset>
                                <legend>Parámetros de búsqueda</legend>
                                <div class="row">
                                    <div class="medium-6 large-6 columns "><label>Libro:<asp:TextBox runat="server" ID="txLibro" Enabled="true" MaxLength="150"></asp:TextBox></label></div>
                                    <div class="medium-6 large-6 columns "><label>Tomo:<asp:TextBox runat="server" ID="txTomo" Enabled="true" MaxLength="150"></asp:TextBox></label></div>
                                    <div class="medium-6 large-6 columns "><label>Serie:<asp:TextBox runat="server" ID="txSerie" Enabled="true" MaxLength="150"></asp:TextBox></label></div>
                                    <div class="medium-6 large-6 columns "><label>Sección:<asp:TextBox runat="server" ID="txSeccion" Enabled="true" MaxLength="150"></asp:TextBox></label></div>
                                    <div class="medium-6 large-6 columns "><label>Semestre:<asp:TextBox runat="server" ID="txSemestre" Enabled="true" MaxLength="150"></asp:TextBox></label></div>
                                    <div class="medium-6 large-6 columns "><label>Año:<asp:TextBox runat="server" ID="txAnio" Enabled="true" MaxLength="150"></asp:TextBox></label></div>
                                    <div class="medium-6 large-6 columns "><label>Partida:<asp:TextBox runat="server" ID="txPartida" Enabled="true" MaxLength="150"></asp:TextBox></label></div>
                                </div>
                            </fieldset>
                            <fieldset>
                                <div class="medium-4 large-4 columns">
                                    <asp:Button runat="server" CssClass="button" ID="btGuardarRegistro" Text="Buscar" OnClick="btGuardarRegistro_Click" />
                                </div> 
                            </fieldset>
                            <div class="row">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        Cargando resultados...
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imgs/loader3.gif" Height="100px" Width="100px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <fieldset>
                                <legend>Resultados</legend>
                                <div class="row">
                                    <div class="medium-6 large-6 columns">
                                        <asp:GridView runat="server" ID="gvResultados" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvAntecedentes_SelectedIndexChanged">
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
                                                <asp:BoundField DataField="IdPrelacion" ReadOnly="true" HeaderText="ID Repositorio" ShowHeader="true"  />
                                                <asp:BoundField DataField="Tramitante" ReadOnly="true" HeaderText="Tramitante" ShowHeader="true"  />
                                                <asp:BoundField DataField="NumeroDocumento" ReadOnly="true" HeaderText="Número de documento" ShowHeader="true"  />
                                                <asp:BoundField DataField="Partida" ReadOnly="true" HeaderText="Partida" ShowHeader="true"  />
                                                <asp:BoundField DataField="RepositoryUrl" ReadOnly="true" HeaderText="URL" ShowHeader="true"  />
                                                <asp:CommandField ShowSelectButton="True" />
                                            </Columns>
                                        </asp:GridView>
                                     </div>
                                </div>
                                <div class="row" id="divResultado">
                                    <asp:Label ID="lblResultado" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="row">
                                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                </div>
                            </fieldset>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>
        </div>
    </div>
    <script>
        $(document).foundation();
    </script>
</asp:Content>
