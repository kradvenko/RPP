using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPPMain;

namespace RPP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["dd"] != null)
            {
                Session.Contents.RemoveAll();
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                Session.Contents.RemoveAll();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario currentUser = new Usuario();

            currentUser = Usuario.IniciarSesion(txUsuario.Text, txPassword.Text);

            if (currentUser != null)
            {
                Session.Contents.Add("usuario", currentUser);
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
                    case 1005://Consulta
                        Response.Redirect("Consulta.aspx");
                        break;
                }
            }
            else
            {
                lblResultado.Text = "Error de inicio de sesión.";
            }
        }
    }
}