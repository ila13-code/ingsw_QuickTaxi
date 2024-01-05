<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Credito.aspx.cs" Inherits="PrenotazioneTaxi_Utente.Credito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ACCESSO</title>
    <style>
        .icon-button {
            width: 50px;
            height: auto;
            border: none;
            background-color: transparent;
            padding: 0;
        }
    </style>
    <script type="text/javascript">
    function apriFinestra(url) {
        var opzioniFinestra = "width=400,height=600,scrollbars=yes,resizable=yes";

        window.open(url, "_blank", opzioniFinestra);

        return false;
    }
    </script>

</head>
<body style="background-color:#ffff66; text-align:center;">
    <form id="form1" runat="server">
        <div>
            <h2>CREDITO APPLICAZIONE</h2>
            <asp:Label ID="lblUtente" runat="server"></asp:Label><br /><br />
            <asp:Label ID="lblCreditoDisponibile" runat="server"></asp:Label><br /><br />
            <fieldset class="auto-style1">
                <h3>RICARICA CREDITO</h3>
                <h4>Seleziona un sistema di pagamento per la ricarica</h4>
                <asp:ImageButton ID="plsVisa" runat="server" ImageUrl="visa.png" CssClass="icon-button" OnClientClick="return apriFinestra('Visa.aspx');"/><br />
                <asp:ImageButton ID="plsMastercard" runat="server" ImageUrl="mastercard.png" CssClass="icon-button" OnClientClick="return apriFinestra('Mastercard.aspx');"/><br />
                <asp:ImageButton ID="plsPayPal" runat="server" ImageUrl="paypal.png" CssClass="icon-button" OnClientClick="return apriFinestra('PayPal.aspx');"/>
            </fieldset>   
        </div>
    </form>
</body>
</html>
