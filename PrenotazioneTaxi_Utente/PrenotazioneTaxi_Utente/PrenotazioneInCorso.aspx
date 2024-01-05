<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrenotazioneInCorso.aspx.cs" Inherits="PrenotazioneTaxi_Utente.PrenotazioneInCorso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 315px;
            height: 170px;
            text-align:center;
            margin-left: auto; margin-right: auto;
        }
    </style>
</head>
<body style="background-color:#ffff66; text-align:center;">
    <form id="form1" runat="server">
        <div>
            <h1>UNIONE RADIO TAXI</h1>
            <h3>PRENOTAZIONE IN CORSO</h3>
            <img src="taxiDivertente.png" /><br /><br />
           <asp:Label ID="lblUtente" runat="server" Text=""></asp:Label><br /><br />
            <asp:Label ID="lblPrenotazione" runat="server" Text=""></asp:Label><br /><br />
            <asp:Label ID="lblPren" runat="server" Text=""></asp:Label><br /><br />
             <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1"
                             runat="server">
                <ContentTemplate>
                <asp:Timer ID="tmrPrenotazione" runat="server" Interval="20000" OnTick="tmrPrenotazione_Tick" ></asp:Timer>
                    <asp:Label runat="server" ID="lblMin" ></asp:Label>
                    </ContentTemplate>
            </asp:UpdatePanel>
            <fieldset id="fld" runat="server" class="auto-style1">
                <br /><label><b>COORDINATE CORRENTI</b></label><br />
                <asp:TextBox ID="txtLat" runat="server"  ></asp:TextBox>
                <asp:TextBox ID="txtLong" runat="server" ></asp:TextBox><br /><br />
                <br /><label><b>VELOCITA' CORRENTE (m/sec)</b></label><br />
                <asp:TextBox ID="TEMP" runat="server" ></asp:TextBox><br /><br />
                <script type="text/javascript">
                    var lat = document.getElementById("txtLat");
                    var long = document.getElementById("txtLong");
                    var temp = document.getElementById("TEMP");
                    var myVar = setInterval(Timer, 1000);
                    function getLocation() {
                        if (navigator.geolocation)
                            navigator.geolocation.getCurrentPosition(showPosition);
                        else
                            alert("La geolocalizzazione non è supportata da questo browser");
                    }

                    function showPosition(position) {
                        lat.value = position.coords.latitude;
                        long.value = position.coords.longitude;
                        temp.value = position.coords.speed;
                    }
                    function Timer() {
                        getLocation();
                    }
                </script>
            </fieldset><br /><br />
         <asp:HyperLink runat="server" ID="miop" Target="_blank">VISUALIZZA IL PERCORSO PER ARRIVARE DAL CLIENTE</asp:HyperLink><br /><br />
           <asp:Button id="plsConferma" Text="SONO ARRIVATO DAL CLIENTE" runat="server" OnClick="plsConferma_Click" /><br /><br />
            <asp:HyperLink ID="hplTermina" runat="server" Text="CLICCA QUI PER TERMINARE LA CORSA"></asp:HyperLink><br /><br />
        </div>
    </form>
</body>
</html>
