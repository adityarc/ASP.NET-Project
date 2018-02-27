<%@ Page MasterPageFile="~/Site1.Master" Language="C#" EnableSessionState="True" AutoEventWireup="true" CodeBehind="CustomerAccessPage1.aspx.cs" Inherits="WebApplication2.CustomerAccessPage1" %>


<asp:Content ContentPlaceHolderID="head" runat="server">
   <title>Welcome Customer </title>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                      <h3> Welcome, <asp:Label Text="" id="lblUname" runat="server" />! </h3>
                  <div id="divSout" style="margin-left:1100px">    </div>
                  <br /><br /><br />
                   <asp:DataList ID="DataList1" runat="server" HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal" OnSelectedIndexChanged="Page_Load" OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <asp:Image ID="imgProduct" Height="100" Width="150" ImageUrl='<%#"~/ImageHandler.ashx?ID="+Eval("ProductId") %>' runat="server" />
            <br /><br />
            <asp:Label ID="lblPname" Text='<%#Eval("ProductName") %>' runat="server" />
            <br /><br />
            <asp:Button Text="Buy Now" ID="btnBuyNow" runat="server" CommandArgument='<%#Eval("ProductID") %>' CommandName="cmd_buyproduct" />
            <br /><br />

        </ItemTemplate>
    </asp:DataList>

    </asp:Content>
                   








