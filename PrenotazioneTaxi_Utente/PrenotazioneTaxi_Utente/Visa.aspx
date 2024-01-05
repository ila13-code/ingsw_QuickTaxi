<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visa.aspx.cs" Inherits="PrenotazioneTaxi_Utente.Visa" %>

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
            <h2>VISA</h2>
            <label>Numero carta di credito:</label><br />
            <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox><br /><br />
            <label>Scadenza:</label><br />
            <asp:TextBox ID="txtScadenza" runat="server" TextMode="Date"></asp:TextBox><br /><br />
            <label>CVV:</label><br />
            <asp:TextBox ID="txtCVV" runat="server"></asp:TextBox><br /><br />
            <label>Importo ricarica:</label><br />
            <asp:TextBox ID="txtImporto" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="plsRicarica" Text="RICARICA" runat="server" OnClick="plsRicarica_Click" />
        </div>
    </form>
</body>
</html>
