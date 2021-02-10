<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLoggedIn.Master" AutoEventWireup="true" CodeBehind="UpdateEmail.aspx.cs" Inherits="healthsight_project.UpdateEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 id="UpdEmailLink">Update Email</h2>
    <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
    <table class="nav-justified">
        <tr>
            <td style="width: 210px; height: 30px;">Update Email</td>
            <td style="height: 30px;">
                <asp:TextBox ID="tbEmail" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Confrim Password</td>
            <td style="height: 30px;">
                <asp:TextBox ID="tbConPass" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;"></td>
            <td style="height: 30px;">
              <asp:Button style="width: 200px;" ID="btnUpdEmail" runat="server" Text="Update Email" OnClick="btnUpdEmail_Click" CssClass="btn" />
            </td>
        </tr>
    </table>

</asp:Content>
