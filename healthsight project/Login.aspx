<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="healthsight_project.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
        <table style="width: 40%;">
            <tr>
                <td class="modal-sm" style="padding: 10px; font-size: 21px; ">&nbsp;</td>
                <td style="padding: 10px; font-size: 21px;">
                    <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="padding: 10px; font-size: 21px; ">Email</td>
                <td style="padding: 10px; font-size: 21px;">
                    <asp:TextBox ID="tbEmail" runat="server" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="padding: 10px; font-size: 21px; ">Password</td>
                <td style="padding: 10px; font-size: 21px;">
                    <asp:TextBox ID="tbPass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="padding: 10px; font-size: 21px; ">&nbsp;</td>
                <td style="padding: 10px; font-size: 21px;">
                    <asp:Button ID="BtnLogin" runat="server" Text="Login" />
                </td>
            </tr>
        </table>

</asp:Content>