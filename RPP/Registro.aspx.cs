using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;

namespace RPP
{
    public partial class Registro : System.Web.UI.Page
    {
        private RPPMain.Main main = new RPPMain.Main();
        Prelacion prelacion = new Prelacion();
        List<Movimientos> listamovimientos = new List<Movimientos>();

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

                llenarCheckboxList(currentUser.IdUsuario);
                
                llenarDatosUsuario();
            }
        }

        protected void llenarCheckboxList(int idUsuario)
        {
            lbFolio.Text = "";
            lbTitular.Text = "";
            lbNumEscritura.Text = "";
            lbDescripcion.Text = "";
            lbFecha.Text = "";
            lbTramitante.Text = "";
            lbMovimientos.Items.Clear();
            gvAntecedentes.DataSource = null;
            gvAntecedentes.DataBind();

            rbObservaciones.Items.Clear();
            rbSinRegistrar.Items.Clear();
            //Llenar el CheckBoxList de Prelaciones Sin Registrar
            foreach (Prelacion var in prelacion.ObtenerPrelacionesUsuario(idUsuario, "ASIGNADA"))
            {
                List<Movimientos> mov = Prelacion.ObtenerMovimientosPrelacion(var.IdPrelacion, "");
                ListItem item = new ListItem();
                item.Text = var.IdPrelacion.ToString() + " | " + mov[0].Acto.Nombre;
                item.Value = var.IdPrelacion.ToString();
                rbSinRegistrar.Items.Add(item);
            }
            foreach (Prelacion var in prelacion.ObtenerPrelacionesUsuario(idUsuario, "REVISAR"))
            {
                List<Movimientos> mov = Prelacion.ObtenerMovimientosPrelacion(var.IdPrelacion, "");
                ListItem item = new ListItem();
                item.Text = var.IdPrelacion.ToString() + " | " + mov[0].Acto.Nombre;
                item.Value = var.IdPrelacion.ToString();
                rbObservaciones.Items.Add(item);
            }
        }
        protected void rbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList listaprelaciones = (RadioButtonList)sender;
            Prelacion pre = Prelacion.ObtenerPrelacionPorId(int.Parse(listaprelaciones.SelectedValue));
            if (listaprelaciones.ID.Equals("rbSinRegistrar")) 
            { 
                rbObservaciones.SelectedIndex = -1;
                fsObservaciones.Visible = false;
                listamovimientos = Prelacion.ObtenerMovimientosPrelacion(int.Parse(listaprelaciones.SelectedValue), "NOREGISTRADA");
            }
            else
            {
                rbSinRegistrar.SelectedIndex = -1;
                fsObservaciones.Visible = true;
                txObservaciones.InnerText = pre.ObservacionesVerificador;
                listamovimientos = Prelacion.ObtenerMovimientosPrelacion(int.Parse(listaprelaciones.SelectedValue), "REVISION");
            }

            lbMovimientos.Items.Clear();
            foreach (Movimientos var in listamovimientos)
            {
                ListItem l = new ListItem();
                l.Text = var.Nombre;
                l.Value = var.ClaveActo.ToString() + ";" + var.Clave.ToString();
                lbMovimientos.Items.Add(l);
            }
            lbFolio.Text = pre.Folio;
            lbTitular.Text = pre.NombreTitular;
            lbNumEscritura.Text = pre.NumeroEscritura;
            lbDescripcion.Text = pre.DescripcionBien;
            lbFecha.Text = pre.Fecha;
            lbTramitante.Text = pre.Tramitante;
            gvAntecedentes.DataSource = Prelacion.ObtenerAntecedentesPrelacion(int.Parse(listaprelaciones.SelectedValue));
            gvAntecedentes.DataBind();
           
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if ((rbSinRegistrar.SelectedIndex!=-1 || rbObservaciones.SelectedIndex!=-1))
            {
                Session["IDPRELACION"] = (rbSinRegistrar.SelectedIndex == -1) ?  rbObservaciones.SelectedValue : rbSinRegistrar.SelectedValue;

                if (rbObservaciones.SelectedIndex != -1)
                {
                    Response.Redirect("Registrar.aspx");
                }
                else
                {
                    listamovimientos = Prelacion.ObtenerMovimientosPrelacion(int.Parse(Session["IDPRELACION"].ToString()), "NOREGISTRADA");
                    int cont = 0;
                    foreach (Movimientos mov in listamovimientos)
                    {
                        String[] secci = mov.Acto.Seccion.ToString().Split(';');
                        if (secci[0].Length > 3) cont++;
                    }
                    if (listamovimientos.Count == cont)
                    {
                        Prelacion.CambiarEstadoPrelacion("ENTREGA", int.Parse(Session["IDPRELACION"].ToString()));
                        Prelacion.CambiarEstadoMovimientos("REGISTRADA", int.Parse(Session["IDPRELACION"].ToString()));
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Todos son Movimientos NO Registrales. Prelación Registrada con éxito.')", true);
                        Usuario currentUser = (Usuario)Session.Contents["usuario"];
                        llenarCheckboxList(currentUser.IdUsuario);
                    }
                    else
                    {
                        Response.Redirect("Registrar.aspx");
                    }
                }
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes elegir una Prelación a Registrar.')", true);
            }
        }

        #region PERFIL DE USUARIO
        protected void llenarDatosUsuario()
        {
            Usuario usuarioLog = (Usuario)Session.Contents["usuario"];
          //  Session["TIPOUSUARIO"] = usuarioLog.IdTipoUsuario;
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

    }
}