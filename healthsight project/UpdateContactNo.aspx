<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLoggedIn.Master" AutoEventWireup="true" CodeBehind="UpdateContactNo.aspx.cs" Inherits="healthsight_project.UpdateContactNo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 id="UpdPhoneNoLink">Update Contact No</h2>
    <asp:Label ID="lbUpdPhoneNo" runat="server" ForeColor="Red"></asp:Label>
    <table class="nav-justified">
        <tr>
            <td style="width: 210px; height: 30px;">Contact No</td>
            <td style="height: 30px;">
                <asp:TextBox ID="tbPhoneNo" runat="server" style="width: 200px;"></asp:TextBox>
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
              <asp:Button style="width: 200px;" ID="btnUpdPhoneNo" runat="server" Text="Update Email" OnClick="btnUpdEmail_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
