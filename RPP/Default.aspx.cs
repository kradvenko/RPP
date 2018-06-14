using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;

namespace RPP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RPPMain.Main main = new RPPMain.Main();
            AreaTrabajo area =  main.AreasTrabajo[1];
            
            String descrpcionArea = area.Descripcion;
        }
    }
}