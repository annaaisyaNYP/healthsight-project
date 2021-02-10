<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLoggedIn.Master" AutoEventWireup="true" CodeBehind="UpdateAddr.aspx.cs" Inherits="healthsight_project.UpdateAddr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 id="UpdAddrLink">Update Address</h2>
    <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
    <table class="nav-justified">
        <tr>
            <td style="width: 210px; height: 30px;">Update Address</td>
            <td style="height: 30px;">
                <asp:TextBox ID="tbAddress" runat="server" style="width: 200px;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Confrim Password</td>
            <td style="height: 30px;">
                <asp:TextBox ID="tbConPass" runat="server" style="width: 200px;" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;"></td>
            <td style="height: 30px;">
              <asp:Button style="width: 200px;" ID="btnUpdAddr" runat="server" Text="Update Address"  CssClass="btn" OnClick="btnUpdAddr_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
