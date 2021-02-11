<%@ Page Title="Admin Board" Language="C#" MasterPageFile="~/SiteLoggedIn.Master" AutoEventWireup="true" CodeBehind="AdminBoard.aspx.cs" Inherits="healthsight_project.AdminBoard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Registered Users</h3>
    <!-- TO DO: Fix the mix up btw name and nric-->
    <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
    <asp:GridView ID="GVRegisteredUsers" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" 
      onrowcommand="GVRegisteredUsers_RowCommand">
        <Columns>
            <asp:BoundField DataField="nric" HeaderText="Name" />
            <asp:BoundField DataField="dob" HeaderText="Birthdate" DataFormatString="{0:d}" />
            <asp:BoundField DataField="phoneNo" HeaderText="Phone No." />
            <asp:BoundField DataField="email" HeaderText="Email" />
            <asp:ButtonField Text="Remove" commandname="Remove">
              <ControlStyle BackColor="Red" CssClass="btn btn-danger" ForeColor="White" />
            </asp:ButtonField>
        </Columns>        
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>

</asp:Content>
