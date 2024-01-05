<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrazione.aspx.cs" Inherits="PrenotazioneTaxi_Utente.Registrazione" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="it">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registrazione</title>
</head>
<body style="background-color:#ffff66; text-align:center;">
    <form id="form1" runat="server">
        <div style="text-align:center;">
            <h3>REGISTRATI AL SERVIZIO DI RADIOTAXI!</h3>
            <main id="Principale">
            <section>
            <img src="taxi.png" alt="TAXI"/>
            <table style="margin-left: auto; margin-right: auto; text-align:left;">    
                <tr>
                    <th>
            <label>Nome:</label>
                    </th>
                    <th><asp:TextBox ID="txtNome" runat="server"></asp:TextBox></th>
                    </tr>
                <tr>
            <th><label>Cognome:</label></th><th><asp:TextBox ID="txtCognome" runat="server"></asp:TextBox></th>
                    </tr>
                <tr>
           <th> <label>Data di nascita:&nbsp&nbsp</label></th><th><asp:TextBox ID="txtDataNascita" runat="server" TextMode="Date"></asp:TextBox></th>
            </tr>
                 <tr>
                    <th colspan="2"><hr />INSERISCI USERNAME E PASSWORD </th>
                </tr>
                <tr>
                    <th><label>Username:</label></th><th><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></th>
                </tr>
                <tr>
                 <th><label>Password:</label></th><th><asp:TextBox ID="txtPSW" runat="server" TextMode="Password"></asp:TextBox></th>
                </tr>
                <tr style="text-align:center;"><th colspan="2" ><br /><asp:Button ID="plsRegistrati" runat="server" Text="REGISTRATI" Height="25px" Width="150px" OnClick="plsRegistrati_Click" /></th></tr>
        </table>
            </section>
                </main>
            <footer>
                <small>©2021 Ilaria Frandina</small>
            </footer>
        </div>
    </form>
</body>
</html>
