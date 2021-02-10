<%@ Page Title="Settings" Language="C#" MasterPageFile="~/SiteLoggedIn.Master" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="healthsight_project.UserSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>

    <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-default" OnClick="btnLogout_Click" />

    <h3>Update Info</h3>
    <table style="width: 800px;">
        <tr>
            <td style="width: 420px"><h4>Email</h4>
                <asp:Label ID="lbEmail" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnEmail" runat="server" CssClass="btn btn-default" Text="..." OnClick="btnEmail_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 420px"><h4>Contact No</h4>
                <asp:Label ID="lbPhoneNo" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnPhoneNo" runat="server" CssClass="btn btn-default" Text="..." OnClick="btnPhoneNo_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 420px"><h4>Address</h4>
                <asp:Label ID="lbAddr" runat="server"></asp:Label></td>
            <td>
                <asp:Button ID="btnAddr" runat="server" CssClass="btn btn-default" Text="..." OnClick="btnAddr_Click" />
            </td>
        </tr>
    </table>

    <h3 id="ChaPassLink">Change Password</h3>
    <asp:Label ID="lbUpdPassEr" runat="server" ForeColor="Red"></asp:Label>
    <table style="width: 800px;">
        <tr>
            <td style="width: 210px; height: 30px;">Current Password</td>
            <td style="height: 30px; width: 317px;">
                <asp:TextBox ID="tbCurrPass" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
            <td style="height: 30px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">New Password</td>
            <td style="height: 30px; width: 317px;">
                <asp:TextBox ID="tbNewPass" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
            <td style="height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">&nbsp;</td>
            <td style="height: 30px;" colspan="2">
                Requirements: minimum 8 charaters, and at least one of each of the following: a lowercase, an uppercase, a number and a special character ( !, *, @, #, $, %, ^, &amp;, +, = )</td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Confirm New Password</td>
            <td style="height: 30px; width: 317px;">
                <asp:TextBox ID="tbConPass" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
            <td style="height: 30px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 210px; height: 32px;">&nbsp;</td>
            <td style="height: 32px; width: 317px;">
                <asp:Button style="width: 200px;" ID="btnUpdPass" runat="server" Text="Change Password" CssClass="btn btn-default" />
            </td>
            <td style="height: 32px;">
                &nbsp;</td>
        </tr>
    </table>


    </asp:Content>


