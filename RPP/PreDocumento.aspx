<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PreDocumento.aspx.cs" Inherits="RPP.PreDocumento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <div class="center800">
            <div class="center">
                <fieldset>
                    <legend>Resultado de búsqueda de documentos digitalizados</legend>
                    <div class="row">
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
                                        <asp:BoundField DataField="Tramitante" ReadOnly="true" HeaderText="Tramitante" ShowHeader="true"  />
                                        <asp:BoundField DataField="RepositoryUrl" ReadOnly="true" HeaderText="URL" ShowHeader="true"  />
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                                </div>
                        </div>
                    </div>
                </fieldset>
            </div>            
        </div>
</asp:Content>
