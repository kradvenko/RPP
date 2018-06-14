using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitMiracle.LibTiff.Classic;
using System.Net;
using System.Windows.Media.Imaging;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RPP
{
    public partial class DocumentoImagen : System.Web.UI.Page
    {

        TiffBitmapDecoder decoder;
        List<System.Drawing.Image> images;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String url = Page.Request.QueryString["url"];
                String fromMemory = Page.Request.QueryString["memory"];
                if (url != null)
                {
                    try
                    {
                        lblError.Text = "";
                        System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                        request.UseDefaultCredentials = true;

                        System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

                        System.IO.Stream responseStream = response.GetResponseStream();

                        string fileName = Path.GetRandomFileName();

                        //new System.Drawing.Bitmap(responseStream).Save(@"C:\Digitas\" + fileName + ".tif", System.Drawing.Imaging.ImageFormat.Tiff);

                        //System.IO.Stream tbStream = File.OpenRead(@"C:\Digitas\" + fileName + ".tif");

                        decoder = new TiffBitmapDecoder(responseStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                        int pagecount = decoder.Frames.Count;


                        //lblError.Text = pagecount.ToString();
                        TiffBitmapEncoder encoderFile = new TiffBitmapEncoder();
                        images = new List<System.Drawing.Image>();                        

                        for (int i = 0; i < decoder.Frames.Count; i++)
                        {
                            MemoryStream ms = new MemoryStream();
                            TiffBitmapEncoder encoder = new TiffBitmapEncoder();
                            //ddlPaginas.Items.Add("Página " + (i + 1));
                            encoder.Frames.Add(decoder.Frames[i]);
                            encoder.Save(ms);
                            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                            images.Add(img);

                            MemoryStream ms3 = new MemoryStream();
                            images[i].Save(ms3, System.Drawing.Imaging.ImageFormat.Tiff);
                            System.Windows.Media.Imaging.BitmapFrame bmFrame = System.Windows.Media.Imaging.BitmapFrame.Create(ms3);
                            encoderFile.Frames.Add(bmFrame);
                        }
                        Session["images"] = images;
                        System.IO.FileStream fsTemp = new System.IO.FileStream(@"C:\Digitas\" + fileName + ".tif", FileMode.Create);
                        encoderFile.Save(fsTemp);
                        fsTemp.Close();

                        //Response.ContentType = "image/jpeg";
                        //new System.Drawing.Bitmap(responseStream).Save(@"C:\Digitas\Temp_Tiff.tif", System.Drawing.Imaging.ImageFormat.Tiff);


                        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 5, 5, 5, 5);
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new System.IO.FileStream(@"C:\Digitas\" + fileName + ".pdf", System.IO.FileMode.Create));

                        System.Drawing.Bitmap bm = new System.Drawing.Bitmap(@"C:\Digitas\" + fileName + ".tif");
                        int total = bm.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);

                        document.Open();

                        iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;

                        for (int k = 0; k < total; ++k)
                        {
                            bm.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, k);
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bm, System.Drawing.Imaging.ImageFormat.Bmp);
                            // scale the image to fit in the page  
                            img.ScaleAbsolute(600, 800);
                            img.SetAbsolutePosition(0, 0);
                            cb.AddImage(img);
                            document.NewPage();
                        }
                        document.Close();
                        Response.ContentType = "Application/pdf";
                        Response.TransmitFile(@"C:\Digitas\" + fileName + ".pdf");
                         
                        /*
                        System.Drawing.Image img = System.Drawing.Image.FromStream(responseStream);

                        Tiff image = Tiff.ClientOpen("memory", "r", responseStream, new TiffStream());
                    
                        if (img == null)
                        {
                            lblError.Text = "Null image s";
                        }
                        else
                        {
                            img.Save(@"C:\Digitas\digit.tif");
                        }

                        if (image == null)
                        {
                            lblError.Text = "Null image tiff";
                        }
                        else
                        {
                            var num = image.NumberOfDirectories();
                            lblError.Text = num.ToString();
                        }
                        */

                        


                        
                        /*
                        MemoryStream ms2 = new MemoryStream();
                        images[0].Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //BinaryReader br = new BinaryReader(ms2);
                        //Byte[] bytes = br.ReadBytes((Int32)ms2.Length);
                        byte[] bytes = ms2.ToArray();
                        //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        string base64String = Convert.ToBase64String(bytes);
                        //string base64String = Convert.ToBase64String((byte[])img);
                        Image1.ImageUrl = "data:image/jpg;base64," + base64String;
                        */
                        /*
                        Session["images"] = images;


                        var document = new Document(PageSize.LETTER, 5, 5, 5, 5);

                        // Create a new PdfWriter object, specifying the output stream
                        var output = new MemoryStream();
                        var writer = PdfWriter.GetInstance(document, output);

                        document.Open();

                        for (int i = 0; i < images.Count; i++)
                        {
                            var image = iTextSharp.text.Image.GetInstance(images[i], iTextSharp.text.BaseColor.WHITE);
                            image.ScaleAbsolute(600, 800);
                            document.Add(image);
                            document.NewPage();
                        }                        

                        document.Close();

                        Response.ContentType = "application/pdf";
                        //Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Receipt-{0}.pdf", txtOrderID.Text));
                        Response.BinaryWrite(output.ToArray()); 

                        
                        // Open the Document for writing
                        
                        //img.Save(@"C:\Digitas\digit2.jpg");

                        //Response.ContentType = "image/jpeg";
                        //new System.Drawing.Bitmap(ms).Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                       
                        //HttpContext.Current.Response.Flush();
                        //HttpContext.Current.Response.SuppressContent = true;
                        //HttpContext.Current.ApplicationInstance.CompleteRequest();

                        /*HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.SuppressContent = true;
                        HttpContext.Current.ApplicationInstance.CompleteRequest();

                        /*FileWebRequest request = (FileWebRequest)WebRequest.Create(url);

                        request.UseDefaultCredentials = true;

                        System.Net.FileWebResponse response = (System.Net.FileWebResponse)request.GetResponse();*/

                        //System.IO.Stream responseStream = response.GetResponseStream();

                        /*System.IO.StreamReader reader = new StreamReader(responseStream);

                        if (reader == null)
                        {
                            lblError.Text = "Null";
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream();
                            responseStream.CopyTo(ms);
                            /*responseStream.Close();
                            reader.Close();
                        
                            Tiff image = Tiff.ClientOpen("memory", "r", ms, new TiffStream());

                            if (image == null)
                            {
                                lblError.Text = "Null image";
                            }
                            lblError.Text = ms.Length.ToString();
                            using (FileStream file = new FileStream(@"C:\Digitas\digit.tif", FileMode.Create, System.IO.FileAccess.Write))
                            {
                                byte[] bytes = new byte[ms.Length];
                                ms.Read(bytes, 0, (int)ms.Length);
                                file.Write(bytes, 0, bytes.Length);
                                //ms.Close();
                                //file.Close();
                            }

                            Tiff image = Tiff.Open(@"C:\Digitas\digit.tif", "r");
                            if (image == null)
                            {
                                lblError.Text = "Null image";
                            }
                            else
                            { 
                                var num = image.NumberOfDirectories();
                                lblError.Text = num.ToString();
                            }

                        
                        }*/



                    }
                    catch (System.Exception ex)
                    {
                        lblError.Text = lblError.Text + " 0.- " + ex.Message;
                    }
                }
                else if (fromMemory == null)
                {
                    try
                    {
                        RPPMain.SharepointLibrary spLibrary = new RPPMain.SharepointLibrary("http://servidors04/sitios/digitalizacion", "Seccion Primera", "autostore", "Rpp1234");
                        //RPPMain.SharepointLibrary spLibrary = new RPPMain.SharepointLibrary("http://servidors04/sitios/digitalizacion", "Seccion Primera", "administrador", "Zmy45r1");

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


                        /*query = string.Format(@query,
                                    reg_act_tomo,
                                    reg_act_semestre,
                                    reg_act_año,
                                    reg_act_seccion,
                                    reg_act_serie,
                                    reg_act_partida,
                                    reg_act_libro);*/

                        /*string query = string.Format(@"<View>
                                                       <Query>
                                                           <Where>
                                                               <And>
                                                               <And>
                                                               <And>
                                                                   <Eq><FieldRef Name='Fec_Reg_Libro' /><Value Type='Text'>{0}</Value></Eq>
                                                                   <Eq><FieldRef Name='Partida' /><Value Type='Text'>{1}</Value></Eq>
                                                               </And>
                                                                   <Eq><FieldRef Name='Fec_Reg_Seccion' /><Value Type='Text'>{2}</Value></Eq>
                                                               </And>
                                                                   <Eq><FieldRef Name='Fec_Reg_Partida' /><Value Type='Text'>{3}</Value></Eq>
                                                               </And>
                                                           </Where>
                                                       </Query>
                                                   </View>",
                               2384,
                               1,
                               1,
                               "A");*/

                        System.Collections.ArrayList arlRows = spLibrary.GetLibraryItem(query);

                        if (arlRows.Count > 0)
                        {
                            lblError.Text = "";

                            Microsoft.SharePoint.Client.ListItem itemRepositorio = (Microsoft.SharePoint.Client.ListItem)arlRows[0];
                            Dictionary<string, object> dc = (Dictionary<string, object>)itemRepositorio.FieldValues;
                            Microsoft.SharePoint.Client.FieldUrlValue fURl = (Microsoft.SharePoint.Client.FieldUrlValue)dc["Pagina"];

                            try
                            {
                                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(fURl.Url);
                                request.UseDefaultCredentials = true;

                                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

                                System.IO.Stream responseStream = response.GetResponseStream();

                                /*Response.ContentType = "image/jpeg";
                                new System.Drawing.Bitmap(responseStream).Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        
                                HttpContext.Current.Response.Flush();
                                HttpContext.Current.Response.SuppressContent = true;
                                HttpContext.Current.ApplicationInstance.CompleteRequest();*/

                            }
                            catch (System.Exception ex)
                            {
                                lblError.Text = lblError.Text + " 1.- " + ex.Message;
                            }

                        }
                    }
                    catch (System.Exception ex)
                    {
                        lblError.Text = lblError.Text + " 2.- " + ex.Message;
                    }
                }
                else if (fromMemory != null)
                {
                    try
                    {

                        images = new List<System.Drawing.Image>();
                        images = (List<System.Drawing.Image>)Session["images"];
                        
                        TiffBitmapEncoder encoder = new TiffBitmapEncoder();
                        MemoryStream ms3 = new MemoryStream();

                        for (int i = 0; i < images.Count; i++)
                        {
                            //ddlPaginas.Items.Add("Página " + (i + 1));
                            ms3 = new MemoryStream();
                            images[i].Save(ms3, System.Drawing.Imaging.ImageFormat.Tiff);
                            System.Windows.Media.Imaging.BitmapFrame bmFrame = System.Windows.Media.Imaging.BitmapFrame.Create(ms3);
                            encoder.Frames.Add(bmFrame);
                        }
                        /*
                        MemoryStream ms2 = new MemoryStream();
                        images[0].Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] bytes = ms2.ToArray();
                        string base64String = Convert.ToBase64String(bytes);
                        Image1.ImageUrl = "data:image/jpg;base64," + base64String;

                        /*string fileName = Path.GetTempFileName();

                        lblError.Text = fileName;

                        Session["tempFileName"] = fileName;*/

                        string fileName = Path.GetRandomFileName();

                        Session["tempFileName"] = fileName + ".tif";

                        System.IO.FileStream fsTemp = new System.IO.FileStream(@"C:\Digitas\" + fileName + ".tif", FileMode.Create);
                        encoder.Save(fsTemp);
                        fsTemp.Close();



                        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 5, 5, 5, 5);
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new System.IO.FileStream(@"C:\Digitas\" + fileName + ".pdf", System.IO.FileMode.Create));

                        System.Drawing.Bitmap bm = new System.Drawing.Bitmap(@"C:\Digitas\" + fileName + ".tif");
                        int total = bm.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);

                        document.Open();
                        iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
                        for (int k = 0; k < total; ++k)
                        {
                            bm.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, k);
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bm, System.Drawing.Imaging.ImageFormat.Bmp);
                            // scale the image to fit in the page  
                            img.ScaleAbsolute(600, 800);
                            img.SetAbsolutePosition(0, 0);
                            cb.AddImage(img);
                            document.NewPage();
                        }
                        document.Close();

                        Response.ContentType = "Application/pdf";
                        Response.TransmitFile(@"C:\Digitas\" + fileName + ".pdf");

                    }
                    catch (Exception exc)
                    {
                        lblError.Text = exc.Message;
                    }
                }
            }
            else
            {
                //decoder = (TiffBitmapDecoder)Session["decoder"];
                images = new List<System.Drawing.Image>();
                images = (List<System.Drawing.Image>)Session["images"];
            }
    }

        protected void ddlPaginas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Text = "Cargando";
            try
            {
                int frame = ddlPaginas.SelectedIndex;

                /*MemoryStream ms = new MemoryStream();

                TiffBitmapEncoder encoder = new TiffBitmapEncoder();

                encoder.Frames.Add(decoder.Frames[frame]);
                encoder.Save(ms);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);*/

                MemoryStream ms2 = new MemoryStream();
                images[frame].Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] bytes = ms2.ToArray();

                string base64String = Convert.ToBase64String(bytes);

                Image1.ImageUrl = "data:image/jpg;base64," + base64String;
                lblError.Text = "";
            }
            catch (Exception exc)
            {
                lblError.Text = exc.Message;
            }
        }
    }
}