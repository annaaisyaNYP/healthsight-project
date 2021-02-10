<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="healthsight_project.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <asp:Panel ID="PanelSuccess" Visible="false" runat="server" CssClass="alert alert-dismissable alert-success">
      <button type="button" class="close" data-dismiss="alert">
      <span aria-hidden="true">&times;</span>
      </button>
      <asp:Label ID="lbSuccess" runat="server">Account successfully registered! <a href="Login.aspx">Login now</a>! </asp:Label>
    </asp:Panel>

    <table class="nav-justified" style="margin: 20px; font-size: 12px; margin-bottom: 0px;">
        <caption>
            Fields marked * are required</caption>
        <tr>
            <td style="width: 210px; height: 30px">Full Name *</td>
            <td style="height: 30px; width: 280px;">
                <asp:TextBox style="width: 200px;" ID="tbName" runat="server"></asp:TextBox>
            </td>
            <td rowspan="10" style="vertical-align: top;">
                <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Date of Birth *</td>
            <td style="height: 30px; width: 280px;">
                <asp:TextBox style="width: 200px;" ID="tbDOB" runat="server" TextMode="Date"></asp:TextBox>
                <br />
                </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Gender *</td>
            <td style="height: 30px; width: 280px;">
                <asp:DropDownList ID="ddGender" runat="server">
                    <asp:ListItem Value="0">- Select -</asp:ListItem>
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                    <asp:ListItem Value="O">Others</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px">Nationality&nbsp; Type*</td>
            <td style="height: 30px; width: 280px;" class="RPtd">
                <asp:DropDownList ID="ddNationality" runat="server" style="width: 220px;">
                    <asp:ListItem Value="0">- Select - </asp:ListItem>
                    <asp:ListItem Value="SG">Singaporean</asp:ListItem>
                    <asp:ListItem Value="PR">Singapore Permenant Resident</asp:ListItem>
                    <asp:ListItem Value="FN">Foreign Nationality</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">&nbsp;NRIC *</td>
            <td class="RPtd" style="height: 30px; width: 280px;">
                <asp:TextBox style="width: 200px;" ID="tbNRIC" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Address *</td>
            <td style="height: 30px; width: 280px;">
                <asp:TextBox style="width: 200px;" ID="tbAddr" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 210px; height: 30px;">Known Allergies</td>
            <td style="height: 30px; width: 280px;">
                <asp:TextBox style="width: 200px;" ID="tbAllergies" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 210px;">&nbsp;</td>
            <td style="width: 280px">
                <asp:Label ID="lbEmailER" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 30px; width: 210px;">Email *</td>
            <td style="height: 30px; width: 280px;">
                <asp:TextBox style="width: 200px;" ID="tbEmail" runat="server" TextMode="Email"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 30px; width: 210px;">Phone No. *</td>
            <td style="height: 30px; width: 280px;">
                <asp:TextBox style="width: 200px;" ID="tbPhoneNo" runat="server" TextMode="Phone"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px">&nbsp;</td>
            <td style="width: 280px">
                <asp:Label ID="lbPassER" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px; height: 30px;">Password *</td>
            <td style="height: 30px; width: 280px;">
                <asp:TextBox style="width: 200px;" ID="tbPass" runat="server" TextMode="Password" Height="21px"></asp:TextBox>
            </td>
            <td rowspan="3">
                Password
                Requirements:
                <ul>
                    <li>minimum 8 charaters</li>
                </ul>
                <p>
                    and at least one of each of the following:</p>
                <ul>
                    <li>&nbsp;a lowercase</li>
                    <li>&nbsp;an uppercase</li>
                    <li>&nbsp;a number</li>
                    <li>&nbsp;a special character ( !, *, @, #, $, %, ^, &amp;, +, = )</li>
                </ul>
             </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px">&nbsp;</td>
            <td style="width: 280px">
                <asp:Label ID="lbConPassER" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px; height: 30px">Confirm Password *</td>
            <td style="width: 280px">
                <asp:TextBox style="width: 200px;" ID="tbConfrimPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px; height: 17px;"></td>
            <td style="height: 17px; width: 280px;"></td>
            <td style="height: 17px">&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 210px">&nbsp;</td>
            <td style="width: 280px">
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_OnClick"/>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>

    <br>

</asp:Content>
