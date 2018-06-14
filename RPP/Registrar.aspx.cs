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
    public partial class Registrar : System.Web.UI.Page
    {
        private RPPMain.Main main = new RPPMain.Main();
        List<Movimientos> listamovimientos = new List<Movimientos>();
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
                if (currentUser.IdTipoUsuario != 4)
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

            

          if (!IsPostBack)
            {
                prelacionElegida = Prelacion.ObtenerPrelacionPorId(int.Parse(Session["IDPRELACION"].ToString()));
                llenarListaMovimientos();
            }
          else
          {
              prelacionElegida = (Prelacion)HttpContext.Current.Session["prelacionElegida"];
          }
          obtenerAntecedentes(); 
        }

        protected void radbMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            formularioRegistro.Visible = false;
            string[] datos = Session["IDPRELACION"].ToString().Split(';');
            if (datos.Length == 2)
                listamovimientos = Prelacion.ObtenerMovimientosPrelacion(int.Parse(datos[0]), "REVISION");
            else
                listamovimientos = Prelacion.ObtenerMovimientosPrelacion(int.Parse(Session["IDPRELACION"].ToString()), "");
            
            foreach (Movimientos var in listamovimientos)
            {
                if (radbMovimientos.SelectedValue.Equals(var.ClavePrelacionActo.ToString()))
                {
                    ddlSeccion.Visible = true;
                    ddlSeccion.Items.Clear();
                    ddlSeccion.Items.Add("Elige una Seccion");
                    string[] words = var.Acto.Seccion.ToString().Split(';');
                    foreach (string word in words)
                    {
                        ListItem l = new ListItem();
                        String secc = Acto.ObtenerSeccion(word);
                        l.Text = secc;
                        l.Value = word;
                        ddlSeccion.Items.Add(l);
                    }
                    ddlSeccion.Items.RemoveAt(ddlSeccion.Items.Count - 1);
                    if (ddlSeccion.Items.Count > 2) { ddlSeccion.Visible = true; } else { ddlSeccion.Visible = false; }

                }
            }
        }

        protected void btRegistrar_Click(object sender, EventArgs e)
        {
            String seccion = (ddlSeccion.Visible) ? ddlSeccion.SelectedValue.ToString() : ddlSeccion.Items[1].Value.ToString();
            if (!seccion.Equals("Elige una Seccion"))
            {
                if (!(seccion.Length > 3))
                {
                    formularioRegistro.Visible = true;
                    
                    string[] datosp = Session["IDPRELACION"].ToString().Split(';');
                    if (datosp.Length == 2)
                        listamovimientos = Prelacion.ObtenerMovimientosPrelacion(int.Parse(datosp[0]), "REVISION");
                    else
                        listamovimientos = Prelacion.ObtenerMovimientosPrelacion(int.Parse(Session["IDPRELACION"].ToString()), "");
                    //id_prelacion_acto ; seccion
                    Session["REGISTRO"] = listamovimientos.ElementAt(radbMovimientos.SelectedIndex).ClavePrelacionActo + ";" + seccion;
                    switch (seccion)
                    {
                        case "1":
                            adquirientes.Visible = true;
                            datosI.Visible = true;
                            descripcion.Visible = true;
                            anotaciones.Visible = true;
                            break;
                        case "2":                            
                            txNombreA.Visible = true;
                            tipopredio.Visible = false;
                            anotaciones.Visible = false;
                            break;
                        case "3-1":
                            ubicacionI.Visible = false;
                            datosI.Visible = false;
                            superficie.Visible = false;
                            unidadsuperficie.Visible = false;
                            descripcion.Visible = true;
                            ddlCalle.Visible = true;
                            txCalle.Visible = true;
                            idcalle.Visible = true;
                            numinterior.Visible = true;
                            numexterior.Visible = true;

                            legDescripcion.InnerText = "Datos de Permiso de Transporte";
                            lblColindancias.Visible = false;
                            lblNorte.InnerText = "Modalidad";
                            lblSur.InnerText = "Ubicación Permiso de Transporte";
                            lblEste.InnerText = "Circunscripción autorizada";
                            lblOeste.InnerText = "Municipio";
                            lblNoreste.InnerText = "Población";
                            lblNoroeste.InnerText = "Número económico";
                            rowSureste.Visible = false;
                            rowSuroeste.Visible = false;

                            break;
                        case "3-2":       
                     
                            datosI.Visible = false;
                            idcalle.Visible = true;
                            numinterior.Visible = true;
                            numexterior.Visible = true;
                            manzana.Visible = false;
                            lote.Visible = false;
                            descripcion.Visible = true;
                            clavecatastral.Visible = false;
                            ddlCalle.Visible = true;
                            txCalle.Visible = true;

                            lblNorte.InnerText = "Descripción de Garantía";
                            lblColindancias.Visible = false;
                            rowSur.Visible = false;
                            rowEste.Visible = false;
                            rowOeste.Visible = false;
                            rowNoreste.Visible = false;
                            rowNoroeste.Visible = false;
                            rowSureste.Visible = false;
                            rowSuroeste.Visible = false;

                            break;
                        case "4":
                            legOtorgante.InnerText = "Nombre Razon social o denominación";
                            datosI.Visible = false;
                            idcalle.Visible = true;
                            numinterior.Visible = true;
                            numexterior.Visible = true;
                            manzana.Visible = false;
                            lote.Visible = false;
                            descripcion.Visible = true;
                            adquirientes.Visible = false;
                            clavecatastral.Visible = false;
                            ddlCalle.Visible = true;
                            txCalle.Visible = true;

                            labelNombreO.InnerText = "";
                            labelAPaternoO.InnerText = "";
                            labelAMaternoO.InnerText = "";

                            legDescripcion.InnerText = "Domicilio Social";
                            lblNorte.InnerText = "";
                            lblColindancias.Visible = false;
                            rowSur.Visible = false;
                            rowEste.Visible = false;
                            rowOeste.Visible = false;
                            rowNoreste.Visible = false;
                            rowNoroeste.Visible = false;
                            rowSureste.Visible = false;
                            rowSuroeste.Visible = false;

                            break;
                        case "5":
                            adquirientes.Visible = true;
                            datosI.Visible = true;
                            descripcion.Visible = true;
                            anotaciones.Visible = true;
                            break;
                        default:
                            Server.Transfer("Registro.aspx");
                            break;
                    }
                                        //id_prelacion_acto ; seccion
                    string[] datos = Session["REGISTRO"].ToString().Split(';');
                    //Si tiene un Registro es porque fue regresada en Verificacion.
                    RegistroActo registroGuardado = RegistroActo.ObtenerDatosRegistro(int.Parse(datos[0]));
                    if (registroGuardado == null)
                    {
                        txFechaReg.Text = DateTime.Now.ToShortDateString();
                        limpiarOtorgantes();
                        limpiarAnotaciones();
                        limpiarAdquirientes();
                        //Llenar el dropdownlist de municipios para el formulario de usuarios
                        foreach (Municipio item in main.Municipios.Catalogo())
                        {
                            ListItem l = new ListItem();
                            l.Text = item.Nombre;
                            l.Value = item.Clave.ToString();
                            ddlMunicipios.Items.Add(l);
                        }

                        //Llenar el dropdownlist de poblaciones para el formulario de usuarios
                        foreach (Poblacion item in main.Poblaciones.CatalogoPorMunicipio(1))
                        {
                            ListItem l = new ListItem();
                            l.Text = item.Nombre;
                            l.Value = item.ClavePoblacion.ToString();
                            ddlPoblaciones.Items.Add(l);
                        }
                    }
                    else
                    {//LENAR LOS CAMPOS CON EL REGISTRO YA GUARDADO.
                        
                        foreach (Municipio item in main.Municipios.Catalogo())
                        {
                            ListItem l = new ListItem();
                            l.Text = item.Nombre;
                            l.Value = item.Clave.ToString();
                            ddlMunicipios.Items.Add(l);
                        }

                        //Llenar el dropdownlist de poblaciones para el formulario de usuarios
                        foreach (Poblacion item in main.Poblaciones.CatalogoPorMunicipio(1))
                        {
                            ListItem l = new ListItem();
                            l.Text = item.Nombre;
                            l.Value = item.ClavePoblacion.ToString();
                            ddlPoblaciones.Items.Add(l);
                        }

                        txFolio.Text = registroGuardado.Folio;
                        txFechaReg.Text = registroGuardado.FechaRegistro;
                        txCalle.Text = registroGuardado.CalleTexto;
                        txColonia.Text = registroGuardado.ColoniaTexto;
                        txInterior.Text = registroGuardado.NumeroInterior;
                        txExterior.Text = registroGuardado.NumeroExterior;
                        txSuperficie.Text = registroGuardado.Superficie;
                        txTipoPredio.Text = registroGuardado.TipoPredio;
                        if (registroGuardado.UnidadSuperficie.Length > 0)
                        {
                            ddlUnidadSup.SelectedValue = registroGuardado.UnidadSuperficie;
                        }
                        txManzana.Text = registroGuardado.Manzana;
                        txLote.Text = registroGuardado.Lote;
                        txNorte.Text = registroGuardado.Norte;
                        txSur.Text = registroGuardado.Sur;
                        txEste.Text = registroGuardado.Este;
                        txOeste.Text = registroGuardado.Oeste;
                        txNoroeste.Text = registroGuardado.Noroeste;
                        txNoreste.Text = registroGuardado.Noreste;
                        txSuroeste.Text = registroGuardado.Suroeste;
                        txSureste.Text = registroGuardado.Sureste;
                        txLibroR.Text = registroGuardado.RegistroActual.Libro;
                        ddlSeccionR.SelectedValue = registroGuardado.RegistroActual.Seccion;
                        txPartidaR.Text = registroGuardado.RegistroActual.Partida;
                        txClaveCat.Text = registroGuardado.ClaveCatastral;
                        txObservaciones.InnerText = registroGuardado.Observaciones;
                        ddlMunicipios.SelectedIndex = int.Parse(registroGuardado.Municipio.ToString()) - 1;
                        ddlPoblaciones.SelectedIndex = int.Parse(registroGuardado.Poblacion.ToString()) - 1;


                        gvOtorgantes.DataSource = registroGuardado.Otorgantes;
                        gvOtorgantes.DataBind();
                        gvAdquirientes.DataSource = registroGuardado.Adquirientes;
                        gvAdquirientes.DataBind();
                        gvAnotaciones.DataSource = registroGuardado.AnotacionesMarginales;
                        gvAnotaciones.DataBind();

                        limpiarOtorgantesRevision();
                        limpiarAnotacionesRevision();
                        limpiarAdquirientesRevision();

                    }
                }
                else
                {
                    Prelacion.CambiarEstadoMovimiento("REGISTRADA", int.Parse(radbMovimientos.SelectedValue));
                    if (radbMovimientos.Items.Count == 1) { Prelacion.CambiarEstadoPrelacion("ENTREGA", int.Parse(Session["IDPRELACION"].ToString())); }
                    ScriptManager.RegisterClientScriptBlock(panelMovimientos, panelMovimientos.GetType(), "alert", "alert('Es un movimiento No Registral, Movimiento Registrado.')", true);
                    llenarListaMovimientos();
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes elegir la Seccion a la que corresponde el Movimiento a Registrar')", true);
            }
        }
        protected void btGuardarRegistro_Click(object sender, EventArgs e)
        {
            DataTable Temporal = (DataTable)Session["tablaOt"];
            DataTable Temporal2 = (DataTable)Session["tablaAd"];
            if (!Temporal.Rows[0][0].ToString().Equals(""))
            {
                string[] datos = Session["REGISTRO"].ToString().Split(';');
                if (!datos[1].Equals("4") && Temporal2.Rows[0][0].ToString().Equals(""))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes introducir los datos del(os) Adquirientes.')", true);
                }
                else
                {
                    //obtener registro completo con todos los datos a guardar
                    RegistroActo registrocompleto = armarRegistro(datos[0], datos[1]);
                    //Si tiene un Registro es porque fue regresada en Verificacion.
                    RegistroActo registroGuardado = RegistroActo.ObtenerDatosRegistro(int.Parse(datos[0]));
                    if (registroGuardado != null) { registrocompleto.IdRegistro = registroGuardado.IdRegistro; }
                    else { registrocompleto.IdRegistro = 0; }
                    //Guardarregistro.
                    String resultado = RegistroActo.GuardarRegistroObjeto(registrocompleto);
                    if (resultado.Equals("OK"))
                    {
                        //Si se registraron todos los movimientos, debe cambiarse de estado a la prelacion. 
                        listamovimientos = Prelacion.ObtenerMovimientosPrelacion(int.Parse(Session["IDPRELACION"].ToString()), "NOREGISTRADA");
                        if (listamovimientos.Count < 1)
                        {
                            //Cambiar estado de Prelacion "VERIFICACION"
                            Prelacion.CambiarEstadoPrelacion("VERIFICACION", int.Parse(Session["IDPRELACION"].ToString()));
                            Session["REGISTRO"] = null;
                            Session["IDPRELACION"] = null;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro Guardado Correctamente.')", true);
                            Response.Redirect("Registro.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Prelación Registrada Correctamente.')", true);
                            Response.Redirect("Registrar.aspx");
                        }
                    }
                    else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al guardar el Registro." + resultado + "')", true); }
                }
            }
            else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes introducir los datos del(os) Otorgantes.')", true); }         
        }
        #region OTORGANTES/ADQUIRIENTES/ANOTACIONES
        protected void limpiarOtorgantes()
        {
            DataTable Temporal = new DataTable();
            //Inicializar GridViews
            Temporal.Columns.Add("IdPersona");
            Temporal.Columns.Add("Nombre");
            Temporal.Columns.Add("Paterno");
            Temporal.Columns.Add("Materno");
            DataRow dr = Temporal.NewRow();
            dr["IdPersona"] = string.Empty;
            Temporal.Rows.Add(dr);
            Session["tablaOt"] = Temporal;
            gvOtorgantes.DataSource = Temporal;
            gvOtorgantes.DataBind();
        }
        protected void limpiarAdquirientes()
        {
            DataTable Temporal = new DataTable();
            //Inicializar GridViews
            Temporal.Columns.Add("IdPersona");
            Temporal.Columns.Add("Nombre");
            Temporal.Columns.Add("Paterno");
            Temporal.Columns.Add("Materno");
            DataRow dr = Temporal.NewRow();
            dr["IdPersona"] = string.Empty;
            Temporal.Rows.Add(dr);
            Session["tablaAd"] = Temporal;
            gvAdquirientes.DataSource = Temporal;
            gvAdquirientes.DataBind();
        }
        protected void limpiarAnotaciones()
        {
            DataTable Temporal = new DataTable();
            Temporal.Columns.Add("Id");
            Temporal.Columns.Add("Libro");
            Temporal.Columns.Add("Tomo");
            Temporal.Columns.Add("Seccion");
            Temporal.Columns.Add("Serie");
            Temporal.Columns.Add("Semestre");
            Temporal.Columns.Add("Año");
            Temporal.Columns.Add("Partida");
            DataRow dr = Temporal.NewRow();
            dr["Id"] = string.Empty;
            Temporal.Rows.Add(dr);
            Session["tablaAnotaciones"] = Temporal;
            gvAnotaciones.DataSource = Temporal;
            gvAnotaciones.DataBind();
        }

        protected void limpiarOtorgantesRevision()
        {
            DataTable Temporal = new DataTable();
            //Inicializar GridViews
            Temporal.Columns.Add("IdPersona");
            Temporal.Columns.Add("Nombre");
            Temporal.Columns.Add("Paterno");
            Temporal.Columns.Add("Materno");

            foreach (GridViewRow item in gvOtorgantes.Rows)
            {
                DataRow dr = Temporal.NewRow();
                dr["IdPersona"] = Temporal.Rows.Count + 1;
                dr["Nombre"] = item.Cells[2].Text;
                dr["Paterno"] = item.Cells[3].Text;
                dr["Materno"] = item.Cells[4].Text;
                Temporal.Rows.Add(dr);
            }

            Session["tablaOt"] = Temporal;
            gvOtorgantes.DataSource = Temporal;
            gvOtorgantes.DataBind();
        }
        protected void limpiarAdquirientesRevision()
        {
            DataTable Temporal = new DataTable();
            //Inicializar GridViews
            Temporal.Columns.Add("IdPersona");
            Temporal.Columns.Add("Nombre");
            Temporal.Columns.Add("Paterno");
            Temporal.Columns.Add("Materno");

            foreach (GridViewRow item in gvAdquirientes.Rows)
            {
                DataRow dr = Temporal.NewRow();
                dr["IdPersona"] = Temporal.Rows.Count + 1;
                dr["Nombre"] = item.Cells[2].Text;
                dr["Paterno"] = item.Cells[3].Text;
                dr["Materno"] = item.Cells[4].Text;
                Temporal.Rows.Add(dr);
            }

            Session["tablaAd"] = Temporal;
            gvAdquirientes.DataSource = Temporal;
            gvAdquirientes.DataBind();
        }
        protected void limpiarAnotacionesRevision()
        {
            DataTable Temporal = new DataTable();
            Temporal.Columns.Add("Id");
            Temporal.Columns.Add("Libro");
            Temporal.Columns.Add("Tomo");
            Temporal.Columns.Add("Seccion");
            Temporal.Columns.Add("Serie");
            Temporal.Columns.Add("Semestre");
            Temporal.Columns.Add("Año");
            Temporal.Columns.Add("Partida");

            foreach (GridViewRow item in gvAnotaciones.Rows)
            {
                DataRow dr = Temporal.NewRow();
                dr["Id"] = Temporal.Rows.Count + 1;
                dr["Libro"] = item.Cells[2].Text;
                dr["Tomo"] = item.Cells[3].Text;
                dr["Seccion"] = item.Cells[4].Text;
                dr["Serie"] = item.Cells[5].Text;
                dr["Semestre"] = item.Cells[6].Text;
                dr["Año"] = item.Cells[7].Text;
                dr["Partida"] = item.Cells[8].Text;
                Temporal.Rows.Add(dr);
            }

            Session["tablaAnotaciones"] = Temporal;
            gvAnotaciones.DataSource = Temporal;
            gvAnotaciones.DataBind();
        }

        protected void gvOtorgantes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable Temporal = (DataTable)Session["tablaOt"];
            int id = e.RowIndex;
            Temporal.Rows.RemoveAt(id);
            if (Temporal.Rows.Count == 0)
            {
                DataRow dr = Temporal.NewRow();
                dr["IdPersona"] = string.Empty;
                Temporal.Rows.Add(dr);
            }
            Session["tablaOt"] = Temporal;
            gvOtorgantes.DataSource = Temporal;
            gvOtorgantes.DataBind();
        }

        protected void gvAdquirientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable Temporal = (DataTable)Session["tablaAd"];
            int id = e.RowIndex;
            Temporal.Rows.RemoveAt(id);
            if (Temporal.Rows.Count == 0)
            {
                DataRow dr = Temporal.NewRow();
                dr["IdPersona"] = string.Empty;
                Temporal.Rows.Add(dr);
            }
            Session["tablaAd"] = Temporal;
            gvAdquirientes.DataSource = Temporal;
            gvAdquirientes.DataBind();
        }

        protected void btAddAdquiriente_Click(object sender, EventArgs e)
        {
            if (!(txNombreA.Text.Equals("")) && !(txPaternoA.Text.Equals("")) && !(txMaternoA.Text.Equals("")))
            {
                DataTable Temporal = (DataTable)Session["tablaAd"];
                if (Temporal.Rows[0][0].ToString().Equals("")) { Temporal.Rows.Clear(); }
                DataRow dr = Temporal.NewRow();
                dr["IdPersona"] = Temporal.Rows.Count + 1;
                dr["Nombre"] = txNombreA.Text;
                dr["Paterno"] = txPaternoA.Text;
                dr["Materno"] = txMaternoA.Text;
                Temporal.Rows.Add(dr);
                Session["tablaAd"] = Temporal;
                gvAdquirientes.DataSource = Temporal;
                gvAdquirientes.DataBind();
                txNombreA.Text = "";
                txPaternoA.Text = "";
                txMaternoA.Text = "";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes escribir nombre Completo del Adquiriente')", true);
            }
        }

        protected void btAddOtorgante_Click(object sender, EventArgs e)
        {
            if (!(txNombreO.Text.Equals("")) && !(txPaternoO.Text.Equals("")) && !(txMaternoO.Text.Equals("")))
            {
                DataTable Temporal = (DataTable)Session["tablaOt"];

                if (Temporal.Rows[0][0].ToString().Equals("")) { Temporal.Rows.Clear(); }
                DataRow dr = Temporal.NewRow();
                dr["IdPersona"] = Temporal.Rows.Count + 1;
                dr["Nombre"] = txNombreO.Text;
                dr["Paterno"] = txPaternoO.Text;
                dr["Materno"] = txMaternoO.Text;
                Temporal.Rows.Add(dr);
                Session["tablaOt"] = Temporal;
                gvOtorgantes.DataSource = Temporal;
                gvOtorgantes.DataBind();
                txNombreO.Text = "";
                txPaternoO.Text = "";
                txMaternoO.Text = "";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes escribir nombre Completo del Otorgante')", true);
            }
        }

        protected void btAgregarAnotacion_Click(object sender, EventArgs e)
        {
            if ((txLTM.Text.Equals("") && ddlSemestreM.SelectedIndex == -1) && txPartidaM.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes llenar los datos necesarios para una anotacion marginal.')", true);
            }
            else
            {

                DataTable Temporal = (DataTable)Session["tablaAnotaciones"];

                if (Temporal.Rows[0][0].ToString().Equals("")) { Temporal.Rows.Clear(); }
                DataRow dr = Temporal.NewRow();
                dr["Id"] = Temporal.Rows.Count + 1;

                if (ddlLTSM.SelectedValue.Equals("Libro")) dr["Libro"] = txLTM.Text;
                if (ddlLTSM.SelectedValue.Equals("Tomo")) dr["Tomo"] = txLTM.Text;
                if (ddlLTSM.SelectedValue.Equals("Semestre"))
                {
                    dr["Semestre"] = ddlSemestreM.SelectedValue.ToString();
                    dr["Año"] = txASemM.Text;
                }
                else
                {
                    dr["Seccion"] = ddlSeccionM.SelectedValue.ToString();
                    dr["Serie"] = ddlSerieM.SelectedValue.ToString();
                }
                dr["Partida"] = txPartidaM.Text;
                Temporal.Rows.Add(dr);
                Session["tablaAnotaciones"] = Temporal;
                gvAnotaciones.DataSource = Temporal;
                gvAnotaciones.DataBind();
                if (ddlLTSM.SelectedValue.Equals("Semestre"))
                {
                    ddlSemestreM.SelectedIndex = 0;
                    txASemM.Text = "";
                }
                else
                {
                    ddlSeccionM.SelectedIndex = 0;
                    ddlSerieM.SelectedIndex = 0;
                }
                txPartidaM.Text = "";
                txLTM.Text = "";
            }
        }

        protected void gvAnotaciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable Temporal = (DataTable)Session["tablaAnotaciones"];
            int id = e.RowIndex;
            Temporal.Rows.RemoveAt(id);
            if (Temporal.Rows.Count == 0)
            {
                DataRow dr = Temporal.NewRow();
                dr["Id"] = string.Empty;
                Temporal.Rows.Add(dr);
            }
            Session["tablaAnotaciones"] = Temporal;
            gvAnotaciones.DataSource = Temporal;
            gvAnotaciones.DataBind();
        }
  
        #endregion

        #region DropDownList
        protected void ddlLTSR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLTSM.SelectedValue.Equals("Semestre"))
            {
                txLTM.Visible = false;
                ddlSemestreM.Visible = true;
                lbASemM.Visible = true;
                txASemM.Visible = true;
                lbSeccionM.Visible = false;
                ddlSeccionM.Visible = false;
                lbSerieM.Visible = false;
                ddlSerieM.Visible = false;
            }
            else
            {
                txLTM.Visible = true;
                ddlSemestreM.Visible = false;
                lbASemM.Visible = false;
                txASemM.Visible = false;
                lbSeccionM.Visible = true;
                ddlSeccionM.Visible = true;
                lbSerieM.Visible = true;
                ddlSerieM.Visible = true;
            }
        }

        protected void ddlMunicipios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPoblaciones.Items.Clear();
            foreach (Poblacion item in main.Poblaciones.CatalogoPorMunicipio(int.Parse(ddlMunicipios.SelectedValue.ToString())))
            {
                ListItem l = new ListItem();
                l.Text = item.Nombre;
                l.Value = item.ClavePoblacion.ToString();
                ddlPoblaciones.Items.Add(l);
            }
            if (ddlMunicipios.SelectedValue.Equals("17"))
            {
                ddlColonia.Items.Clear();
                ddlColonia.Items.Add("Colonia:");
                foreach (Ubicacion item in Ubicacion.ListaColonias())
                {
                    ListItem l = new ListItem();
                    l.Text = item.Colonia;
                    l.Value = item.IdColonia.ToString();
                    ddlColonia.Items.Add(l);
                }
            }
            else
            {
                ddlColonia.Items.Clear();
                ddlCalle.Items.Clear();
            }

        }

        protected void ddlColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCalle.Items.Clear();
            int idcol= 0;
            
            if (int.TryParse(ddlColonia.SelectedValue.ToString(), out idcol)) 
            {
                ddlCalle.Items.Add("Calle:");
                foreach (Ubicacion item in Ubicacion.ListaCalles(idcol))
                {
                    ListItem l = new ListItem();
                    l.Text = item.Calle;
                    l.Value = item.Calle;
                    ddlCalle.Items.Add(l);
                }
            }
            
        }

        protected void ddlCalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlNum.Items.Clear();
            ddlNum.Items.Add("Numero:");
            foreach (Ubicacion item in Ubicacion.ListaNumerosCalles(ddlCalle.SelectedValue.ToString()))
            {
                ListItem l = new ListItem();
                l.Text = item.Numero;
                l.Value = item.IdNumero.ToString();
                ddlNum.Items.Add(l);
            }
        }
        #endregion
        protected void llenarListaMovimientos()
        {
            //Session["REGISTRO"] = "1";
            if (Session["IDPRELACION"] != null)
            {
                string[] datos = Session["IDPRELACION"].ToString().Split(';');
                if (datos.Length == 2)
                {
                    listamovimientos = Prelacion.ObtenerMovimientosPrelacion(int.Parse(datos[0]), "REVISION");                    
                }
                else
                    listamovimientos = Prelacion.ObtenerMovimientosPrelacion(int.Parse(Session["IDPRELACION"].ToString()), "");


                txIdPrelacion.Text = datos[0];
                radbMovimientos.Items.Clear();
                ddlSeccion.Items.Clear();
                ddlSeccion.Items.Add("Elige una Seccion");
                foreach (Movimientos var in listamovimientos)
                {
                    ListItem l = new ListItem();
                    l.Text = var.Nombre;
                    l.Value = var.ClavePrelacionActo.ToString();
                    radbMovimientos.Items.Add(l);
                }
            }
            else
            {
                Server.Transfer("Registro.aspx");
            }
        }
        protected RegistroActo armarRegistro(String idPrelacion, String seccion)
        {
            RegistroActo registro = new RegistroActo();

            int tidcalle = 0,tidcolonia=0,tidnumero=0;
            int.TryParse(ddlColonia.SelectedValue.ToString(), out tidcolonia);
            if (ddlCalle.SelectedIndex!=-1)
            int.TryParse(Ubicacion.ListaCalles(tidcolonia).ElementAt(ddlCalle.SelectedIndex).IdCalle.ToString(), out tidcalle);
            int.TryParse(ddlNum.SelectedValue.ToString(), out tidnumero);
            
            registro.IdPrelacionActo = int.Parse(idPrelacion);
            registro.Folio = "Folio";
            registro.TipoPredio = txTipoPredio.Text;
            registro.Superficie = txSuperficie.Text;
            registro.UnidadSuperficie = ddlUnidadSup.SelectedValue.ToString();
            registro.UbicacionInmuebleCalle = tidcalle;
            registro.UbicacionInmuebleColonia = tidcolonia;
            registro.UbicacionInmuebleNumero = tidnumero;
            registro.ColoniaTexto = txColonia.Text;
            registro.CalleTexto = txCalle.Text;
            registro.NumeroExterior = txExterior.Text;
            registro.NumeroInterior = txInterior.Text;
            registro.Manzana = txManzana.Text;
            registro.Lote = txLote.Text;
            registro.Municipio = int.Parse(ddlMunicipios.SelectedValue.ToString());
            registro.Poblacion = int.Parse(ddlPoblaciones.SelectedValue.ToString());
            registro.ClaveCatastral = txClaveCat.Text;
            registro.Norte = txNorte.Text;
            registro.Sur = txSur.Text;
            registro.Este = txEste.Text;
            registro.Oeste = txOeste.Text;
            registro.Noreste = txNoreste.Text;
            registro.Noroeste = txNoroeste.Text;
            registro.Sureste = txSureste.Text;
            registro.Suroeste = txSuroeste.Text;
            registro.FechaRegistro = txFechaReg.Text;
            registro.RegistroActual = new Antecedente();
            registro.RegistroActual.Libro = txLibroR.Text;
            registro.RegistroActual.Seccion = ddlSeccionR.SelectedValue.ToString();
            registro.RegistroActual.Partida = txPartidaR.Text;
            registro.RegistroActual.Serie = ddlSerie.SelectedValue.ToString();
            registro.Observaciones = txObservaciones.InnerText.ToString();
            registro.AnotacionActualizada = txAnotacionActualizada.InnerText.ToString();
            //agregar otorgantes
            DataTable Temporal = (DataTable)Session["tablaOt"];
            registro.Otorgantes = new List<Persona>();
            foreach (DataRow row in Temporal.Rows)
            {
                Persona per = new Persona();
                per.Nombre = row["Nombre"].ToString();
                per.Paterno = row["Paterno"].ToString();
                per.Materno = row["Materno"].ToString();
                registro.Otorgantes.Add(per);
            }
            //agregar adquirientes
            DataTable Temporal2 = (DataTable)Session["tablaAd"];
            registro.Adquirientes = new List<Persona>();
            foreach (DataRow row in Temporal2.Rows)
            {
                Persona per = new Persona();
                per.Nombre = row["Nombre"].ToString();
                per.Paterno = row["Paterno"].ToString();
                per.Materno = row["Materno"].ToString();
                registro.Adquirientes.Add(per);
            }
            //agregar anotaciones marginales
            DataTable Temporal3 = (DataTable)Session["tablaAnotaciones"];
            registro.AnotacionesMarginales = new List<Antecedente>();
            foreach (DataRow row in Temporal3.Rows)
            {
                Antecedente ant = new Antecedente();
                ant.Libro = row["Libro"].ToString();
                ant.Tomo = row["Tomo"].ToString();
                ant.Seccion = row["Seccion"].ToString();
                ant.Serie = row["Serie"].ToString();
                ant.Semestre = row["Semestre"].ToString();
                ant.Año = row["Año"].ToString();
                ant.Partida = row["Partida"].ToString();
                registro.AnotacionesMarginales.Add(ant);
            }

            // id_prelacion_acto ; seccion
            switch (seccion)
            {
                case "2":
                    registro.TipoPredio = "";
                    registro.AnotacionesMarginales.Clear();
                    break;
                case "3-1":
                    registro.Superficie = "";
                    registro.UnidadSuperficie = "";
                    registro.Norte = "";
                    registro.Sur = "";
                    registro.Este = "";
                    registro.Oeste = "";
                    registro.Noreste = "";
                    registro.Noroeste = "";
                    registro.Sureste = "";
                    registro.Suroeste = "";
                    break;
                case "3-2":
                    registro.TipoPredio = "";
                    registro.Superficie = "";
                    registro.UnidadSuperficie = "";
                    registro.UbicacionInmuebleCalle = 0;
                    registro.UbicacionInmuebleColonia = 0;
                    registro.UbicacionInmuebleNumero = 0;
                    registro.ColoniaTexto = "";
                    registro.CalleTexto = "";
                    registro.NumeroExterior = "";
                    registro.NumeroInterior = "";
                    registro.Manzana = "";
                    registro.Lote = "";
                    registro.Norte = "";
                    registro.Sur = "";
                    registro.Este = "";
                    registro.Oeste = "";
                    registro.Noreste = "";
                    registro.Noroeste = "";
                    registro.Sureste = "";
                    registro.Suroeste = "";
                    break;
                case "4":
                    registro.TipoPredio = "";
                    registro.Superficie = "";
                    registro.UnidadSuperficie = "";
                    registro.UbicacionInmuebleCalle = 0;
                    registro.UbicacionInmuebleColonia = 0;
                    registro.UbicacionInmuebleNumero = 0;
                    registro.ColoniaTexto = "";
                    registro.CalleTexto = "";
                    registro.NumeroExterior = "";
                    registro.NumeroInterior = "";
                    registro.Manzana = "";
                    registro.Lote = "";
                    registro.Norte = "";
                    registro.Sur = "";
                    registro.Este = "";
                    registro.Oeste = "";
                    registro.Noreste = "";
                    registro.Noroeste = "";
                    registro.Sureste = "";
                    registro.Suroeste = "";
                    registro.Adquirientes.Clear();
                    break;
            }

            return registro;
        }

        protected void btCancelarRegistro_Click(object sender, EventArgs e)
        {
            Session["REGISTRO"] = null;
            Session["IDPRELACION"] = null;
            Response.Redirect("Registro.aspx");
        }

        private void obtenerAntecedentes()
        {
            List<Antecedente> antecedentes = new List<Antecedente>();
            antecedentes = Prelacion.ObtenerAntecedentesPrelacion(prelacionElegida.IdPrelacion);

            gvAntecedentes.DataSource = antecedentes;
            gvAntecedentes.DataBind();

            HttpContext.Current.Session.Add("prelacionElegida", prelacionElegida);
        }

        protected void gvAntecedentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String libro = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[1].Text;
            String tomo = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[2].Text;
            String seccion = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[3].Text;
            String serie = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[4].Text;
            String semestre = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[5].Text;
            String anio = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[6].Text;
            String partida = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[7].Text;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('PreDocumento.aspx?libro=" + libro + "&tomo=" + tomo + "&semestre=" + semestre + "&anio=" + anio + "&seccion=" + seccion + "&serie=" + serie + "&partida=" + partida + "','_blank')", true);
        }
    }
}