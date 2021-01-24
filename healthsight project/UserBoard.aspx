<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLoggedIn.Master" AutoEventWireup="true" CodeBehind="UserBoard.aspx.cs" Inherits="healthsight_project.UserBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Hello [USER.NAME]</h2>
    <table class="nav-justified" style="width: 60%">
        <caption>
        </caption>
        <tr>
            <td style="width: 33%">
                <asp:Button ID="Button1" runat="server" Text="Button" />
            </td>
            <td style="width: 33%">
                <asp:Button ID="Button2" runat="server" Text="Button" />
            </td>
            <td style="width: 33%">
                <asp:Button ID="Button3" runat="server" Text="Button" />
            </td>
        </tr>        
    </table>
    
</asp:Content>
