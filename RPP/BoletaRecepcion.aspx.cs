using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;

namespace RPP
{
    public partial class BoletaRecepcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener el usuario que tiene la sesion
            Usuario currentUser = (Usuario)Session.Contents["usuario"];
            //obtener id_prelacion de la session 
            int prelacionId = int.Parse(Session["IDPRELACION"].ToString());
            //int prelacionId = 2;
            lbFecha.Text = DateTime.Today.ToShortDateString();
            lbHora.Text = DateTime.Now.ToShortTimeString();
            lbPrelacion.Text = prelacionId.ToString();
            gvAntecedentes.DataSource = Prelacion.ObtenerAntecedentesPrelacion(prelacionId);
            gvAntecedentes.DataBind();
            Prelacion pre = Prelacion.PrelacionPorId(prelacionId);
            lbFecha.Text = pre.Fecha.ToString();
            lbUsuario.Text = currentUser.Nombre+" " +currentUser.ApellidoPaterno +" " + currentUser.ApellidoMaterno;
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

            gvCostos.DataSource = Prelacion.ObtenerCostosPrelacion(prelacionId);
            gvCostos.DataBind();
            lbTotal.Text = pre.Total.ToString();

            lbFecha2.Text = DateTime.Today.ToShortDateString();
            lbHora2.Text = DateTime.Now.ToShortTimeString();
            lbPrelacion2.Text = prelacionId.ToString();
            gvAntecedentes2.DataSource = Prelacion.ObtenerAntecedentesPrelacion(prelacionId);
            gvAntecedentes2.DataBind();
            lbFecha2.Text = pre.Fecha.ToString();
            lbUsuario2.Text = currentUser.Nombre + " " + currentUser.ApellidoPaterno + " " + currentUser.ApellidoMaterno;
            lbTramitante2.Text = pre.Tramitante;
            lbTitular2.Text = pre.NombreTitular;
            lbDescripcion2.Text = pre.DescripcionBien;
            lbValorBase2.Text = pre.ValorInmueble.ToString();
            lbRfc2.Text = tram.Rfc;
            lbDomicilio12.Text = tram.Calle + " " + tram.Numero + " " + tram.Colonia;
            lbDomicilio22.Text = tram.Municipio + " " + tram.Estado + " " + tram.CodigoPostal;

            gvServicios2.DataSource = Prelacion.ObtenerMovimientosPrelacion(prelacionId,"");
            gvServicios2.DataBind();

            lbTotal2.Text = pre.Total.ToString();
        }
    }
}