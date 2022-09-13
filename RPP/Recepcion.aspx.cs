using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;
using System.Data;

namespace RPP
{
    public partial class Recepcion : System.Web.UI.Page
    {
        private RPPMain.Main main = new RPPMain.Main();
        private List<Antecedente> bAntecedentes;
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                #region Verificación de usuario
                Usuario currentUser = (Usuario)Session.Contents["usuario"];
                if (currentUser == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    if (currentUser.IdTipoUsuario != 2)
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

                txFecha.Text = DateTime.Today.Date.ToShortDateString();
                

                //Llenar el dropdownlist de actos para el formulario de nuevo tramite
                foreach (Acto item in main.Actos.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = item.ClaveIngresos.Substring(item.ClaveIngresos.Length - 4) + " - " +  item.Nombre;
                    l.Value = item.ClaveActo.ToString();
                    ddlActos.Items.Add(l);
                }
                //Llenar dropdownlist de Tramitantes para el formulario de nuevo tramite
                foreach (Tramitante var in main.Tramitantes.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = var.NumNotaria + " - " + var.Nombre + " " + var.ApellidoPaterno + " " + var.ApellidoMaterno;
                    l.Value = var.Clave.ToString();
                    ddlTramitantes.Items.Add(l);
                    ddlBTramitante.Items.Add(l);
                }

                //Llenar el dropdownlist de municipios para el formulario de Tramitantes
                foreach (Municipio item in main.Municipios.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = item.Nombre;
                    l.Value = item.Clave.ToString();
                    ddlMunicipioT.Items.Add(l);
                    ddlMunicipiosU.Items.Add(l);
                }
                //Llenar el dropdownlist de poblaciones para el formulario de Tramitantes
                foreach (Poblacion item in main.Poblaciones.CatalogoPorMunicipio(1))
                {
                    ListItem l = new ListItem();
                    l.Text = item.Nombre;
                    l.Value = item.ClavePoblacion.ToString();
                    ddlPoblacionT.Items.Add(l);
                }
                limpiarGridActos();
                limpiarGridAntecedentes();

                llenarDatosUsuario();
            }
        }


