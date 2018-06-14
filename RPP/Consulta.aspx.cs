using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;
using Microsoft.SharePoint.Client;

namespace RPP
{
    public partial class Consulta : System.Web.UI.Page
    {

        private RPPMain.Main main = new RPPMain.Main();
        private List<Prelacion> prelaciones;
        Prelacion prelacionElegida;

        protected void Page_Load(object sender, EventArgs e)
        {
            /*#region Verificación de usuario
            Usuario currentUser = (Usuario)Session.Contents["usuario"];
            if (currentUser == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (currentUser.IdTipoUsuario != 7)
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
            #endregion*/
        }
        /*
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
        */
        private void Buscar()
        {
            try
            {
                RPPMain.SharepointLibrary spLibrary = new RPPMain.SharepointLibrary("http://servidors04/sitios/digitalizacion", "Seccion Primera", "autostore", "Rpp1234");
                //spLibrary.Prueba();
                lblError.Text = "";
                //int documentoID = int.Parse(Page.Request.QueryString["documentoID"]);

                String reg_act_tomo = txTomo.Text;
                String reg_act_semestre = txSemestre.Text;
                String reg_act_año = txAnio.Text;
                String reg_act_seccion = txSeccion.Text;
                String reg_act_serie = txSerie.Text;
                String reg_act_partida = txPartida.Text;
                String reg_act_libro = txLibro.Text;


                bool firstParameter = true;
                bool secondParameter = false;
                bool nextParameter = false;
                string query = "";

                if (reg_act_tomo.Length > 0)
                {
                    if (firstParameter)
                    {
                        query = query + "<And><Eq><FieldRef Name='Fec_Reg_Tomo' /><Value Type='Text'>{0}</Value></Eq>";
                        firstParameter = false;
                        secondParameter = true;
                    }
                    else
                    {
                        if (secondParameter)
                        {
                            query = query + "<Eq><FieldRef Name='Fec_Reg_Tomo' /><Value Type='Text'>{0}</Value></Eq></And>";
                            secondParameter = false;
                            nextParameter = true;
                        }
                        else
                        {
                            query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Tomo' /><Value Type='Text'>{0}</Value></Eq></And>";
                        }
                    }
                }

                if (reg_act_semestre.Length > 0)
                {
                    if (firstParameter)
                    {
                        query = query + "<And><Eq><FieldRef Name='Fec_Reg_Semestre' /><Value Type='Text'>{1}</Value></Eq>";
                        firstParameter = false;
                        secondParameter = true;
                    }
                    else
                    {
                        if (secondParameter)
                        {
                            query = query + "<Eq><FieldRef Name='Fec_Reg_Semestre' /><Value Type='Text'>{1}</Value></Eq></And>";
                            secondParameter = false;
                            nextParameter = true;
                        }
                        else
                        {
                            query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Semestre' /><Value Type='Text'>{1}</Value></Eq></And>";
                        }
                    }
                }

                if (reg_act_año.Length > 0)
                {
                    if (firstParameter)
                    {
                        query = query + "<And><Eq><FieldRef Name='Fec_Reg_A_x00f1_o_x0020_Semestre' /><Value Type='Text'>{2}</Value></Eq>";
                        firstParameter = false;
                        secondParameter = true;
                    }
                    else
                    {
                        if (secondParameter)
                        {
                            query = query + "<Eq><FieldRef Name='Fec_Reg_A_x00f1_o_x0020_Semestre' /><Value Type='Text'>{2}</Value></Eq></And>";
                            secondParameter = false;
                            nextParameter = true;
                        }
                        else
                        {
                            query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_A_x00f1_o_x0020_Semestre' /><Value Type='Text'>{2}</Value></Eq></And>";
                        }
                    }
                }

                if (reg_act_seccion.Length > 0)
                {
                    if (firstParameter)
                    {
                        query = query + "<And><Eq><FieldRef Name='Fec_Reg_Seccion' /><Value Type='Text'>{3}</Value></Eq>";
                        firstParameter = false;
                        secondParameter = true;
                    }
                    else
                    {
                        if (secondParameter)
                        {
                            query = query + "<Eq><FieldRef Name='Fec_Reg_Seccion' /><Value Type='Text'>{3}</Value></Eq></And>";
                            secondParameter = false;
                            nextParameter = true;
                        }
                        else
                        {
                            query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Seccion' /><Value Type='Text'>{3}</Value></Eq></And>";
                        }
                    }
                }

                if (reg_act_serie.Length > 0)
                {
                    if (firstParameter)
                    {
                        query = query + "<And><Eq><FieldRef Name='Fec_Reg_Partida' /><Value Type='Text'>{4}</Value></Eq>";
                        firstParameter = false;
                        secondParameter = true;
                    }
                    else
                    {
                        if (secondParameter)
                        {
                            query = query + "<Eq><FieldRef Name='Fec_Reg_Partida' /><Value Type='Text'>{4}</Value></Eq></And>";
                            secondParameter = false;
                            nextParameter = true;
                        }
                        else
                        {
                            query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Partida' /><Value Type='Text'>{4}</Value></Eq></And>";
                        }
                    }
                }

                if (reg_act_partida.Length > 0)
                {
                    if (firstParameter)
                    {
                        query = query + "<And><Eq><FieldRef Name='Partida' /><Value Type='Text'>{5}</Value></Eq>";
                        firstParameter = false;
                        secondParameter = true;
                    }
                    else
                    {
                        if (secondParameter)
                        {
                            query = query + "<Eq><FieldRef Name='Partida' /><Value Type='Text'>{5}</Value></Eq></And>";
                            secondParameter = false;
                            nextParameter = true;
                        }
                        else
                        {
                            query = "<And>" + query + "<Eq><FieldRef Name='Partida' /><Value Type='Text'>{5}</Value></Eq></And>";
                        }
                    }
                }

                if (reg_act_libro.Length > 0)
                {
                    if (firstParameter)
                    {
                        query = query + "<And><Eq><FieldRef Name='Fec_Reg_Libro' /><Value Type='Text'>{6}</Value></Eq>";
                        firstParameter = false;
                        secondParameter = true;
                    }
                    else
                    {
                        if (secondParameter)
                        {
                            query = query + "<Eq><FieldRef Name='Fec_Reg_Libro' /><Value Type='Text'>{6}</Value></Eq></And>";
                            secondParameter = false;
                            nextParameter = true;
                        }
                        else
                        {
                            query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Libro' /><Value Type='Text'>{6}</Value></Eq></And>";
                        }
                    }
                }

                query = "<View><Query><Where>" + query + "</Where></Query></View>";

                query = "<Query><Where><Eq><FieldRef Name='Numero_x0020_de_x0020_Documento' /><Value Type='Text'>154456</Value></Eq></Where></Query>";

                /*
                query = string.Format(@"<View>
                                                <Query>
                                                    <Where>
                                                        <And>
                                                            <And>
                                                                <And>
                                                                    <And>
                                                                        <And>
                                                                            <And>
                                                                                <Eq><FieldRef Name='Fec_Reg_Tomo' /><Value Type='Text'>{0}</Value></Eq>
                                                                                <Eq><FieldRef Name='Fec_Reg_Semestre' /><Value Type='Text'>{1}</Value></Eq>
                                                                            </And>
                                                                            <Eq><FieldRef Name='Fec_Reg_A_x00f1_o_x0020_Semestre' /><Value Type='Text'>{2}</Value></Eq>
                                                                        </And>
                                                                        <Eq><FieldRef Name='Fec_Reg_Seccion' /><Value Type='Text'>{3}</Value></Eq>
                                                                    </And>
                                                                    <Eq><FieldRef Name='Fec_Reg_Partida' /><Value Type='Text'>{4}</Value></Eq>
                                                                </And>
                                                                <Eq><FieldRef Name='Partida' /><Value Type='Text'>{5}</Value></Eq>
                                                            </And>
                                                            <Eq><FieldRef Name='Fec_Reg_Libro' /><Value Type='Text'>{6}</Value></Eq>                                                            
                                                        </And>
                                                    </Where>
                                                </Query>
                                            </View>",
                            reg_act_tomo,
                            reg_act_semestre,
                            reg_act_año,
                            reg_act_seccion,
                            reg_act_serie,
                            reg_act_partida,
                            reg_act_libro);
                 */
                /*

                query = string.Format(@query,
                            reg_act_tomo,
                            reg_act_semestre,
                            reg_act_año,
                            reg_act_seccion,
                            reg_act_serie,
                            reg_act_partida,
                            reg_act_libro);*/

                System.Collections.ArrayList arlRows = spLibrary.GetLibraryItem(query);

                if (arlRows.Count > 0)
                {
                    lblError.Text = arlRows.Count.ToString();

                    List<Prelacion> resultados = new List<Prelacion>();
                    Prelacion r = new Prelacion();


                    for (int i = 0; i <= arlRows.Count - 1; i++)
                    {
                        Microsoft.SharePoint.Client.ListItem itemRepositorio = (Microsoft.SharePoint.Client.ListItem)arlRows[i];
                        Dictionary<string, object> dc = (Dictionary<string, object>)itemRepositorio.FieldValues;
                        Microsoft.SharePoint.Client.FieldUrlValue fURl = (Microsoft.SharePoint.Client.FieldUrlValue)dc["Pagina"];

                        r = new Prelacion();
                        
                        r.RepositoryUrl = fURl.Url;
                        r.Tramitante = dc["No_x002e__x0020_Notaria"].ToString();
                        r.IdPrelacion = int.Parse(dc["ID"].ToString());
                        r.NumeroDocumento = dc["Numero_x0020_de_x0020_Documento"].ToString();

                        resultados.Add(r);

                        //lblError.Text = lblError.Text + "\n" + fURl.Url.ToString();
                    }

                    gvResultados.DataSource = resultados;
                    gvResultados.DataBind();

                    /*
                    try
                    {
                        System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(fURl.Url);
                        request.UseDefaultCredentials = true;

                        System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

                        System.IO.Stream responseStream = response.GetResponseStream();

                        Response.ContentType = "image/jpeg";
                        new System.Drawing.Bitmap(responseStream).Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        Response.End();
                        

                    }
                    catch (System.Exception ex)
                    {
                        lblError.Text = lblError.Text + " 1.- " + ex.Message;
                    }*/

                }
            }
            catch (System.Exception ex)
            {
                lblError.Text = lblError.Text + " 2.- " + ex.Message;
            }
        }

