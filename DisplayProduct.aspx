<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayProduct.aspx.cs" Inherits="WebApplication2.DisplayProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <asp:Image ID="imgProduct" Height="100" Width="150" ImageUrl='<%#"~/ImageHandler.ashx?ID="+Eval("ProductId") %>' runat="server" />
            <br />
            <asp:Label Text='<%#Eval("ProductName") %>' runat="server" />
            <asp:Button Text="Buy Now" ID="btnBuyNow" runat="server" />

        </ItemTemplate>
    </asp:DataList>
    </div>
    </form>
</body>
</html>
