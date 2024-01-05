<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayPal.aspx.cs" Inherits="PrenotazioneTaxi_Utente.PayPal" %>

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
            <h2>PAYPAL</h2>
            <label>E-mail:</label><br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><br />
            <label>Password:</label><br />
            <asp:TextBox ID="txtPW" runat="server"></asp:TextBox><br /><br />
            <label>Importo ricarica:</label><br />
            <asp:TextBox ID="txtImporto" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="plsRicarica" Text="RICARICA" runat="server" OnClick="plsRicarica_Click" />
        </div>
    </form>
</body>
</html>
