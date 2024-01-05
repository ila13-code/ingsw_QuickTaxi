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
    public partial class TracciaIlMioTaxi : System.Web.UI.Page
    {
        SqlConnection CN = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=PrenotazioneTaxi; user id=sa;password=abacus");
        SqlCommand cmd;
        SqlDataReader DR;
        int idPrenotazione = 0;
        double[] vetLat = new double[] { 39.302542092151484, 39.303687772999794, 39.30612020719825, 39.30720771865373, 39.30942419734798, 39.31015470677998, 39.31100972516435, 39.31080219739043, 39.31013810437785, 39.30939929349547 };
        double[] vetLong = new double[] { 16.252392826103673, 16.252199707055674, 16.252156791719628, 16.252328453095625, 16.252296266589468, 16.25217824939341, 16.25334769251739, 16.253798303629384, 16.25391632082538, 16.25408798220138 };

        protected void Page_Load(object sender, EventArgs e)
        {
            idPrenotazione =Convert.ToInt32(Request.QueryString["idPrenotazione"]);
            if (Session["idUtente"] == null && idPrenotazione<=0)
                Response.Redirect("Errore.aspx");
            else
            {
                if (!IsPostBack)
                {
                    cmd = new SqlCommand("SELECT (Nome +' '+ Cognome) AS Nominativo FROM Utente WHERE idUtente=" + Session["idUtente"], CN);
                    CN.Open();
                    string Nominativo = cmd.ExecuteScalar().ToString().Trim();
                    CN.Close();
                        lblUtente.Text = "Benvenuto nella tua area personale " + Nominativo.ToUpper() + ", qui potrai prenotare seguire il taxi che hai prenotato (" +idPrenotazione+")!";
                }
            }
        }

        protected void tmrPrenotazione_Tick(object sender, EventArgs e)
        {
            int K =Convert.ToInt32(Session["cont"]);
            string NomeTaxi = "";
            double Lat = vetLat[K];
            double Long = vetLong[K];
            int Min = 0;
            cmd = new SqlCommand("SELECT NomeTaxi, LatitudineCorr, LongitudineCorr, MinAttesaCorr FROM Prenotazione INNER JOIN Taxi ON Prenotazione.idTaxi=Taxi.idTaxi WHERE idPrenotazione=" + idPrenotazione, CN);
            CN.Open();
            DR = cmd.ExecuteReader();
            if (DR.HasRows)
                while (DR.Read())
                {
                    NomeTaxi = DR["NomeTaxi"].ToString().Trim();
                    txtLat.Text = Lat.ToString().Replace(",", ".");
                    txtLong.Text = Long.ToString().Replace(",", ".");
                    Min = int.Parse(DR["MinAttesaCorr"].ToString());
                    txtMin.Text = Min.ToString();
                    Session["cont"] = Convert.ToInt32(Session["cont"]) + 1;
                }
            else
                lblRis.Text = "Qualcosa non va, i dati non sono disponibili. Contatta l'associazione Unione RadioTaxi!";
            CN.Close();
        }
    }
}