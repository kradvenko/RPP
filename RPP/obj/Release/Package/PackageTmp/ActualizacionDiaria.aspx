<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ActualizacionDiaria.aspx.cs" Inherits="RPP.ActualizacionDiaria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <div class="center800">
            <div class="center">
                <fieldset>
                    <legend>Búsqueda por folio del sistema</legend>
                    <div class="row">
                        <asp:TextBox ID="txFolio" runat="server"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:Button ID="Button1" runat="server" CssClass="button" Text="Buscar" OnClick="Button1_Click" />
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Búsqueda por número de documento histórico</legend>
                    <div class="row">
                        <asp:TextBox ID="txNumeroDocumento" runat="server"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:Button ID="Button5" runat="server" CssClass="button" Text="Buscar" OnClick="Button5_Click" />
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Antecedentes encontrados</legend>
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
                </fieldset>
                <fieldset>
                    <legend>Resultado de búsqueda de documentos digitalizados</legend>
                    <div class="row">
                        <div class="row">
                            <div class="medium-6 large-6 columns">
                                <asp:GridView runat="server" ID="gvResultados" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvResultados_SelectedIndexChanged">
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
                                        <asp:BoundField DataField="RepositoryUrl" ReadOnly="true" HeaderText="URL" ShowHeader="true"  />
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                                </div>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Elija la imagen</legend>
                    <div class="row">
                        <asp:FileUpload ID="fuImagen" runat="server" />
                    </div>
                    <div class="row">
                        <asp:Button ID="Button3" runat="server" CssClass="button" Text="Ver imagen" OnClick="Button3_Click"  />
                    </div>
                    <div class="row">
                        <asp:Image ID="imgFileUpload" runat="server" />
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Elija una acción</legend>
                    <div class="row">
                        <asp:RadioButtonList ID="rblAccion" runat="server" CssClass="opposite">
                            <asp:ListItem Selected="True" Value="1">Actualizar última hoja</asp:ListItem>
                            <asp:ListItem Value="2">Agregar última hoja</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Verifique que la actualización de la imagen es correcta</legend>
                    <div class="row">
                        <asp:Button ID="Button2" runat="server" CssClass="button" Text="Verificar" OnClick="Button2_Click" />
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Si la imagen creada no contienen errores. envíe la actualización al repositorio</legend>
                    <div class="row">
                        <asp:Button ID="Button4" runat="server" CssClass="button" Text="Enviar" OnClick="Button4_Click" />
                    </div>
                </fieldset>
            </div>            
        </div>
</asp:Content>
