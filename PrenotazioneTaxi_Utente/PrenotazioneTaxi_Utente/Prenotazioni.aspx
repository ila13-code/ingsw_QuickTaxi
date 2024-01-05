<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prenotazioni.aspx.cs" Inherits="PrenotazioneTaxi_Utente.Prenotazioni" %>

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
            <asp:Label ID="lblUtente" runat="server" Text=""></asp:Label><br /><br />
           
                <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1"
                             runat="server">
                <ContentTemplate>
                <asp:Timer ID="tmrPrenotazione" runat="server" Interval="20000" OnTick="tmrPrenotazione_Tick"></asp:Timer>
                <asp:Label ID="lblPrenotazione" runat="server" ></asp:Label><br /><br />
                <asp:HyperLink ID="hplPercorso" Text="VISUALIZZA IL PERCORSO DA COMPIERE" runat="server"></asp:HyperLink>
             </ContentTemplate>
            </asp:UpdatePanel>
                

        </div>
    </form>
</body>
</html>
