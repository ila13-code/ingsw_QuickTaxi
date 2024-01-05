<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TracciaIlMioTaxi.aspx.cs" Inherits="PrenotazioneTaxi_Utente.TracciaIlMioTaxi" %>

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
            margin-left: auto; 
            margin-right: auto;
        }
        div#map{
            width:500px;
            height:300px;
            margin:10px;
        }
        
    </style>
     
      <script type='text/javascript'>
          function GetMap() {
              var Lat = document.getElementById("txtLat");
              var Long = document.getElementById("txtLong");
              var myVar = setInterval(Timer, 35000);
              var map = new Microsoft.Maps.Map('#myMap', {
                  credentials: 'AvSIS_iy0lmyDPiCP2ddMyiLv02n_XK8M8HnatNk2Fp6CTnUX096Y8zSs2O8NM-p',
                  center: new Microsoft.Maps.Location(Lat.value, Long.value)
              });

              var center = map.getCenter();

              var pin = new Microsoft.Maps.Pushpin(center, {
                  title: 'Posizione corrente',
                  text: 'TAXI',
                  color: 'red'
              });

              map.entities.push(pin);  
          }
          function Timer() {
              GetMap();
          }
    </script>
     <script type='text/javascript' src='http://www.bing.com/api/maps/mapcontrol?callback=GetMap' async defer></script>
</head>
<body  style="background-color:#ffff66; text-align:center;">
    <form id="form1" runat="server">
        <div>
             <h1>UNIONE RADIO TAXI</h1>
            <h3>SEGUI IL TUO TAXI</h3>
            <img src="taxi.png" /><br /><br />
           <asp:Label ID="lblUtente" runat="server" Text=""></asp:Label><br /><br />
            <asp:Label ID="lblRis" runat="server" Text=""></asp:Label><br /><br />
            <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1"
                             runat="server">
                <ContentTemplate>
                <asp:Timer ID="tmrPrenotazione" runat="server" Interval="30000" OnTick="tmrPrenotazione_Tick" ></asp:Timer>
                    <fieldset class="auto-style1" >
            <label>COORDINATE DEL TAXI</label><br />
            <asp:TextBox ID="txtLat" runat="server" ></asp:TextBox> <asp:TextBox ID="txtLong" runat="server" ></asp:TextBox><br /><br />
            <label>MINUTI DI ATTESA</label><br />
             <asp:TextBox ID="txtMin" runat="server" ></asp:TextBox> <br /><br />
            </fieldset>
                    </ContentTemplate>
            </asp:UpdatePanel><br /><br />
            <div style = "margin-left: auto; margin-right: auto;">
            <div id="myMap" style="position:center;width:600px;height:400px;margin-left: auto; margin-right: auto;"></div>
           </div>
</div>
    </form>
</body>
</html>
