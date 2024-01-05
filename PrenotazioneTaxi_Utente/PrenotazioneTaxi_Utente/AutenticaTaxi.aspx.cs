using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Device.Location;

namespace PrenotazioneTaxi_Utente
{
    public partial class AutenticaTaxi : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void plsAccedi_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPSW.Text != "")
            {
                double Latitudine = 39.3050487821813;
                double Longitudine = 16.25205726340376;
                GeoCoordinate GeoCorr = new GeoCoordinate(Latitudine, Longitudine);
                SqlConnection CN = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=PrenotazioneTaxi; user id=sa;password=abacus");
                SqlCommand CMD = new SqlCommand("SELECT idTaxi FROM Taxi WHERE Username=@Username AND Password=@Password", CN);
                CMD.Parameters.Add("@Username", SqlDbType.NChar);
                CMD.Parameters.Add("@Password", SqlDbType.NChar);
                CMD.Parameters["@Username"].Value = txtUsername.Text;
                CMD.Parameters["@Password"].Value = txtPSW.Text;
                CN.Open();
                int Ris = 0;
                if (CMD.ExecuteScalar() != null)
                    Ris = int.Parse(CMD.ExecuteScalar().ToString());
                CN.Close();
                CMD = new SqlCommand("UPDATE Taxi SET LatitudineCorr=@Latitudine, LongitudineCorr=@Longitudine, Libero=1 WHERE idTaxi=" + Ris, CN);
                CMD.Parameters.Add("@Latitudine", SqlDbType.Float);
                CMD.Parameters["@Latitudine"].Value = Latitudine;
                CMD.Parameters.Add("@Longitudine", SqlDbType.Float);
                CMD.Parameters["@Longitudine"].Value = Longitudine;
                CN.Open();
                int Mod = CMD.ExecuteNonQuery();
                CN.Close();
                if (Ris >= 1 && Mod==1)
                {
                    Session["idTaxi"] = Ris;
                    Session.Timeout = 5;
                    Response.Redirect("Prenotazioni.aspx");
                }
                else
                    Response.Redirect("Errore.aspx");
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "ERRORE", "alert('" + "Non hai compilato correttamente tutti i campi; AUTENTICAZIONE FALLITA!" + "');", true);
        }
    }
}