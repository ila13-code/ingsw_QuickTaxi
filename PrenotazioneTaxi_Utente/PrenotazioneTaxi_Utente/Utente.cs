using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrenotazioneTaxi_Utente
{
    public class Utente
    {
        private string id;
        private PaymentStrategy strategy;
        private static Utente instance;
        private double credito;

        private Utente()
        {
            credito = 0;
            id = "";
        }

        public static Utente getInstance()
        {
            if (instance == null)
                instance  = new Utente();
            return instance;
        }

        public void setInitialCredit(double credit)
        {
            credito = credit;
        }

        public void setId(string id)
        { this.id = id; }

        public void setPaymentStrategy(PaymentStrategy str)
        {
            this.strategy = str;
        }

        public string recharge(double amount)
        {
            String res=this.strategy.processPayment(amount);
            credito += amount;

            SqlConnection CN = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=PrenotazioneTaxi; user id=sa;password=abacus");
            SqlCommand CMD;
            CMD = new SqlCommand("UPDATE Utente SET CreditoDisponibile=@credito WHERE idUtente=" + id +";", CN);
            CMD.Parameters.Add("@credito", SqlDbType.SmallMoney);
            CMD.Parameters["@credito"].Value = credito;
            CN.Open();
            int MOD = CMD.ExecuteNonQuery();
            CN.Close();
            if (MOD != 0)
            {
                return res;
            }
            return "RICARICA FALLITA!";

        }
    }
}
