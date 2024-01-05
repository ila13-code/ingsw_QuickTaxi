<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PrenotazioneTaxi_Utente._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Unione RadioTaxi</title>
    <style type="text/css">
        .auto-style1 {
            width: 188px;
            height: 200px;
        }
        body {
background-color:#ffff66;
text-align:center;
}
    </style>
</head>
<body style="background-color:#ffff66; text-align:center;">
    <form id="form1" runat="server">
        <div><br />
            <h1>BENVENUTO NEL SITO UNIONE RADIOTAXI!</h1>
            <img src="taxi.png" />
           <table style = "margin-left: auto; margin-right: auto;">
               <tr>
                   <th>
            <fieldset class="auto-style1">
                <h3>Sei un utente?</h3>
                <asp:Button ID="plsRegistratiUtente" Text="REGISTRATI" runat="server" OnClick="plsRegistratiUtente_Click" />
                <h4>Se hai già un account</h4>
                <asp:Button ID="plsAccediUtente" Text="ACCEDI" runat="server" OnClick="plsAccediUtente_Click" /><br /><br />
            </fieldset>
                   </th>
                   <th>
            <fieldset class="auto-style1">
                <h3>Sei un taxista?</h3>
                <h4>Accedi con le credenziali associate al tuo taxi!</h4>
                <asp:Button ID="plsAccediTaxi" Text="ACCEDI" runat="server" OnClick="plsAccediTaxi_Click" /><br /><br />
            </fieldset>
                   </th>
              </tr>
         </table>
            
        </div>
    </form>
</body>
</html>
