<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorseEffettuate.aspx.cs" Inherits="PrenotazioneTaxi_Utente.CorseEffettuate" %>

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
            <asp:Label ID="lblUtente" runat="server"></asp:Label><br /><br />
            <asp:GridView runat="server" ID="grdCorse" style = "margin-left: auto; margin-right: auto;" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <Columns>
                    <asp:BoundField DataField="idPrenotazione" HeaderText="ID" />
                    <asp:BoundField DataField="NomeTaxi" HeaderText="Taxi" />
                    <asp:BoundField DataField="DataOraPartenza" HeaderText="Data&amp;Ora partenza" />
                    <asp:BoundField DataField="DataOraArrivo" HeaderText="Data&amp;Ora arrivo" />
                    <asp:BoundField DataField="Costo" HeaderText="Costo" />
                </Columns>

                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />

            </asp:GridView>
        </div>
    </form>
</body>
</html>
