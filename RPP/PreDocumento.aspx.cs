using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;

namespace RPP
{
    public partial class PreDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Buscar();
        }//

        protected void gvAntecedentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('DocumentoImagen.aspx?url=" + gvResultados.Rows[gvResultados.SelectedIndex].Cells[1].Text + "','_blank')", true);
        }

        private void Buscar()
        {
            try
            {
                RPPMain.SharepointLibrary spLibrary = new RPPMain.SharepointLibrary("http://servidors04/sitios/digitalizacion", "Seccion Primera", "autostore", "Rpp1234");
                lblError.Text = "";
                //int documentoID = int.Parse(Page.Request.QueryString["documentoID"]);

                String reg_act_tomo = Page.Request.QueryString["tomo"];
                String reg_act_semestre = Page.Request.QueryString["semestre"];
                String reg_act_año = Page.Request.QueryString["anio"];
                String reg_act_seccion = Page.Request.QueryString["seccion"];
                String reg_act_serie = Page.Request.QueryString["serie"];
                String reg_act_partida = Page.Request.QueryString["partida"];
                String reg_act_libro = Page.Request.QueryString["libro"];


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

                query = string.Format(@query,
                            reg_act_tomo,
                            reg_act_semestre,
                            reg_act_año,
                            reg_act_seccion,
                            reg_act_serie,
                            reg_act_partida,
                            reg_act_libro);

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

                        resultados.Add(r);
                    }

                    gvResultados.DataSource = resultados;
                    gvResultados.DataBind();
                }
            }
            catch (System.Exception ex)
            {
                lblError.Text = lblError.Text + " 2.- " + ex.Message;
            }
        }
    }
}