<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EjemploImagenes.aspx.cs" Inherits="RPP.EjemploImagenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .documento {
            float:inherit;
            width:100%;
            height:500px;
        }
        .controles {
            float:inherit;
            width:100%;
            height:10%;
        }
    </style>
    <iframe align="top" class="documento" name ="Documento" src="DocumentoImagen.aspx?libro=1&tomo=2&semestre=2&anio=1980&seccion=2&serie=A&partida=1" ></iframe>
    <iframe align="bottom" class="controles" name="Controles" src="DocumentoControles.aspx" ></iframe>
</asp:Content>
