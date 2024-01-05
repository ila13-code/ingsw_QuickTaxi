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
    public partial class Prenotazioni : System.Web.UI.Page
    {
        SqlConnection CN = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=PrenotazioneTaxi; user id=sa;password=abacus");
        SqlCommand CMD;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idTaxi"] == null)
                Response.Redirect("Errore.aspx");
            else
            {
                if (!IsPostBack)
                {
                    CMD = new SqlCommand("SELECT NomeTaxi FROM Taxi WHERE idTaxi=" + Session["idTaxi"], CN);
                    CN.Open();
                    string NomeTaxi = CMD.ExecuteScalar().ToString().Trim();
                    lblUtente.Text = "Ciao, benvenuto nella pagina dedicata al taxi che guidi:" + NomeTaxi.ToUpper() + ", qui potrai attendere nuove prenotazioni; appena te ne arriverà una potrai visualizzare il percorso da compiere per arrivare dal tuo cliente!";
                    CN.Close();
                    hplPercorso.Visible = false;
                    Session["K"] = 0;
                }
            }
        }

        protected void tmrPrenotazione_Tick(object sender, EventArgs e)
        {
            CMD = new SqlCommand("SELECT idPrenotazione, Cognome, Nome, LatitudinePart, LongitudinePart FROM Prenotazione INNER JOIN Utente ON Prenotazione.idUtente=Utente.idUtente WHERE LatitudineArr IS NULL AND idTaxi=" + Session["idTaxi"], CN);
            CN.Open();
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                lblPrenotazione.Text = "Ti è stata affidata la prenotazione numero " + DR["idPrenotazione"].ToString() + "\n" + "Il tuo passeggero è: " + DR["Cognome"].ToString().Trim().ToUpper() + " " + DR["Nome"].ToString().Trim().ToUpper() + "\n" + "Per visualizzare il percorso da compiere clicca sul link qui sotto!";
                hplPercorso.NavigateUrl = "PrenotazioneInCorso.aspx?idPrenotazione=" + DR["idPrenotazione"];
                hplPercorso.Visible = true;
            }
            else
                lblPrenotazione.Text = "Non ti è stata affidata nessuna prenotazione!!";
            CN.Close();
        }
    }
}