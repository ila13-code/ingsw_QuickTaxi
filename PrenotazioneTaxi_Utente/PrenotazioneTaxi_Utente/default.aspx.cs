using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrenotazioneTaxi_Utente
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void plsRegistratiUtente_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrazione.aspx");
        }

        protected void plsAccediUtente_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accesso.aspx");
        }

        protected void plsAccediTaxi_Click(object sender, EventArgs e)
        {
            Response.Redirect("AutenticaTaxi.aspx");
        }
    }
}