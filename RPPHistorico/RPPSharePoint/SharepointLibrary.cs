 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace RPPMain
{
    public class SharepointLibrary
    {
        private const string consignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ";
        private const string sinsignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC";

        private ClientContext clientContext;
        private Web rootWeb;
        private List libraryList;

        private string mSiteURL;
        private string mLibraryName;
        private ArrayList arlCoincidenciasCampos;
        private string mUserName;
        private string mPassword;
        
        public SharepointLibrary(string siteURL, string libraryName, string userName, string password)
        {

            // Descarga de DLL Sharepoint Client
            // --http://www.microsoft.com/en-us/download/details.aspx?id=21786
            // server05 - 192.168.10.6 - digitalizacion - Seccion Primera

            mSiteURL = siteURL;
            mLibraryName = libraryName;

            arlCoincidenciasCampos = new ArrayList();

            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_01", "Tipo de Documento" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_02", "Numero de Documento" });            
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_03", "Fecha Documento" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_04", "Lugar de Otorgamiento" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_05", "No. Notaria" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_06", "Actos juridicos" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_08_01", "Ant_Reg_Libro" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_08_02", "Ant_Reg_Tomo" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_08_03", "Ant_Reg_Semestre" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_09", "Ant_Reg_Año Semestre" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_10", "Ant_Reg_Seccion 1" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_11", "Ant_Reg_Serie" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_12", "Ant_Reg_Partida" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_13", "Otorgante" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_14", "Adquiriente" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_15", "Valor de la Operacion" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_16", "Tipo de Moneda" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_18", "Tipo de Predio" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_19", "Superficie" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_20", "Unidad Superficie" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_22", "Descripcion del Inmueble" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_23", "Municipio" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_24", "Poblacion" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_25", "Clave Catastral" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_27", "Norte" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_28", "Sur" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_29", "Este (Oriente)" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_30", "Oeste (Poniente)" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_31", "Noreste (NorOriente)" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_32", "Noroeste (NorPoniente)" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_33", "Sureste (SurOriente)" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_34", "Suroeste (SurPoniente)" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_36", "Fecha Registro" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_37_01", "Reg_Act_Libro" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_37_02", "Reg_Act_Tomo" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_37_03", "Reg_Act_Semestre" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_38", "Reg_Act_Año Semestre" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_39", "Reg_Act_Seccion" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_40", "Reg_Act_Serie" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_41", "Reg_Act_Partida" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_43", "Anotaciones Marginales" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_44_01", "An_Marg_Libro" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_44_02", "An_Marg_Tomo" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_44_03", "An_Marg_Semestre" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_45", "An_Marg_Seccion" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_46", "An_Marg_Serie" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_47", "An_Marg_Partida" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_49", "Observaciones" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_50", "Inegi IdEstado" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_51", "Inegi IdMunicipio" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_52", "Inegi IdPoblacion" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_53", "Inegi IdColonia" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_54", "Inegi IdCalle" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_55", "Inegi IdNumeroCalle" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_56", "Folio Unico Propiedad" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_99", "Pagina" });
            arlCoincidenciasCampos.Add(new string[2] { "Etiqueta_100", "Folio Tramite Sistema" });

            try
            {
                mUserName = userName;
                mPassword = password;

                clientContext = new ClientContext(siteURL);
                var credentials = new NetworkCredential(userName, password);
                clientContext.Credentials = credentials;                

                libraryList = clientContext.Web.Lists.GetByTitle(libraryName);


                clientContext.Load(libraryList);
                clientContext.ExecuteQuery();

                rootWeb = clientContext.Web;
                clientContext.Load(rootWeb);
                clientContext.ExecuteQuery();
                
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Ocurió un error al inicializar acceso a libreria:", ex);
            }

        }

        public void Prueba()
        {
            ClientContext clientContext = new ClientContext("http://servidors04/sitios/digitalizacion");
            Web site = clientContext.Web;
            clientContext.Load(site);
            clientContext.ExecuteQuery();

            //htp://servidors04/sitios/digitalizacion/_vti_history/512/seccion%20primera/Libro_2384_0001.tif
            Microsoft.SharePoint.Client.File file = site.GetFileByServerRelativeUrl("/sitios/digitalizacion/Seccion Primera/Libro_2384_0001.tif");
            clientContext.Load(file);
            clientContext.ExecuteQuery();

            ListItem currentItem = file.ListItemAllFields;
            clientContext.Load(currentItem);
            clientContext.ExecuteQuery();

           
            FileVersionCollection versions = file.Versions;
            clientContext.Load(versions);
            clientContext.ExecuteQuery();

            

            if (versions != null)
            {
                foreach(FileVersion oldFileVersion in versions)
                {
                    if (oldFileVersion.VersionLabel == "1.0")
                    {
                        Microsoft.SharePoint.Client.ListCollection lists = site.Lists;

                        clientContext.Load(lists);
                        clientContext.ExecuteQuery();

                    
                    }
                   
                }
                
            
            }

        }

        public ArrayList GetLibraryHistoricItem(int idItem)
        {
            CamlQuery query = new CamlQuery();

            //ListItemCollection colItems = libraryList.GetItems(CamlQuery.CreateAllItemsQuery());
            ListItem colItems = libraryList.GetItemById(idItem);            

            clientContext.Load(colItems);

            /*
            clientContext.Load(colItems,
                items => items.Include(
                    item => item.Id,
                    item => item["Pagina"],
                    item => item["Adquiriente"]
                    )
                );
            */

            clientContext.ExecuteQuery();

            FileVersionCollection versions = colItems.File.Versions;

            clientContext.Load(versions);
            IEnumerable<Microsoft.SharePoint.Client.FileVersion> oldVersions;
            oldVersions = clientContext.LoadQuery(versions.Where(v => v != null));
            
            clientContext.ExecuteQuery();

            ArrayList arlVersiones = new ArrayList();
            if (oldVersions != null)
            {
                foreach (FileVersion version in oldVersions)
                {
                    int versionID = version.ID;
                    bool isCurrentVersion = version.IsCurrentVersion;
                    string url = version.Url;
                    string versionLabel = version.VersionLabel;

                    arlVersiones.Add(clientContext.Url+"/"+ url+"|"+versionLabel);
                    
                }

                
            }
                 
            return arlVersiones;

        }

        public ArrayList GetLibraryItem(string camlQuery)
        {
            CamlQuery query = new CamlQuery();
            query.ViewXml = camlQuery;

            //ListItemCollection colItems = libraryList.GetItems(CamlQuery.CreateAllItemsQuery());
            ListItemCollection colItems = libraryList.GetItems(query);

            clientContext.Load(colItems);

            /*
            clientContext.Load(colItems,
                items => items.Include(
                    item => item.Id,
                    item => item["Pagina"],
                    item => item["Adquiriente"]
                    )
                );
            */

            clientContext.ExecuteQuery();

            ArrayList arlRows = new ArrayList();
            foreach (ListItem olistItem in colItems)
            {
                arlRows.Add(olistItem); //.FieldValues );
                //Microsoft.SharePoint.Client.FieldUrlValue fURl = (Microsoft.SharePoint.Client.FieldUrlValue) olistItem["Pagina"];
            }

            return arlRows;

        }

        private string BuscarCoincidenciaEtiqueta(string etiquetaNumero)
        {
            string valorEtiqueta = "";
            foreach (string[] valores in arlCoincidenciasCampos)
            {
                if (valores[0] == etiquetaNumero)
                {
                    valorEtiqueta = valores[1].ToString();
                    break;
                }
            }

            return valorEtiqueta;
        }

        public void ValidateLibraryItem(string documentsFullPath, string documentFileName, Boolean ignoreFieldsNotFound)
        {
            #region Upload document information to SharePoint Library

            string documentFullFileName = documentsFullPath + "\\" + documentFileName;

            clientContext.Load(libraryList);
            clientContext.Load(libraryList.Fields);
            clientContext.ExecuteQuery();

            ArrayList arlMetadatos = new ArrayList();
            using (CsvFileReader reader = new CsvFileReader(documentFullFileName))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {

                    ArrayList arlEtiquetas = new ArrayList();
                    if (row[0] == "Etiqueta_08" || row[0] == "Etiqueta_37" || row[0] == "Etiqueta_44")
                    {
                        if (row[0] == "Etiqueta_08")
                        {
                            arlEtiquetas.Add("Etiqueta_08_01");
                            arlEtiquetas.Add("Etiqueta_08_02");
                            arlEtiquetas.Add("Etiqueta_08_03");
                        }

                        if (row[0] == "Etiqueta_37")
                        {
                            arlEtiquetas.Add("Etiqueta_37_01");
                            arlEtiquetas.Add("Etiqueta_37_02");
                            arlEtiquetas.Add("Etiqueta_37_03");
                        }

                        if (row[0] == "Etiqueta_44")
                        {
                            arlEtiquetas.Add("Etiqueta_44_01");
                            arlEtiquetas.Add("Etiqueta_44_02");
                            arlEtiquetas.Add("Etiqueta_44_03");
                        }

                    }
                    else
                        arlEtiquetas.Add(row[0]);


                    foreach (string etiquetaActual in arlEtiquetas)
                    {
                        ArrayList arlValores = new ArrayList();
                        arlValores.Add(BuscarCoincidenciaEtiqueta(etiquetaActual)); // Field Label

                        string iName = string.Empty;
                        string iType = string.Empty;
                        foreach (Field f in libraryList.Fields)
                        {
                            if (f.Title.Trim().ToUpper().Contains(arlValores[0].ToString().Trim().ToUpper()))
                            {
                                iName = f.InternalName;
                                iType = f.TypeAsString;
                                break;
                            }
                        }


                        string valor = "";

                        if (row.Count < 3)
                        {
                            if (etiquetaActual == "Etiqueta31" || etiquetaActual == "Etiqueta32" || etiquetaActual == "Etiqueta33" || etiquetaActual == "Etiqueta34")
                                valor = "";
                            else
                                throw new System.Exception("El renglon no cuenta con los campos adecuados. Etiqueta:" + etiquetaActual);
                        }
                        else
                            valor = row[2];

                        if (iType == "Text")
                        {
                            if (row.Count > 3)
                            {
                                if (etiquetaActual != "Etiqueta_04")
                                {
                                    for (int i = 3; i < row.Count; i++)
                                        valor += row[i].ToString();
                                }
                            }
                        }

                        arlValores.Add(valor); // Field Value
                        arlValores.Add(iName); //Field Internal Name
                        arlValores.Add(iType); //Field Type
                        arlValores.Add(row[0]); //Etiqueta
                        arlMetadatos.Add(arlValores);
                    }
                    
                }
            }

            if (ignoreFieldsNotFound == false)
            {
                string msgError = "";
                foreach (ArrayList valores in arlMetadatos)
                {
                    if (valores[3].ToString() == string.Empty)
                        msgError += valores[0] + ", ";
                }

                if (msgError.Length > 0)
                    throw new System.Exception("No se encontró coincidencia para los campos: " + msgError.Substring(0, msgError.Length - 2));
            }

            #endregion

            #region Validate document metadata

            foreach (ArrayList valores in arlMetadatos)
            {
                if (valores[2].ToString() != string.Empty)
                {
                    switch (valores[3].ToString())
                    {
                        case "Text":
                            string tmpText = valores[1].ToString();
                            if (tmpText.Length > 250)
                                tmpText = tmpText.Substring(0, 250);
                            break;
                        case "Number":
                            if (!Util.IsNumeric(valores[1].ToString()) || valores[1].ToString().Length == 0)
                                throw new System.Exception("El valor númerico en el campo: " + valores[4].ToString() + " del documento" + documentFileName + " es inválido. valor actual: " + valores[1].ToString());
                            break;
                        case "DateTime":
                            DateTime valorFecha = DateTime.MinValue;
                            try
                            {
                                valorFecha = DateTime.Parse(valores[1].ToString());
                            }
                            catch
                            {
                                throw new System.Exception("El valor de fecha en el campo: " + valores[0].ToString() + " es inválido. valor actual :" + valores[1].ToString());
                            }

                            break;
                    }
                }
            }

            #endregion

        }

        public void InsertLibraryItem(string documentsFullPath, string imagesFullPath, string imageFileName, string documentFileName, Boolean ignoreFieldsNotFound )
        {
            #region Upload document information to SharePoint Library

            string documentFullFileName = documentsFullPath + "\\" + documentFileName;

            clientContext.Load(libraryList);
            clientContext.Load(libraryList.Fields);
            clientContext.ExecuteQuery();
                
            ArrayList arlMetadatos = new ArrayList();
            using (CsvFileReader reader = new CsvFileReader(documentFullFileName))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    //if (row[0] == "Etiqueta_36")
                    //{
                        #region Ciclo etiqueta

                        ArrayList arlEtiquetas = new ArrayList();
                        bool etiquetasLibros = false;
                        if (row[0] == "Etiqueta_15")
                        {
                            string x = "";
                        }

                        if (row[0] == "Etiqueta_08" || row[0] == "Etiqueta_37" || row[0] == "Etiqueta_44")
                        {
                            if (row[0] == "Etiqueta_08")
                            {
                                arlEtiquetas.Add("Etiqueta_08_01");
                                arlEtiquetas.Add("Etiqueta_08_02");
                                arlEtiquetas.Add("Etiqueta_08_03");
                            }

                            if (row[0] == "Etiqueta_37")
                            {
                                arlEtiquetas.Add("Etiqueta_37_01");
                                arlEtiquetas.Add("Etiqueta_37_02");
                                arlEtiquetas.Add("Etiqueta_37_03");
                            }

                            if (row[0] == "Etiqueta_44")
                            {
                                arlEtiquetas.Add("Etiqueta_44_01");
                                arlEtiquetas.Add("Etiqueta_44_02");
                                arlEtiquetas.Add("Etiqueta_44_03");
                            }

                            etiquetasLibros = true;

                        }
                        else
                            arlEtiquetas.Add(row[0]);

                        foreach (string etiquetaActual in arlEtiquetas)
                        {
                            ArrayList arlValores = new ArrayList();

                            arlValores.Add(BuscarCoincidenciaEtiqueta(etiquetaActual)); // Field Label                    

                            string iName = string.Empty;
                            string iType = string.Empty;
                            foreach (Field f in libraryList.Fields)
                            {
                                if (f.Title.Trim().ToUpper().Contains(arlValores[0].ToString().Trim().ToUpper()))
                                {
                                    iName = f.InternalName;
                                    iType = f.TypeAsString;
                                    break;
                                }
                            }

                            string valor = "";
                            if (row.Count < 3)
                            {
                                if (etiquetaActual == "Etiqueta_31" || etiquetaActual == "Etiqueta_32" || etiquetaActual == "Etiqueta_33" || etiquetaActual == "Etiqueta_34" || etiquetaActual == "Etiqueta_25" || etiquetaActual == "Etiqueta_27" || etiquetaActual == "Etiqueta_28" || etiquetaActual == "Etiqueta_29" || etiquetaActual == "Etiqueta_30" || etiquetaActual == "Etiqueta_48")
                                    valor = "";
                                else
                                    throw new System.Exception("El renglon no cuenta con los campos adecuados. Etiqueta:" + row[0]);
                            }
                            else
                                valor = row[2];

                            if (etiquetasLibros)
                            {
                                valor = "";
                                if (etiquetaActual == "Etiqueta_08_01" || etiquetaActual == "Etiqueta_37_01" || etiquetaActual == "Etiqueta_44_01")
                                    if (row.Count > 3)
                                        valor = row[3];

                                if (row.Count >= 5)
                                {
                                    if (etiquetaActual == "Etiqueta_08_02" || etiquetaActual == "Etiqueta_37_02" || etiquetaActual == "Etiqueta_44_02")
                                        valor = row[4];

                                    if (row.Count >= 7)
                                    {
                                        if (etiquetaActual == "Etiqueta_08_03" || etiquetaActual == "Etiqueta_37_03" || etiquetaActual == "Etiqueta_44_03")
                                            valor = row[6];
                                    }
                                }

                            }

                            if (iType == "Text")
                            {
                                if (row.Count > 3)
                                {
                                    if (etiquetaActual != "Etiqueta_04")
                                    {
                                        for (int i = 3; i < row.Count; i++)
                                            valor += row[i].ToString();
                                    }
                                }
                            }

                            if (iType == "Number")
                            {
                                if (valor == ".")
                                    valor = "0";

                                string[] tempVal = valor.Split('.');
                                if (tempVal.Length > 2)
                                {
                                    valor = "";
                                    for (int i = 0; i < tempVal.Length - 1; i++)
                                    {
                                        valor += tempVal[i];
                                    }
                                    valor += "." + tempVal[tempVal.Length - 1];
                                }

                                if (!Util.IsNumeric(valor.ToString()))
                                    valor = "0";

                            }

                            if (iType == "Currency")
                            {
                                if (valor == ".")
                                    valor = "0";

                                string[] tempVal = valor.Split('.');
                                if (tempVal.Length > 2)
                                {
                                    valor = "";
                                    for (int i = 0; i < tempVal.Length - 1; i++)
                                    {
                                        valor += tempVal[i];
                                    }
                                    valor += "." + tempVal[tempVal.Length - 1];
                                }

                                if (!Util.IsNumeric(valor.ToString()))
                                {
                                    valor = "0";
                                }
                            }

                            arlValores.Add(valor); // Field Value
                            arlValores.Add(iName); //Field Internal Name
                            arlValores.Add(iType); //Field Type
                            arlValores.Add(etiquetaActual); //Etiqueta
                            arlMetadatos.Add(arlValores);
                        }

                        #endregion

                    //}
                }
            }

            if (ignoreFieldsNotFound == false)
            {
                string msgError = "";
                foreach (ArrayList valores in arlMetadatos)
                {
                    if(valores[3].ToString() == string.Empty)
                        msgError += valores[0] + ", ";
                }

                if(msgError.Length > 0 )
                    throw new System.Exception("No se encontró coincidencia para los campos: " + msgError.Substring(0, msgError.Length - 2));
            }
            
            #endregion

            #region Upload image file to SharePoint Library

            string tifImageFileNameFullPath = imagesFullPath + "\\" + imageFileName;

            var _file = new FileCreationInformation();
            _file.Content = System.IO.File.ReadAllBytes(tifImageFileNameFullPath);
            _file.Overwrite = true;
            _file.Url = this.mSiteURL + "/" + this.mLibraryName + "/" + imageFileName;

            Microsoft.SharePoint.Client.File uploadFile = libraryList.RootFolder.Files.Add(_file);
            

            #endregion

            #region Validate document metadata

            foreach (ArrayList valores in arlMetadatos)
            {
                if (valores[2].ToString() != string.Empty)
                {
                    switch (valores[3].ToString())
                    {
                        case "Text":
                        case "Note":
                            string tmpText = valores[1].ToString();
                            if (tmpText.Length > 250)
                                tmpText = tmpText.Substring(0, 250);
                            uploadFile.ListItemAllFields[valores[2].ToString()] = tmpText;
                            break;
                        case "Number":
                        case "Currency":
                            if (Util.IsNumeric(valores[1].ToString()))
                                uploadFile.ListItemAllFields[valores[2].ToString()] = valores[1].ToString();
                            else
                                uploadFile.ListItemAllFields[valores[2].ToString()] = "0";
                                //throw new System.Exception("El valor númerico en el campo: " + valores[4].ToString() + " del documento" + documentFileName + " es inválido");
                            break;
                        case "DateTime":
                            DateTime valorFecha = DateTime.MinValue;
                            try
                            {
                                valorFecha = DateTime.Parse( valores[1].ToString());
                            }
                            catch {
                                throw new System.Exception("El valor de fecha en el campo: "+valores[0].ToString()+" es inválido");
                            }

                            uploadFile.ListItemAllFields[valores[2].ToString()] = valorFecha;
                            break;
                        case "File":
                        case "URL":
                            break;
                        default:
                            string x1 = "";
                            break;
                    }
                }
            }
            
            uploadFile.ListItemAllFields["Pagina"] = _file.Url;

            //uploadFile.CheckOut();
            uploadFile.ListItemAllFields.Update();
            //uploadFile.CheckIn("", CheckinType.MajorCheckIn);
            
            clientContext.Load(uploadFile);
            
            clientContext.ExecuteQuery();

            #endregion

        }

        public void InsertLibraryItem(string[] documentFields, string imagesFullPath, string imageFileName, Boolean ignoreFieldsNotFound)
        {
            #region Upload document information to SharePoint Library

            clientContext.Load(libraryList);
            clientContext.Load(libraryList.Fields);
            clientContext.ExecuteQuery();

            ArrayList arlMetadatos = new ArrayList();
            foreach(string fieldValue in documentFields)
            {
                try
                {
                    string[] fieldValues = fieldValue.Split('|');
                    ArrayList arlValores = new ArrayList();

                    arlValores.Add(BuscarCoincidenciaEtiqueta(fieldValues[0])); // Field Label                    

                    string iName = string.Empty;
                    string iType = string.Empty;
                    foreach (Field f in libraryList.Fields)
                    {
                        if (f.Title.Trim().ToUpper().Contains(arlValores[0].ToString().Trim().ToUpper()))
                        {
                            iName = f.InternalName;
                            iType = f.TypeAsString;
                            break;
                        }
                    }

                    string valor = fieldValues[1];

                    arlValores.Add(valor); // Field Value
                    arlValores.Add(iName); //Field Internal Name
                    arlValores.Add(iType); //Field Type
                    arlValores.Add(fieldValues[0]); //Etiqueta
                    arlMetadatos.Add(arlValores);
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception("Ocurrió un error al intentar cargar valores de metadatos, por favor verifique que los pares etiqueta|valor sean correctos." + ex.Message +" - " +ex.StackTrace);
                }
            }

            if (ignoreFieldsNotFound == false)
            {
                string msgError = "";
                foreach (ArrayList valores in arlMetadatos)
                {
                    if (valores[3].ToString() == string.Empty)
                        msgError += valores[0] + ", ";
                }

                if (msgError.Length > 0)
                    throw new System.Exception("No se encontró coincidencia para los campos: " + msgError.Substring(0, msgError.Length - 2));
            }

            #endregion

            #region Upload image file to SharePoint Library

            string tifImageFileNameFullPath = imagesFullPath + "\\" + imageFileName;

            var _file = new FileCreationInformation();
            _file.Content = System.IO.File.ReadAllBytes(tifImageFileNameFullPath);
            _file.Overwrite = true;
            _file.Url = this.mSiteURL + "/" + this.mLibraryName + "/" + imageFileName;

            Microsoft.SharePoint.Client.File uploadFile = libraryList.RootFolder.Files.Add(_file);

            #endregion

            #region Validate document metadata

            foreach (ArrayList valores in arlMetadatos)
            {
                if (valores[2].ToString() != string.Empty)
                {
                    switch (valores[3].ToString())
                    {
                        case "Text":
                            uploadFile.ListItemAllFields[valores[2].ToString()] = valores[1].ToString();
                            break;
                        case "Number":
                            if (!Util.IsNumeric(valores[1].ToString()))
                                throw new System.Exception("El valor númerico en el campo: " + valores[4].ToString() + " es inválido");

                            uploadFile.ListItemAllFields[valores[2].ToString()] = valores[1].ToString();
                            break;
                        case "DateTime":
                            DateTime valorFecha = DateTime.MinValue;
                            try
                            {
                                valorFecha = DateTime.Parse(valores[1].ToString());
                            }
                            catch
                            {
                                throw new System.Exception("El valor de fecha en el campo: " + valores[0].ToString() + " es inválido");
                            }

                            uploadFile.ListItemAllFields[valores[2].ToString()] = valorFecha;
                            break;
                    }
                }
            }

            uploadFile.ListItemAllFields["Pagina"] = _file.Url;

            uploadFile.ListItemAllFields.Update();
            clientContext.Load(uploadFile);
            clientContext.ExecuteQuery();

            #endregion

        }

        //-https://msdn.microsoft.com/en-us/library/office/fp179912.aspx        
    }

    /// <summary>
    /// Utilerias
    /// </summary>
    public class Util
    {
        private const string consignos = "áàäéèëíìïóòöúùuÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ";
        private const string sinsignos = "aaaeeeiiiooouuuAAAEEEIIIOOOUUUcC";        

        public static string RemoverSignosAcentos(String texto)
        {
            StringBuilder textoSinAcentos = new StringBuilder(texto.Length);
            int indexConAcento;
            foreach (char caracter in texto)
            {
                indexConAcento = consignos.IndexOf(caracter);
                if (indexConAcento > -1)
                    textoSinAcentos.Append(sinsignos.Substring(indexConAcento, 1));
                else
                    textoSinAcentos.Append(caracter);
            }
            return textoSinAcentos.ToString();
        }

        public static bool IsNumeric(string s)
        {
            int pointCount = 0;
            foreach (char c in s)
            {
                if (c == '.')
                    pointCount++;

                if (!char.IsDigit(c) && (c != '.' && c != ','))
                {
                    return false;
                }
            }

            if (pointCount > 1)
                return false;
            else
                return true;
        }

    }

    /// <summary>
    /// Class to store one CSV row
    /// </summary>
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }

    /// <summary>
    /// Class to read data from a CSV file
    /// </summary>
    public class CsvFileReader : StreamReader
    {
        public CsvFileReader(Stream stream)
            : base(stream)
        {
        }

        public CsvFileReader(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Reads a row of data from a CSV file
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool ReadRow(CsvRow row)
        {
            row.LineText = ReadLine();
            if (String.IsNullOrEmpty(row.LineText))
                return false;

            int pos = 0;
            int rows = 0;

            while (pos < row.LineText.Length)
            {
                string value;

                // Special handling for quoted field
                if (row.LineText[pos] == '"')
                {
                    // Skip initial quote
                    pos++;

                    // Parse quoted value
                    int start = pos;
                    while (pos < row.LineText.Length)
                    {
                        // Test for quote character
                        if (row.LineText[pos] == '"')
                        {
                            // Found one
                            pos++;

                            // If two quotes together, keep one
                            // Otherwise, indicates end of value
                            if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;
                    }
                    value = row.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    // Parse unquoted value
                    int start = pos;
                    while (pos < row.LineText.Length && row.LineText[pos] != '|')
                        pos++;
                    value = row.LineText.Substring(start, pos - start);
                }

                // Add field to list
                if (rows < row.Count)
                    row[rows] = value;
                else
                    row.Add(value);
                rows++;

                // Eat up to and including next comma
                while (pos < row.LineText.Length && row.LineText[pos] != '|')
                    pos++;
                if (pos < row.LineText.Length)
                    pos++;
            }
            // Delete any unused items
            while (row.Count > rows)
                row.RemoveAt(rows);

            // Return true if any columns read
            return (row.Count > 0);
        }
    }
}
