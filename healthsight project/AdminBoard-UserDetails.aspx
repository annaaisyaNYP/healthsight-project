<%@ Page Title="Admin Board - User Details" Language="C#" MasterPageFile="~/SiteLoggedIn.Master" AutoEventWireup="true" CodeBehind="AdminBoard-UserDetails.aspx.cs" Inherits="healthsight_project.AdminBoard_UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>
        <table style="width: 100%; font-size: 12px;">
            <tr>
                <td style="height: 30px; width: 260px;">Name</td>
                <td style="height: 30px">
                    <asp:Label ID="lbName" runat="server"></asp:Label>
                </td>
                <td style="height: 30px"></td>
            </tr>
            <tr>
                <td style="height: 30px; width: 260px;">NRIC</td>
                <td style="height: 30px">
                    <asp:Label ID="lbNric" runat="server"></asp:Label>
                </td>
                <td style="height: 30px">&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 30px; width: 260px;">Date of Birth</td>
                <td style="height: 30px">
                    <asp:Label ID="lbDOB" runat="server"></asp:Label>
                </td>
                <td style="height: 30px">&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 30px; width: 260px;">&nbsp;</td>
                <td style="height: 30px">&nbsp;</td>
                <td style="height: 30px">&nbsp;</td>
            </tr>
        </table>
    </h2>

</asp:Content>
