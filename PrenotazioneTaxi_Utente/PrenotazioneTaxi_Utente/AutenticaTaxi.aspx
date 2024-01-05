<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutenticaTaxi.aspx.cs" Inherits="PrenotazioneTaxi_Utente.AutenticaTaxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#ffff66; text-align:center;">
    <form id="form1" runat="server">
        <div>
             <h3>ACCEDI CON LE CREDENZIALI ASSOCIATE AL TUO TAXI</h3>
            <h4>Potrai visualizzare le prenotazioni che affidate al tuo taxi e il percorso da compiere per arrivare dove si trova il tuo cliente!</h4>
            <table style = "margin-left: auto; margin-right: auto;">
                <tr>
                    <th><label>Username:</label></th><th><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></th>
                </tr>
                <tr>
                    <th><label>Password:</label></th><th><asp:TextBox ID="txtPSW" runat="server" TextMode="Password"></asp:TextBox></th>
                </tr>
                <tr>
                    <th colspan="2"><br /><asp:Button ID="plsAccedi" Text="ACCEDI" runat="server" OnClick="plsAccedi_Click" /></th>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
