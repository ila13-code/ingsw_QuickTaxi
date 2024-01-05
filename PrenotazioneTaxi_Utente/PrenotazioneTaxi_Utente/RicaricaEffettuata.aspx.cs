using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PrenotazioneTaxi_Utente
{
    public partial class RicaricaEffettuata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string result = (string)Session["RicaricaResult"];
                lblRes.Text = result;
                Session.Remove("RicaricaResult");
            }
        }

        
    }
}