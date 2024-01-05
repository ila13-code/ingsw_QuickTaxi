<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RicaricaEffettuata.aspx.cs" Inherits="PrenotazioneTaxi_Utente.RicaricaEffettuata" %>

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
</head>
<body style="background-color:#ffff66; text-align:center;">
    <form id="form1" runat="server">
        <div>
            <h2>ESITO RICARICA</h2>
            <asp:Label ID="lblRes" runat="server" Text=""></asp:Label><br />
            <h4>Se l'operazione ha avuto esito positivo, ti basterà ricaricare la pagina per visualizzare il tuo credito aggiornato.</h4>
        </div>
    </form>
</body>
</html>
