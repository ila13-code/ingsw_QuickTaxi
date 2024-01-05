<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaRiservata.aspx.cs" Inherits="PrenotazioneTaxi_Utente.AreaRiservata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#ffff66; text-align:center;">
    <form id="form1" runat="server">
        <div>
            <h1>UNIONE RADIOTAXI</h1>
            <img src="taxi.png" /><br /><br />
            <asp:Label ID="lblUtente" runat="server"></asp:Label><br /><br />
            <a href="CorseEffettuate.aspx">VISUALIZZA LE CORSE EFFETTUATE</a><br /><br />
            <a href="PrenotaTaxi.aspx">PRENOTA UN TAXI</a><br /> <br />
            <a href="Credito.aspx">CREDITO APPLICAZIONE</a>
        </div>
    </form>
</body>
</html>
