using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;
using System.IO;
using Microsoft.SharePoint.Client;

namespace RPP
{
    public partial class ActualizacionDiaria : System.Web.UI.Page
    {
        Prelacion prelacionEncontrada;
        List<Antecedente> antecedentesPrelacion;
        MemoryStream ms;
        List<System.Drawing.Image> images;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                /*prelacionEncontrada = (Prelacion)Session["prelacionEncontrada"];
                antecedentesPrelacion = (List<Antecedente>)Session["antecedentesPrelacion"];
                gvAntecedentes.DataSource = antecedentesPrelacion;
                gvAntecedentes.DataBind();*/
                ms = (MemoryStream)Session["ms"];
            }
        }

        protected void gvAntecedentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                prelacionEncontrada = Prelacion.ObtenerPrelacionPorId(int.Parse(txFolio.Text));
                antecedentesPrelacion = Prelacion.ObtenerAntecedentesPrelacion(prelacionEncontrada.IdPrelacion);
                gvAntecedentes.DataSource = antecedentesPrelacion;
                gvAntecedentes.DataBind();
                Session["prelacionEncontrada"] = prelacionEncontrada;
                Session["antecedentesPrelacion"] = antecedentesPrelacion;
                txFolio.Text = "";
            }
            catch (Exception exc)
            {
                lblError.Text = exc.Message;
            }
        }

        protected void gvResultados_SelectedIndexChanged(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('DocumentoImagen.aspx?url=" + gvResultados.Rows[gvResultados.SelectedIndex].Cells[2].Text + "','_blank')", true);
        }

        private void Buscar()
        {
            try
            {
                RPPMain.SharepointLibrary spLibrary = new RPPMain.SharepointLibrary("http://servidors04/sitios/digitalizacion", "Seccion Primera", "autostore", "Rpp1234");
                lblError.Text = "";

                String reg_act_tomo = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[2].Text;
                String reg_act_semestre = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[5].Text;
                String reg_act_año = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[6].Text;
                String reg_act_seccion = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[3].Text;
                String reg_act_serie = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[4].Text;
                String reg_act_partida = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[7].Text;
                String reg_act_libro = gvAntecedentes.Rows[gvAntecedentes.SelectedIndex].Cells[1].Text;

                reg_act_tomo = reg_act_tomo =="&nbsp;" ? "" : reg_act_tomo;
                reg_act_semestre = reg_act_semestre == "&nbsp;" ? "" : reg_act_semestre;
                reg_act_año = reg_act_año == "&nbsp;" ? "" : reg_act_año;
                reg_act_seccion = reg_act_seccion == "&nbsp;" ? "" : reg_act_seccion;
                reg_act_serie = reg_act_serie == "&nbsp;" ? "" : reg_act_serie;
                reg_act_partida = reg_act_partida == "&nbsp;" ? "" : reg_act_partida;
                reg_act_libro = reg_act_libro == "&nbsp;" ? "" : reg_act_libro;

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

                query = string.Format(@query,
                            reg_act_tomo,
                            reg_act_semestre,
                            reg_act_año,
                            reg_act_seccion,
                            reg_act_serie,
                            reg_act_partida,
                            reg_act_libro);

                //System.Collections.ArrayList arlRows = spLibrary.GetLibraryItem(query);

                using (ClientContext ctx = new ClientContext("http://servidors04/sitios/digitalizacion"))
                {
                    Web web = ctx.Web;
                    List list = web.Lists.GetById(new Guid("9c3f7319-7740-426f-87a4-bf9b8c0eb6b8"));
                    var q = new CamlQuery() { ViewXml = query };

                    Microsoft.SharePoint.Client.ListItemCollection arlRows = list.GetItems(q);
                    ctx.Load(arlRows);
                    ctx.ExecuteQuery();

                    lblError.Text = "Se han obtenido " + arlRows.Count + " resultados de la búsqueda.";

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
            catch (Exception exc)
            {
                lblError.Text = exc.Message;
            }
        }

        private void BuscaPorFolioInterno()
        {
            try
            {
                //RPPMain.SharepointLibrary spLibrary = new RPPMain.SharepointLibrary("http://servidors04/sitios/digitalizacion", "Seccion Primera", "autostore", "Rpp1234");
                lblError.Text = "";

                String numero_documento = txNumeroDocumento.Text;
                
                string query = "";

                query = "<Eq><FieldRef Name='Numero_x0020_de_x0020_Documento' /><Value Type='Number'>{0}</Value></Eq>";

                query = "<View><Query><Where>" + query + "</Where></Query></View>";

                query = string.Format(@query,
                            numero_documento);

                //System.Collections.ArrayList arlRows = spLibrary.GetLibraryItem(query);
                
                using (ClientContext ctx = new ClientContext("http://servidors04/sitios/digitalizacion"))
                {
                    Web web = ctx.Web;
                    List list = web.Lists.GetById(new Guid("9c3f7319-7740-426f-87a4-bf9b8c0eb6b8"));
                    var q = new CamlQuery() { ViewXml = query };

                    Microsoft.SharePoint.Client.ListItemCollection arlRows = list.GetItems(q);
                    ctx.Load(arlRows);
                    ctx.ExecuteQuery();

                    lblError.Text = "Se han obtenido " + arlRows.Count + " resultados de la búsqueda.";

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

        private void CrearImagenNueva()
        {
            try
            {
                images = new List<System.Drawing.Image>();
                images = (List<System.Drawing.Image>)Session["images"];

                if (rblAccion.SelectedIndex == 0)
                {
                    MemoryStream ms2 = new MemoryStream();
                    ms2 = (MemoryStream)Session["ms"];

                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms2);

                    images[images.Count - 1] = img;

                    Session["images"] = images;

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('DocumentoImagen.aspx?memory=true','_blank')", true);

                }
                else
                {
                    MemoryStream ms2 = new MemoryStream();
                    ms2 = (MemoryStream)Session["ms"];

                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms2);

                    images.Add(img);

                    Session["images"] = images;

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('DocumentoImagen.aspx?memory=true','_blank')", true);
                }
                lblError.Text = "";
            }
            catch (Exception exc)
            {
                lblError.Text = exc.Message;
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CrearImagenNueva();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            bool fileOK = false;
            if (fuImagen.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(fuImagen.FileName).ToLower();
                //String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                String[] allowedExtensions = { ".tif" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }
            if (fileOK)
            {
                lblError.Text = "";
                ms = new MemoryStream();

                fuImagen.PostedFile.InputStream.CopyTo(ms);
                Session["ms"] = ms;
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                try
                {
                    MemoryStream ms2 = new MemoryStream();
                    img.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);

                    byte[] bytes = ms2.ToArray();

                    string base64String = Convert.ToBase64String(bytes);

                    imgFileUpload.ImageUrl = "data:image/jpg;base64," + base64String;
                    lblError.Text = "";
                }
                catch (Exception exc)
                {
                    lblError.Text = exc.Message;
                }
            }
            else
            {
                lblError.Text = "No ha seleccionado un archivo válido.";
            }
        }
        //En esta función se empaqueta el registro a enviar al repositorio.
        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                //Se realiza una búsqueda en el repositorio para obtener la lista completa de los metadatos y sus valores para
                //adjuntarlos al registro que se va a crear.
                RPPMain.SharepointLibrary spLibrary = new RPPMain.SharepointLibrary("http://servidors04/sitios/digitalizacion", "Seccion Primera", "autostore", "Rpp1234");
                
                /*string query = string.Format(@"<View>
                                            <Query>
                                                <Where>                                                
                                                    <And>
                                                        <Eq><FieldRef Name='No_x002e__x0020_Notaria'/><Value Type='Text'>{0}</Value></Eq>
                                                        <Eq><FieldRef Name='Pagina' /><Value Type='Text'>{1}</Value></Eq>
                                                    </And>                                                    
                                                </Where>
                                            </Query>
                                        </View>",
                                gvResultados.Rows[gvResultados.SelectedIndex].Cells[0].Text,
                                gvResultados.Rows[gvResultados.SelectedIndex].Cells[1].Text);*/

                string query = string.Format(@"<View>
                                            <Query>
                                                <Where>                                                    
                                                        <Eq><FieldRef Name='ID'/><Value Type='Text'>{0}</Value></Eq>                                                        
                                                </Where>
                                            </Query>
                                        </View>",
                                gvResultados.Rows[gvResultados.SelectedIndex].Cells[0].Text);

                System.Collections.ArrayList arlRows = spLibrary.GetLibraryItem(query);

                if (arlRows.Count > 0)
                {
                    //lblError.Text = arlRows.Count.ToString();

                    Microsoft.SharePoint.Client.ListItem itemRepositorio = (Microsoft.SharePoint.Client.ListItem)arlRows[0];
                    Dictionary<string, object> dc = (Dictionary<string, object>)itemRepositorio.FieldValues;
                    //Aquí se obtienen los datos de los metadatos.
                    string[] metadatos = new string[54];

                    metadatos[0] = "Etiqueta_01|" + itemRepositorio["Tipo_x0020_de_x0020_documento"];
                    metadatos[1] = "Etiqueta_02|" + itemRepositorio["Numero_x0020_de_x0020_Documento"];
                    metadatos[2] = "Etiqueta_03|" + itemRepositorio["Feche_x0020_Documento"];
                    metadatos[3] = "Etiqueta_04|" + itemRepositorio["Lugar_x0020_de_x0020_Otorgamiento"];
                    metadatos[4] = "Etiqueta_05|" + itemRepositorio["No_x002e__x0020_Notaria"];
                    metadatos[5] = "Etiqueta_06|" + itemRepositorio["Actos_x0020_Juridicos"];
                    metadatos[6] = "Etiqueta_08_01|" + itemRepositorio["Ant_Reg_Libro"];
                    metadatos[7] = "Etiqueta_08_02|" + itemRepositorio["Ant_Reg_Tomo"];
                    metadatos[8] = "Etiqueta_08_03|" + itemRepositorio["Ant_Reg_Semestre"];
                    metadatos[9] = "Etiqueta_09|" + itemRepositorio["Ant_Reg_A_x00f1_o_x0020_Semestre"];
                    metadatos[10] = "Etiqueta_10|" + itemRepositorio["Ant_Reg_Seccion_x0020_1"];
                    metadatos[11] = "Etiqueta_11|" + itemRepositorio["Ant_Reg_Serie"];
                    metadatos[12] = "Etiqueta_12|" + itemRepositorio["Ant_Reg_Partida"];
                    metadatos[13] = "Etiqueta_13|" + itemRepositorio["Otorgante"];
                    metadatos[14] = "Etiqueta_14|" + itemRepositorio["Adquiriente"];
                    metadatos[15] = "Etiqueta_15|" + itemRepositorio["Valor_x0020_de_x0020_la_x0020_Operacion"];
                    metadatos[16] = "Etiqueta_16|" + itemRepositorio["Tipo_x0020_de_x0020_Moneda"];
                    metadatos[17] = "Etiqueta_18|" + itemRepositorio["Tipo_x0020_de_x0020_Predio"];
                    metadatos[18] = "Etiqueta_19|" + itemRepositorio["Superficie"];
                    metadatos[19] = "Etiqueta_20|" + itemRepositorio["Unidad_x0020_Superficie"];
                    metadatos[20] = "Etiqueta_22|" + itemRepositorio["Descripcion_x0020_del_x0020_Inmueble"];
                    metadatos[21] = "Etiqueta_23|" + itemRepositorio["Municipio"];
                    metadatos[22] = "Etiqueta_24|" + itemRepositorio["Poblacion"];
                    metadatos[23] = "Etiqueta_25|" + itemRepositorio["Clave_x0020_Catastral"];
                    metadatos[24] = "Etiqueta_27|" + itemRepositorio["Norte"];
                    metadatos[25] = "Etiqueta_28|" + itemRepositorio["Sur"];
                    metadatos[26] = "Etiqueta_29|" + itemRepositorio["Este"];
                    metadatos[27] = "Etiqueta_30|" + itemRepositorio["Oeste_x0020__x0028_Poniente_x0029_"];
                    metadatos[28] = "Etiqueta_31|" + itemRepositorio["Noreste_x0020__x0028_Noroeste_x0029_"];
                    metadatos[29] = "Etiqueta_32|" + itemRepositorio["Noroeste_x0020__x0028_NorPoniente_x0029_"];
                    metadatos[30] = "Etiqueta_37_01|" + itemRepositorio["Fec_Reg_Libro"];
                    metadatos[31] = "Etiqueta_33|" + itemRepositorio["Sureste_x0020__x0028_SurOriente_x0029_"];
                    metadatos[32] = "Etiqueta_34|" + itemRepositorio["Suroeste_x0020__x0028_SurPoniente_x0029_"];
                    metadatos[33] = "Etiqueta_37_02|" + itemRepositorio["Fec_Reg_Tomo"];
                    metadatos[34] = "Etiqueta_37_03|" + itemRepositorio["Fec_Reg_Semestre"];
                    metadatos[35] = "Etiqueta_38|" + itemRepositorio["Fec_Reg_A_x00f1_o_x0020_Semestre"];
                    metadatos[36] = "Etiqueta_39|" + itemRepositorio["Fec_Reg_Seccion"];
                    metadatos[37] = "Etiqueta_40|" + itemRepositorio["Fec_Reg_Partida"];
                    metadatos[38] = "Etiqueta_41|" + itemRepositorio["Partida"];
                    metadatos[39] = "Etiqueta_43|" + itemRepositorio["Anotaciones_x0020_Marginales"];
                    metadatos[40] = "Etiqueta_44_01|" + itemRepositorio["An_Marg_Libro"];
                    metadatos[41] = "Etiqueta_44_02|" + itemRepositorio["An_Marg_Tomo"];
                    metadatos[42] = "Etiqueta_44_03|" + itemRepositorio["An_Marg_Semestre"];
                    //metadatos[43] = "Etiqueta_45|" + itemRepositorio["An_Marg_A_x00f1_o_Semestre"];
                    metadatos[43] = "Etiqueta_45|" + itemRepositorio["An_Marg_Seccion"];
                    metadatos[44] = "Etiqueta_46|" + itemRepositorio["An_Marg_Serie"];
                    metadatos[45] = "Etiqueta_47|" + itemRepositorio["An_Marg_Partida"];
                    //metadatos[47] = "Etiqueta_48|" + itemRepositorio["Anotaciones_x0020_Marginales_x0020_Adicionales"];
                    metadatos[46] = "Etiqueta_49|" + itemRepositorio["Observaciones"];
                    metadatos[47] = "Etiqueta_50|" + itemRepositorio["Inegi_x0020_IdEstado"];
                    metadatos[48] = "Etiqueta_51|" + itemRepositorio["Inegi_x0020_IdMunicipio"];
                    metadatos[49] = "Etiqueta_52|" + itemRepositorio["Inegi_x0020_IdPoblacion"];
                    metadatos[50] = "Etiqueta_53|" + itemRepositorio["Inegi_x0020_IdColonia"];
                    metadatos[51] = "Etiqueta_54|" + itemRepositorio["Inegi_x0020_IdCalle"];
                    metadatos[52] = "Etiqueta_55|" + itemRepositorio["Inegi_x0020_IdNumeroCalle"];
                    metadatos[53] = "Etiqueta_56|" + itemRepositorio["Folio_x0020_Unico_x0020_Propiedad"];
                    /*metadatos[56] = "Etiqueta_57|" + itemRepositorio["Pagina"];
                    metadatos[57] = "Etiqueta_58|" + itemRepositorio["Folio_x0020_Tramite_x0020_Sistema"];
                    metadatos[58] = "Etiqueta_59|" + itemRepositorio["_ModerationStatus"];*/


                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + Session["tempFileName"] + "','_blank')", true);

                    string fileName = Session["tempFileName"].ToString();
                    //string fileName = "Libro_2384_0001.tif";

                    try 
                    {
                        spLibrary.InsertLibraryItem(metadatos, @"C:\Digitas", fileName, true);
                    }
                    catch (Exception exc)
                    {
                        lblError.Text = exc.Message;
                    }

                    //lblError.Text = metadatos[0];
                    //lblError.Text = "OK";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Se ha actualizado el documento electrónico.')", true);
                    gvAntecedentes.DataSource = null;
                    gvAntecedentes.DataBind();
                    gvResultados.DataSource = null;
                    gvResultados.DataBind();
                    imgFileUpload.ImageUrl = "";
                }
            }
            catch (Exception exc)
            {
                lblError.Text = "Error: " + exc.Message;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            BuscaPorFolioInterno();
        }
    }
}