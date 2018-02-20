<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebApplication2.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WELCOME</title>
    <style>
        #GridView1 { margin-top:50px;
                     margin:auto;
        }
        #lblWelcome {margin:750px;
               font-family:Georgia;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div1" style="margin-top:25px;margin:auto;float:left;height:750px;width:2000px;background-color:#dc1717;border-radius: 10px 10px 10px 10px">
        
        <br />
        <asp:Label ID="lblWelcome" Text="" runat="server" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID" />
                <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" SortExpression="MobileNo" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="EmailID" HeaderText="EmailID" SortExpression="EmailID" />
                <asp:BoundField DataField="PinCode" HeaderText="PinCode" SortExpression="PinCode" />
                <asp:BoundField DataField="registrationdate" HeaderText="registrationdate" SortExpression="registrationdate" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=CGI-JDN-01\CGI;Initial Catalog=CGI;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [CustomerDetails]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
