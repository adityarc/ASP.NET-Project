<%@ Page MasterPageFile="~/WebsiteMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="WebApplication2.LoginForm" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <title>Customer Login</title>
    </asp:Content>
<asp:Content ContentPlaceHolderID="content1" runat="server">
    <div style="margin:auto;">
     <br /><br />
                
                
                    <table border="0" style="margin:auto">
                        <tr>
                            <td>
                                <asp:Label ID="lblWelcomeMsg" Text="Customer Log In" runat="server" Font-Size="Larger" />
                            </td>
                        </tr>
                            
                        <tr>
                            <td>
                                <asp:TextBox id="txtusername" placeholder="UserName" runat="server" style="height:35px; width:300px; border-radius:10px" />  
                                
                            </td>
                            <td><asp:RequiredFieldValidator ID="rfvuname" runat="server" ControlToValidate="txtusername" ErrorMessage="Enter the username." /></td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:TextBox id="txtpassword" placeholder="Password" runat="server" TextMode="Password" style="height:35px; width:300px; border-radius:10px" />  
                                
                                <br /><br />
                            </td>
                            <td><asp:RequiredFieldValidator ID="rfvpswd" runat="server" ControlToValidate="txtpassword" ErrorMessage="Enter the Password." /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="cmdSignIn" runat="server" Text="Sign In" OnClick="cmdSignIn_Click" />
                                
                                
                            </td>
                        </tr>
                        <tr><td>
                            <asp:CheckBox ID="chkUserID" Text="Remember Me" runat="server" Font-Size="Small" /></td></tr>
                        <tr>
                  <td> <asp:Label ID="txtMsg" Text="" runat="server" /> </td>
              </tr>
                        
                    </table>
                
    </div>
</asp:Content>    