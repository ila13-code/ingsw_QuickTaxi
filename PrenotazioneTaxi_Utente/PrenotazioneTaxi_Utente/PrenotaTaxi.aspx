<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrenotaTaxi.aspx.cs" Inherits="PrenotazioneTaxi_Utente.PrenotaTaxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        fieldset{
            width: 400px;
            height: 100px;
            text-align:center;
        }
    </style>
     
</head>
<body style="background-color:#ffff66; text-align:center;" >
    <form id="form1" runat="server">
        <div>
            <h3>PRENOTA IL TUO TAXI!</h3>
            <asp:Label ID="lblUtente" runat="server" Text=""></asp:Label><br /><br />
            <fieldset id="fld" runat="server" style = "margin-left: auto; margin-right: auto;">
                <br /><label>COORDINATE CORRENTI</label><br />
                <asp:TextBox ID="txtLat" runat="server" ></asp:TextBox><asp:TextBox ID="txtLong" runat="server" ></asp:TextBox><br /><br />
                <input type="button" id="plsGEO" value="GEOLOCALIZZAMI" onclick="getLocation()" />
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
            </fieldset><br /><br />
            
            <asp:Button ID="plsPrenota" runat="server" Text="PRENOTA IL TUO TAXI!" OnClick="plsPrenota_Click" /><br /><br />
            <asp:Label ID="lblEsito" runat="server" Text=""></asp:Label><br /><br />
            <asp:HyperLink ID="hplTraccia" runat="server" Text="TRACCIA IL MIO TAXI" ></asp:HyperLink>
        </div>
    </form>
</body>
</html>
