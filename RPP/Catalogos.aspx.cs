using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;

namespace RPP
{
    public partial class Catalogos : System.Web.UI.Page
    {

        private List<Usuario> listaUsuarios;
        private List<Tramitante> listaTramitantes;
        private RPPMain.Main main = new RPPMain.Main();

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
                if (currentUser.IdTipoUsuario != 1)
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
                listaUsuarios = new List<Usuario>();
                listaTramitantes = new List<Tramitante>();

                #region Cargar GridViews Inicial
                //Llenar el datasource para mostrar el catalogo de Areas de Trabajo.
                gvAreasTrabajo.DataSource = main.AreasTrabajo.Catalogo();
                gvAreasTrabajo.DataBind();

                //Llenar el datasource para mostrar el catalogo de Actos Juridicos.
                gvActos.DataSource = main.Actos.Catalogo();
                gvActos.DataBind();

                //Llenar el datasource para mostrar el catalogo de Tarifas.
                gvTarifas.DataSource = main.Tarifas.Catalogo();
                gvTarifas.DataBind();

                //Llenar el datasource para mostrar el catalogo de Estatus.
                gvEstatus.DataSource = main.Estatus.Catalogo();
                gvEstatus.DataBind();

                //Llenar el datasource para mostrar el catalogo de TiposFolio.
                gvTiposFolio.DataSource = main.Folios.Catalogo();
                gvTiposFolio.DataBind();

                //Llenar el datasource para mostrar el catalogo de Municipios.
                gvMunicipios.DataSource = main.Municipios.Catalogo();
                gvMunicipios.DataBind();

                //Llenar el datasource para mostrar el catalogo de Parametros.
                gvParametros.DataSource = main.Parametros.Catalogo();
                gvParametros.DataBind();

                //Llenar el datasource para mostrar el catalogo de Secciones de Archivo.
                gvSecciones.DataSource = main.Secciones.Catalogo();
                gvSecciones.DataBind();

                #endregion

                #region Cargar DropDownList Inicial
                //Llenar el dropdownlist de usuarios
                listaUsuarios = main.Usuarios.Catalogo();
                foreach (Usuario var in listaUsuarios)
                {
                    ListItem l = new ListItem();
                    l.Text = var.Login;
                    l.Value = var.IdUsuario.ToString();
                    ddlUsuarios.Items.Add(l);
                }

                //Llenar el dropdownlist de tramitantes
                listaTramitantes = main.Tramitantes.Catalogo();
                foreach (Tramitante var in listaTramitantes)
                {
                    ListItem l = new ListItem();
                    l.Text = var.Nombre + " " + var.ApellidoPaterno + " " + var.ApellidoMaterno;
                    l.Value = var.Clave.ToString();
                    ddlTramitantes.Items.Add(l);
                }

                //Llenar el dropdownlist de los tipos de usuarios
                foreach (TipoUsuario var in main.TiposUsuario.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = var.Tipo;
                    l.Value = var.Clave.ToString();
                    ddlTiposUsuario.Items.Add(l);
                }

                //Llenar el dropdownlist de los Actos
                foreach (Acto var in main.Actos.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = var.Nombre;
                    l.Value = var.ClaveActo.ToString();
                    ddlActos.Items.Add(l);
                }

                //Llenar el dropdownlist de municipios para el formulario de usuarios
                foreach (Municipio item in main.Municipios.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = item.Nombre;
                    l.Value = item.Clave.ToString();
                    ddlFMunicipios.Items.Add(l);
                    ddlFMunicipios.SelectedIndex = 0;
                }

                //Llenar el dropdownlist de municipios para el formulario de usuarios
                foreach (Municipio item in main.Municipios.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = item.Nombre;
                    l.Value = item.Clave.ToString();
                    ddlMunicipios.Items.Add(l);
                    ddlMunicipioT.Items.Add(l);
                }

