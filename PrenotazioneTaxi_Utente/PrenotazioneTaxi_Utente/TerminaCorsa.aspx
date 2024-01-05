<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TerminaCorsa.aspx.cs" Inherits="PrenotazioneTaxi_Utente.TerminaCorsa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#ffff66; text-align:center;">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUtente" runat="server" Text=""></asp:Label><br /><br />
             <asp:Label ID="lblPrenotazione" runat="server" Text=""></asp:Label><br /><br />
            <asp:Button ID="plsTermina" runat="server" Text="TERMINA CORSA" OnClick="plsTermina_Click" OnClientClick="getLocation()" /><br /><br />
            <asp:Label ID="lblRis" runat="server" Text=""></asp:Label>
             <asp:TextBox ID="txtLat" runat="server" ></asp:TextBox><asp:TextBox ID="txtLong" runat="server" ></asp:TextBox><br /><br />               
                <script type="text/javascript">
                    var lat = document.getElementById("txtLat");
                    var long = document.getElementById("txtLong");
                function getLocation() {
                    if (navigator.geolocation)
                        navigator.geolocation.getCurrentPosition(showPosition);
                    else
                        alert("La geolocalizzazione non è supportata da questo browser");
                }

               function showPosition(position) {
                        lat.value = position.coords.latitude;
                        long.value = position.coords.longitude;
               }
                </script>
               <asp:Button ID="plsDisconnettiti" runat="server" Text="DISCONNETTITI" OnClick="plsDisconnettiti_Click" />
        </div>
    </form>
</body>
</html>
