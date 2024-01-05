using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrenotazioneTaxi_Utente
{
    public class PayPalPayment:PaymentStrategy
    {
        private string email;
        private string pw;

        public PayPalPayment(string email, string pw)
        {
            this.email=email;
            this.pw = pw;
        }

        public String processPayment(double amount)
        {
            return "Credito ricaricato attraverso PayPal ("+email+"): IMPORTO = " + amount;
        }
    }
}
