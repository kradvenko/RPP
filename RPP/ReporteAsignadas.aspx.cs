using RPPMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RPP
{
    public partial class ReporteAsignadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String fecha = Request.QueryString["fecha"];
            //Response.Write(fecha);
            List<Prelacion> prelaciones = Prelacion.ObtenerPrelacionesEstatusFechaReporte("%", fecha);
            String registradorActual = "";

            if (prelaciones.Count > 0)
            {
                Response.Write("<B>RELACION DE ASIGNACIÓN DE TRAMITES PARA REGISTRO</B>");
                Response.Write("<table border='1'>");
                for(int i = 0; i < prelaciones.Count; i++)
                {
                    if (registradorActual == prelaciones[i].Usuario)
                    {
                        Response.Write("<tr>");
                        Response.Write("<td>" + prelaciones[i].IdPrelacion + "</td>");
                        Response.Write("<td>" + prelaciones[i].NombreActo + "</td>");
                        Response.Write("<td>" + prelaciones[i].FechaAsignacion + "</td>");
                        Response.Write("<td>" + prelaciones[i].NumeroEscritura + "</td>");
                        Response.Write("<td>" + prelaciones[i].Status + "</td>");
                        Response.Write("</tr>");
                    }
                    else
                    {
                        registradorActual = prelaciones[i].Usuario;

                        Response.Write("<tr>");
                        Response.Write("<td colspan='3'><B>" + prelaciones[i].Usuario + "</B></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                        Response.Write("<td><B>Número de prelación</B></td>");
                        Response.Write("<td><B>Acto</B></td>");
                        Response.Write("<td><B>Fecha de asignación</B></td>");
                        Response.Write("<td><B>Número de escritura</B></td>");
                        Response.Write("<td><B>Estatus</B></td>");
                        Response.Write("</tr>");

                        Response.Write("<tr>");
                        Response.Write("<td>" + prelaciones[i].IdPrelacion + "</td>");
                        Response.Write("<td>" + prelaciones[i].NombreActo +"</td>");
                        Response.Write("<td>" + prelaciones[i].FechaAsignacion + "</td>");
                        Response.Write("<td>" + prelaciones[i].NumeroEscritura + "</td>");
                        Response.Write("<td>" + prelaciones[i].Status + "</td>");
                        Response.Write("</tr>");
                    }
                    if (i == 0)
                    {
                        registradorActual = prelaciones[0].Usuario;
                    }
                }
                Response.Write("</table>");
            }
        }
    }
}