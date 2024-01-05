using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrenotazioneTaxi_Utente
{

    public class VisaPayment:PaymentStrategy
    {
        private string number;
        private string cvv;
        private string dataScad;

        public VisaPayment(string number, string cvv, string dataScad)
        {
            this.number = number;
            this.cvv = cvv;
            this.dataScad = dataScad;
        }

        public String processPayment(double amount)
        {
            return "Credito ricaricato attraverso Visa: IMPORTO = " + amount;
        }
    }
 
}
