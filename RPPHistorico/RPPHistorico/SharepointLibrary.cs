using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using Microsoft.SharePoint.Client;
using System.Net;

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

            try
            {
                clientContext = new ClientContext(siteURL);
                var credentials = new NetworkCredential(userName, password);
                clientContext.Credentials = credentials;

                libraryList = clientContext.Web.Lists.GetByTitle(libraryName);

                clientContext.Load(libraryList);
                clientContext.ExecuteQuery();
                
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Ocurió un error al inicializar acceso a libreria:", ex);
            }

        }

        public ArrayList GetLibraryItem()
        {

            CamlQuery query = new CamlQuery();
            query.ViewXml = string.Format(@"<View>
                                                <Query>
                                                    <Where>
                                                        <And>
                                                            <Eq><FieldRef Name='Tipo_x0020_de_x0020_documento' /><Value Type='Text'>{0}</Value></Eq>
                                                            <Eq><FieldRef Name='Numero_x0020_de_x0020_Documento' /><Value Type='Text'>{1}</Value></Eq>
                                                        </And>
                                                    </Where>
                                                </Query>
                                            </View>",
                            "Escritura Pública",
                            8828);
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
                arlRows.Add( olistItem.FieldValues );
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
                    ArrayList arlValores = new ArrayList();

                    arlValores.Add(BuscarCoincidenciaEtiqueta(row[0])); // Field Label                    

                    string iName = string.Empty;
                    string iType= string.Empty;
                    foreach (Field f in libraryList.Fields)
                    {
                        if (f.Title.Trim().ToUpper().Contains( arlValores[0].ToString().Trim().ToUpper()))
                        {
                            iName = f.InternalName;
                            iType = f.TypeAsString;
                            break;
                        }
                    }

                    if (row.Count < 3)
                    {
                        throw new System.Exception("El renglon no cuenta con los campos adecuados. Etiqueta:" + row[0]);
                    }

                    string valor = row[2];

                    if (iType == "Text")
                    {
                        if (row.Count > 3)
                        {
                            if (row[0].ToString() != "Etiqueta_04")
                            {
                                for (int i = 3; i < row.Count; i++)
                                    valor += row[i].ToString();
                            }
                        }
                    }

                    arlValores.Add(valor); // Field Value
                    arlValores.Add(iName); //Field Internal Name
                    arlValores.Add(iType); //Field Type
                    arlValores.Add(row[0]); //Etiquta
                    arlMetadatos.Add(arlValores);
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
                            if (documentFileName == "Libro_2518_008_007.out")
                            {
                                ;
                            }

                            uploadFile.ListItemAllFields[valores[2].ToString()] = valores[1].ToString();
                            break;
                        case "Number":
                            if (! Util.IsNumeric(valores[1].ToString()))
                                throw new System.Exception("El valor númerico en el campo: " + valores[4].ToString() + " del documento" + documentFileName + " es inválido");

                            uploadFile.ListItemAllFields[valores[2].ToString()] = valores[1].ToString();
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
            foreach (char c in s)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }

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
