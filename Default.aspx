<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" validateRequest="false" %>

<%@ OutputCache Duration="20" VaryByParam="None" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Michael Moore Assignment 5<br />
            <br />
            <br />
            Enter a US Zip code to retrieve the city/state/latitude/longitude for the location<br />
            <br />
            (Input zip code saves as a cookie for one minute)<br />
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Search" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </div>
        <p>
            Enter a US Zip code to retrieve a five day weather forcast for the location</p>
        <p>
            (Page data saved in twenty second cache)</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <p>
            Enter a country to retrieve Covid 19 data for the country</p>
        <p>
            (Input zip code saved as a cookie for one minute)</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
