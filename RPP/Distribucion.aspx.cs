using RPPMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RPP
{
    public partial class Distribucion : System.Web.UI.Page
    {
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
                if (currentUser.IdTipoUsuario != 3)
                {
                    switch (currentUser.IdTipoUsuario)
                    {
                        case 1: //Administrador
                            Response.Redirect("Catalogos.aspx");
                            break;
                        case 2://Recepcion
                            //Response.Redirect("Recepcion.aspx");
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
                //Session["IDUSUARIO"] = currentUser.IdUsuario;
                limpiarListas();
                cargarListas();
                llenarDatosUsuario();
                //txFechaAsignada.Text = DateTime.Today.Date.ToShortDateString();
            }
            else
            {
                
            }

            
        }

        #region FUNCIONES OTRAS
        protected void limpiarListas()
        {
            cbSinAsignar.Items.Clear();
            cbAsignadas.Items.Clear();
            rbUsuarios.Items.Clear();
            rbUsuarios2.Items.Clear();
            ddlUsuarios.Items.Clear();
            ListItem item = new ListItem();
            item.Text = "Todos los Usuarios";
            item.Value = "0";
            ddlUsuarios.Items.Add(item);
        }
        protected void cargarListas()
        {
            Prelacion pre = new Prelacion();
            //Llenar el CheckBoxList de Prelaciones Sin Asignar
            foreach (Prelacion var in pre.ObtenerPrelacionesEstatus("RECEPCION"))
            {
                ListItem item = new ListItem();
                List<Movimientos> mov = Prelacion.ObtenerMovimientosPrelacion(var.IdPrelacion,"");
                item.Text = "<b>" +var.IdPrelacion.ToString() + "</b> |" + mov[0].Acto.Nombre;
                item.Value = var.IdPrelacion.ToString();
                cbSinAsignar.Items.Add(item);
            }
            /*
            //Llenar el CheckBoxList de Prelaciones Asignadas
            foreach (Prelacion var in pre.ObtenerPrelacionesEstatus("ASIGNADA"))
            {
                List<Movimientos> mov = Prelacion.ObtenerMovimientosPrelacion(var.IdPrelacion,"");
                String usuario = (var.Usuario.Length > 23) ? var.Usuario.Substring(0, 23) : var.Usuario;
                ListItem item = new ListItem();
                item.Text = var.IdPrelacion.ToString() + " |" + mov[0].Acto.Nombre + " | <b> " + usuario + "</b>";
                item.Value = var.IdPrelacion.ToString();
                cbAsignadas.Items.Add(item);
            }
            */
            //Llenar los RadioButtonList y Dropdownlist para Usuarios.
            foreach (Usuario var in main.Usuarios.CatalogoRegistradores())
            {
                ListItem item = new ListItem();
                String nombre = var.Nombre + " " + var.ApellidoPaterno + " " + var.ApellidoMaterno;
                nombre = (nombre.Length>35)? nombre.Substring(0,35) : nombre;
                item.Text = nombre;
                item.Value = var.IdUsuario.ToString();
                ddlUsuarios.Items.Add(item);
                rbUsuarios.Items.Add(item);
                rbUsuarios2.Items.Add(item);
            }
            
        }

        protected void CargarListas2()
        {
            Prelacion pre = new Prelacion();
            foreach (Prelacion var in pre.ObtenerPrelacionesEstatus("ASIGNADA"))
            {
                List<Movimientos> mov = Prelacion.ObtenerMovimientosPrelacion(var.IdPrelacion, "");
                String usuario = (var.Usuario.Length > 23) ? var.Usuario.Substring(0, 23) : var.Usuario;
                ListItem item = new ListItem();
                item.Text = var.IdPrelacion.ToString() + " |" + mov[0].Acto.Nombre + " | <b> " + usuario + "</b>";
                item.Value = var.IdPrelacion.ToString();
                cbAsignadas.Items.Add(item);
            }
        }
        #endregion

        #region PERFIL DE USUARIO
        protected void llenarDatosUsuario()
        { 
            //Usuario usuarioLog = Usuario.ObtenerUsuarioPorId(int.Parse(Session["IDUSUARIO"].ToString()));
            Usuario usuarioLog = (Usuario)Session.Contents["usuario"];
           // Session["TIPOUSUARIO"] = usuarioLog.IdTipoUsuario;
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
        protected void btAsignar_Click(object sender, EventArgs e)
        {
            
            Prelacion pre = new Prelacion();
            List<ListItem> selectedP = new List<ListItem>();
            foreach (ListItem item in cbSinAsignar.Items)
                if (item.Selected) selectedP.Add(item);

            String usuario = rbUsuarios.SelectedValue;

            if (!usuario.Equals("") && selectedP.Count > 0)
            {
                foreach (ListItem item in selectedP)
                {
                    pre.GuardarNuevaPrelacionUsuario(int.Parse(item.Value), int.Parse(usuario), "ASIGNADA:" + DateTime.Now + ";");
                    Prelacion.CambiarEstadoPrelacion("ASIGNADA", int.Parse(item.Value));
                }
                limpiarListas();
                cargarListas();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Prelaciones Asignadas Correctamente')", true);
            }
            else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes elegir un Usuario y al menos una Prelación')", true); }
        }

        protected void btCambios_Click(object sender, EventArgs e)
        {
            Prelacion pre = new Prelacion();
            List<ListItem> selectedP = new List<ListItem>();
            foreach (ListItem item in cbAsignadas.Items)
                if (item.Selected) selectedP.Add(item);
            String usuario = rbUsuarios2.SelectedValue;

            if (!usuario.Equals("") && selectedP.Count > 0)
            {
                foreach (ListItem item in selectedP)
                {
                    Prelacion prel = Prelacion.ObtenerPrelacionPorId(int.Parse(item.Value));
                    pre.ActualizarPrelacionUsuario(int.Parse(item.Value), int.Parse(prel.IdUsuario.ToString()), int.Parse(usuario), "REASIGNADA:" + DateTime.Now + ";");
                    Prelacion.CambiarEstadoPrelacion("ASIGNADA", int.Parse(item.Value));
                }
                limpiarListas();
                cargarListas();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cambio de Asignación Correctamente')", true);
            }
            else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes elegir un Usuario y al menos una Prelación')", true); }
        }

        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!ddlUsuarios.SelectedValue.ToString().Equals("0")){
                Prelacion pre = new Prelacion();
                cbAsignadas.Items.Clear();
                //Llenar el CheckBoxList de Prelaciones Asignadas segun un Usuario
                foreach (Prelacion var in pre.ObtenerPrelacionesUsuario(int.Parse(ddlUsuarios.SelectedValue.ToString()),"ASIGNADA"))
                {
                    List<Movimientos> mov = Prelacion.ObtenerMovimientosPrelacion(var.IdPrelacion, "");
                    String usuario = (var.Usuario.Length > 23) ? var.Usuario.Substring(0, 23) : var.Usuario;
                    ListItem item = new ListItem();
                    item.Text = var.IdPrelacion.ToString()+" |"+mov[0].Acto.Nombre + " | <b> " + usuario + "</b>";
                    item.Value = var.IdPrelacion.ToString();
                    cbAsignadas.Items.Add(item);
                }
            }
            else{
                limpiarListas();
                cargarListas();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string url = "ReporteAsignadas.aspx?fecha=" + txFechaAsignada.Text;
            //string s = "window.open('" + url + "', 'popup_window', 'width=750,height=800,left=100,top=100,resizable=no');";
            string url = "ReporteAsignadasRango.aspx?fechaInicio=" + txFechaInicio.Text + "&fechaFin=" + txFechaFin.Text;
            string s = "window.open('" + url + "', '_blank');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["IDPRELACION"] = txReimprimir.Text;
            string url = "BoletaRecepcion.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=750,height=800,left=100,top=100,resizable=no');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        protected void Button3_Command(object sender, CommandEventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            CargarListas2();
        }
    }
}