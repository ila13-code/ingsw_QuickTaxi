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
    public partial class TerminaCorsa : System.Web.UI.Page
    {
        SqlConnection CN = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=PrenotazioneTaxi; user id=sa;password=abacus");
        SqlCommand CMD;
        string idPrenotazione = "";

        private int IDZona(List<double> MiaLst)
        {
            int PosIDMin = 0;
            for (int K = 3; K <= MiaLst.Count - 1; K += 2)
                if (MiaLst[PosIDMin + 1] > MiaLst[K])
                    PosIDMin = K - 1;
            if (MiaLst[PosIDMin + 1] <= 10000)
                return Convert.ToInt32(MiaLst[PosIDMin]);
            else
                return -1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            plsDisconnettiti.Visible = false;
            txtLat.Visible = false;
            txtLong.Visible = false;
            idPrenotazione = Request.QueryString["idPrenotazione"];
            if (Session["idTaxi"] == null && idPrenotazione == "")
                Response.Redirect("Errore.aspx");
            else
            {
                if (!IsPostBack)
                {
                    CMD = new SqlCommand("SELECT NomeTaxi FROM Taxi WHERE idTaxi=" + Session["idTaxi"], CN);
                    CN.Open();
                    string NomeTaxi = CMD.ExecuteScalar().ToString().Trim();
                    lblUtente.Text = "Ciao " + NomeTaxi.ToUpper() + ", termina la corsa numero " + idPrenotazione + " subito!";
                    CN.Close();
                }
            }
        }

        protected void plsTermina_Click(object sender, EventArgs e)
        {
            List<double> DistanzeInM = new List<double>();
            double LatitudineCorr = 39.304484757311236;
            double LongitudineCorr = 16.25093370495827;
            GeoCoordinate geo = new GeoCoordinate(LatitudineCorr, LongitudineCorr);
            CMD = new SqlCommand("SELECT * FROM Zona", CN);
            CN.Open();
            SqlDataReader DR = CMD.ExecuteReader();
            GeoCoordinate PuntoZona;
            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    DistanzeInM.Add(Convert.ToDouble(DR["idZona"]));
                    PuntoZona = new GeoCoordinate(Convert.ToDouble(DR["CentroLatitudine"].ToString()), Convert.ToDouble(DR["CentroLongitudine"].ToString()));
                    DistanzeInM.Add(geo.GetDistanceTo(PuntoZona));
                }
            }
            CN.Close();
            int idZonaArr = IDZona(DistanzeInM);
            if (idZonaArr != -1)
            {
                CMD = new SqlCommand("UPDATE Prenotazione SET DataOraArrivo=@DataOraArrivo, LatitudineArr=@Lat, LongitudineArr=@Long, Costo=8, idZonaArr=" + idZonaArr + " WHERE idPrenotazione=" + idPrenotazione + "; UPDATE Taxi SET Libero=1 WHERE idTaxi=" + Session["idTaxi"], CN);
                CMD.Parameters.Add("@DataOraArrivo", SqlDbType.DateTime);
                CMD.Parameters["@DataOraArrivo"].Value = DateTime.Now;
                CMD.Parameters.Add("@Lat", SqlDbType.Float);
                CMD.Parameters["@Lat"].Value = LatitudineCorr;
                CMD.Parameters.Add("@Long", SqlDbType.Float);
                CMD.Parameters["@Long"].Value = LongitudineCorr;
                CN.Open();
                int MOD = CMD.ExecuteNonQuery();
                CN.Close();
                if (MOD != 0)
                {
                    lblRis.Text = "PRENOTAZIONE CHIUSA! IL PAGAMENTO AVVERRA' IN AUTOMATICO";
                    plsDisconnettiti.Visible = true;
                }
                else
                    lblRis.Text = "OPS.. C'è stato un problema.. contatta l'associazione!";
            }
            else
                lblRis.Text = "OPS.. Questa zona non è coperta dal servizio.. contatta l'associazione!";
        }

        protected void plsDisconnettiti_Click(object sender, EventArgs e)
        {
            CMD = new SqlCommand("UPDATE Taxi SET Libero=0 WHERE idTaxi=" + Session["idTaxi"], CN);
            CN.Open();
            CMD.ExecuteNonQuery();
            CN.Close();
            Session.Abandon();
            Response.Redirect("default.aspx");
        }
    }
}