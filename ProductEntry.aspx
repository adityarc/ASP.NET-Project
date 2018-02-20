<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductEntry.aspx.cs" Inherits="WebApplication2.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Products for ARC ENTERPRISES.</title> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder1" runat="server">
    <div style="margin:auto; border-radius:15px 15px 15px 15px; background-color:azure">
        <div style="margin-left:1100px">
            <asp:Button ID="cmdsignout" Text="Sign Out" runat="server" OnClick="cmdsignout_Click" /> </div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblPname" Text="Product Name" runat="server" /></td>
                    <td>
                        <asp:TextBox ID="txtPname" runat="server" />
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblPrice" Text="Price" runat="server" /></td>
                    <td>
                        <asp:TextBox ID="TxtPrice" runat="server" />
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblQuantity" Text="Quantity" runat="server" /></td>
                    <td>
                        <asp:TextBox ID="TxtQuantity" runat="server" />
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPImage" Text="Product Image" runat="server" />
                </td>
                <td>
                    <asp:FileUpload ID="imgProduct" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="cmdSubmit" Text="Submit" runat="server" OnClick="cmdSubmit_Click"/>

                </td>
                </tr>
            <tr>
                <td><asp:Label Text="" ID="txtMsg" runat="server" /></td>
                </tr>
            
        </table>
    </div>
</asp:Content>
