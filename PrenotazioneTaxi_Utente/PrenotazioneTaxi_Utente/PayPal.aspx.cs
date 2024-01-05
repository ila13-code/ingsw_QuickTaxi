using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using WebSharper.Bing.Maps;

namespace PrenotazioneTaxi_Utente
{
    public partial class PayPal : System.Web.UI.Page
    {
        private PaymentStrategy payPalPayment;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void plsRicarica_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string pw = txtPW.Text;
            if (txtImporto.Text != null && txtImporto.Text != "")
            {
                double importo = double.Parse(txtImporto.Text);
                if (email != "" && pw != "" && importo > 0)
                {
                    payPalPayment = new PayPalPayment(email, pw);
                    Utente.getInstance().setPaymentStrategy(payPalPayment);
                    String res = Utente.getInstance().recharge(importo);
                    Session["RicaricaResult"] = res;

                    Response.Redirect("RicaricaEffettuata.aspx");
                }
            }
        }
    }
}