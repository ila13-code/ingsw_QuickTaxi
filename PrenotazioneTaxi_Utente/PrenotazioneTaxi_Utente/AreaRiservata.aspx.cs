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
    public partial class AreaRiservata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=PrenotazioneTaxi; user id=sa;password=abacus");
            if (Session["idUtente"] == null)
                Response.Redirect("Errore.aspx");
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT (Nome +' '+ Cognome) AS Nominativo FROM Utente WHERE idUtente=" + Session["idUtente"], CN);
                CN.Open();
                string Nominativo = cmd.ExecuteScalar().ToString().Trim();
                CN.Close();
                lblUtente.Text = "Ciao " + Nominativo.ToUpper() + "  benvenuto nella tua area riservata";
            }
        }
    }
}