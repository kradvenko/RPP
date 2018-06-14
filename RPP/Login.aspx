<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RPP.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="center row">      
            <section>
                <asp:Image runat="server" ImageUrl="~/Imgs/logo_inicio.jpg" Width="800" />
                
              <p class="title" data-section-title><br />Inicio de sesión</p>
              <div class="content" data-section-content>
                <p>
                  <div class="row">
                    <div class="large-12 columns">
                      <div class="signup-panel">
                        <p class="welcome">Bienvenido</p>
                        <div>
                          <div class="row collapse">
                            <div class="small-2 columns">
                              <span class="prefix"><i class="fi-mail"></i></span>
                            </div>
                            <div class="small-10  columns">
                                <asp:TextBox ID="txUsuario" placeholder="Usuario" runat="server"></asp:TextBox>
                            </div>
                          </div>
                          <div class="row collapse">
                            <div class="small-2 columns ">
                              <span class="prefix"><i class="fi-lock"></i></span>
                            </div>
                            <div class="small-10 columns ">
                              <asp:TextBox ID="txPassword" runat="server" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                            </div>
                          </div>
                        </div>
                          <asp:Button ID="btnLogin" runat="server" CssClass="button" Text="Identificarse" OnClick="btnLogin_Click" />
                          <br />
                          <asp:Label ID="lblResultado" runat="server" CssClass="label" Text=""></asp:Label>
                      </div>
                    </div>
                   </div></p>
              </div>
            </section>
        </div>      

    <script>
        $(document).foundation();
    </script>
</asp:Content>
