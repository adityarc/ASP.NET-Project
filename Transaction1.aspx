<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Transaction1.aspx.cs" Inherits="WebApplication2.Transaction1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Payment Gateway</title>
    <style type="text/css">
        .auto-style1 {
            width: 308px;
            height: 11px;
        }

        .auto-style4 {
            height: 32px;
            width: 1148px;
        }

        .auto-style5 {
            height: 11px;
            width: 383px;
        }
        .auto-style6 {
            width: 599px;
        }
        .auto-style7 {
            width: 1244px;
        }
        .auto-style8 {
            height: 11px;
            width: 586px;
        }
        .auto-style9 {
            height: 32px;
            width: 586px;
        }
        .auto-style12 {
            width: 1314px;
        }
        .auto-style13 {
            width: 586px;
        }
        .auto-style15 {
            width: 4px;
        }
        .auto-style16 {
            width: 308px;
        }
        .auto-style17 {
            width: 498px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style12">
        <tr>
            <td class="auto-style4" colspan="3">
                <h4>Bill Amount</h4>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <h5>Base Price:</h5>
            </td>
            <td class="auto-style16">
                <asp:Label Text="" ID="lblbase" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <h5>CGST:</h5>
            </td>
            <td class="auto-style16">
                <asp:Label Text="" ID="Lblcgst" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <h5>SGST:</h5>
            </td>
            <td class="auto-style16">
                <asp:Label Text="" ID="Lblsgst" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <h5>Delivery Charges:</h5>
            </td>
            <td class="auto-style16">
                <asp:Label Text="" ID="Lbldel" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <h5>Total Price:</h5>
            </td>
            <td class="auto-style16">
                <asp:Label Text="" ID="Lblfinal" runat="server" />
            </td>
        </tr>



        <tr>
            <td class="auto-style9">
                <h4>Select Mode of Payment</h4>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">

                <asp:RadioButton GroupName="Grp1" ID="rbCOD" Text="Cash on Delivery" runat="server"  /></td>
            <td class="auto-style1">
                <asp:RadioButton GroupName="Grp1" ID="rbDebit" Text="Debit" runat="server" /></td>
            <td class="auto-style5">
                <asp:RadioButton GroupName="Grp1" ID="rbNet" Text="Net Banking (ICICI BANK only)" runat="server"  />
            </td>
            <td class="auto-style15">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label runat="server">
                    Enter Delivery Address
                </asp:Label>
            </td>
            <td class="auto-style16">
                <asp:TextBox ID="txtDeliveryAddress" runat="server" Height="67px" TextMode="MultiLine" Width="280px" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="Enter an address" ControlToValidate="txtDeliveryAddress" ForeColor="Red" runat="server" />
            </td>
        </tr>
        
        <tr>
            <td class="auto-style7" colspan="3">
                
                <asp:Panel ID="Panel1" runat="server">
                    <div id="divDebit">
                        <table>
                            <tr>
                                <td class="auto-style17">
                                    <h4>Enter Card Details</h4>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">Debit Card Number:</td>
                                <td>
                                    <asp:TextBox id="txtDebNo" runat="server" />
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ErrorMessage="Card Number Not Valid" ControlToValidate="txtDebNo" ForeColor="Red" ValidationExpression="[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">
                                    Enter Expiration Date:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtexpdate" runat="server" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ErrorMessage="Enter the expiry Date (if no expiry date: Enter 01/49)" ControlToValidate="txtexpdate" ForeColor="Red" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">
                                    Enter Name on Card:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCardName" runat="server" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ErrorMessage="Account holder Name Required" ForeColor="Red" ControlToValidate="txtCardName" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">
                                    Enter CVV:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcvv" runat="server" />
                                </td>
                                <td>
                                <asp:RegularExpressionValidator ErrorMessage="Enter valid CVV" ForeColor="Red" ControlToValidate="txtcvv" ValidationExpression="[0-9][0-9][0-9]" runat="server" />
                                    </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div style="text-align:center">
                                       
                                        <br />
                                        <asp:Button Text="Confirm Payment" ID="cmdConfirm" runat="server" Width="120px" OnClick="cmdConfirm_Click" /> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Button Text="Cancel Payment" ID="btnCancel" runat="server" Width="120px" OnClick="btnCancel_Click" />
                                        <br />
                                        <br />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server">
                    <div id="divNet" style="text-align:center">
                        <asp:CheckBox id="chkagree" Text="I agree to comply with the terms and Condtions of the websites transactional policies" runat="server"   /><br />
                        <asp:LinkButton Text="Redirect to Bank Website" id="lbtnNet" OnClick="lbtnNet_Click" runat="server" />
                    </div>
                </asp:Panel>
                <br />
                <br />


            </td>
        </tr>
        <tr>
            <td colspan="3" >
                <br />
                <br />
                <div style="text-align:center">
                <asp:Button ID="btnProceed" Text="Proceed" runat="server" Width="74px" OnClick="btnProceed_Click" />
                    </div>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div style="text-align:center">
                <h5>
                    <asp:Label Text="" ID="lblOrder" runat="server" /></h5>
                    </div>
            </td>
        </tr>
    </table>
</asp:Content>


