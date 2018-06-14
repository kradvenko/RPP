using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;

namespace RPP
{
    public partial class Entrega : System.Web.UI.Page
    {
        private RPPMain.Main main = new RPPMain.Main();
        private List<Prelacion> prelaciones;
        Prelacion prelacionElegida;

        private List<Prelacion> listaEntrega;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Verificación de usuario
            Usuario currentUser = (Usuario)Session.Contents["usuario"];
            if (currentUser == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (currentUser.IdTipoUsuario != 6)
                {
                    switch (currentUser.IdTipoUsuario)
                    {
                        case 1: //Administrador
                            Response.Redirect("Catalogos.aspx");
                            break;
                        case 2://Recepcion
                            Response.Redirect("Recepcion.aspx");
                            break;
                        case 3://Distribucion
                            Response.Redirect("Distribucion.aspx");
                            break;
                        case 4://Registrador
                            Response.Redirect("Registro.aspx");
                            break;
                        case 5://Verificación
                            Response.Redirect("Revision.aspx");
                            break;
                        case 6://Entrega
                            Response.Redirect("Entrega.aspx");
                            break;
                    }
                }
            }
            #endregion

            prelaciones = new List<Prelacion>();
            

            prelacionElegida = new Prelacion();
            Session["IDPRELACION"] = null;
            prelaciones = prelacionElegida.ObtenerPrelacionesEstatus("ENTREGA");
            gvPrelaciones.DataSource = prelaciones;
            gvPrelaciones.DataBind();

            listaEntrega = new List<Prelacion>();
            listaEntrega = (List<Prelacion>)Session["listaEntrega"];
            if (listaEntrega != null)
            {
                gvEntrega.DataSource = listaEntrega;
                gvEntrega.DataBind();
            }
            else
            {
                listaEntrega = new List<Prelacion>();
            }

            if (IsPostBack)
            {
                prelacionElegida = (Prelacion)HttpContext.Current.Session["prelacionElegida"];                
            }
            if (!IsPostBack)
            {
                llenarDatosUsuario();
            }
        }

