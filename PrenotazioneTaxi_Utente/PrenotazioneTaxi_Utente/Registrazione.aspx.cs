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
    public partial class Registrazione : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void plsRegistrati_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtCognome.Text != "" && txtDataNascita.Text != "" && txtUsername.Text != "" && txtPSW.Text != "")
            {
                SqlConnection CN = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=PrenotazioneTaxi; user id=sa;password=abacus");
                SqlCommand CMD = new SqlCommand("INSERT INTO Utente (Nome, Cognome, DataDiNascita, Username, Password, CreditoDisponibile) VALUES (@Nome, @Cognome, @DataDiNascita, @Username, @Password, @CreditoDisponibile);", CN);
                CMD.Parameters.Add("@Nome", SqlDbType.NChar);
                CMD.Parameters.Add("@Cognome", SqlDbType.NChar);
                CMD.Parameters.Add("@DataDiNascita", SqlDbType.Date);
                CMD.Parameters.Add("@Username", SqlDbType.NChar);
                CMD.Parameters.Add("@Password", SqlDbType.NChar);
                CMD.Parameters.Add("@CreditoDisponibile", SqlDbType.SmallMoney);
                CMD.Parameters["@Nome"].Value = txtNome.Text;
                CMD.Parameters["@Cognome"].Value = txtCognome.Text;
                CMD.Parameters["@DataDiNascita"].Value = Convert.ToDateTime(txtDataNascita.Text);
                CMD.Parameters["@Username"].Value = txtUsername.Text;
                CMD.Parameters["@Password"].Value = txtPSW.Text;
                CMD.Parameters["@CreditoDisponibile"].Value = 0;
                CN.Open();
                int NumModifiche=CMD.ExecuteNonQuery();
                CN.Close();
                if (NumModifiche >= 1)
                    Response.Redirect("home.aspx");
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "ATTENZIONE", "alert('" + "Qualcosa è andato storto! Prova a registrarti di nuovo!!" + "');", true);
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "ERRORE", "alert('" + "Non hai compilato correttamente tutti i campi; REGISTRAZIONE FALLITA!" + "');", true);
        }
    }
}