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
            <td style="height: 30px; width: 205px;">
                <asp:TextBox ID="tbCurrPass" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
            <td style="height: 30px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">New Password</td>
            <td style="height: 30px; width: 205px;">
                <asp:TextBox ID="tbNewPass" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
            <td style="height: 30px; width: 45%;">
                <asp:Label ID="lbPassStrength" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">&nbsp;</td>
            <td style="height: 30px;" colspan="2">
                Requirements: minimum 8 charaters, and at least one of each of the following: a lowercase, an uppercase, a number and a special character ( !, *, @, #, $, %, ^, &amp;, +, = )</td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Confirm New Password</td>
            <td style="height: 30px; width: 205px;">
                <asp:TextBox ID="tbConPass" runat="server" style="width: 200px;"></asp:TextBox>
            </td>
            <td style="height: 30px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 210px; height: 32px;">&nbsp;</td>
            <td style="height: 32px; width: 205px;">
                <asp:Button style="width: 200px;" ID="btnUpdPass" runat="server" Text="Change Password" CssClass="btn btn-default" OnClick="btnUpdPass_Click" />
            </td>
            <td style="height: 32px;">
                &nbsp;</td>
        </tr>
    </table></br>

    <asp:Button ID="btnDeleteAcc" runat="server" Text="Delete Account" CssClass="btn btn-danger" />

    <script type="text/javascript">
        function validate() {
            var str = document.getElementById('<%= tbNewPass.ClientID %>').value;

            if (str.length < 8) {
                document.getElementById('<%= lbPassStrength.ClientID %>').innerHTML = "Password Strength: Very Weak";
                document.getElementById('<%= lbPassStrength.ClientID %>').style.color = "Red";
                return "too_short";
            }

            else if (str.search(/[a-z]/) == -1) {
                document.getElementById('<%= lbPassStrength.ClientID %>').innerHTML = "Password Strength: Weak";
                document.getElementById('<%= lbPassStrength.ClientID %>').style.color = "#FF8C00";
                return "no_lwc";
            }

            else if (str.search(/[A-Z]/) == -1) {
                document.getElementById('<%= lbPassStrength.ClientID %>').innerHTML = "Password Strength: Medium";
                document.getElementById('<%= lbPassStrength.ClientID %>').style.color = "#FFCC00";
                return "no_upc";
            }

            else if (str.search(/[0-9]/) == -1) {
                document.getElementById('<%= lbPassStrength.ClientID %>').innerHTML = "Password Strength: Okay";
                document.getElementById('<%= lbPassStrength.ClientID %>').style.color = "#FFCC00";
                return "no_number";
            }

            else if (str.search(/[!*@#$%^&+=]/) == -1) {
                document.getElementById('<%= lbPassStrength.ClientID %>').innerHTML = "Password Strength: Strong";
                document.getElementById('<%= lbPassStrength.ClientID %>').style.color = "#FFCC00";
                return "no_spc";
            }

            document.getElementById('<%= lbPassStrength.ClientID %>').innerHTML = "Password Strength: Very Strong";
            document.getElementById('<%= lbPassStrength.ClientID %>').style.color = "Lime";
            return "good";
        }
    </script>

    </asp:Content>


