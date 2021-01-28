<%@ Page Title="Settings" Language="C#" MasterPageFile="~/SiteLoggedIn.Master" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="healthsight_project.UserSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>
    <table class="nav-justified">
        <tr>
            <td style="width: 210px; height: 30px;">&nbsp;</td>
            <td style="height: 30px;">
                <asp:Label ID="lbUpdEmailEr" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Current Email</td>
            <td style="height: 30px;">
                <asp:Label ID="lbCurrEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Update Email</td>
            <td style="height: 30px;">
                <asp:TextBox ID="tbEmail" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Confrim Password</td>
            <td style="height: 30px;">
                <asp:TextBox ID="tbConPass4Email" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;"></td>
            <td style="height: 30px;">
                <asp:Button style="width: 200px;" ID="btnUpdEmail" runat="server" Text="Update Email" OnClick="btnUpdEmail_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">&nbsp;</td>
            <td style="height: 30px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">&nbsp;</td>
            <td style="height: 30px;">
                <asp:Label ID="lbUpdPassEr" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Current Password</td>
            <td style="height: 30px;">
                <asp:TextBox ID="tbCurrPass" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">New Password</td>
            <td style="height: 30px;">
                <asp:TextBox ID="tbNewPass" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Confirm New Password</td>
            <td style="height: 30px;">
                <asp:TextBox ID="tbConPass" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 32px;">&nbsp;</td>
            <td style="height: 32px;">
                <asp:Button style="width: 200px;" ID="btnUpdPass" runat="server" Text="Change Password" />


            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 33px;"></td>
            <td style="height: 33px;">


            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">&nbsp;</td>
            <td style="height: 30px;">
                <asp:Button style="width: 200px;" ID="btnDltAcc" runat="server" Text="Delete Account" />
            </td>
        </tr>
    </table>


</asp:Content>


