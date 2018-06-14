using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;

namespace RPP
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ActosCollection act = new ActosCollection();
            List<Acto> listaActos = act.Catalogo();

            foreach (Acto var in listaActos)
            {
                ListItem l = new ListItem();
                l.Text = var.Nombre;
                l.Value = var.Clave.ToString();
                ddlActos.Items.Add(l);
            }
        }

        protected void gvAntecedentes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Prelacion> lista = new List<Prelacion>();
            Prelacion p = new Prelacion();
            lista = p.ObtenerPrelacionesEstatusReporte("ASIGNADA");

            gvResultados.DataSource = null;
            gvResultados.DataBind();
            lblError.Text = "";

            if (lista.Count > 0)
            {
                gvResultados.DataSource = lista;
                gvResultados.DataBind();
                lblError.Text = "Se encontraron " + lista.Count.ToString() + " resultados.";
            }
            else
            {
                lblError.Text = "No se encontraron resultados";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Prelacion> lista = new List<Prelacion>();
            Prelacion p = new Prelacion();
            lista = p.ObtenerPrelacionesEstatusReporte("ENTREGADA");

            gvResultados.DataSource = null;
            gvResultados.DataBind();
            lblError.Text = "";

            if (lista.Count > 0)
            {
                gvResultados.DataSource = lista;
                gvResultados.DataBind();
                lblError.Text = "Se encontraron " + lista.Count.ToString() + " resultados.";
            }
            else
            {
                lblError.Text = "No se encontraron resultados";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            List<Prelacion> lista = new List<Prelacion>();
            Prelacion p = new Prelacion();
            lista = p.ObtenerPrelacionesActo(int.Parse(ddlActos.SelectedValue));

            gvResultados.DataSource = null;
            gvResultados.DataBind();
            lblError.Text = "";

            if (lista.Count > 0)
            {
                gvResultados.DataSource = lista;
                gvResultados.DataBind();
                lblError.Text = "Se encontraron " + lista.Count.ToString() + " resultados.";
            }
            else
            {
                lblError.Text = "No se encontraron resultados";
            }
        }
    }
}