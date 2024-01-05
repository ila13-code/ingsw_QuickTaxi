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
    public partial class Accesso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void plsAccedi_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text!="" && txtPSW.Text!="")
            {
                SqlConnection CN = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=PrenotazioneTaxi; user id=sa;password=abacus");
                SqlCommand CMD = new SqlCommand("SELECT idUtente FROM Utente WHERE Username=@Username AND Password=@Password", CN);
                CMD.Parameters.Add("@Username", SqlDbType.NChar);
                CMD.Parameters.Add("@Password", SqlDbType.NChar);
                CMD.Parameters["@Username"].Value = txtUsername.Text;
                CMD.Parameters["@Password"].Value = txtPSW.Text;
                CN.Open();
                int Ris = 0;
                if (CMD.ExecuteScalar() != null)
                    Ris = int.Parse(CMD.ExecuteScalar().ToString());
                CN.Close();
                if (Ris >= 1)
                {
                    Session["idUtente"] = Ris;
                    Session.Timeout = 5;
                    Response.Redirect("AreaRiservata.aspx");
                }
                else
                    Response.Redirect("Errore.aspx");
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "ERRORE", "alert('" + "Non hai compilato correttamente tutti i campi; AUTENTICAZIONE FALLITA!" + "');", true);
        }
    }
}