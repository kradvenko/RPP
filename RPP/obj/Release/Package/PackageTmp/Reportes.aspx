<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="RPP.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" />
        <div class="center800">
        <ul class="tabs" data-tab role="tablist">
          <li class="tab-title menu active" role="presentational"><a href="#panel-1" role="tab" tabindex="0" aria-selected="true" controls="panel-1">Inicio</a></li>
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
                <h2>Reportes</h2>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="center">
                            <fieldset>
                                <legend>Tipos de reportes</legend>
                                <div class="row">                                    
                                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="Tramites ingresados" OnClick="Button1_Click" />
                                    <asp:Button ID="Button2" runat="server" CssClass="button" Text="Tramites entregados" OnClick="Button2_Click" />
                                    <asp:Button ID="Button3" runat="server" CssClass="button" Text="Tramites por acto" OnClick="Button3_Click" />                                    
                                </div>                                
                            </fieldset>
                            <fieldset>
                                <div class="row">
                                    <asp:DropDownList ID="ddlActos" runat="server"></asp:DropDownList>
                                </div>
                            </fieldset>
                            <div class="row">
                                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                </div>
                            <fieldset>
                                <legend>Resultados</legend>
                                <div class="row">
                                    <div class="medium-6 large-6 columns">
                                        <asp:GridView runat="server" ID="gvResultados" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                                                <asp:BoundField DataField="IdPrelacion" ReadOnly="true" HeaderText="Id de prelación" ShowHeader="true"  />
                                                <asp:BoundField DataField="Fecha" ReadOnly="true" HeaderText="Fecha" ShowHeader="true"  />
                                                <asp:BoundField DataField="Tramitante" ReadOnly="true" HeaderText="Tramitante" ShowHeader="true"  />
                                                <asp:BoundField DataField="NombreTitular" ReadOnly="true" HeaderText="Titular" ShowHeader="true"  />
                                                <asp:BoundField DataField="NombreRecibe" ReadOnly="true" HeaderText="Recibe" ShowHeader="true"  />
                                            </Columns>
                                        </asp:GridView>
                                     </div>
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