        private void BuscarV2()
        {
            String reg_act_tomo = txTomo.Text;
            String reg_act_semestre = txSemestre.Text;
            String reg_act_año = txAnio.Text;
            String reg_act_seccion = txSeccion.Text;
            String reg_act_serie = txSerie.Text;
            String reg_act_partida = txPartida.Text;
            String reg_act_libro = txLibro.Text;


            bool firstParameter = true;
            bool secondParameter = false;
            bool nextParameter = false;
            string query = "";

            if (reg_act_tomo.Length > 0)
            {
                if (firstParameter)
                {
                    query = query + "<Eq><FieldRef Name='Fec_Reg_Tomo' /><Value Type='Number'>{0}</Value></Eq>";
                    firstParameter = false;
                    secondParameter = true;
                }
                else
                {
                    if (secondParameter)
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Tomo' /><Value Type='Number'>{0}</Value></Eq></And>";
                        secondParameter = false;
                        nextParameter = true;
                    }
                    else
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Tomo' /><Value Type='Number'>{0}</Value></Eq></And>";
                    }
                }
            }

            if (reg_act_semestre.Length > 0)
            {
                if (firstParameter)
                {
                    query = query + "<Eq><FieldRef Name='Fec_Reg_Semestre' /><Value Type='Number'>{1}</Value></Eq>";
                    firstParameter = false;
                    secondParameter = true;
                }
                else
                {
                    if (secondParameter)
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Semestre' /><Value Type='Number'>{1}</Value></Eq></And>";
                        secondParameter = false;
                        nextParameter = true;
                    }
                    else
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Semestre' /><Value Type='Number'>{1}</Value></Eq></And>";
                    }
                }
            }

            if (reg_act_año.Length > 0)
            {
                if (firstParameter)
                {
                    query = query + "<Eq><FieldRef Name='Fec_Reg_A_x00f1_o_x0020_Semestre' /><Value Type='Number'>{2}</Value></Eq>";
                    firstParameter = false;
                    secondParameter = true;
                }
                else
                {
                    if (secondParameter)
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_A_x00f1_o_x0020_Semestre' /><Value Type='Number'>{2}</Value></Eq></And>";
                        secondParameter = false;
                        nextParameter = true;
                    }
                    else
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_A_x00f1_o_x0020_Semestre' /><Value Type='Number'>{2}</Value></Eq></And>";
                    }
                }
            }

            if (reg_act_seccion.Length > 0)
            {
                if (firstParameter)
                {
                    query = query + "<Eq><FieldRef Name='Fec_Reg_Seccion' /><Value Type='Number'>{3}</Value></Eq>";
                    firstParameter = false;
                    secondParameter = true;
                }
                else
                {
                    if (secondParameter)
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Seccion' /><Value Type='Number'>{3}</Value></Eq></And>";
                        secondParameter = false;
                        nextParameter = true;
                    }
                    else
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Seccion' /><Value Type='Number'>{3}</Value></Eq></And>";
                    }
                }
            }

            if (reg_act_serie.Length > 0)
            {
                if (firstParameter)
                {
                    query = query + "<Eq><FieldRef Name='Fec_Reg_Partida' /><Value Type='Text'>{4}</Value></Eq>";
                    firstParameter = false;
                    secondParameter = true;
                }
                else
                {
                    if (secondParameter)
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Partida' /><Value Type='Text'>{4}</Value></Eq></And>";
                        secondParameter = false;
                        nextParameter = true;
                    }
                    else
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Partida' /><Value Type='Text'>{4}</Value></Eq></And>";
                    }
                }
            }

            if (reg_act_partida.Length > 0)
            {
                if (firstParameter)
                {
                    query = query + "<Eq><FieldRef Name='Partida' /><Value Type='Number'>{5}</Value></Eq>";
                    firstParameter = false;
                    secondParameter = true;
                }
                else
                {
                    if (secondParameter)
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Partida' /><Value Type='Number'>{5}</Value></Eq></And>";
                        secondParameter = false;
                        nextParameter = true;
                    }
                    else
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Partida' /><Value Type='Number'>{5}</Value></Eq></And>";
                    }
                }
            }

            if (reg_act_libro.Length > 0)
            {
                if (firstParameter)
                {
                    query = query + "<Eq><FieldRef Name='Fec_Reg_Libro' /><Value Type='Number'>{6}</Value></Eq>";
                    firstParameter = false;
                    secondParameter = true;
                }
                else
                {
                    if (secondParameter)
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Libro' /><Value Type='Number'>{6}</Value></Eq></And>";
                        secondParameter = false;
                        nextParameter = true;
                    }
                    else
                    {
                        query = "<And>" + query + "<Eq><FieldRef Name='Fec_Reg_Libro' /><Value Type='Number'>{6}</Value></Eq></And>";
                    }
                }
            }

            query = "<View><Query><Where>" + query + "</Where></Query></View>";

            query = string.Format(@query,
                            reg_act_tomo,
                            reg_act_semestre,
                            reg_act_año,
                            reg_act_seccion,
                            reg_act_serie,
                            reg_act_partida,
                            reg_act_libro);

            try
            {
                using (ClientContext ctx = new ClientContext("http://servidors04/sitios/digitalizacion"))
                {
                    Web web = ctx.Web;
                    List list = web.Lists.GetById(new Guid("9c3f7319-7740-426f-87a4-bf9b8c0eb6b8"));
                    var q = new CamlQuery() { ViewXml = query };

                    Microsoft.SharePoint.Client.ListItemCollection arlRows = list.GetItems(q);
                    ctx.Load(arlRows);
                    ctx.ExecuteQuery();

                    lblResultado.Text = "Se han obtenido " + arlRows.Count + " resultados de la búsqueda.";

                    foreach (var item in arlRows)
                    {

                        List<Prelacion> resultados = new List<Prelacion>();
                        Prelacion r = new Prelacion();


                        for (int i = 0; i <= arlRows.Count - 1; i++)
                        {
                            Microsoft.SharePoint.Client.ListItem itemRepositorio = (Microsoft.SharePoint.Client.ListItem)arlRows[i];
                            Dictionary<string, object> dc = (Dictionary<string, object>)itemRepositorio.FieldValues;
                            Microsoft.SharePoint.Client.FieldUrlValue fURl = (Microsoft.SharePoint.Client.FieldUrlValue)dc["Pagina"];

                            r = new Prelacion();

                            r.RepositoryUrl = fURl.Url;
                            r.Tramitante = dc["No_x002e__x0020_Notaria"].ToString();
                            r.IdPrelacion = int.Parse(dc["ID"].ToString());
                            r.Partida = dc["Partida"].ToString();
                            r.NumeroDocumento = dc["Numero_x0020_de_x0020_Documento"].ToString();

                            resultados.Add(r);

                            //lblError.Text = lblError.Text + "\n" + fURl.Url.ToString();
                        }

                        gvResultados.DataSource = resultados;
                        gvResultados.DataBind();
                    }                    
                }
            }
            catch(Exception exc)
            {
                lblError.Text = exc.Message;
            }
        }

        protected void gvAntecedentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            String libro = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[1].Text;
            String tomo = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[2].Text;
            String seccion = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[3].Text;
            String serie = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[4].Text;
            String semestre = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[5].Text;
            String anio = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[6].Text;
            String partida = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[7].Text;*/
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('DocumentoImagen.aspx?libro=" + libro + "&tomo=" + tomo + "&semestre=" + semestre + "&anio=" + anio + "&seccion=" + seccion + "&serie=" + serie + "&partida=" + partida + "','_blank')", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + gvResultados.Rows[gvResultados.SelectedIndex].Cells[1].Text + "','_blank')", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('DocumentoImagen.aspx?url=" + gvResultados.Rows[gvResultados.SelectedIndex].Cells[4].Text + "','_blank')", true);

        }

        protected void btGuardarRegistro_Click(object sender, EventArgs e)
        {
            BuscarV2();
        }
    }
}