        protected void btGuardarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaEntrega.Count > 0)
                {
                    string s = "";
                    foreach (Prelacion item in listaEntrega)
                    {
                        Prelacion.EntregarPrelacion(item.IdPrelacion, txNombreRecibe.Text, ddlTipoIdentificacion.Text, txClave.Text);
                        Prelacion.CambiarEstadoPrelacion("ENTREGADA", item.IdPrelacion);                        

                        //codigo para abrir la ventana de impresion de la boleta
                        //Session["IDPRELACION"] = item.IdPrelacion;
                        //Session["NOMBRE"] = txNombreRecibe.Text;
                        string url = "BoletaEntrega.aspx?IdPrelacion=" + item.IdPrelacion + "&Nombre=" + txNombreRecibe.Text;
                        s = s + "window.open('" + url + "', '_blank');";                        
                        ////
                    }

                    ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                    prelaciones = new List<Prelacion>();
                    prelacionElegida = new Prelacion();
                    listaEntrega = new List<Prelacion>();
                    prelaciones = prelacionElegida.ObtenerPrelacionesEstatus("ENTREGA");
                    gvPrelaciones.DataSource = prelaciones;
                    gvPrelaciones.DataBind();
                    Session.Add("listaEntrega", listaEntrega);
                    gvEntrega.DataSource = listaEntrega;
                    gvEntrega.DataBind();
                    txNombreRecibe.Text = "";
                    txClave.Text = "";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Prelación Finalizada y Entregada.')", true);
                }
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error. No ha elegido una prelación.')", true);
            }
        }

        private void LimpiarCampos()
        {
            txNombreRecibe.Text = "";
            txClave.Text = "";
            prelacionElegida = null;
        }
        protected void gvPrelaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeleccionarPrelacion();
        }

        private void SeleccionarPrelacion()
        {
            prelacionElegida = prelaciones[gvPrelaciones.SelectedIndex];
            /*
            lbFecha.Text = prelacionElegida.Fecha;
            lbFolio.Text = prelacionElegida.Folio;
            lbTramitante.Text = prelacionElegida.Tramitante;
            lbNumEscritura.Text = prelacionElegida.NumeroEscritura;
            lbDescripcion.Text = prelacionElegida.DescripcionBien;
            lbTitular.Text = prelacionElegida.NombreTitular;

            List<Antecedente> antecedentes = new List<Antecedente>();
            antecedentes = Prelacion.ObtenerAntecedentesPrelacion(prelacionElegida.IdPrelacion);

            gvAntecedentes.DataSource = antecedentes;
            gvAntecedentes.DataBind();

            movimientos = new List<Movimientos>();
            movimientos = Prelacion.ObtenerMovimientosPrelacion(prelacionElegida.IdPrelacion, "");
            gvMovimientos.DataSource = movimientos;
            gvMovimientos.DataBind();
            */
            HttpContext.Current.Session.Add("prelacionElegida", prelacionElegida);


            Boolean flag = false; 

            foreach (Prelacion item in listaEntrega)
            {
                if (item.IdPrelacion == prelacionElegida.IdPrelacion)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                
            }
            else
            {
                listaEntrega.Add(prelacionElegida);
                Session.Add("listaEntrega", listaEntrega);
                gvEntrega.DataSource = listaEntrega;
                gvEntrega.DataBind();
            }
        }

        #region PERFIL DE USUARIO
        protected void llenarDatosUsuario()
        {

            Usuario usuarioLog = (Usuario)Session.Contents["usuario"];
            txNombre.Text = usuarioLog.Nombre;
            txAPaterno.Text = usuarioLog.ApellidoPaterno;
            txAMaterno.Text = usuarioLog.ApellidoMaterno;
            txUsuario.Text = usuarioLog.Login;
            txTipoUsuario.Text = usuarioLog.TipoUsuario;
            txRFC.Text = usuarioLog.Rfc;
            txCURP.Text = usuarioLog.Curp;
            txCalle.Text = usuarioLog.Calle;
            txColonia.Text = usuarioLog.Colonia;
            txCodigoPostal.Text = usuarioLog.CodigoPostal;
            txTelefono1.Text = usuarioLog.Telefono1;
            txTelefono2.Text = usuarioLog.Telefono2;
            txNacimiento.Text = DateTime.Parse(usuarioLog.FechaNacimiento).ToString("yyyy-MM-dd");
            txControl.Text = usuarioLog.NoControl;
            //Llenar el dropdownlist de municipios para el formulario de Tramitantes
            foreach (Municipio item in main.Municipios.Catalogo())
            {
                ListItem l = new ListItem();
                l.Text = item.Nombre;
                l.Value = item.Clave.ToString();
                ddlMunicipiosU.Items.Add(l);
            }
            ddlMunicipiosU.SelectedValue = usuarioLog.Municipio.ToString();
            //Llenar el dropdownlist de poblaciones para el formulario de Tramitantes
            foreach (Poblacion item in main.Poblaciones.CatalogoPorMunicipio(usuarioLog.Municipio))
            {
                ListItem l = new ListItem();
                l.Text = item.Nombre;
                l.Value = item.ClavePoblacion.ToString();
                ddlPoblacionesU.Items.Add(l);
            }
            ddlPoblacionesU.SelectedValue = usuarioLog.Poblacion.ToString();

        }
        protected void btCambiarPass_Click(object sender, EventArgs e)
        {
            Usuario currentUser = (Usuario)Session.Contents["usuario"];
            if (txPass1.Text.Equals(txPass2.Text) && !txPass1.Text.Equals("") && !txPass2.Text.Equals(""))
            {
                String resultado = Usuario.CambiarPasswordUsuario(currentUser.IdUsuario, txPass2.Text);
                if (resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Contraseña cambiada correctamente.')", true); }
                else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al cambiar la contraseña.')", true); }
            }
            else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Los campos de Contraseña deben Coincidir.')", true); }
        }

        protected void btGuardarCambios_Click(object sender, EventArgs e)
        {
            if (!txNombre.Text.Equals("") && !txAPaterno.Text.Equals("") && !txAMaterno.Text.Equals(""))
            {
                Usuario currentUser = (Usuario)Session.Contents["usuario"];
                Usuario datosUsuario = new Usuario();
                datosUsuario.IdUsuario = currentUser.IdUsuario;
                datosUsuario.IdTipoUsuario = currentUser.IdTipoUsuario;
                datosUsuario.Login = txUsuario.Text;
                datosUsuario.Nombre = txNombre.Text;
                datosUsuario.ApellidoPaterno = txAPaterno.Text;
                datosUsuario.ApellidoMaterno = txAMaterno.Text;
                datosUsuario.Rfc = txRFC.Text;
                datosUsuario.Curp = txCURP.Text;
                datosUsuario.FechaNacimiento = txNacimiento.Text;
                datosUsuario.Calle = txCalle.Text;
                datosUsuario.Colonia = txColonia.Text;
                datosUsuario.CodigoPostal = txCodigoPostal.Text;
                datosUsuario.Telefono1 = txTelefono1.Text;
                datosUsuario.Telefono2 = txTelefono2.Text;
                datosUsuario.NoControl = txControl.Text;
                datosUsuario.Municipio = int.Parse(ddlMunicipiosU.SelectedValue.ToString());
                datosUsuario.Poblacion = int.Parse(ddlPoblacionesU.SelectedValue.ToString());

                String resultado = Usuario.CambiarDatosUsuario(datosUsuario);
                if (resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos Actualizados Correctamente.')", true); }
                else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al Actualizar los Datos de Usuario.')", true); }
            }
            else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes al menos completar los datos del Nombre.)", true); }
        }
        protected void ddlMunicipiosU_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPoblacionesU.Items.Clear();
            foreach (Poblacion item in main.Poblaciones.CatalogoPorMunicipio(int.Parse(ddlMunicipiosU.SelectedValue.ToString())))
            {
                ListItem l = new ListItem();
                l.Text = item.Nombre;
                l.Value = item.ClavePoblacion.ToString();
                ddlPoblacionesU.Items.Add(l);
            }
        }
        #endregion

        protected void gvEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPrelacion = int.Parse(gvEntrega.Rows[gvEntrega.SelectedRow.RowIndex].Cells[0].Text);
            foreach (Prelacion item in listaEntrega)
            {
                if (item.IdPrelacion == idPrelacion)
                {
                    listaEntrega.Remove(item);
                    Session.Add("listaEntrega", listaEntrega);
                    gvEntrega.DataSource = listaEntrega;
                    gvEntrega.DataBind();
                    break;
                }
            }
        }

        protected void txbFiltroEntrega_TextChanged(object sender, EventArgs e)
        {
            prelaciones = new List<Prelacion>();

            prelacionElegida = new Prelacion();
            Session["IDPRELACION"] = null;
            if (txbFiltroEntrega.Text.Length > 0)
            {
                prelaciones = prelacionElegida.ObtenerPrelacionesEstatusFiltro("ENTREGA", txbFiltroEntrega.Text);
            }
            else
            {
                prelaciones = prelacionElegida.ObtenerPrelacionesEstatusFiltro("ENTREGA", "%");
            }
            gvPrelaciones.DataSource = prelaciones;
            gvPrelaciones.DataBind();

            listaEntrega = new List<Prelacion>();
            listaEntrega = (List<Prelacion>)Session["listaEntrega"];
            if (listaEntrega != null)
            {
                gvEntrega.DataSource = listaEntrega;
                gvEntrega.DataBind();
            }
            else
            {
                listaEntrega = new List<Prelacion>();
            }

            if (IsPostBack)
            {
                prelacionElegida = (Prelacion)HttpContext.Current.Session["prelacionElegida"];
            }
            if (!IsPostBack)
            {
                llenarDatosUsuario();
            }
        }

        
    }
}