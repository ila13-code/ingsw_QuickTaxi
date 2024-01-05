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
    public partial class PrenotazioneInCorso : System.Web.UI.Page
    {
        SqlConnection CN = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=PrenotazioneTaxi; user id=sa;password=abacus");
        SqlCommand CMD;
        string idPrenotazione = "";
        double LongitudineCliente = 0;
        double LatitudineCliente = 0;

        double[] vetLat = new double[] { 39.30244246684364, 39.303687772999794, 39.30612020719825, 39.30720771865373, 39.30942419734798, 39.31015470677998, 39.31100972516435, 39.31080219739043, 39.31013810437785, 39.30939929349547 };
        double[] vetLong = new double[] { 16.252231893563675, 16.252199707055674, 16.252156791719628, 16.252328453095625, 16.252296266589468, 16.25217824939341, 16.25334769251739, 16.253798303629384, 16.25391632082538, 16.25408798220138 };


        protected void Page_Load(object sender, EventArgs e)
        {
            idPrenotazione = Request.QueryString["idPrenotazione"];           
            if (Session["idTaxi"] == null && idPrenotazione == "")
                Response.Redirect("Errore.aspx");
            else
            {
                    hplTermina.Visible = false;
                    plsConferma.Visible = false;
                    string NomeTaxi = "CIAO";
                    string CognomeUtente = "";
                    string NomeUtente = "";
                    CMD = new SqlCommand("SELECT NomeTaxi, LatitudinePart, LongitudinePart, DataOraPartenza, DataOraArrivo, Cognome, Nome FROM Prenotazione INNER JOIN Utente ON Prenotazione.idUtente=Utente.idUtente INNER JOIN Taxi ON Prenotazione.idTaxi=Taxi.idTaxi WHERE idPrenotazione=" + idPrenotazione, CN);
                    CN.Open();
                    SqlDataReader DR = CMD.ExecuteReader();
                    if (DR.HasRows)
                    {
                        while (DR.Read())
                        {
                            LongitudineCliente = Convert.ToDouble(DR["LongitudinePart"].ToString().Replace(".", ","));
                            LatitudineCliente = Convert.ToDouble(DR["LatitudinePart"].ToString().Replace(".", ","));
                            NomeTaxi = DR["NomeTaxi"].ToString().Trim();
                            CognomeUtente = DR["Cognome"].ToString().Trim(); 
                            NomeUtente = DR["Nome"].ToString().Trim();
                            if (DR["DataOraPartenza"] != null) //Verifico se la prenotazione è stata già confermata..
                                plsConferma.Visible = true;
                            else
                            {
                                    if (DR["DataOraArrivo"] != null) //Verifico se la prenotazione è stata già terminata..
                                    {
                                        hplTermina.NavigateUrl = "TerminaCorsa.aspx?idPrenotazione=" + idPrenotazione;
                                        hplTermina.Visible = true;
                                        lblPren.Text = "Questa prenotazione è stata confermata il " + Convert.ToDateTime(DR["DataOraPartenza"]).ToString() + ". Quando arrivi a destinazione puoi terminarla cliccando sull'apposito link!";
                                        miop.Visible = false;
                                    } 
                                    else
                                        Response.Redirect("Prenotazioni.aspx");
                            }
                       
                        }
                        CN.Close();
                    int K = Convert.ToInt32(Session["K"]);
                    //double LatitudineCorr = Convert.ToDouble(txtLat.Text);
                    //double LongitudineCorr = Convert.ToDouble(txtLong.Text);
                    double LatitudineCorr = vetLat[K];
                    double LongitudineCorr = vetLong[K];
                        lblUtente.Text = "Ciao, benvenuto nella pagina dedicata al taxi che guidi:" + NomeTaxi.ToUpper() + ", qui potrai attendere nuove prenotazioni; appena te ne arriverà una potrai visualizzare il percorso da compiere per arrivare dal tuo cliente cliccandos sul link qui in basso!";
                        lblPrenotazione.Text = "TI E' STATA ASSEGNATA LA PRENOTAZIONE NUMERO " + idPrenotazione + " IL TUO CLIENTE E' " + CognomeUtente + " " + NomeUtente;
                        miop.NavigateUrl = "https://www.google.cl/maps/?saddr=" + LatitudineCorr.ToString().Replace(",", ".") + "," + LongitudineCorr.ToString().Replace(",", ".") + "&daddr=" + LatitudineCliente.ToString().Replace(",", ".") + "," + LongitudineCliente.ToString().Replace(",", ".") + "&directionsmode=driving";
                        tmrPrenotazione.Enabled = true;
                        
                }
            }  
        }

        protected void plsConferma_Click(object sender, EventArgs e)
        {
            CMD = new SqlCommand("UPDATE Prenotazione SET DataOraPartenza=@DataOraPartenza WHERE idPrenotazione=" + idPrenotazione, CN);
            CMD.Parameters.Add("@DataOraPartenza", SqlDbType.DateTime);
            CMD.Parameters["@DataOraPartenza"].Value = DateTime.Now;
            CN.Open();
            int MOD=CMD.ExecuteNonQuery();
            CN.Close();
            if (MOD == 1)
            {
                lblPren.Text = "La prenotazione è stata confermata; il pagamento avverrà automaticamente quando questa verrà chiusa!";
                hplTermina.NavigateUrl = "TerminaCorsa.aspx?idPrenotazione=" + idPrenotazione;
                hplTermina.Visible = true;
                plsConferma.Visible = false;
                miop.Visible = false;
                tmrPrenotazione.Enabled = false;
            }
            else
                lblPren.Text = "OPS.. C'è qualche problema..";
            
        }

        protected void tmrPrenotazione_Tick(object sender, EventArgs e)
        {
            //double LatitudineCorr = Convert.ToDouble(txtLat.Text);
            //double LongitudineCorr = Convert.ToDouble(txtLong.Text);
            
            //int Velocita =int.Parse(TEMP.Text);
            if (Convert.ToInt32(Session["K"]) <= vetLat.Length - 1)
            {
                int K = Convert.ToInt32(Session["K"]);
                //int Velocita = 11; //con velocità media di 40km/h
                GeoCoordinate CoordCliente = new GeoCoordinate(LatitudineCliente, LongitudineCliente);
                GeoCoordinate CoordCorr = new GeoCoordinate(vetLat[K], vetLong[K]);
                double Spazio = Math.Truncate(CoordCorr.GetDistanceTo(CoordCliente));
                double MinAttesa = 4;
                CMD = new SqlCommand("UPDATE Taxi SET LatitudineCorr=@Lat, LongitudineCorr=@Long WHERE idTaxi=" + Session["idTaxi"] + "; UPDATE Prenotazione SET MinAttesaCorr=@min WHERE idPrenotazione=" + idPrenotazione, CN);
                CMD.Parameters.Add("@Lat", SqlDbType.Float);
                CMD.Parameters["@Lat"].Value = vetLat[K];
                CMD.Parameters.Add("@Long", SqlDbType.Float);
                CMD.Parameters["@Long"].Value = vetLong[K];
                CMD.Parameters.Add("@min", SqlDbType.TinyInt);
                CMD.Parameters["@min"].Value = Convert.ToSByte(MinAttesa);
                CN.Open();
                int Mod = CMD.ExecuteNonQuery();
                CN.Close();
                if (Mod >= 1)
                    lblMin.Text = "MINUTI ATTESA:" + MinAttesa.ToString();
                Session["K"] = Convert.ToInt32(Session["K"]) + 1 ;
            }
        }
    }
}