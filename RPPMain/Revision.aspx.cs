using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;

namespace RPP
{
    public partial class Revision : System.Web.UI.Page
    {
        private RPPMain.Main main = new RPPMain.Main();
        private List<Prelacion> prelaciones;
        Prelacion prelacionElegida;
        private List<Movimientos> movimientos;

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
                if (currentUser.IdTipoUsuario != 5)
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
            prelaciones = prelacionElegida.ObtenerPrelacionesEstatus("VERIFICACION");
            gvPrelaciones.DataSource = prelaciones;
            gvPrelaciones.DataBind();
            if (IsPostBack)
            {
                prelacionElegida = (Prelacion)HttpContext.Current.Session["prelacionElegida"];
                if (prelacionElegida != null)
                {
                    movimientos = new List<Movimientos>();
                    movimientos = Prelacion.ObtenerMovimientosPrelacion(prelacionElegida.IdPrelacion, "");
                }
            }
            if (!IsPostBack)
            llenarDatosUsuario();
        }

        protected void gvPrelaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeleccionarPrelacion();
            LimpiarCampos();
        }

        protected void gvMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeleccionarMovimiento();
        }

        private void SeleccionarPrelacion()
        {
            prelacionElegida = prelaciones[gvPrelaciones.SelectedIndex];
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

            HttpContext.Current.Session.Add("prelacionElegida", prelacionElegida);
        }

        private void SeleccionarMovimiento()
        {
            RegistroActo registro = new RegistroActo();

            registro = RegistroActo.ObtenerDatosRegistro(movimientos[gvMovimientos.SelectedIndex].ClavePrelacionActo);

            if (registro != null)
            {
                gvOtorgantes.DataSource = registro.Otorgantes;
                gvOtorgantes.DataBind();

                gvAdquirientes.DataSource = registro.Adquirientes;
                gvAdquirientes.DataBind();

                txTipoPredio.Text = registro.TipoPredio;
                txSuperficie.Text = registro.Superficie;
                txUnidadSuperficie.Text = registro.UnidadSuperficie;
                txClaveCat.Text = registro.ClaveCatastral;
                txMunicipio.Text = registro.MunicipioTexto;
                txPoblacion.Text = registro.PoblacionTexto;
                txColonia.Text = registro.ColoniaTexto;
                txCalle.Text = registro.CalleTexto;
                txExterior.Text = registro.NumeroExterior;
                txInterior.Text = registro.NumeroInterior;
                txManzana.Text = registro.Manzana;
                txLote.Text = registro.Lote;
                txNorte.Text = registro.Norte;
                txSur.Text = registro.Sur;
                txEste.Text = registro.Este;
                txOeste.Text = registro.Oeste;
                txNoreste.Text = registro.Noreste;
                txNoroeste.Text = registro.Noroeste;
                txSureste.Text = registro.Sureste;
                txSuroeste.Text = registro.Suroeste;

            }
        }

        private void LimpiarCampos()
        {
            gvOtorgantes.DataSource = null;
            gvOtorgantes.DataBind();

            gvAdquirientes.DataSource = null;
            gvAdquirientes.DataBind();

            txTipoPredio.Text = "";
            txSuperficie.Text = "";
            txUnidadSuperficie.Text = "";
            txClaveCat.Text = "";
            txMunicipio.Text = "";
            txPoblacion.Text = "";
            txColonia.Text = "";
            txCalle.Text = "";
            txExterior.Text = "";
            txInterior.Text = "";
            txManzana.Text = "";
            txLote.Text = "";
            txNorte.Text = "";
            txSur.Text = "";
            txEste.Text = "";
            txOeste.Text = "";
            txNoreste.Text = "";
            txNoroeste.Text = "";
            txSureste.Text = "";
            txSuroeste.Text = "";
        }

        protected void btGuardarRegistro_Click(object sender, EventArgs e)
        {
            if (prelacionElegida.IdPrelacion > 0)
            {
                Prelacion.CambiarEstadoPrelacion("ENTREGA", prelacionElegida.IdPrelacion);
                prelaciones = new List<Prelacion>();
                prelacionElegida = new Prelacion();
                prelaciones = prelacionElegida.ObtenerPrelacionesEstatus("VERIFICACION");
                gvPrelaciones.DataSource = prelaciones;
                gvPrelaciones.DataBind();
                LimpiarCampos();
                prelacionElegida = null;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Prelación ha pasado al Módulo de Entrega')", true);
            }
        }

        protected void btRechazar_Click(object sender, EventArgs e)
        {
            if (prelacionElegida.IdPrelacion > 0)
            {
                Prelacion.CambiarEstadoPrelacion("REVISAR", prelacionElegida.IdPrelacion);
                Prelacion.CambiarEstadoMovimientos("REVISION", prelacionElegida.IdPrelacion);
                Prelacion.CambiarObservacionesVerificadorPrelacion(txObservaciones.Text, prelacionElegida.IdPrelacion);
                prelaciones = new List<Prelacion>();
                prelacionElegida = new Prelacion();
                prelaciones = prelacionElegida.ObtenerPrelacionesEstatus("VERIFICACION");
                gvPrelaciones.DataSource = prelaciones;
                gvPrelaciones.DataBind();
                LimpiarCampos();
                prelacionElegida = null;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Prelación ha regresado al Módulo de Registro')", true);
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
            txCalleU.Text = usuarioLog.Calle;
            txColoniaU.Text = usuarioLog.Colonia;
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
            Usuario currentUser = (Usuario)Session.Contents["usuario"];
            if (!txNombre.Text.Equals("") && !txAPaterno.Text.Equals("") && !txAMaterno.Text.Equals(""))
            {
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
                datosUsuario.Calle = txCalleU.Text;
                datosUsuario.Colonia = txColoniaU.Text;
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

        protected void gvAntecedentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String libro = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[1].Text;
            String tomo = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[2].Text;
            String seccion = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[3].Text;
            String serie = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[4].Text;
            String semestre = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[5].Text;
            String anio = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[6].Text;
            String partida = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[7].Text;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('DocumentoImagen.aspx?libro=" + libro + "&tomo=" + tomo + "&semestre=" + semestre + "&anio=" + anio + "&seccion=" + seccion + "&serie=" + serie + "&partida=" + partida + "','_blank')", true);
        }
    }
}