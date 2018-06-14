<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Catalogos.aspx.cs" Inherits="RPP.Catalogos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" />
    <div class="center800">
        <ul class="tabs cat" data-tab role="tablist">
          <li class="tab-title active" role="presentational" ><a href="#panel2-1" role="tab" tabindex="0" aria-selected="true" controls="panel2-1">Actos</a></li>
          <li class="tab-title" role="presentational" ><a href="#panel2-2" role="tab" tabindex="0"aria-selected="false" controls="panel2-2">Movimientos</a></li>
          <li class="tab-title" role="presentational"><a href="#panel2-3" role="tab" tabindex="0" aria-selected="false" controls="panel2-3">Tarifas</a></li>
          <li class="tab-title" role="presentational" ><a href="#panel2-4" role="tab" tabindex="0" aria-selected="false" controls="panel2-4">Areas Trabajo</a></li>
          <li class="tab-title" role="presentational" ><a href="#panel2-5" role="tab" tabindex="0" aria-selected="false" controls="panel2-5">Estatus</a></li>
          <li class="tab-title" role="presentational" ><a href="#panel2-6" role="tab" tabindex="0" aria-selected="false" controls="panel2-6">Tipos de folio</a></li>
          <li class="tab-title" role="presentational" ><a href="#panel2-7" role="tab" tabindex="0" aria-selected="false" controls="panel2-7">Tramitante</a></li>
          <li class="tab-title" role="presentational" ><a href="#panel2-8" role="tab" tabindex="0" aria-selected="false" controls="panel2-8">Usuarios</a></li>
          <li class="tab-title" role="presentational" ><a href="#panel2-9" role="tab" tabindex="0" aria-selected="false" controls="panel2-9">Municipio</a></li>
          <li class="tab-title" role="presentational" ><a href="#panel2-10" role="tab" tabindex="0" aria-selected="false" controls="panel2-10">Población</a></li>
          <li class="tab-title" role="presentational" ><a href="#panel2-11" role="tab" tabindex="0" aria-selected="false" controls="panel2-11">Secciones</a></li>
          <li class="tab-title" role="presentational" ><a href="#panel2-12" role="tab" tabindex="0" aria-selected="false" controls="panel2-12">Parametros</a></li>
        </ul>
        <ul class="tabs consulta">
            <li class="tab-title" ><a href="Reportes.aspx" target="_blank" tabindex="0" aria-selected="false">Reportes</a></li>
        </ul>
        <ul class="tabs consulta">
            <li class="tab-title" ><a href="Consulta.aspx" target="_blank" tabindex="0" aria-selected="false">Consulta</a></li>
        </ul>
        <ul class="tabs salir cat">
            <li class="tab-title" ><a href="Login.aspx" tabindex="0" aria-selected="false">Salir</a></li>
        </ul>
        <div class="tabs-content">
          <section role="tabpanel" aria-hidden="false" class="content active" id="panel2-1">
            <h2>Actos</h2>
              <asp:UpdatePanel runat="server">
                  <ContentTemplate>
                      <asp:GridView ID="gvActos" runat="server" AutoGenerateColumns="false" DataKeyNames="Clave" AllowPaging="true" PageSize="15" OnPageIndexChanging="gvActos_PageIndexChanging" ShowFooter="true"
                          OnRowCommand="gvActos_RowCommand" OnRowUpdating="gvActos_RowUpdating" OnRowCancelingEdit="RowCancelingEdit" OnRowEditing="RowEditing" OnDataBound="gvActos_DataBound" OnRowDataBound="gvActos_RowDataBound">
                          <Columns>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btEditar" runat="server" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btActualizar" runat="server" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                    <asp:LinkButton ID="btCancelar" runat="server" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btAgregar" runat="server" CommandName="AGREGAR" Text="Agregar"></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Clave" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbEditClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField  HeaderText = "Clave" ItemStyle-Width="60">
                                <ItemTemplate>
                                    <asp:Label ID="lbClaveActo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ClaveActo") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditClaveActo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ClaveActo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txClaveActo" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Cve Ingresos">
                                <ItemTemplate>
                                    <asp:Label ID="lbClaveIngresos" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ClaveIngresos") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditClaveIngresos" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ClaveIngresos") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txClaveIngresos" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Nombre de Acto" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lbNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txNombreActo" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Cuenta">
                                <ItemTemplate>
                                    <asp:Label ID="lbCuenta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Cuenta") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditCuenta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Cuenta") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txCuenta" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Area Trabajo">
                                <ItemTemplate>
                                    <asp:Label ID="lbArea" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Area") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="txEditArea" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "IdArea") %>' Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddlEditArea" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlEditArea" runat="server" AppendDataBoundItems="true"><asp:ListItem Value="0">Seleccione un Area de Trabajo </asp:ListItem></asp:DropDownList>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Seccion" ItemStyle-Width="145px">
                                <ItemTemplate>
                                    <asp:Label ID="lbSeccion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Seccion") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBoxList runat="server" ID="cblSeccion" Font-Size="Smaller"></asp:CheckBoxList>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                  </ContentTemplate>
              </asp:UpdatePanel>
          </section>
          <section role="tabpanel" aria-hidden="true" class="content" id="panel2-2">
            <h2>Movimientos</h2>
              <asp:UpdatePanel runat="server">
                  <ContentTemplate>
                    <div class="row">
                      <div class="medium-6 large-2 columns"><label for="ddlActos">Elige un Acto:</label></div>
                      <div class="medium-6 large-10 columns">
                          <asp:DropDownList ID="ddlActos" runat="server" OnSelectedIndexChanged="ddlActos_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"><asp:ListItem Value="0">Listado de Actos</asp:ListItem></asp:DropDownList></div>
                    </div>
                    <asp:GridView ShowHeaderWhenEmpty="true" ID="gvMovimientos" runat="server" AutoGenerateColumns="false" DataKeyNames="Clave" AllowPaging="true" OnPageIndexChanging="gvMovimientos_PageIndexChanging" PageSize="15" ShowFooter="true"
                        OnRowCommand="gvMovimientos_RowCommand" OnRowUpdating="gvMovimientos_RowUpdating" OnRowCancelingEdit="RowCancelingEdit" OnRowEditing="RowEditing" OnRowDataBound="gvMovimientos_RowDataBound" OnDataBound="gvMovimientos_DataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btEditar" runat="server" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btActualizar" runat="server" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                    <asp:LinkButton ID="btCancelar" runat="server" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btAgregar" runat="server" CommandName="AGREGAR" Text="Agregar"></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Clave">
                                <ItemTemplate>
                                    <asp:Label ID="lbClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbEditClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Nombre de Movimiento">
                                <ItemTemplate>
                                    <asp:Label ID="lbNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txNombreMovimiento" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Tipo de Folio">
                                <ItemTemplate>
                                    <asp:Label ID="lbFolio" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Folio") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="txEditTipoFolio" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TipoFolio") %>' Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddlEditTiposF" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlEditTiposF" runat="server" AppendDataBoundItems="true"><asp:ListItem Value="0">Seleccione un Tipo de Folio </asp:ListItem></asp:DropDownList>
                                </FooterTemplate>
                                
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                  </ContentTemplate>
              </asp:UpdatePanel>
          </section>
          <section role="tabpanel" aria-hidden="true" class="content" id="panel2-3">
            <h2>Tarifas</h2>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvTarifas" runat="server" DataKeyNames="Clave" AllowPaging="true" AutoGenerateColumns="false" PageSize="15" OnPageIndexChanging="gvTarifas_PageIndexChanging" ShowFooter="true"
                        OnRowCommand="gvTarifas_RowCommand" OnRowUpdating="gvTarifas_RowUpdating" OnRowCancelingEdit="RowCancelingEdit" OnRowEditing="RowEditing" OnRowDataBound="gvTarifas_RowDataBound" OnDataBound="gvTarifas_DataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btEditar" runat="server" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btActualizar" runat="server" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                    <asp:LinkButton ID="btCancelar" runat="server" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btAgregar" runat="server" CommandName="AGREGAR" Text="Agregar"></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Clave"  ItemStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:Label ID="lbClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbEditClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Acto" >
                                <ItemTemplate>
                                    <asp:Label ID="lbNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Acto") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="txEditActo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ClaveActo") %>' Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddlEditActo" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlEditActo" runat="server" AppendDataBoundItems="true"><asp:ListItem Value="0">Seleccione un Acto </asp:ListItem></asp:DropDownList>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Cve Ingresos"  ItemStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:Label ID="lbClaveIngresos" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ClaveIngresos") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditClaveIngresos" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ClaveIngresos") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txClaveIngresos" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Desc" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:Label ID="lbDescuento" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Descuento") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditDescuento" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Descuento") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txDescuento" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "%" ItemStyle-Width="85px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lbPorcentaje" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Porcentaje") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditPorcentaje" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Porcentaje") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txPorcentaje" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "SM Min" ItemStyle-Width="85px">
                                <ItemTemplate>
                                    <asp:Label ID="lbSmMinimo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SmMinimo") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditSmMinimo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SmMinimo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txSmMinimo" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "SM Max" ItemStyle-Width="85px">
                                <ItemTemplate>
                                    <asp:Label ID="lbSmMaximo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SmMaximo") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditSmMaximo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SmMaximo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txSmMaximo" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "SM Fijo" ItemStyle-Width="85px">
                                <ItemTemplate>
                                    <asp:Label ID="lbSmFijo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SmFijo") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditSmFijo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SmFijo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txSmFijo" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
          </section>
          <section role="tabpanel" aria-hidden="true" class="content" id="panel2-4">
            <h2>Areas de trabajo</h2>
            <asp:UpdatePanel runat="server">
                  <ContentTemplate>
                    <asp:GridView ID="gvAreasTrabajo" runat="server" AutoGenerateColumns="false" DataKeyNames="Clave" AllowPaging="true" OnPageIndexChanging="gvAreasTrabajo_PageIndexChanging" PageSize="15" ShowFooter="true"
                        OnRowCommand="gvAreasTrabajo_RowCommand" OnRowUpdating="gvAreasTrabajo_RowUpdating" OnRowCancelingEdit="RowCancelingEdit" OnRowEditing="RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btEditar" runat="server" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btActualizar" runat="server" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                    <asp:LinkButton ID="btCancelar" runat="server" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btAgregar" runat="server" CommandName="AGREGAR" Text="Agregar"></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Clave">
                                <ItemTemplate>
                                    <asp:Label ID="lbClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbEditClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Nombre de Area de Trabajo">
                                <ItemTemplate>
                                    <asp:Label ID="lbNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txNombreArea" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                  </ContentTemplate>
            </asp:UpdatePanel>
          </section>
          <section role="tabpanel" aria-hidden="true" class="content" id="panel2-5">
            <h2>Estatus</h2>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvEstatus" runat="server" AutoGenerateColumns="false" DataKeyNames="Clave" AllowPaging="true" OnPageIndexChanging="gvEstatus_PageIndexChanging" PageSize="15" ShowFooter="true"
                         OnRowCommand="gvEstatus_RowCommand" OnRowUpdating="gvEstatus_RowUpdating" OnRowCancelingEdit="RowCancelingEdit" OnRowEditing="RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btEditar" runat="server" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btActualizar" runat="server" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                    <asp:LinkButton ID="btCancelar" runat="server" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btAgregar" runat="server" CommandName="AGREGAR" Text="Agregar"></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Clave">
                                <ItemTemplate>
                                    <asp:Label ID="lbClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbEditClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Nombre de Estatus">
                                <ItemTemplate>
                                    <asp:Label ID="lbNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txNombreEstatus" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
          </section>
          <section role="tabpanel" aria-hidden="true" class="content" id="panel2-6">
            <h2>Tipos de folio</h2>
            <asp:UpdatePanel runat="server">
                  <ContentTemplate>
                      <asp:GridView ID="gvTiposFolio" runat="server" AutoGenerateColumns="false" DataKeyNames="Clave"  ShowFooter="true"
                         OnRowCommand="gvTiposFolio_RowCommand" OnRowUpdating="gvTiposFolio_RowUpdating" OnRowCancelingEdit="RowCancelingEdit" OnRowEditing="RowEditing">
                          <Columns>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btEditar" runat="server" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btActualizar" runat="server" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                    <asp:LinkButton ID="btCancelar" runat="server" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btAgregar" runat="server" CommandName="AGREGAR" Text="Agregar"></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Clave">
                                <ItemTemplate>
                                    <asp:Label ID="lbClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbEditClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Nombre de Estatus">
                                <ItemTemplate>
                                    <asp:Label ID="lbNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txNombreTipoFolio" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                  </ContentTemplate>
            </asp:UpdatePanel>
          </section>
          <section role="tabpanel" aria-hidden="true" class="content" id="panel2-7">
            <h2>Tramitante</h2>
            <asp:UpdatePanel runat="server">
                  <ContentTemplate>
                      <div class="row">
                        <div class="medium-6 large-6 columns"><label>Elige un Tramitante para editar sus datos:<asp:DropDownList ID="ddlTramitantes" runat="server" OnSelectedIndexChanged="ddlTramitantes_SelectedIndexChanged" AutoPostBack="True"  AppendDataBoundItems="true"><asp:ListItem Value="0" >Listado de Tramitantes</asp:ListItem></asp:DropDownList></label></div>
                        <div class="medium-6 large-6 columns"><asp:Button runat="server" CssClass="button" ID="btNuevoTramitante" Text="Nuevo Tramitante"  OnClick="btNuevoTramitante_Click"/></div>
                    </div>
                    <fieldset>
                        <legend>Generales</legend>
                        <div class="row">
                          <div class="medium-4 large-4 columns"><label>Nombre:<asp:TextBox ID="txNombreT" runat="server"></asp:TextBox></label></div>
                          <div class="medium-4 large-4 columns"><label>Apellido Paterno:<asp:TextBox ID="txAPaternoT" runat="server"></asp:TextBox></label></div>
                          <div class="medium-4 large-4 columns"><label>Apellido Materno:<asp:TextBox ID="txAMaternoT" runat="server"></asp:TextBox></label></div>
                        </div>
                        <div class="row">
                          <div class="medium-4 large-4 columns"><label>Razon Social:<asp:TextBox ID="txRazonSocialT" runat="server"></asp:TextBox></label></div>
                          <div class="medium-4 large-4 columns"><label>CURP:<asp:TextBox ID="txCurpT" runat="server"></asp:TextBox></label></div>
                          <div class="medium-4 large-4 columns"><label>RFC:<asp:TextBox ID="txRfcT" runat="server"></asp:TextBox></label></div>
                        </div>
                    </fieldset>
                    <fieldset>
                        <legend>Domicilio</legend>
                        <div class="row">
                          <div class="medium-4 large-4 columns"><label>Calle:<asp:TextBox ID="txCalleT" runat="server"></asp:TextBox></label></div>
                            <div class="medium-2 large-2 columns"><label>Número:<asp:TextBox ID="txNumeroT" runat="server"></asp:TextBox></label></div>
                          <div class="medium-4 large-4 columns"><label>Colonia:<asp:TextBox ID="txColoniaT" runat="server"></asp:TextBox></label></div>
                          <div class="medium-2 large-2 columns"><label>Código Postal:<asp:TextBox ID="txCodigoT" runat="server"></asp:TextBox></label></div>
                        </div>
                        <div class="row">
                          <div class="medium-4 large-4 columns"><label>Municipio:
                              <asp:DropDownList ID="ddlMunicipioT" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipios_SelectedIndexChanged"></asp:DropDownList></label></div>
                          <div class="medium-6 large-6 columns"><label>Poblacion:
                              <asp:DropDownList ID="ddlPoblacionT" runat="server" AutoPostBack="True"></asp:DropDownList></label></div>
                          <div class="medium-2 large-2 columns"><label>Estado:<asp:TextBox ID="txEstadoT" runat="server"></asp:TextBox></label></div>
                        </div>
                    </fieldset>
                    <fieldset>
                        <legend>Datos de Tramitante</legend>
                        <div class="row">
                            <div class="medium-4 large-4 columns"><label>L Notaria:<asp:TextBox ID="txLNotariaT" runat="server"></asp:TextBox></label></div>
                            <div class="medium-4 large-4 columns"><label>No. Notaria:<asp:TextBox ID="txNotariaT" runat="server"></asp:TextBox></label></div>
                            <div class="medium-4 large-4 columns"><label>Tipo de Tramitante:<asp:TextBox ID="txTipoT" runat="server"></asp:TextBox></label></div>
                        </div>
                        <div class="row">
                          <div class="medium-4 large-4 columns"><label>Telefono:<asp:TextBox ID="txTelefonoT" runat="server"></asp:TextBox></label></div>
                          <div class="medium-4 large-4 columns"><label>Fax:<asp:TextBox ID="txFaxT" runat="server"></asp:TextBox></label></div>
                          <div class="medium-4 large-4 columns"><label>Extensión:<asp:TextBox ID="txExtensionT" runat="server"></asp:TextBox></label></div>
                        </div>
                    </fieldset>
                    <asp:Button runat="server" CssClass="button" ID="btGuardarT" Text="Guardar" OnClick="btGuardarT_Click" />
                      <asp:Button runat="server" CssClass="button" ID="btActualizarT" Text="Actualizar" Visible="false" />
                  </ContentTemplate>
            </asp:UpdatePanel>
          </section>
          <section role="tabpanel" aria-hidden="true" class="content" id="panel2-8">
            <h2>Usuarios</h2>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div>
                        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="row">
                        <div class="medium-6 large-6 columns"><label>Elige un Usuario para editar sus datos:<asp:DropDownList ID="ddlUsuarios" runat="server" OnSelectedIndexChanged="ddlUsuarios_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"><asp:ListItem Value="0" >Listado de Usuarios</asp:ListItem></asp:DropDownList></label></div>
                        <div class="medium-6 large-6 columns"><asp:Button runat="server" CssClass="button" ID="btNuevoUsuario" Text="Nuevo Usuario" OnClick="btNuevoUsuario_Click" /></div>
                    </div>
                    <fieldset>
                        <legend>Datos de Usuario</legend>
                        <div class="row">
                            <div class="medium-4 large-4 columns"><label>Tipo de Usuario:
                                <asp:DropDownList ID="ddlTiposUsuario" runat="server"></asp:DropDownList></label></div>
                        </div>
                        <div class="row">
                          <div class="medium-4 large-4 columns"><label>Usuario:<asp:TextBox ID="txLogin" runat="server"></asp:TextBox></label></div>
                          <div class="medium-4 large-4 columns"><label>Contraseña:<asp:TextBox ID="txPassword" runat="server"></asp:TextBox></label></div>
                          <div class="medium-4 large-4 columns"><label>Estatus:
                              <asp:DropDownList ID="txEstatus" runat="server"><asp:ListItem>ACTIVO</asp:ListItem><asp:ListItem>INACTIVO</asp:ListItem></asp:DropDownList></label>
                          </div>
                        </div>
                    </fieldset>
                    <fieldset>
                        <legend>Generales</legend>
                        <div class="row">
                          <div class="medium-4 large-4 columns"><label>Nombre:<asp:TextBox ID="txNombre" runat="server"></asp:TextBox></label></div>
                          <div class="medium-4 large-4 columns"><label>Apellido Paterno:<asp:TextBox ID="txAPaterno" runat="server"></asp:TextBox></label></div>
                          <div class="medium-4 large-4 columns"><label>Apellido Materno:<asp:TextBox ID="txAMaterno" runat="server"></asp:TextBox></label></div>
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
                              <asp:DropDownList ID="ddlMunicipios" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipios_SelectedIndexChanged"></asp:DropDownList></label></div>
                          <div class="medium-4 large-4 columns"><label>Poblacion:
                              <asp:DropDownList ID="ddlPoblaciones" runat="server" AutoPostBack="True"></asp:DropDownList></label></div>
                          <div class="medium-4 large-4 columns"></div>
                        </div>
                    </fieldset>
                    <asp:Button runat="server" CssClass="button" ID="btGuardar" Text="Guardar" OnClick="btGuardar_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
          </section>
          <section role="tabpanel" aria-hidden="true" class="content" id="panel2-9">
            <h2>Municipios</h2>
            <asp:UpdatePanel runat="server">
                  <ContentTemplate>
                      <asp:GridView ID="gvMunicipios" runat="server" AutoGenerateColumns="false" DataKeyNames="Clave" ShowFooter="true"
                         OnRowCommand="gvMunicipios_RowCommand" OnRowUpdating="gvMunicipios_RowUpdating" OnRowCancelingEdit="RowCancelingEdit" OnRowEditing="RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btEditar" runat="server" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btActualizar" runat="server" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                    <asp:LinkButton ID="btCancelar" runat="server" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btAgregar" runat="server" CommandName="AGREGAR" Text="Agregar"></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Clave">
                                <ItemTemplate>
                                    <asp:Label ID="lbClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbEditClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Nombre de Municipio">
                                <ItemTemplate>
                                    <asp:Label ID="lbNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txNombreMunicipio" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                  </ContentTemplate>
            </asp:UpdatePanel>
          </section>
          <section role="tabpanel" aria-hidden="true" class="content" id="panel2-10">
            <h2>Población</h2>
              <asp:UpdatePanel runat="server">
                  <ContentTemplate>
                      <div class="row">
                        <div class="medium-6 large-2 columns"><label for="ddlFMunicipios">Elige un Municipio:</label></div>
                        <div class="medium-6 large-10 columns">
                        <asp:DropDownList ID="ddlFMunicipios" runat="server" OnSelectedIndexChanged="ddlFMunicipios_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"><asp:ListItem Value="0" >Listado de Municipios</asp:ListItem></asp:DropDownList></div>
                      </div>
                      <asp:GridView ID="gvPoblaciones" runat="server" DataKeyNames="ClavePoblacion" AllowPaging="true" PageSize="25" OnPageIndexChanging="gvPoblaciones_PageIndexChanging" ShowFooter="true"  AutoGenerateColumns="false"
                          OnRowCommand="gvPoblaciones_RowCommand" OnRowUpdating="gvPoblaciones_RowUpdating" OnRowCancelingEdit="RowCancelingEdit" OnRowEditing="RowEditing">
                          <Columns>
                            <asp:TemplateField HeaderText="Accion" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btEditar" runat="server" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btActualizar" runat="server" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                    <asp:LinkButton ID="btCancelar" runat="server" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btAgregar" runat="server" CommandName="AGREGAR" Text="Agregar"></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Clave" ItemStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:Label ID="lbClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ClavePoblacion") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbEditClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ClavePoblacion") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Nombre de Población" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lbNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txNombrePoblacion" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField  HeaderText = "Ambito" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Label ID="lbAmbito" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Ambito") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditAmbito" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Ambito") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txAmbito" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                  </ContentTemplate>
              </asp:UpdatePanel>
          </section>
          <section role="tabpanel" aria-hidden="true" class="content" id="panel2-11">
            <h2>Secciones</h2>
            <asp:UpdatePanel runat="server">
                  <ContentTemplate>
                      <asp:GridView ID="gvSecciones" runat="server" AutoGenerateColumns="false" DataKeyNames="Clave" ShowFooter="true"
                           OnRowCommand="gvSecciones_RowCommand" OnRowUpdating="gvSecciones_RowUpdating" OnRowCancelingEdit="RowCancelingEdit" OnRowEditing="RowEditing">
                          <Columns>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btEditar" runat="server" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btActualizar" runat="server" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                    <asp:LinkButton ID="btCancelar" runat="server" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btAgregar" runat="server" CommandName="AGREGAR" Text="Agregar"></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Clave">
                                <ItemTemplate>
                                    <asp:Label ID="lbClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbEditClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Seccion">
                                <ItemTemplate>
                                    <asp:Label ID="lbNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txNombreSeccion" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Descripcion">
                                <ItemTemplate>
                                    <asp:Label ID="lbDescripcion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Descripcion") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditDescripcion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Descripcion") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txDescripcion" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                  </ContentTemplate>
            </asp:UpdatePanel>
          </section>
          <section role="tabpanel" aria-hidden="true" class="content" id="panel2-12">
            <h2>Parametros</h2>
              <asp:UpdatePanel runat="server">
                  <ContentTemplate>
                    <asp:GridView ID="gvParametros" runat="server" AutoGenerateColumns="false" DataKeyNames="Clave" AllowPaging="true" PageSize="15" OnPageIndexChanging="gvParametros_PageIndexChanging" ShowFooter="true"
                         OnRowCommand="gvParametros_RowCommand" OnRowUpdating="gvParametros_RowUpdating" OnRowCancelingEdit="RowCancelingEdit" OnRowEditing="RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btEditar" runat="server" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btActualizar" runat="server" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                    <asp:LinkButton ID="btCancelar" runat="server" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btAgregar" runat="server" CommandName="AGREGAR" Text="Agregar"></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Clave">
                                <ItemTemplate>
                                    <asp:Label ID="lbClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbEditClave" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Clave") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Nombre de Parametro">
                                <ItemTemplate>
                                    <asp:Label ID="lbNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txNombreParametro" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Valor Numerico" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbValorn" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ValorN") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditValorn" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ValorN") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txValorNumero" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText = "Valor Caracter">
                                <ItemTemplate>
                                    <asp:Label ID="lbValorc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ValorC") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txEditValorc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ValorC") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txValorCaracter" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                  </ContentTemplate>
              </asp:UpdatePanel>
          </section>          
        </div>
    </div>

    <script>
        $(document).foundation();
    </script>
</asp:Content>