                //Llenar el dropdownlist de poblaciones para el formulario de usuarios
                foreach (Poblacion item in main.Poblaciones.CatalogoPorMunicipio(1))
                {
                    ListItem l = new ListItem();
                    l.Text = item.Nombre;
                    l.Value = item.ClavePoblacion.ToString();
                    ddlPoblaciones.Items.Add(l);
                    ddlPoblacionT.Items.Add(l);
                }
                #endregion
            }
            else
            {
                listaUsuarios = new List<Usuario>();
                listaUsuarios = main.Usuarios.Catalogo();

                listaTramitantes = new List<Tramitante>();
                listaTramitantes = main.Tramitantes.Catalogo();
           }
        }

        #region SelectIndexChanged DropDownList
        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Traer la informacion del usuario seleccionado al formulario.
            Usuario u = new Usuario();
            u = listaUsuarios.First(item => item.IdUsuario == int.Parse(ddlUsuarios.SelectedValue));
            txNombre.Text = u.Nombre;
            txAMaterno.Text = u.ApellidoMaterno;
            txAPaterno.Text = u.ApellidoPaterno;
            txLogin.Text = u.Login;
            txPassword.Text = u.Password;
            txRFC.Text = u.Rfc;
            txCURP.Text = u.Curp;
            txEstatus.Text = u.Estatus;
            //txNacimiento.Text = DateTime.Parse(u.FechaNacimiento).ToString("yyyy-MM-dd");
            txTelefono1.Text = u.Telefono1;
            txTelefono2.Text = u.Telefono2;
            txControl.Text = u.NoControl;
            txCalle.Text = u.Calle;
            txColonia.Text = u.Colonia;
            txCodigoPostal.Text = u.CodigoPostal;
            ddlTiposUsuario.SelectedValue = u.IdTipoUsuario.ToString();
            ddlMunicipios.SelectedValue = u.Municipio.ToString();
            llenarPoblaciones(ddlMunicipios);
            ddlPoblaciones.SelectedValue = u.Poblacion.ToString();
        }
        protected void ddlTramitantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Traer la informacion del Tramitante seleccionado al formulario.
            Tramitante t = new Tramitante();
            t = listaTramitantes.First(item => item.Clave == int.Parse(ddlTramitantes.SelectedValue));
            txNombreT.Text = t.Nombre;
            txAMaternoT.Text = t.ApellidoMaterno;
            txAPaternoT.Text = t.ApellidoPaterno;
            txRazonSocialT.Text = t.RazonSocial;
            txRfcT.Text = t.Rfc;
            txCurpT.Text = t.Curp;
            txCalleT.Text = t.Calle;
            txNumeroT.Text = t.Numero;
            txColoniaT.Text = t.Colonia;
            txCodigoT.Text = t.CodigoPostal;
            txEstadoT.Text = t.Estado;
            txLNotariaT.Text = t.LNotaria;
            txNotariaT.Text = t.NumNotaria;
            txTipoT.Text = t.TipoTramitante;
            txTelefonoT.Text = t.Telefono;
            txFaxT.Text = t.Fax;
            txExtensionT.Text = t.Extension;
            ddlMunicipioT.SelectedValue = t.Municipio;
            llenarPoblaciones(ddlMunicipioT);
            ddlPoblacionT.SelectedValue = t.Poblacion;

            btGuardarT.Visible = false;
            btActualizarT.Visible = true;

        }
        protected void ddlMunicipios_SelectedIndexChanged(object sender, EventArgs e)
        {   //Filtrado de Poblaciones por Municipio seleccionado del dropdownlist
            llenarPoblaciones(sender);
        }

        protected void ddlActos_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvMovimientos.DataSource = main.Movimientos.Catalogo(int.Parse(ddlActos.SelectedValue.ToString()));
            gvMovimientos.DataBind();
            if (gvMovimientos.Rows.Count == 0)
            {
                gvMovimientos.DataSource = new[]
                      {
                       new{
                        Clave = string.Empty,
                        Nombre = string.Empty ,
                        Folio = string.Empty,
                        //mas cosas
                       }
                      };
                gvMovimientos.DataBind();
            }
        }

        protected void ddlFMunicipios_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvPoblaciones.DataSource = main.Poblaciones.CatalogoPorMunicipio(int.Parse(ddlFMunicipios.SelectedValue.ToString()));
            gvPoblaciones.DataBind();
        }
        #endregion

        #region Paginacion GridViews
        protected void gvPoblaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPoblaciones.PageIndex = e.NewPageIndex;
            gvPoblaciones.DataSource = main.Poblaciones.CatalogoPorMunicipio(int.Parse(ddlFMunicipios.SelectedValue.ToString()));
            gvPoblaciones.DataBind();
        }
        protected void gvEstatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEstatus.PageIndex = e.NewPageIndex;
            gvEstatus.DataSource = main.Estatus.Catalogo();
            gvEstatus.DataBind();
        }
        protected void gvAreasTrabajo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAreasTrabajo.PageIndex = e.NewPageIndex;
            gvAreasTrabajo.DataSource = main.AreasTrabajo.Catalogo();
            gvAreasTrabajo.DataBind();
        }
        protected void gvMovimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMovimientos.PageIndex = e.NewPageIndex;
            gvMovimientos.DataSource = main.Movimientos.Catalogo();
            gvMovimientos.DataBind();
        }
        protected void gvParametros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvParametros.PageIndex = e.NewPageIndex;
            gvParametros.DataSource = main.Parametros.Catalogo();
            gvParametros.DataBind();
        }
        protected void gvTarifas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTarifas.PageIndex = e.NewPageIndex;
            gvTarifas.DataSource = main.Tarifas.Catalogo();
            gvTarifas.DataBind();
        }
        protected void gvActos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvActos.PageIndex = e.NewPageIndex;
            gvActos.DataSource = main.Actos.Catalogo();
            gvActos.DataBind();
        }
        #endregion

        #region GridViews Funciones Datos
        protected void gvEstatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Estatus es = new Estatus();

            if (e.CommandName.Equals("AGREGAR"))
            {
                TextBox txtNombreEstatus = (TextBox)gvEstatus.FooterRow.FindControl("txNombreEstatus");

                String Resultado = es.GuardarNuevo(txtNombreEstatus.Text.ToUpper());

                gvEstatus.DataSource = main.Estatus.Catalogo();
                gvEstatus.DataBind();
                if (Resultado.Equals("OK")){ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos agregados Correctamente')", true);}
            }
        }
        protected void gvEstatus_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Estatus es = new Estatus();

            Label txId = (Label)gvEstatus.Rows[e.RowIndex].FindControl("lbEditClave");
            TextBox txNombre = (TextBox)gvEstatus.Rows[e.RowIndex].FindControl("txEditNombre");

            String Resultado = es.Actualizar(int.Parse(txId.Text), txNombre.Text.ToUpper());

            gvEstatus.EditIndex = -1;
            gvEstatus.DataSource = main.Estatus.Catalogo();
            gvEstatus.DataBind();
            if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos actualizados Correctamente')", true); }
        }

        protected void gvMunicipios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AGREGAR"))
            {
                Municipio m = new Municipio();

                TextBox txtNombreMunicipio= (TextBox)gvMunicipios.FooterRow.FindControl("txNombreMunicipio");

                String Resultado = m.GuardarNuevo(txtNombreMunicipio.Text.ToUpper());

                gvMunicipios.DataSource = main.Municipios.Catalogo();
                gvMunicipios.DataBind();
                if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos agregados Correctamente')", true); }
            }
        }
        protected void gvMunicipios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Municipio m = new Municipio();

            Label txId = (Label)gvMunicipios.Rows[e.RowIndex].FindControl("lbEditClave");
            TextBox txNombre = (TextBox)gvMunicipios.Rows[e.RowIndex].FindControl("txEditNombre");

            String Resultado = m.Actualizar(int.Parse(txId.Text), txNombre.Text.ToUpper());

            gvMunicipios.EditIndex = -1;
            gvMunicipios.DataSource = main.Municipios.Catalogo();
            gvMunicipios.DataBind();
            if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos actualizados Correctamente')", true); }
        }
        
        protected void gvTiposFolio_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AGREGAR"))
            {
                TipoFolio tf = new TipoFolio();

                TextBox txtNombreEstatus = (TextBox)gvTiposFolio.FooterRow.FindControl("txNombreTipoFolio");

                String Resultado = tf.GuardarNuevo(txtNombreEstatus.Text.ToUpper());

                gvTiposFolio.DataSource = main.Folios.Catalogo();
                gvTiposFolio.DataBind();
                if (Resultado.Equals("OK")){ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos agregados Correctamente')", true);}
            }
        }
        protected void gvTiposFolio_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TipoFolio tf = new TipoFolio();

            Label txId = (Label)gvTiposFolio.Rows[e.RowIndex].FindControl("lbEditClave");
            TextBox txNombre = (TextBox)gvTiposFolio.Rows[e.RowIndex].FindControl("txEditNombre");

            String Resultado = tf.Actualizar(int.Parse(txId.Text), txNombre.Text.ToUpper());

            gvTiposFolio.EditIndex = -1;
            gvTiposFolio.DataSource = main.Folios.Catalogo();
            gvTiposFolio.DataBind();
            if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos actualizados Correctamente')", true); }
        }
        
        protected void gvAreasTrabajo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AGREGAR"))
            {
                AreaTrabajo at = new AreaTrabajo();

                TextBox txtNombreArea = (TextBox)gvAreasTrabajo.FooterRow.FindControl("txNombreArea");

                String Resultado = at.GuardarNuevo(txtNombreArea.Text.ToUpper(), "");

                gvAreasTrabajo.DataSource = main.AreasTrabajo.Catalogo();
                gvAreasTrabajo.DataBind();
                if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos agregados Correctamente')", true); }
            }
        }
        protected void gvAreasTrabajo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            AreaTrabajo at = new AreaTrabajo();

            Label txId = (Label)gvAreasTrabajo.Rows[e.RowIndex].FindControl("lbEditClave");
            TextBox txNombre = (TextBox)gvAreasTrabajo.Rows[e.RowIndex].FindControl("txEditNombre");

            String Resultado = at.Actualizar(int.Parse(txId.Text), txNombre.Text.ToUpper(), "");

            gvAreasTrabajo.EditIndex = -1;
            gvAreasTrabajo.DataSource = main.AreasTrabajo.Catalogo();
            gvAreasTrabajo.DataBind();
            if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos actualizados Correctamente')", true); }
        }

        protected void gvParametros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AGREGAR"))
            {
                Parametro p = new Parametro();
                TextBox txtNombreParametro = (TextBox)gvParametros.FooterRow.FindControl("txNombreParametro");
                TextBox txtValorN = (TextBox)gvParametros.FooterRow.FindControl("txValorNumero");
                TextBox txtValorC = (TextBox)gvParametros.FooterRow.FindControl("txValorCaracter");

                String Resultado = p.GuardarNuevo(txtNombreParametro.Text.ToUpper(), txtValorN.Text, txtValorC.Text.ToUpper());

                gvParametros.DataSource = main.Parametros.Catalogo();
                gvParametros.DataBind();
                if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos agregados Correctamente')", true); }
            }
        }
        protected void gvParametros_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Parametro p = new Parametro();
            Label txId = (Label)gvParametros.Rows[e.RowIndex].FindControl("lbEditClave");
            TextBox txNombre = (TextBox)gvParametros.Rows[e.RowIndex].FindControl("txEditNombre");
            TextBox txtValorN = (TextBox)gvParametros.Rows[e.RowIndex].FindControl("txEditValorn");
            TextBox txtValorC = (TextBox)gvParametros.Rows[e.RowIndex].FindControl("txEditValorc");

            String Resultado = p.Actualizar(int.Parse(txId.Text), txNombre.Text.ToUpper(), txtValorN.Text, txtValorC.Text.ToUpper());
            gvParametros.EditIndex = -1;
            gvParametros.DataSource = main.Parametros.Catalogo();
            gvParametros.DataBind();
            if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos actualizados Correctamente')", true); }
        }

        protected void gvPoblaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AGREGAR"))
            {
                Poblacion p = new Poblacion();

                int idMunicipio = int.Parse(ddlFMunicipios.SelectedValue.ToString());
                TextBox txtNombrePob = (TextBox)gvPoblaciones.FooterRow.FindControl("txNombrePoblacion");
                TextBox txtAmbito = (TextBox)gvPoblaciones.FooterRow.FindControl("txAmbito");

                String Resultado = p.GuardarNuevo(idMunicipio, txtNombrePob.Text.ToUpper(), txtAmbito.Text.ToUpper());

                gvPoblaciones.DataSource = main.Poblaciones.CatalogoPorMunicipio(idMunicipio);
                gvPoblaciones.DataBind();
                if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos agregados Correctamente')", true); }
            }
        }
        protected void gvPoblaciones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Poblacion p = new Poblacion();

            int idMunicipio = int.Parse(ddlFMunicipios.SelectedValue.ToString());
            Label txId = (Label)gvPoblaciones.Rows[e.RowIndex].FindControl("lbEditClave");
            TextBox txNombre = (TextBox)gvPoblaciones.Rows[e.RowIndex].FindControl("txEditNombre");
            TextBox txtAmbito = (TextBox)gvPoblaciones.Rows[e.RowIndex].FindControl("txEditAmbito");

            String Resultado = p.Actualizar(int.Parse(txId.Text), idMunicipio, txNombre.Text.ToUpper(), txtAmbito.Text.ToUpper());


            gvPoblaciones.EditIndex = -1;
            gvPoblaciones.DataSource = main.Poblaciones.CatalogoPorMunicipio(idMunicipio);
            gvPoblaciones.DataBind();
            if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos actualizados Correctamente')", true); }
        }

        protected void gvSecciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AGREGAR"))
            {
                SeccionArchivo sa = new SeccionArchivo();
                TextBox txtNombreSec = (TextBox)gvSecciones.FooterRow.FindControl("txNombreSeccion");
                TextBox txtDescripcion = (TextBox)gvSecciones.FooterRow.FindControl("txDescripcion");

                String Resultado = sa.GuardarNuevo(txtNombreSec.Text.ToUpper(), txtDescripcion.Text.ToUpper());

                gvSecciones.DataSource = main.Secciones.Catalogo();
                gvSecciones.DataBind();
                if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos agregados Correctamente')", true); }
            }
        }
        protected void gvSecciones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SeccionArchivo sa = new SeccionArchivo();

            Label txId = (Label)gvPoblaciones.Rows[e.RowIndex].FindControl("lbEditClave");
            TextBox txtNombreSec = (TextBox)gvPoblaciones.Rows[e.RowIndex].FindControl("txEditNombre");
            TextBox txtDescripcion = (TextBox)gvPoblaciones.Rows[e.RowIndex].FindControl("txEditDescripcion");

            String Resultado = sa.Actualizar(int.Parse(txId.Text), txtNombreSec.Text.ToUpper(), txtDescripcion.Text.ToUpper());
            
            gvSecciones.EditIndex = -1;
            gvSecciones.DataSource = main.Secciones.Catalogo();
            gvSecciones.DataBind();
            if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos actualizados Correctamente')", true); }
        }

        protected void gvTarifas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AGREGAR"))
            {
                Tarifa t = new Tarifa();

                DropDownList ddlActo = (DropDownList)gvTarifas.FooterRow.FindControl("ddlEditActo");
                String txtIngresos = ((TextBox)gvTarifas.FooterRow.FindControl("txClaveIngresos")).Text;
                String txtDescuento = ((TextBox)gvTarifas.FooterRow.FindControl("txDescuento")).Text.Replace('.', ',');
                String txtPorcentaje = ((TextBox)gvTarifas.FooterRow.FindControl("txPorcentaje")).Text.Replace('.', ',');
                String txtMinimo = ((TextBox)gvTarifas.FooterRow.FindControl("txSmMinimo")).Text.Replace('.', ',');
                String txtMaximo = ((TextBox)gvTarifas.FooterRow.FindControl("txSmMaximo")).Text.Replace('.', ',');
                String txtFijo = ((TextBox)gvTarifas.FooterRow.FindControl("txSmFijo")).Text.Replace('.', ',');

                String claveActo = Tarifa.ObtenerClaveActoPorId(ddlActo.SelectedValue);

                String Resultado = t.GuardarNuevo(int.Parse(claveActo), txtIngresos, Convert.ToDecimal(txtDescuento), Convert.ToDecimal(txtPorcentaje), Convert.ToDecimal(txtMinimo), Convert.ToDecimal(txtMaximo), Convert.ToDecimal(txtFijo));

                gvTarifas.DataSource = main.Tarifas.Catalogo();
                gvTarifas.DataBind();
                if (Resultado.Equals("OK")){ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos agregados Correctamente')", true);}
            }
        }
        protected void gvTarifas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Tarifa t = new Tarifa();

            Label txId = (Label)gvTarifas.Rows[e.RowIndex].FindControl("lbEditClave");
            DropDownList ddlActo = (DropDownList)gvTarifas.Rows[e.RowIndex].FindControl("ddlEditActo");
            TextBox txtIngresos = (TextBox)gvTarifas.Rows[e.RowIndex].FindControl("txEditClaveIngresos");
            String txtDescuento = ((TextBox)gvTarifas.Rows[e.RowIndex].FindControl("txEditDescuento")).Text.Replace('.', '.');
            String txtPorcentaje = ((TextBox)gvTarifas.Rows[e.RowIndex].FindControl("txEditPorcentaje")).Text.Replace('.', '.');
            String txtMinimo = ((TextBox)gvTarifas.Rows[e.RowIndex].FindControl("txEditSmMinimo")).Text.Replace('.', '.');
            String txtMaximo = ((TextBox)gvTarifas.Rows[e.RowIndex].FindControl("txEditSmMaximo")).Text.Replace('.', '.');
            String txtFijo = ((TextBox)gvTarifas.Rows[e.RowIndex].FindControl("txEditSmFijo")).Text.Replace('.', '.');

            String Resultado = t.Actualizar(int.Parse(txId.Text), int.Parse(ddlActo.SelectedValue), txtIngresos.Text, Convert.ToDecimal(txtDescuento), Convert.ToDecimal(txtPorcentaje), Convert.ToDecimal(txtMinimo), Convert.ToDecimal(txtMaximo), Convert.ToDecimal(txtFijo));

            gvTarifas.EditIndex = -1;
            gvTarifas.DataSource = main.Tarifas.Catalogo();
            gvTarifas.DataBind();
            if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos actualizados Correctamente')", true); }
        }
        protected void gvTarifas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvTarifas.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlActos = (DropDownList)e.Row.FindControl("ddlEditActo");
                foreach (Acto var in main.Actos.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = var.Nombre;
                    l.Value = var.ClaveActo.ToString();
                    ddlActos.Items.Add(l);
                }
                ddlActos.Items.FindByValue((e.Row.FindControl("txEditActo") as Label).Text).Selected = true;
            }
        }
        protected void gvTarifas_DataBound(object sender, EventArgs e)
        {
            GridViewRow footrow = gvTarifas.FooterRow;
            if (footrow != null)
            {
                DropDownList ddlActos = (DropDownList)footrow.FindControl("ddlEditActo");
                foreach (Acto var in main.Actos.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = var.Nombre;
                    l.Value = var.Clave.ToString();
                    ddlActos.Items.Add(l);
                }
            }
        }

        protected void gvActos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AGREGAR"))
            {
                Acto a = new Acto();

                TextBox txtClave = (TextBox)gvActos.FooterRow.FindControl("txClaveActo");
                TextBox txtClaveI = (TextBox)gvActos.FooterRow.FindControl("txClaveIngresos");
                TextBox txtNombre = (TextBox)gvActos.FooterRow.FindControl("txNombreActo");
                TextBox txtCuenta = (TextBox)gvActos.FooterRow.FindControl("txCuenta");
                DropDownList txArea = (DropDownList)gvActos.FooterRow.FindControl("ddlEditArea");
                CheckBoxList cbsecciones = (CheckBoxList)gvActos.FooterRow.FindControl("cblSeccion");
                String secciones = "";
                foreach (ListItem item in cbsecciones.Items)
                    if (item.Selected) secciones += item.Value + ";";

                String Resultado = a.GuardarNuevo(int.Parse(txtClave.Text), txtClaveI.Text, txtNombre.Text.ToUpper(), txtCuenta.Text, int.Parse(txArea.SelectedValue),secciones);

                gvActos.DataSource = main.Actos.Catalogo();
                gvActos.DataBind();
                if (Resultado.Equals("OK"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos agregados Correctamente')", true);
                }
                
            }
        }
        protected void gvActos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Acto a = new Acto();

            Label txId = (Label)gvActos.Rows[e.RowIndex].FindControl("lbEditClave");
            TextBox txClaveActo = (TextBox)gvActos.Rows[e.RowIndex].FindControl("txEditClaveActo");
            TextBox txClaveIngresos = (TextBox)gvActos.Rows[e.RowIndex].FindControl("txEditClaveIngresos");
            TextBox txNombre = (TextBox)gvActos.Rows[e.RowIndex].FindControl("txEditNombre");
            TextBox txCuenta = (TextBox)gvActos.Rows[e.RowIndex].FindControl("txEditCuenta");
            DropDownList txArea = (DropDownList)gvActos.Rows[e.RowIndex].FindControl("ddlEditArea");
            CheckBoxList cbsecciones = (CheckBoxList)gvActos.FooterRow.FindControl("cblSeccion");
            String secciones = "";
            foreach (ListItem item in cbsecciones.Items)
                if (item.Selected) secciones += item.Value + ";";

            String Resultado = a.Actualizar(int.Parse(txId.Text), int.Parse(txClaveActo.Text), txClaveIngresos.Text, txNombre.Text.ToUpper(), txCuenta.Text, int.Parse(txArea.SelectedValue),secciones);

            gvActos.EditIndex = -1;
            gvActos.DataSource = main.Actos.Catalogo();
            gvActos.DataBind();
            if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos actualizados Correctamente')", true); }
        }
        protected void gvActos_DataBound(object sender, EventArgs e)
        {
            GridViewRow footrow = gvActos.FooterRow;
            if (footrow != null)
            {
                DropDownList ddlAreas = (DropDownList)footrow.FindControl("ddlEditArea");
                foreach (AreaTrabajo var in main.AreasTrabajo.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = var.Nombre;
                    l.Value = var.Clave.ToString();
                    ddlAreas.Items.Add(l);
                }
                CheckBoxList cblSecciones = (CheckBoxList)footrow.FindControl("cblSeccion");
                foreach (SeccionArchivo var in main.Secciones.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = var.Nombre;
                    l.Value = var.Nombre;
                    cblSecciones.Items.Add(l);
                }
            }
        }
        protected void gvActos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvActos.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlAreas = (DropDownList)e.Row.FindControl("ddlEditArea");
                foreach (AreaTrabajo var in main.AreasTrabajo.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = var.Nombre;
                    l.Value = var.Clave.ToString();
                    ddlAreas.Items.Add(l);
                }
                ddlAreas.Items.FindByValue((e.Row.FindControl("txEditArea") as Label).Text).Selected = true;
            }
        }

        protected void gvMovimientos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AGREGAR"))
            {
                Movimientos m = new Movimientos();
                int idActo = int.Parse(ddlActos.SelectedValue.ToString());
                TextBox txtNombreMov = (TextBox)gvMovimientos.FooterRow.FindControl("txNombreMovimiento");
                DropDownList ddlTipo = (DropDownList)gvMovimientos.FooterRow.FindControl("ddlEditTiposF");

                String Resultado = m.GuardarNuevo(idActo, txtNombreMov.Text.ToUpper(), int.Parse(ddlTipo.SelectedValue));

                gvMovimientos.DataSource = main.Movimientos.Catalogo(idActo);
                gvMovimientos.DataBind();
                if (gvMovimientos.Rows.Count == 0)
                {
                    gvMovimientos.DataSource = new[]
                      {
                       new{
                        Clave = string.Empty,
                        Nombre = string.Empty ,
                        Folio = string.Empty,
                        //mas cosas
                       }
                      };
                    gvMovimientos.DataBind();
                                    }
                if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos agregados Correctamente')", true); }
            }
        }
        protected void gvMovimientos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Movimientos m = new Movimientos();

            int idActo = int.Parse(ddlActos.SelectedValue.ToString());
            Label txId = (Label)gvMovimientos.Rows[e.RowIndex].FindControl("lbEditClave");
            TextBox txNombre = (TextBox)gvMovimientos.Rows[e.RowIndex].FindControl("txEditNombre");
            DropDownList ddlTipo = (DropDownList)gvMovimientos.Rows[e.RowIndex].FindControl("ddlEditTiposF");

            String Resultado = m.Actualizar(int.Parse(txId.Text), idActo, txNombre.Text.ToUpper(), int.Parse(ddlTipo.SelectedValue));

            gvMovimientos.EditIndex = -1;
            gvMovimientos.DataSource = main.Movimientos.Catalogo(idActo);
            gvMovimientos.DataBind();
            if (Resultado.Equals("OK")) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos actualizados Correctamente')", true); }
        }
        protected void gvMovimientos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvMovimientos.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddltiposFolio = (DropDownList)e.Row.FindControl("ddlEditTiposF");
                foreach (TipoFolio var in main.Folios.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = var.Nombre;
                    l.Value = var.Clave.ToString();
                    ddltiposFolio.Items.Add(l);
                }
                ddltiposFolio.Items.FindByValue((e.Row.FindControl("txEditTipoFolio") as Label).Text).Selected = true;
            }
        }
        protected void gvMovimientos_DataBound(object sender, EventArgs e)
        {
            GridViewRow footrow = gvMovimientos.FooterRow;
            if (footrow != null)
            {
                DropDownList ddltiposFolio = (DropDownList)footrow.FindControl("ddlEditTiposF");
                foreach (TipoFolio var in main.Folios.Catalogo())
                {
                    ListItem l = new ListItem();
                    l.Text = var.Nombre;
                    l.Value = var.Clave.ToString();
                    ddltiposFolio.Items.Add(l);
                }
            }
        }

        protected void RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView gv = (GridView)sender;

            gv.EditIndex = -1;

            switch (gv.ID)
            {
                case "gvAreasTrabajo":
                    gv.DataSource = main.AreasTrabajo.Catalogo();
                    break;
                case "gvEstatus":
                    gv.DataSource = main.Estatus.Catalogo();
                    break;
                case "gvMovimientos":
                    gv.DataSource = main.Movimientos.Catalogo(int.Parse(ddlActos.SelectedValue.ToString()));
                    break;
                case "gvTiposFolio":
                    gv.DataSource = main.Folios.Catalogo();
                    break;
                case "gvMunicipios":
                    gv.DataSource = main.Municipios.Catalogo();
                    break;
                case "gvParametros":
                    gv.DataSource = main.Parametros.Catalogo();
                    break;
                case "gvTarifas":
                    gv.DataSource = main.Tarifas.Catalogo();
                    break;
                case "gvPoblaciones":
                    gv.DataSource = main.Poblaciones.CatalogoPorMunicipio(int.Parse(ddlFMunicipios.SelectedValue.ToString()));
                    break;
                case "gvSecciones":
                    gv.DataSource = main.Secciones.Catalogo();
                    break;
                case "gvActos":
                    gv.DataSource = main.Actos.Catalogo();
                    break;
            }
            gv.DataBind();
        }
        protected void RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = (GridView)sender;

            gv.EditIndex = e.NewEditIndex;
            switch (gv.ID)
            {
                case "gvAreasTrabajo":
                    gv.DataSource = main.AreasTrabajo.Catalogo();
                    break;
                case "gvEstatus":
                    gv.DataSource = main.Estatus.Catalogo();
                    break;
                case "gvMovimientos":
                    gv.DataSource = main.Movimientos.Catalogo(int.Parse(ddlActos.SelectedValue.ToString()));
                    break;
                case "gvTiposFolio":
                    gv.DataSource = main.Folios.Catalogo();
                    break;
                case "gvMunicipios":
                    gv.DataSource = main.Municipios.Catalogo();
                    break;
                case "gvParametros":
                    gv.DataSource = main.Parametros.Catalogo();
                    break;
                case "gvTarifas":
                    gv.DataSource = main.Tarifas.Catalogo();
                    break;
                case "gvPoblaciones":
                    gv.DataSource = main.Poblaciones.CatalogoPorMunicipio(int.Parse(ddlFMunicipios.SelectedValue.ToString()));
                    break;
                case "gvSecciones":
                    gv.DataSource = main.Secciones.Catalogo();
                    break;
                case "gvActos":
                    gv.DataSource = main.Actos.Catalogo();
                    break;
            }
            gv.DataBind();
        }
        #endregion

        #region Funciones de Botones
        protected void btGuardar_Click(object sender, EventArgs e)
        {
            if (ddlUsuarios.SelectedIndex == 0)
            {
                //Guardar los datos del Usuario
                Usuario u = new Usuario();
                String result = u.GuardarNuevo(int.Parse(ddlTiposUsuario.SelectedValue.ToString()), txNombre.Text, txAPaterno.Text, txAMaterno.Text, txLogin.Text, txPassword.Text, txEstatus.Text, txCalle.Text, txColonia.Text, int.Parse(ddlPoblaciones.SelectedValue.ToString()), int.Parse(ddlMunicipios.SelectedValue.ToString()), txCodigoPostal.Text, txRFC.Text, txCURP.Text, txTelefono1.Text, txTelefono2.Text, txNacimiento.Text, txControl.Text);
                if (result == "OK")
                {
                    LimpiarUsuario();
                    lblResultado.Text = "Usuario agregado.";
                }
                else
                {
                    lblResultado.Text = result;
                }
            }
            else
            {
                //Actualizar los datos del Usuario
                Usuario u = new Usuario();
                String result = u.Actualizar(int.Parse(ddlUsuarios.SelectedValue.ToString()), int.Parse(ddlTiposUsuario.SelectedValue.ToString()), txNombre.Text, txAPaterno.Text, txAMaterno.Text, txLogin.Text, txPassword.Text, txEstatus.Text, txCalle.Text, txColonia.Text, int.Parse(ddlPoblaciones.SelectedValue.ToString()), int.Parse(ddlMunicipios.SelectedValue.ToString()), txCodigoPostal.Text, txRFC.Text, txCURP.Text, txTelefono1.Text, txTelefono2.Text, txNacimiento.Text, txControl.Text);
                if (result == "OK")
                {
                    lblResultado.Text = "Usuario actualizado.";
                }
                else
                {
                    lblResultado.Text = result;
                }
            }
        }
        protected void btNuevoTramitante_Click(object sender, EventArgs e)
        { //limpiar todos los campos del formulario para Tramitantes.
            LimpiarTramitante();
        }
        protected void btGuardarT_Click(object sender, EventArgs e)
        {
            //Guardar los datos del Tramitante
            Tramitante t = new Tramitante();
            String result = t.Guardar(txNombreT.Text, txAPaternoT.Text, txAMaternoT.Text, txRazonSocialT.Text, txRfcT.Text, txCurpT.Text, txCalleT.Text, txNumeroT.Text, txColoniaT.Text, txCodigoT.Text, int.Parse(ddlPoblacionT.SelectedValue.ToString()), int.Parse(ddlMunicipioT.SelectedValue.ToString()), txEstadoT.Text, txLNotariaT.Text, txNotariaT.Text, txTipoT.Text, txTelefonoT.Text, txFaxT.Text, txExtensionT.Text);
            //lblResultado.Text = result;
            LimpiarTramitante();
        }
        protected void btActualizarT_Click(object sender, EventArgs e)
        {
            //Actualizar los datos del Tramitante
            Tramitante t = new Tramitante();
            String result = t.Actualizar(int.Parse(ddlTramitantes.SelectedValue), txNombreT.Text, txAPaternoT.Text, txAMaternoT.Text, txRazonSocialT.Text, txRfcT.Text, txCurpT.Text, txCalleT.Text, txNumeroT.Text, txColoniaT.Text, txCodigoT.Text, int.Parse(ddlPoblacionT.SelectedValue.ToString()), int.Parse(ddlMunicipioT.SelectedValue.ToString()), txEstadoT.Text, txLNotariaT.Text, txNotariaT.Text, txTipoT.Text, txTelefonoT.Text, txFaxT.Text, txExtensionT.Text);
            //lblResultado.Text = result;
            LimpiarTramitante();
        }

        protected void btNuevoUsuario_Click(object sender, EventArgs e)
        {
            LimpiarUsuario();
        }
        #endregion

        #region Funciones Otras
               
        //Funcion para hacer el filtrado de poblaciones segun el municipio
        protected void llenarPoblaciones(object sender)
        {
            DropDownList ddl = (DropDownList)sender;
            ddlPoblaciones.Items.Clear();
            ddlPoblacionT.Items.Clear();
            foreach (Poblacion item in main.Poblaciones.CatalogoPorMunicipio(int.Parse(ddl.SelectedValue.ToString())))
            {
                ListItem l = new ListItem();
                l.Text = item.Nombre;
                l.Value = item.ClavePoblacion.ToString();
                ddlPoblaciones.Items.Add(l);
                ddlPoblacionT.Items.Add(l);
            }
        }

        protected void LimpiarUsuario()
        {
            ddlUsuarios.SelectedIndex = 0;
            ddlTiposUsuario.SelectedIndex = 0;
            txNombre.Text = "";
            txAPaterno.Text = "";
            txAMaterno.Text = "";
            txLogin.Text = "";
            txPassword.Text = "";
            txRFC.Text = "";
            txCURP.Text = "";
            txEstatus.Text = "";
            txNacimiento.Text = "";
            txTelefono1.Text = "";
            txTelefono2.Text = "";
            txControl.Text = "";
            txCalle.Text = "";
            txColonia.Text = "";
            txCodigoPostal.Text = "";
            ddlMunicipioT.SelectedValue = "1";
            llenarPoblaciones(ddlMunicipios);
            ddlPoblacionT.SelectedValue = "1";
            lblResultado.Text = "";
        }

        protected void LimpiarTramitante()
        {
            ddlTramitantes.SelectedIndex = 0;
            txNombreT.Text = "";
            txAMaternoT.Text = "";
            txAPaternoT.Text = "";
            txRazonSocialT.Text = "";
            txRfcT.Text = "";
            txCurpT.Text = "";
            txCalleT.Text = "";
            txNumeroT.Text = "";
            txColoniaT.Text = "";
            txCodigoT.Text = "";
            txEstadoT.Text = "";
            txLNotariaT.Text = "";
            txNotariaT.Text = "";
            txTipoT.Text = "";
            txTelefonoT.Text = "";
            txFaxT.Text = "";
            txExtensionT.Text = "";
            ddlMunicipioT.SelectedValue = "1";
            llenarPoblaciones(ddlMunicipioT);
            ddlPoblacionT.SelectedValue = "1";

            btActualizarT.Visible = false;
            btGuardarT.Visible = true;
        }

        #endregion

    }
}