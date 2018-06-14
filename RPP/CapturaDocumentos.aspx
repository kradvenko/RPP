<%@ Page Language="C#" AutoEventWireup="true"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 186px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td class="auto-style1">Tipo de Documento</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="160">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Número de Documento</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Fecha de Documento</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Lugar de Otorgamiento</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">No. de Notaria</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Actos Juridicos</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Libro</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Tomo</td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Semestre</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Año Semestre</td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Sección</td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Serie</td>
            <td>
                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Partida</td>
            <td>
                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Otorgantes o Propietarios</td>
            <td>
                <asp:TextBox ID="TextBox12" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Adquirientes</td>
            <td>
                <asp:TextBox ID="TextBox13" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Valor de la Operación</td>
            <td>
                <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Tipo de Moneda</td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server" Width="160">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Tipo de Predio</td>
            <td>
                <asp:DropDownList ID="DropDownList4" runat="server" Width="160">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Superficie</td>
            <td>
                <asp:TextBox ID="TextBox31" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Unidad de Superficie</td>
            <td>
                <asp:DropDownList ID="DropDownList5" runat="server" Width="60">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Descripción del Inmueble</td>
            <td>
                <asp:TextBox ID="TextBox30" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Municipio</td>
            <td>
                <asp:DropDownList ID="DropDownList6" runat="server" Width="260">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Población</td>
            <td>
                <asp:DropDownList ID="DropDownList7" runat="server" Width="260">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Clave Catastral</td>
            <td>
                <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Norte</td>
            <td>
                <asp:TextBox ID="TextBox16" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Sur</td>
            <td>
                <asp:TextBox ID="TextBox17" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Este (Oriente)</td>
            <td>
                <asp:TextBox ID="TextBox18" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Oeste (Poniente)</td>
            <td>
                <asp:TextBox ID="TextBox19" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Noreste (NorOriente)</td>
            <td>
                <asp:TextBox ID="TextBox20" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Noroeste (NorPoniente)</td>
            <td>
                <asp:TextBox ID="TextBox21" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Sureste (SurOriente)</td>
            <td>
                <asp:TextBox ID="TextBox22" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Suroeste (SurPoniente)</td>
            <td>
                <asp:TextBox ID="TextBox23" runat="server"  Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Fecha Registro</td>
            <td>
                <asp:TextBox ID="TextBox24" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Observaciones</td>
            <td>
                <asp:TextBox ID="TextBox25" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Inegi Estado</td>
            <td>
                <asp:DropDownList ID="DropDownList8" runat="server" Width="260">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Inegi Municipio</td>
            <td>
                <asp:DropDownList ID="DropDownList9" runat="server"  Width="260">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Inegi Población</td>
            <td>
                <asp:DropDownList ID="DropDownList10" runat="server" Width="260">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Inegi Colonia</td>
            <td>
                <asp:DropDownList ID="DropDownList12" runat="server" Width="260">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Inegi Calle</td>
            <td>
                <asp:TextBox ID="TextBox26" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Inegi Número Calle</td>
            <td>
                <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Folio Unico Propiedad</td>
            <td>
                <asp:TextBox ID="TextBox28" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Página</td>
            <td>
                <asp:TextBox ID="TextBox29" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