        #region FUNCIONES DE AGREGAR TRAMITE
        protected void ddlLTS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlLTS.SelectedValue.Equals("Semestre"))
            {
                txLT.Visible = false;
                ddlSemestre.Visible = true;
                lbASem.Visible = true;
                txASem.Visible = true;
                lbSeccion.Visible = false;
                ddlSeccion.Visible = false;
                lbSerie.Visible = false;
                ddlSerie.Visible = false;
            }
            else
            {
                txLT.Visible = true;
                ddlSemestre.Visible = false;
                lbASem.Visible = false;
                txASem.Visible = false;
                lbSeccion.Visible = true;
                ddlSeccion.Visible = true;
                lbSerie.Visible = true;
                ddlSerie.Visible = true;
            }
        }
        protected void btGuardarTramite_Click(object sender, EventArgs e)
        {
            //Prelacion pre = new Prelacion();
            String total = txTotal.Text.Replace("$", "");
            DataTable Temporal = (DataTable)Session["tablaActos"];
            DataTable Temporal2 = (DataTable)Session["tablaAntecedentes"];
            if (!Temporal.Rows[0][0].ToString().Equals("") && !Temporal2.Rows[0][0].ToString().Equals(""))
            {
                Prelacion prelacioncompleta = armarPrelacion(total,Temporal,Temporal2);
                String resultado = Prelacion.GuardarPrelacionObjeto(prelacioncompleta);
                int IdPrelacion = 0;
                if (int.TryParse(resultado, out IdPrelacion))
                {
                    //Se crea un registro en CompendioDigitalizacion
                    CompendioDigitalizacion.CrearCompendio(prelacioncompleta);
                    //pasar a la sesion idPrelacion para obtenerlo en la boleta de impresion
                    Session["IDPRELACION"] = IdPrelacion.ToString();
                    limpiarFormulario();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Prelación Agregada Correctamente')", true);
                    string url = "BoletaRecepcion.aspx";
                    string s = "window.open('" + url + "', 'popup_window', 'width=750,height=800,left=100,top=100,resizable=no');";
                    ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                }
            }
            else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes llenar al menos un Acto y/o Antecedente en tu Prelación')", true); }
        }

        protected Prelacion armarPrelacion(String total, DataTable Movimientos,DataTable Antecedentes)
        {
            String valor = txValorBase.Text.Replace('.', ',').ToString();
            Prelacion prelacion = new Prelacion();
            prelacion.IdTramitante = int.Parse(ddlTramitantes.SelectedValue.ToString());
            prelacion.NombreTitular = txNombreTitular.Text;
            prelacion.DescripcionBien = txDescripcion.Text;
            prelacion.NumeroEscritura = txNumeroEscritura.Text;
            prelacion.ValorInmueble = Convert.ToDecimal(valor);
            prelacion.Folio = txFolio.Text;
            prelacion.Total = Convert.ToDecimal(total);
            prelacion.Status = "RECEPCION";
            prelacion.Fecha= txFecha.Text;
            prelacion.LugarOtorgamiento = txLugarOtorg.Text;
            prelacion.TipoDocumento = txTipoDocto.Text;
            prelacion.TipoMoneda = txMoneda.Text;
            prelacion.FechaDocumento = txFechaOtorg.Text;
            //NUEVO 22/03/2022
            Usuario currentUser = (Usuario)Session.Contents["usuario"];
            prelacion.IdUsuarioCreador = currentUser.IdUsuario.ToString();
            //NUEVO 18/04/2022
            prelacion.TipoPago = ddlTipoPago.SelectedValue.ToString();
            prelacion.ReferenciaPago = txReferenciaPago.Text;
            //agregar Actos.
            prelacion.ActosPrelacion = new List<Movimientos>();
            foreach (DataRow row in Movimientos.Rows)
            {
                Movimientos mov = new Movimientos();
                mov.ClaveActo = int.Parse(row["Acto"].ToString());
                mov.Clave = int.Parse(row["Movimiento"].ToString());
                mov.Importe = Convert.ToDecimal(row["Subtotal"].ToString());
                prelacion.ActosPrelacion.Add(mov);
            }
            //agregarantecedentes
            prelacion.Antecedentes = new List<Antecedente>();
            foreach (DataRow row in Antecedentes.Rows)
            {
                Antecedente ant = new Antecedente();
                ant.Libro = row["Libro"].ToString();
                ant.Tomo = row["Tomo"].ToString();
                ant.Semestre = row["Semestre"].ToString();
                ant.Seccion = row["Seccion"].ToString();
                ant.Serie = row["Serie"].ToString();
                ant.Partida = row["Partida"].ToString();
                ant.Año = row["Año"].ToString();
                ant.Folio = row["Folio"].ToString();
                prelacion.Antecedentes.Add(ant);
            }

            return prelacion;
        }
        protected bool limpiarFormulario()
        {
            ddlTramitantes.SelectedIndex = 0;
            ddlLTS.SelectedIndex = 0;
            ddlSemestre.SelectedIndex = 0;
            ddlSeccion.SelectedIndex = 0;
            ddlSerie.SelectedIndex = 0;
            ddlActos.SelectedIndex = 0;
            ddlMovimientos.Items.Clear();

            txFolio.Text = "";
            txNombreTitular.Text = "";
            txNumeroEscritura.Text = "";
            txDescripcion.Text = "";
            txTipoDocto.Text = "";
            txLugarOtorg.Text = "";
            txFechaOtorg.Text = "";
            txASem.Text = "";
            txLT.Text = "";
            txPartida.Text = "";
            txValorBase.Text = "0.00";
            txTotal.Text = "$0.00";



            limpiarGridActos();
            limpiarGridAntecedentes();

            return true;

        }
        protected void limpiarGridActos()
        {
            DataTable Temporal = new DataTable();
            //Inicializar GridView de Movimientos para el formulario de nuevo tramite
            Temporal.Columns.Add("Id");
            Temporal.Columns.Add("Acto");
            Temporal.Columns.Add("Movimiento");
            Temporal.Columns.Add("Descripcion");
            Temporal.Columns.Add("ValorBase");
            Temporal.Columns.Add("Cantidad");
            Temporal.Columns.Add("Descuento");
            Temporal.Columns.Add("Subtotal");
            DataRow dr = Temporal.NewRow();
            dr["Id"] = string.Empty;
            Temporal.Rows.Add(dr);
            Session["tablaActos"] = Temporal;
            gvMovimientos.DataSource = Temporal;
            gvMovimientos.DataBind();
        }
        protected void limpiarGridAntecedentes()
        {
            DataTable Temporal = new DataTable();
            //Inicializar GridView de Movimientos para el formulario de nuevo tramite
            Temporal.Columns.Add("Id");
            Temporal.Columns.Add("Libro");
            Temporal.Columns.Add("Tomo");
            Temporal.Columns.Add("Seccion");
            Temporal.Columns.Add("Serie");
            Temporal.Columns.Add("Semestre");
            Temporal.Columns.Add("Año");
            Temporal.Columns.Add("Partida");
            Temporal.Columns.Add("Folio");
            DataRow dr = Temporal.NewRow();
            dr["Id"] = string.Empty;
            Temporal.Rows.Add(dr);
            Session["tablaAntecedentes"] = Temporal;
            gvAntecedentes.DataSource = Temporal;
            gvAntecedentes.DataBind();
        }
        #endregion
        
        #region AGREGAR NUEVO TRAMITANTE
        protected void btAddTramitante_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            if (dNuevoTram.Visible == false && boton.Text.Equals("+"))
            {
                dNuevoTram.Visible = true;
                ddlPoblacionT.Items.Clear();
                ddlMunicipioT.Items.Clear();
                //Llenar el dropdownlist de municipios para el formulario de Tramitantes
                foreach (Municipio item in main.Municipios.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = item.Nombre;
                    l.Value = item.Clave.ToString();
                    ddlMunicipioT.Items.Add(l);
                }
                //Llenar el dropdownlist de poblaciones para el formulario de Tramitantes
                foreach (Poblacion item in main.Poblaciones.CatalogoPorMunicipio(1))
                {
                    ListItem l = new ListItem();
                    l.Text = item.Nombre;
                    l.Value = item.ClavePoblacion.ToString();
                    ddlPoblacionT.Items.Add(l);
                }
            }
            else if (dNuevoTram.Visible == true && boton.Text.Equals("-"))
            {
                dNuevoTram.Visible = false;
            }
            
        }
        protected void ddlMunicipioT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPoblacionT.Items.Clear();
            foreach (Poblacion item in main.Poblaciones.CatalogoPorMunicipio(int.Parse(ddlMunicipioT.SelectedValue.ToString())))
            {
                ListItem l = new ListItem();
                l.Text = item.Nombre;
                l.Value = item.ClavePoblacion.ToString();
                ddlPoblacionT.Items.Add(l);
                dNuevoTram.Style.Add("display", "block");
            }
        }
        protected void btGuardarT_Click(object sender, EventArgs e)
        {
            if(!(txNombreT.Text.Equals("")&& txAPaternoT.Text.Equals("")&& txAMaternoT.Text.Equals("")&&txNotariaT.Text.Equals(""))){
                //Guardar los datos del Tramitante
                Tramitante t = new Tramitante();
                String result = t.Guardar(txNombreT.Text, txAPaternoT.Text, txAMaternoT.Text, txRazonSocialT.Text, txRfcT.Text, txCurpT.Text, txCalleT.Text, txNumeroT.Text, txColoniaT.Text, txCodigoT.Text, int.Parse(ddlPoblacionT.SelectedValue.ToString()), int.Parse(ddlMunicipioT.SelectedValue.ToString()), txEstadoT.Text, txLNotariaT.Text, txNotariaT.Text, txTipoT.Text, txTelefonoT.Text, txFaxT.Text, txExtensionT.Text);
                //Cargar el dropdownlist con el nuevo tramitante
                dNuevoTram.Visible = false;
                ddlTramitantes.Items.Clear();
                foreach (Tramitante var in main.Tramitantes.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = var.Nombre + " " + var.ApellidoPaterno + " " + var.ApellidoMaterno;
                    l.Value = var.Clave.ToString();
                    ddlTramitantes.Items.Add(l);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes llenar por lo menos el nombre completo del Nuevo Tramitante y el Numero de Notaria.')", true); 
            }
        }
        #endregion

        #region MOVIMIENTOS DE LA PRELACION
        protected void ddlActos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMovimientos.Items.Clear();
            foreach (Movimientos item in main.Movimientos.Catalogo(int.Parse(ddlActos.SelectedValue.ToString())))
            {
                ListItem l = new ListItem();
                l.Text = item.Nombre;
                l.Value = item.Clave.ToString();
                ddlMovimientos.Items.Add(l);
            }
        }
        protected void btAgregarMovimiento_Click(object sender, EventArgs e)
        {
            DataTable Temporal = (DataTable)Session["tablaActos"];
            if (!ddlActos.SelectedValue.ToString().Equals("0") && !txValorBase.Text.Equals("0.00"))
            {
                Parametro par = new Parametro();
                Acto acto = new Acto();
                Tarifa tar = acto.ObtenerTarifa(int.Parse(ddlActos.SelectedValue.ToString()));
                
                //Llenar el grid con los datos del movimiento
                if (Temporal.Rows[0][0].ToString().Equals("")) { Temporal.Rows.Clear(); }

                int repetir = 1;

                if (txRepetir.Text.Length > 0)
                {
                    repetir = int.Parse(txRepetir.Text);
                }

                for (int i = 0; i < repetir; i++)
                {

                    DataRow dr = Temporal.NewRow();
                    dr["Id"] = Temporal.Rows.Count + 1;
                    dr["Acto"] = ddlActos.SelectedValue.ToString();
                    dr["Movimiento"] = ddlMovimientos.SelectedValue.ToString();
                    dr["Descripcion"] = ddlMovimientos.SelectedItem.Text.ToString();
                    dr["ValorBase"] = txValorBase.Text;

                    //calcular el costo del movimiento
                    String cant = "";
                    if (!(tar.SmFijo.ToString()).Equals("0"))
                    {
                        float salMin = float.Parse(par.ObtenerSalario());
                        cant = ((float.Parse(tar.SmFijo.ToString())) * salMin).ToString("0.00");
                    }
                    else
                    {
                        float valorC = (tar.Porcentaje * float.Parse(txValorBase.Text)) / 100;
                        float salMax = tar.SmMaximo * (float.Parse(par.ObtenerSalario()));
                        if (valorC > salMax)
                        {
                            cant = salMax.ToString("0.00");
                        }
                        else
                        {
                            cant = valorC.ToString("0.00");
                        }
                    }
                    dr["Cantidad"] = cant;
                    dr["Descuento"] = tar.Descuento.ToString();
                    dr["Subtotal"] = (float.Parse(cant) - tar.Descuento).ToString("0.00");
                    Temporal.Rows.Add(dr);
                    Session["tablaActos"] = Temporal;
                    gvMovimientos.DataSource = Temporal;
                    gvMovimientos.DataBind();
                }

                float total = 0;
                foreach (DataRow row in Temporal.Rows)
                {
                    total += float.Parse(row["Subtotal"].ToString());
                }
                txTotal.Text = "$" + total.ToString("0.00");
                ddlActos.SelectedIndex = 0;
                ddlMovimientos.Items.Clear();
                ddlMovimientos.Items.Add("Listado de movimientos");
                ddlMovimientos.SelectedIndex = 0;
            }
        }
        protected void gvMovimientos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable Temporal = (DataTable)Session["tablaActos"];
            int id = e.RowIndex;
            Temporal.Rows.RemoveAt(id);
            if (Temporal.Rows.Count == 0)
            {
                DataRow dr = Temporal.NewRow();
                dr["Id"] = string.Empty;
                Temporal.Rows.Add(dr);
            }
            Session["tablaActos"] = Temporal;
            gvMovimientos.DataSource = Temporal;
            gvMovimientos.DataBind();

            if (!Temporal.Rows[0][0].ToString().Equals(""))
            {
                float total = 0;
                foreach (DataRow row in Temporal.Rows)
                {
                    total += float.Parse(row["Subtotal"].ToString());
                }
                txTotal.Text = "$" + total.ToString("0.00");
            }
            else
            {
                txTotal.Text = "$0.00";
            }
        }
        #endregion

        #region ANTECEDENTES DE LA PRELACION
        protected void btAgregarAntecedente_Click(object sender, EventArgs e)
        {
            if (!(ddlLTS.SelectedIndex != 2 && txLT.Text.Equals("")) && !txPartida.Text.Equals(""))
            {
                DataTable Temporal = (DataTable)Session["tablaAntecedentes"];

                if (Temporal.Rows[0][0].ToString().Equals("")) { Temporal.Rows.Clear(); }
                DataRow dr = Temporal.NewRow();
                dr["Id"] = Temporal.Rows.Count + 1;
                if (ddlLTS.SelectedValue.Equals("Libro")) dr["Libro"] = txLT.Text;
                if (ddlLTS.SelectedValue.Equals("Tomo")) dr["Tomo"] = txLT.Text;
                if (ddlLTS.SelectedValue.Equals("Semestre"))
                {
                    dr["Semestre"] = ddlSemestre.SelectedValue.ToString();
                    dr["Año"] = txASem.Text;
                }
                else
                {
                    dr["Seccion"] = ddlSeccion.SelectedValue.ToString();
                    dr["Serie"] = ddlSerie.SelectedValue.ToString();
                }
                dr["Partida"] = txPartida.Text;
                dr["Folio"] = txFolioA.Text;
                Temporal.Rows.Add(dr);
                Session["tablaAntecedentes"] = Temporal;
                gvAntecedentes.DataSource = Temporal;
                gvAntecedentes.DataBind();

                ddlLTS.SelectedIndex = 0;
                ddlSemestre.SelectedIndex = 0;
                ddlSeccion.SelectedIndex = 0;
                ddlSerie.SelectedIndex = 0;
                txASem.Text = "";
                txLT.Text = "";
                txPartida.Text = "";
                txFolioA.Text = "";

            }
            else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes Agregar todos los campos necesarios para Antecedentes.')", true); }
        }
        protected void gvAntecedentes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable Temporal = (DataTable)Session["tablaAntecedentes"];
            int id = e.RowIndex;
            Temporal.Rows.RemoveAt(id);
            if (Temporal.Rows.Count == 0)
            {
                DataRow dr = Temporal.NewRow();
                dr["Id"] = string.Empty;
                Temporal.Rows.Add(dr);
            }
            Session["tablaAntecedentes"] = Temporal;
            gvAntecedentes.DataSource = Temporal;
            gvAntecedentes.DataBind();
        }
        #endregion

        #region PERFIL DE USUARIO
        protected void llenarDatosUsuario()
        {
            
            Usuario usuarioLog = (Usuario)Session.Contents["usuario"];
            if (usuarioLog != null)
            {
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
            //txNacimiento.Text = DateTime.Parse(usuarioLog.FechaNacimiento).ToString("yyyy-MM-dd");
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
            else { Response.Redirect("Login.aspx"); }

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
            else  {   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Los campos de Contraseña deben Coincidir.')", true);  }
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (txBuscarPrelacion.Text.Length > 0)
            {
                Prelacion pre = Prelacion.ObtenerPrelacionPorIdBusqueda(int.Parse(txBuscarPrelacion.Text));

                if (pre.IdPrelacion > 0)
                {
                    txBNuevoTitular.Text = pre.NombreTitular;
                    txBFolio.Text = pre.Folio;
                    txBEscritura.Text = pre.NumeroEscritura;
                    txBDescripcion.Text = pre.DescripcionBien;
                    txBTipoDocumento.Text = pre.TipoDocumento;
                    txBFechaOtorgamiento.Text = pre.FechaDocumento;
                    txBLugarOtorgamiento.Text = pre.LugarOtorgamiento;
                    ddlBTramitante.SelectedValue = pre.IdTramitante.ToString();
                    gvBAntecedentes.DataSource = pre.Antecedentes;
                    gvBAntecedentes.DataBind();
                    Session["bAntecedentes"] = pre.Antecedentes;
                    Session["bIdPrelacion"] = pre.IdPrelacion;
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Prelacion p = new Prelacion();

            p.NombreTitular = txBNuevoTitular.Text;
            p.DescripcionBien = txBDescripcion.Text;
            p.NumeroEscritura = txBEscritura.Text;
            p.LugarOtorgamiento = txBLugarOtorgamiento.Text;
            p.TipoDocumento = txBTipoDocumento.Text;
            p.FechaDocumento = txBFechaOtorgamiento.Text;
            p.Folio = txBFolio.Text;
            p.IdTramitante = int.Parse(ddlBTramitante.SelectedValue.ToString());
            p.IdPrelacion = (int)Session["bIdPrelacion"];
            p.Antecedentes = new List<Antecedente>();
            p.Antecedentes = (List<Antecedente>)Session["bAntecedentes"]; 

            Prelacion.ActualizarPrelacion(p);

            txBNuevoTitular.Text = "";
            txBDescripcion.Text = "";
            txBEscritura.Text = "";
            txBLugarOtorgamiento.Text = "";
            txBTipoDocumento.Text = "";
            txBFechaOtorgamiento.Text = "";
            txBFolio.Text = "";
            ddlBTramitante.SelectedIndex = 0;
            Session["bIdPrelacion"] = null;
            Session["bAntecedentes"] = null;
            txBuscarPrelacion.Text = "";
            gvBAntecedentes.DataSource = null;
            gvBAntecedentes.DataBind();

        }

        protected void gvBAntecedentes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bAntecedentes = (List<Antecedente>)Session["bAntecedentes"];
            bAntecedentes.RemoveAt(e.RowIndex);
            gvBAntecedentes.DataSource = bAntecedentes;
            gvBAntecedentes.DataBind();
            Session["bAntecedentes"] = bAntecedentes;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Antecedente a = new Antecedente();

            if (ddlBLTS.SelectedValue.Equals("Libro")) a.Libro = txBLibro.Text;
            if (ddlBLTS.SelectedValue.Equals("Tomo")) a.Tomo = txBLibro.Text;
            if (ddlBLTS.SelectedValue.Equals("Semestre"))
            {
                a.Semestre = ddlBSemestre.SelectedValue.ToString();
                a.Año = txBASem.Text;
            }
            else
            {
                a.Seccion = ddlBSeccion.SelectedValue.ToString();
                a.Serie = ddlBSerie.SelectedValue.ToString();
            }
            a.Partida = txBPartida.Text;
            a.Folio = txBFolioA.Text;

            bAntecedentes = (List<Antecedente>)Session["bAntecedentes"];
            bAntecedentes.Add(a);

            Session["bAntecedentes"] = bAntecedentes;
            gvBAntecedentes.DataSource = bAntecedentes;
            gvBAntecedentes.DataBind();

            ddlBLTS.SelectedIndex = 0;
            ddlBSemestre.SelectedIndex = 0;
            ddlBSeccion.SelectedIndex = 0;
            ddlBSerie.SelectedIndex = 0;
            txBASem.Text = "";
            txBLibro.Text = "";
            txBPartida.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int idPrelacion = (int)Session["bIdPrelacion"];

            if (idPrelacion > 0)
            {
                Prelacion.CambiarEstadoPrelacion("CANCELADA", idPrelacion);
                txBNuevoTitular.Text = "";
                txBDescripcion.Text = "";
                txBEscritura.Text = "";
                txBLugarOtorgamiento.Text = "";
                txBTipoDocumento.Text = "";
                txBFechaOtorgamiento.Text = "";
                txBFolio.Text = "";
                ddlBTramitante.SelectedIndex = 0;
                Session["bIdPrelacion"] = null;
                Session["bAntecedentes"] = null;
                txBuscarPrelacion.Text = "";
                gvBAntecedentes.DataSource = null;
                gvBAntecedentes.DataBind();
            }            
        }

    }
}