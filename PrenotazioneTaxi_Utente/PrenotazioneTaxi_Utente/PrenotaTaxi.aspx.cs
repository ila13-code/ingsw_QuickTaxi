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
    public partial class PrenotaTaxi : System.Web.UI.Page
    {
        SqlConnection CN = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=PrenotazioneTaxi; user id=sa;password=abacus");
        SqlCommand cmd;
        SqlDataReader DR;

        private int TaxiVicino(List<double> MiaLst)
        {
            int PosIDMin = 0;
            for (int K = 3; K <= MiaLst.Count - 1; K += 2)
                if (MiaLst[PosIDMin + 1] > MiaLst[K])
                    PosIDMin = K - 1;
            return Convert.ToInt32(MiaLst[PosIDMin]);
        }

        private int IDZona(List<double> MiaLst)
        {
            int PosIDMin = 0;
            for (int K = 3; K <= MiaLst.Count - 1; K += 2) 
                if (MiaLst[PosIDMin+1] > MiaLst[K])
                    PosIDMin = K-1;
            if (MiaLst[PosIDMin + 1] <= 10000)
                return Convert.ToInt32(MiaLst[PosIDMin]);
            else
                return -1;
        }

        private bool PrenAttiva()
        {
            bool Ris = false;
            cmd = new SqlCommand("SELECT idPrenotazione FROM Prenotazione WHERE LongitudineArr IS NULL AND idUtente=" + Session["idUtente"], CN);
            CN.Open();
            if (cmd.ExecuteScalar()!=null)
            {
                plsPrenota.Visible = false;
                int idPren = int.Parse(cmd.ExecuteScalar().ToString());
                lblEsito.Text = "Hai già prenotato il tuo taxi!! La tua prenotazione è " +idPren ;
                hplTraccia.Visible = true;
                hplTraccia.NavigateUrl = "TracciaIlMioTaxi.aspx?idPrenotazione="+idPren;
                fld.Visible = false;
                Ris = true;
            }
            CN.Close();
            return Ris;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            hplTraccia.Visible = false;
            if (Session["idUtente"] == null)
                Response.Redirect("Errore.aspx");
            else
            {
                if (!IsPostBack)
                {
                    cmd = new SqlCommand("SELECT (Nome +' '+ Cognome) AS Nominativo FROM Utente WHERE idUtente=" + Session["idUtente"], CN);
                    CN.Open();
                    string Nominativo = cmd.ExecuteScalar().ToString().Trim();
                    CN.Close();
                    if (!PrenAttiva())
                        lblUtente.Text = "Benvenuto nella tua area personale " + Nominativo.ToUpper() + ", qui potrai prenotare un taxi; ricorda di attivare il GPS!";
                    else
                        lblUtente.Text = "Benvenuto nella tua area personale " + Nominativo.ToUpper() + " hai già una prenotazione attiva, traccia il tuo taxi con il link qui sotto!";
                    Session["cont"] = 0;
                }
            }
        }

        protected void plsPrenota_Click(object sender, EventArgs e)
        {
           if (txtLat.Text.Length>0 && txtLong.Text.Length>0)
            {
                List<double> DistanzeInM = new List<double>();
               // double Latitudine=double.Parse(txtLat.Text);
                // double Longitudine = Convert.ToDouble(txtLong.Text);
                double Latitudine = 39.30939929349547;
                double Longitudine = 16.25408798220138;
                GeoCoordinate geo = new GeoCoordinate(Latitudine, Longitudine);
                cmd= new SqlCommand("SELECT * FROM Zona", CN);
                CN.Open();
                DR = cmd.ExecuteReader();
                GeoCoordinate PuntoZona;
                if(DR.HasRows)
                {
                    while (DR.Read())
                    {
                        DistanzeInM.Add(Convert.ToDouble(DR["idZona"]));
                        PuntoZona = new GeoCoordinate(Convert.ToDouble(DR["CentroLatitudine"].ToString()), Convert.ToDouble(DR["CentroLongitudine"].ToString()));
                        DistanzeInM.Add(geo.GetDistanceTo(PuntoZona));
                    }
                }
                CN.Close();
                int idZona = IDZona(DistanzeInM);
            if (idZona != -1)
            {               
                cmd = new SqlCommand("SELECT idTaxi, LatitudineCorr, LongitudineCorr FROM Taxi WHERE Libero=1 AND idZona="+idZona, CN);
                CN.Open();
                DR = cmd.ExecuteReader();
                GeoCoordinate geotaxi;
                DistanzeInM.Clear();
                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        geotaxi = new GeoCoordinate(Convert.ToDouble(DR["LatitudineCorr"].ToString()), Convert.ToDouble(DR["LongitudineCorr"].ToString()));
                        DistanzeInM.Add(Convert.ToDouble(DR["idTaxi"]));
                        DistanzeInM.Add(geo.GetDistanceTo(geotaxi));
                    }
                    int IdTaxiVicino = TaxiVicino(DistanzeInM);
                    CN.Close();
                    cmd = new SqlCommand("INSERT INTO Prenotazione (idUtente, idTaxi, LatitudinePart, LongitudinePart, idZonaPart) VALUES (" + Session["idUtente"] + ", " + IdTaxiVicino + ", @Lat, @Long, "+ idZona+"); SELECT @@Identity; UPDATE Taxi SET Libero=0 WHERE idTaxi=" + IdTaxiVicino, CN);
                    cmd.Parameters.Add("@Lat", SqlDbType.Float);
                    cmd.Parameters["@Lat"].Value = Latitudine;
                    cmd.Parameters.Add("@Long", SqlDbType.Float);
                    cmd.Parameters["@Long"].Value = Longitudine;
                    CN.Open();
                        int idPren = Convert.ToInt32(cmd.ExecuteScalar());
                    CN.Close();
                        if (idPren >= 1)
                        {
                            hplTraccia.NavigateUrl = "TracciaIlMioTaxi.aspx?idPrenotazione=" + idPren;
                            lblEsito.Text = "HAI PRENOTATO CORRETTAMENTE IL TUO TAXI! SEGUILO CLICCANDO IL LINK QUI SOTTO!";
                            hplTraccia.Visible = true;
                        }
                        else
                            lblEsito.Text = "OPS.. Qualcosa è andato storto.. Riprova tra qualche minuto!";
                }
                else
                    lblEsito.Text = "Non sono disponibili taxi al momento; risultano tutti occupati!! Riprova tra poco";
            }
            else
                lblEsito.Text = "La posizione in cui ti trovi è in una zona non coperta dal servizio; prova a spostarti!!";
           }
           else
                lblEsito.Text = "IMPOSSIBILE PRENOTARE IL TAXI; PRIMA DEVI ATTIVARE LA GEOLOCALIZZAZIONE!";
        }
    }
}