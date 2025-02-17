﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PrenotazioneTaxi_Utente
{
    public partial class Mastercard : System.Web.UI.Page
    {
        private PaymentStrategy mastercardPayment;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void plsRicarica_Click(object sender, EventArgs e)
        {
            string num=txtNumero.Text;
            string cvv=txtCVV.Text;
            string data=txtScadenza.Text;
            if (txtImporto.Text != null && txtImporto.Text != "")
            {
                double importo = double.Parse(txtImporto.Text);
                if (num != "" && cvv != "" && data != "" && importo >= 0)
                {
                    mastercardPayment = new MastercardPayment(num, data, cvv);
                    Utente.getInstance().setPaymentStrategy(mastercardPayment);
                    String res = Utente.getInstance().recharge(importo);
                    Session["RicaricaResult"] = res;

                    Response.Redirect("RicaricaEffettuata.aspx");
                }
            } 
        }
    }
}