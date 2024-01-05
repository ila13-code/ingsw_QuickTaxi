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
    public partial class CorseEffettuate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=PrenotazioneTaxi; user id=sa;password=abacus");
            if (Session["idUtente"] == null)
                Response.Redirect("Errore.aspx");
            else
            {
                grdCorse.AutoGenerateColumns = false;
                SqlCommand cmd = new SqlCommand("SELECT (Nome +' '+ Cognome) AS Nominativo FROM Utente WHERE idUtente=" + Session["idUtente"], CN);
                    CN.Open();
                    string Nominativo = cmd.ExecuteScalar().ToString().Trim();
                    CN.Close();
                    lblUtente.Text = "Ciao " + Nominativo.ToUpper() + " qui trovi tutte le corse effettuate e i relativi costi che ti sono stati addebbitati sulla carta che hai fornito al momento della registrazione!";
                    SqlDataAdapter DA = new SqlDataAdapter("SELECT DISTINCT idPrenotazione, NomeTaxi, DataOraPartenza, DataOraArrivo, Costo FROM Prenotazione INNER JOIN Taxi ON Prenotazione.idTaxi=Taxi.idTaxi WHERE idUtente=" + Session["idUtente"], CN);
                    DataTable dt = new DataTable();
                    DA.Fill(dt);
                    grdCorse.DataSource = dt;
                    grdCorse.DataBind();
            }
        }
    }
}