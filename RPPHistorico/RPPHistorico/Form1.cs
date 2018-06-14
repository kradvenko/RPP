using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace RPPHistorico
{
    public partial class Form1 : Form
    {
        private FolderBrowserDialog folderDocuments;
        private FolderBrowserDialog folderImages;
        private ArrayList logArchivosProcesados;
        public Form1()
        {
            InitializeComponent();

            txtLibreriaSharePoint.Text = "Seleccionar...";
            txtLibreriaSharePoint.Text = "http://servidors04/sitios/digitalizacion";
            folderDocuments = new FolderBrowserDialog();
            folderDocuments.RootFolder = Environment.SpecialFolder.MyComputer;
            txtDirectorioDocumentos.Text = "Seleccionar...";

            folderDocuments.SelectedPath = @"\\192.168.137.39\Imagenes historico\datos_final_07082016\CorreccionFinal";
            txtDirectorioDocumentos.Text = @"\\192.168.137.39\Imagenes historico\datos_final_07082016\CorreccionFinal";

            //folderDocuments.SelectedPath = @"\\192.168.137.39\Imagenes historico\Pruebas";
            //txtDirectorioDocumentos.Text = @"\\192.168.137.39\Imagenes historico\Pruebas";

            //folderDocuments.SelectedPath = @"\\192.168.137.39\Imagenes historico\ActualizarFecha";
            //txtDirectorioDocumentos.Text = @"\\192.168.137.39\Imagenes historico\ActualizarFecha";
            
            folderImages = new FolderBrowserDialog();
            folderImages.RootFolder = Environment.SpecialFolder.MyComputer;
            txtDirectorioImagenes.Text = "Seleccionar...";

            folderImages.SelectedPath = "";

            folderImages.SelectedPath = @"\\192.168.137.39\Imagenes historico\datos_final_07082016\Imagenes";
            txtDirectorioImagenes.Text = @"\\192.168.137.39\Imagenes historico\datos_final_07082016\Imagenes";

            CargarArchivosOUT();
        }

        private void btnInsertarDocumentos_Click(object sender, EventArgs e)
        {
            if (txtLibreriaSharePoint.Text == "Seleccionar...")
            {
                MessageBox.Show("Debe especificar el Repositorio de Sharepoint para la importación Documentos", "Repositorio de Sharepoint", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtDirectorioDocumentos.Text == "Seleccionar...")
            {
                MessageBox.Show("Debe seleccionar el directorio donde se encuentran los archivos .out para importar", "Directorio de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtDirectorioDocumentos.Text == "Seleccionar...")
            {
                MessageBox.Show("Debe seleccionar el directorio donde se encuentran las imágenes .tif para importar", "Directorio de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!Directory.Exists(txtDirectorioDocumentos.Text))
            {
                MessageBox.Show("El directorio seleccionado para ubicación de documentos no existe, por favor verifiquelo", "Directorio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!Directory.Exists(txtDirectorioImagenes.Text))
            {
                MessageBox.Show("El directorio seleccionado para ubicación de imágenes no existe, por favor verifiquelo", "Directorio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            RPPMain.SharepointLibrary spLibrary = null;
            try
            {
                spLibrary = new RPPMain.SharepointLibrary(txtLibreriaSharePoint.Text, "Seccion Primera", "autostore", "Rpp1234");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar conectarse a Sharepoint: " + ex.Message, "Conexión Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string documentoActual = "";
            string itemFile = "";
            ArrayList lstArchivosImagenes = new ArrayList();
            try
            {
                lblTareaActual.Text = "Validando archivos de imágenes...";
                pgbAvance.Value = 0;
                pgbAvance.Maximum = lstDocumentos.Items.Count;
                lstArchivosNoEncontrados.Items.Clear();
                documentoActual = "Paso1";                

                for (int i = 0; i < lstDocumentos.Items.Count; i++)
                {
                    #region Revisar
                    try
                    {
                        if (lstDocumentos.GetItemChecked(i) == false || chkReprocesar.Checked)
                        {
                            itemFile = lstDocumentos.Items[i].ToString();
                            string documentFullFileName = txtDirectorioDocumentos.Text + "\\" + itemFile;

                            documentoActual = "Paso2:" + documentFullFileName;

                            using (RPPMain.CsvFileReader reader = new RPPMain.CsvFileReader(documentFullFileName))
                            {
                                RPPMain.CsvRow row = new RPPMain.CsvRow();
                                while (reader.ReadRow(row))
                                {
                                    if (row[1] != "Página" && row[1] != "PÃ¡gina" && row[1].IndexOf("gina") > 0 && row[1].IndexOf("ginales") == 0)
                                    {
                                        string x = "";
                                    }

                                    if (row[1] == "Página" || row[1] == "PÃ¡gina")
                                    {
                                        documentoActual = "Paso3";
                                        string[] valores = row[2].Split('\\');
                                        if (valores.Length > 0)
                                        {
                                            string imagenFileName = valores[valores.Length - 1];
                                            documentoActual = "Paso4:" + valores.Length.ToString();
                                            string imageFullFileName = txtDirectorioImagenes.Text + "\\" + valores[valores.Length - 2] + "\\" + imagenFileName;
                                            documentoActual = "Paso5";
                                            
                                            bool existe = false;
                                            foreach (string[] imagen in lstArchivosImagenes)
                                            {
                                                if (imagen[0] == imagenFileName)
                                                {
                                                    int numeroInstancias = int.Parse(imagen[1]) + 1;
                                                    imagen[1] = numeroInstancias.ToString();
                                                    existe = true;
                                                    break;
                                                }
                                            }

                                            if(!existe)
                                            {
                                                string[] imagenObject = new string[2];
                                                imagenObject[0] = imagenFileName;
                                                imagenObject[1] = "1";
                                                lstArchivosImagenes.Add(imagenObject);
                                            }

                                            if (!File.Exists(imageFullFileName))
                                                lstArchivosNoEncontrados.Items.Add(itemFile + " Archivo de imágen no existe");
                                            //throw new System.Exception(string.Format("El archivo de imágen [{0}] ligado al archivo out [{1}] no existe en la ruta de imágenes especificada.", imageFullFileName, documentFullFileName));
                                        }
                                        else
                                            lstArchivosNoEncontrados.Items.Add(itemFile + "Archivo de imágen no definido");
                                        //throw new System.Exception(string.Format("El archivo de imágen ligado al archivo out [{0}] no se especifico.", documentFullFileName));
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch 
                    {
                        lstArchivosNoEncontrados.Items.Add(itemFile + " Con error en estructura");
                    }

                    #endregion

                    pgbAvance.Value++;
                }

                #region Imagenes no referenciadas

                lblNumeroImagenes.Text = lstArchivosImagenes.Count + " Imágenes";
                foreach (string[] imagen in lstArchivosImagenes)
                {
                    lstImagenes.Items.Add(imagen[0] + " - " +imagen[1]);
                }

                string[] tifFiles = Directory.GetFiles(folderImages.SelectedPath, "*.tif", SearchOption.AllDirectories);

                string archivoLogNoRef = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\imagenesNoReferenciadasA.txt";

                using (StreamWriter sw = new StreamWriter(archivoLogNoRef))
                {
                    foreach (string tifFile in tifFiles)
                    {
                        bool tifFound = false;
                        foreach (string[] imagen in lstArchivosImagenes)
                        {
                            string imagenFullPath = folderImages.SelectedPath + "\\" + imagen[0].Substring(0, 10) + "\\" + imagen[0];
                            if (tifFile == imagenFullPath)
                            {
                                tifFound = true;
                                break;
                            }
                        }

                        if (!tifFound)
                        {
                            lstImagenesNoReferenciadas.Items.Add(tifFile);
                            sw.WriteLine(tifFile);
                        }
                    }

                }

                lblTotalArchivosNoReferenciados.Text = lstImagenesNoReferenciadas.Items.Count.ToString();

                documentoActual = "Paso6";
                if (lstArchivosNoEncontrados.Items.Count > 0)
                {

                    string archivoNoRef = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\imagenesNoReferenciadas.txt";

                    if (File.Exists(archivoNoRef))
                    {
                        File.Delete(archivoNoRef);
                    }

                    int countFiles = 0;
                    using (StreamWriter sw = new StreamWriter(archivoNoRef))
                    {
                        foreach (string itemFileA in lstArchivosNoEncontrados.Items)
                        {
                            countFiles++;
                            sw.WriteLine(countFiles.ToString() + " - " + itemFileA);
                        }
                    }

                    DialogResult result = MessageBox.Show("No se encontraron los archivos de imágenes referenciadas en algunos de los documentos seleccionados, ¿ Procesar el resto de los documentos ?", "Archivos de Documento sin Imágen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        pgbAvance.Value = 0;
                        lblTareaActual.Text = "En Espera...";
                        return;
                    }
                }

                #endregion

                #region Importar

                this.Cursor = Cursors.WaitCursor;
                lblTareaActual.Text = "Importando documentos e imágenes al repositorio...";
                pgbAvance.Value = 0;

                logArchivosProcesados.Clear();

                int numeroProcesadosReal = 0;
                for (int i = 0; i < lstDocumentos.Items.Count; i++)
                {
                    if (lstDocumentos.GetItemChecked(i) == false || chkReprocesar.Checked)
                    { 
                        itemFile = lstDocumentos.Items[i].ToString();
                        documentoActual = itemFile;
                        string documentFullFileName = txtDirectorioDocumentos.Text + "\\" + itemFile;
                        using (RPPMain.CsvFileReader reader = new RPPMain.CsvFileReader(documentFullFileName))
                        {
                            RPPMain.CsvRow row = new RPPMain.CsvRow();
                            while (reader.ReadRow(row))
                            {
                                if (row.Count > 0)
                                {
                                    if (row[1] == "Página" || row[1] == "PÃ¡gina")
                                    {
                                        string[] valores = row[2].Split('\\');
                                        if (valores.Length > 0)
                                        {
                                            string imageFullFileName = txtDirectorioImagenes.Text + "\\" + valores[valores.Length - 2] + "\\" + valores[valores.Length - 1];
                                            if (File.Exists(imageFullFileName))
                                            {
                                                string strDirectorioDocumentos = txtDirectorioDocumentos.Text;
                                                string strDirectorioImagenes = txtDirectorioImagenes.Text + "\\" + valores[valores.Length - 2];

                                                try
                                                {
                                                    spLibrary.InsertLibraryItem(strDirectorioDocumentos, strDirectorioImagenes, valores[valores.Length - 1], itemFile, chkIgnorarCamposFaltantes.Checked);
                                                    lstDocumentos.SetItemChecked(i, true);
                                                    logArchivosProcesados.Add(itemFile + "," + imageFullFileName);
                                                    numeroProcesadosReal++;
                                                    this.lblTareaActual.Text = numeroProcesadosReal.ToString();
                                                    this.lblTareaActual.Refresh();
                                                }
                                                catch (Microsoft.SharePoint.Client.ServerException ex)
                                                {
                                                    lstArchivosNoEncontrados.Items.Add(itemFile + " - " + ex.Message);
                                                }
                                                catch (System.Exception ex)
                                                {
                                                    lstArchivosNoEncontrados.Items.Add(itemFile + " - " + ex.Message);
                                                }
                                            }
                                        }

                                        break;
                                    }
                                }
                            }
                        }                        
                    }

                    pgbAvance.Value++;
                }

                #endregion

                #region Escribir archivos

                string archivoLog = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\outUpload.txt";

                if (File.Exists(archivoLog))
                {
                    File.Delete(archivoLog);
                }

                int countFilesNR = 0;
                using (StreamWriter sw = new StreamWriter(archivoLog))
                {
                    foreach(string itemFileA in logArchivosProcesados)
                    {
                        countFilesNR++;
                        sw.WriteLine(countFilesNR.ToString() + " - " + itemFileA);
                    }
                }

                this.Cursor = Cursors.Default;
                MessageBox.Show("Proceso de importación finalizado correctamente", "Proceso Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pgbAvance.Value = 0;
                lblTareaActual.Text = "En Espera...";

                #endregion

            }
            catch (System.Exception ex)
            {
                this.Cursor = Cursors.Default;
                pgbAvance.Value = 0;
                lblTareaActual.Text = "En Espera...";
                MessageBox.Show("Ocurrió un error al intentar importar el documento["+documentoActual+"] : " + ex.Message+ ex.StackTrace, "Importación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSeleccionarDirectorioDocumentos_Click(object sender, EventArgs e)
        {
            DialogResult result = folderDocuments.ShowDialog();

            if (result == DialogResult.OK)
            {
                CargarArchivosOUT();
            }
        }

        private void btnSeleccionarDirectorioImagenes_Click(object sender, EventArgs e)
        {
            DialogResult result = folderImages.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtDirectorioImagenes.Text = folderImages.SelectedPath;
            }
        }

        private void CargarArchivosOUT()
        {
            if (folderDocuments.SelectedPath != "")
            { 
                txtDirectorioDocumentos.Text = folderDocuments.SelectedPath;

                string[] outFiles = Directory.GetFiles(folderDocuments.SelectedPath, "*.out", SearchOption.AllDirectories);

                string archivoLog = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\outUpload.txt";

                logArchivosProcesados = new ArrayList();

                if (File.Exists(archivoLog))
                {                    
                    using (StreamReader sr = new StreamReader(archivoLog))
                    {
                        while (sr.Peek() > 0)
                        {
                            string nombreArchivo = sr.ReadLine().ToUpper();
                            logArchivosProcesados.Add(nombreArchivo);
                        }
                    }
                }

                lstDocumentos.Items.Clear();
                int totalProcesados = 0;
                ArrayList alrNoProcesados = new ArrayList();
                foreach (string fileNamePath in outFiles)
                {
                    string fileName = fileNamePath.Substring(folderDocuments.SelectedPath.Length + 1);
                    int itemIndex = lstDocumentos.Items.Add(fileName);

                    bool encontrado = false;
                    foreach (string archivoProcesado in logArchivosProcesados)
                    {
                        string x = archivoProcesado.Split(',')[0].ToString().Split('-')[1].Trim();

                        if (fileName.ToUpper() == x.ToUpper())
                        {
                            lstDocumentos.SetItemChecked(itemIndex, true);
                            totalProcesados++;
                            encontrado = true;

                            break;
                        }
                    }

                    if (!encontrado)
                    {
                        //alrNoProcesados.Add(fileNamePath);
                        //File.Copy(fileNamePath, folderDocuments.SelectedPath + "\\NoProcesados\\" + fileName.Split('\\')[1]);
                    }
                    //lstDocumentos.SetItemChecked(itemIndex, true);
                }

                lblTotalFiles.Text = outFiles.Length.ToString() + " Archivos ( " + totalProcesados.ToString()+" Previamente procesados )" ;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            RPPMain.SharepointLibrary spLibrary = null;
            try
            {
                spLibrary = new RPPMain.SharepointLibrary(txtLibreriaSharePoint.Text, "Seccion Primera", "autostore", "Rpp1234");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar conectarse a Sharepoint: " + ex.Message, "Conexión Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            string query =  string.Format(@"<View>
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
                            38773);
            
            query = @"<View>
                        <Query>
                            <Where> 
                                <And>
                                    <Eq><FieldRef Name='Partida' /><Value Type='Number'>15</Value></Eq>
                                    <Eq><FieldRef Name='Numero_x0020_de_x0020_Documento' /><Value Type='Text'>38885</Value></Eq>                                   
                                </And>
                                <And>
                                    <Eq><FieldRef Name='Fec_Reg_Libro' /><Value Type='Text'>1474</Value></Eq>
                                    <Eq><FieldRef Name='Fec_Reg_Seccion' /><Value Type='Text'>1</Value></Eq>
                                </And>
                            </Where>
                        </Query>
                    </View>";


            query = @"<View>
                        <Query>
                            <Where>
                                <And>
                                <And>
                                <And>
                                    <Eq><FieldRef Name='Fec_Reg_Seccion' /><Value Type='Text'>I</Value></Eq>
                                    <Eq><FieldRef Name='Fec_Reg_Partida' /><Value Type='Text'>A</Value></Eq>
                                </And>
                                    <Eq><FieldRef Name='Partida' /><Value Type='Text'>124</Value></Eq>
                                </And>
                                    <Eq><FieldRef Name='Fec_Reg_Libro' /><Value Type='Text'>1474</Value></Eq>
                                </And>
                            </Where>
                        </Query>
                      </View>";
            ArrayList valores = spLibrary.GetLibraryItem(query);

            if (valores.Count > 0)
            {
                Microsoft.SharePoint.Client.ListItem itemActual = (Microsoft.SharePoint.Client.ListItem)valores[0];

                Dictionary<string, object> dc = (Dictionary<string, object>)itemActual.FieldValues;
                Microsoft.SharePoint.Client.FieldUrlValue fURl = (Microsoft.SharePoint.Client.FieldUrlValue)dc["Pagina"];

                /*
                ArrayList arlResultado = spLibrary.GetLibraryItem(query);

                string strUrl = arlResultado[2].ToString().Split('|')[0];
                System.Uri uri = new Uri(strUrl);

                var request = System.Net.WebRequest.Create(uri);
                
                 */
                
                var request = System.Net.WebRequest.Create(fURl.Url);
                request.UseDefaultCredentials = true;
                var response = request.GetResponse();
                var stream = response.GetResponseStream();

                pictureBox1.Image = Bitmap.FromStream(stream);

                

            }            
            

            

        }

        private void lstDocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            RPPMain.SharepointLibrary spLibrary = null;
            try
            {
                spLibrary = new RPPMain.SharepointLibrary(txtLibreriaSharePoint.Text, "Seccion Primera", "autostore", "Rpp1234");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar conectarse a Sharepoint: " + ex.Message, "Conexión Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string itemFile = "";
            string documentoActual = "";
            string archivoIncidencias = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\archivosConIncidencias.txt";
            

            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblTareaActual.Text = "Validando archivos con incidencias...";
                pgbAvance.Value = 0;

                using (RPPMain.CsvFileReader reader1 = new RPPMain.CsvFileReader(archivoIncidencias))
                {
                    RPPMain.CsvRow row1 = new RPPMain.CsvRow();
                    while (reader1.ReadRow(row1))
                    {                        
                        itemFile = "Libro_"+row1[0].Substring(0, 4)+"\\Libro_"+row1[0].Substring(0, 12)+".out";

                        string documentFullFileName = txtDirectorioDocumentos.Text + "\\" + itemFile;
                        string strDirectorioDocumentos = txtDirectorioDocumentos.Text;

                        try
                        {
                            spLibrary.ValidateLibraryItem(strDirectorioDocumentos, itemFile, false);
                        }
                        catch (Microsoft.SharePoint.Client.ServerException ex)
                        {
                            logArchivosProcesados.Add(itemFile + " - " + ex.Message);
                        }
                        catch (System.Exception ex)
                        {
                            logArchivosProcesados.Add(itemFile + " - " + ex.Message);
                        }                        

                        pgbAvance.Value++;
                    }
                    
                }

                string archivoLog = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\observaciones.txt";

                if (File.Exists(archivoLog))
                {
                    File.Delete(archivoLog);
                }

                using (StreamWriter sw = new StreamWriter(archivoLog))
                {
                    foreach (string itemFileA in logArchivosProcesados)
                    {
                        sw.WriteLine(itemFileA);
                    }
                }

                this.Cursor = Cursors.Default;
                MessageBox.Show("Proceso de importación finalizado correctamente", "Proceso Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pgbAvance.Value = 0;
                lblTareaActual.Text = "En Espera...";
            }
            catch (System.Exception ex)
            {
                this.Cursor = Cursors.Default;
                pgbAvance.Value = 0;
                lblTareaActual.Text = "En Espera...";
                MessageBox.Show("Ocurrió un error al intentar importar el documento[" + documentoActual + "] : " + ex.Message + ex.StackTrace, "Importación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string itemFile = "";
            string documentoActual = "";
            string archivoIncidencias = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\procesados.txt";

            ArrayList logArchivosProcesados = new ArrayList();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblTareaActual.Text = "Calculando archivos no procesados...";
                pgbAvance.Value = 0;

                using (RPPMain.CsvFileReader reader1 = new RPPMain.CsvFileReader(archivoIncidencias))
                {
                    RPPMain.CsvRow row1 = new RPPMain.CsvRow();
                    while (reader1.ReadRow(row1))
                    {
                        itemFile = row1[0].ToString().Split('-')[1].Trim();

                        string documentFullFileName = txtDirectorioDocumentos.Text + "\\" + itemFile;
                        string strDirectorioDocumentos = txtDirectorioDocumentos.Text;

                        //foreach( )

                        pgbAvance.Value++;
                    }

                }

                string archivoLog = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\NoProcesados.txt";

                if (File.Exists(archivoLog))
                {
                    File.Delete(archivoLog);
                }

                using (StreamWriter sw = new StreamWriter(archivoLog))
                {
                    foreach (string itemFileA in logArchivosProcesados)
                    {
                        sw.WriteLine(itemFileA);
                    }
                }

                this.Cursor = Cursors.Default;
                MessageBox.Show("Proceso finalizado correctamente", "Proceso Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pgbAvance.Value = 0;
                lblTareaActual.Text = "En Espera...";
            }
            catch (System.Exception ex)
            {
                this.Cursor = Cursors.Default;
                pgbAvance.Value = 0;
                lblTareaActual.Text = "En Espera...";
                MessageBox.Show("Ocurrió un error" + ex.Message + ex.StackTrace, "Proceso Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
