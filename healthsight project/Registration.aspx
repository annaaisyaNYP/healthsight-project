<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="healthsight_project.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <table class="nav-justified" style="margin: 20px; font-size: 12px; margin-bottom: 0px;">
        <caption>
            Fields marked * are required</caption>
        <tr>
            <td style="width: 210px; height: 30px">&nbsp;</td>
            <td style="height: 30px">
                <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px">Full Name *</td>
            <td style="height: 30px">
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Date of Birth *</td>
            <td style="height: 30px">
                <asp:TextBox ID="tbDOB" runat="server" TextMode="Date"></asp:TextBox>
                <br />
                </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Gender *</td>
            <td style="height: 30px">
                <asp:DropDownList ID="ddGender" runat="server">
                    <asp:ListItem Value="0">- Select -</asp:ListItem>
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                    <asp:ListItem Value="O">Others</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px">Nationality *</td>
            <td style="height: 30px" class="RPtd">
                <asp:DropDownList ID="ddNationality" runat="server">
                    <asp:ListItem Value="0">- Select - </asp:ListItem>
                    <asp:ListItem Value="SG">Singaporean</asp:ListItem>
                    <asp:ListItem Value="PR">Singapore Permenant Resident</asp:ListItem>
                    <asp:ListItem Value="FN">Foreign Nationality</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">&nbsp;NRIC *</td>
            <td class="RPtd" style="height: 30px">
                <asp:TextBox ID="tbNRIC" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Address *</td>
            <td style="height: 30px">
                <asp:TextBox ID="tbAddr" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Known Allergies</td>
            <td style="height: 30px">
                <asp:TextBox ID="tbAllergies" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 210px;">&nbsp;</td>
            <td>
                <asp:Label ID="lbEmailER" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 30px; width: 210px;">Email *</td>
            <td style="height: 30px">
                <asp:TextBox ID="tbEmail" runat="server" TextMode="Email"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 30px; width: 210px;">Phone No. *</td>
            <td style="height: 30px">
                <asp:TextBox ID="tbPhoneNo" runat="server" TextMode="Phone"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px">&nbsp;</td>
            <td>
                <asp:Label ID="lbPassER" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px; height: 30px">Password *</td>
            <td style="height: 30px">
                <asp:TextBox ID="tbPass" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                Requirements: 1 lowercase, 1 uppercase, 1 number and 12 minimum characters</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px">&nbsp;</td>
            <td>
                <asp:Label ID="lbConPassER" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px; height: 30px">Confirm Password *</td>
            <td>
                <asp:TextBox ID="tbConfrimPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px; height: 17px;"></td>
            <td style="height: 17px"></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px">&nbsp;</td>
            <td>
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_OnClick"/>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>

    <br>

</asp:Content>
