using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;

namespace RPP
{
    public partial class BoletaEntrega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener id_prelacion de la session 
            //Session["IDPRELACION"] = Request.QueryString["IdPrelacion"];
            //Session["NOMBRE"] = "Esthela Vianey Vazquez Medina";
            int prelacionId = int.Parse(Request.QueryString["IdPrelacion"]);
            lbFecha.Text = DateTime.Today.ToShortDateString();
            lbHora.Text = DateTime.Now.ToShortTimeString();
            lbPrelacion.Text = prelacionId.ToString();
            gvAntecedentes.DataSource = Prelacion.ObtenerAntecedentesPrelacion(prelacionId);
            gvAntecedentes.DataBind();
            Prelacion pre = Prelacion.PrelacionPorId(prelacionId);
            lbUsuario.Text = "Usuario Actual";
            lbTramitante.Text = pre.Tramitante;
            lbTitular.Text = pre.NombreTitular;
            lbDescripcion.Text = pre.DescripcionBien;
            lbValorBase.Text = pre.ValorInmueble.ToString();
            Tramitante tram = Tramitante.ObtenerTramitantePorId(pre.IdTramitante);
            lbRfc.Text = tram.Rfc;
            lbDomicilio.Text = tram.Calle + " " + tram.Numero + " " + tram.Colonia;
            lbDomicilio2.Text = tram.Municipio + " " + tram.Estado + " " + tram.CodigoPostal;

            gvServicios.DataSource = Prelacion.ObtenerMovimientosPrelacion(prelacionId, "");
            gvServicios.DataBind();
            lbTotal.Text = pre.Total.ToString();
            lbNombreC.Text = Request.QueryString["Nombre"];

        }
    }
}