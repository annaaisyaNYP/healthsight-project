<%@ Page Title="Admin Board" Language="C#" MasterPageFile="~/SiteLoggedIn.Master" AutoEventWireup="true" CodeBehind="AdminBoard.aspx.cs" Inherits="healthsight_project.AdminBoard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Registered Users</h3>
    <!-- TO DO: Fix the mix up btw name and nric-->
    <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>

    <asp:Panel ID="PanelDelete" Visible=false runat="server" CssClass="panel panel-danger">
        <div class ="panel-heading"><h3>Are you sure?</h3></div>
        <div class ="panel-body" style="margin-left: 15px;">
            <div class="row">
                <asp:Label ID="lbAlert" runat="server"></asp:Label>
            </div>
            <div class="row">
                <asp:Label ID="lbAlert1" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="row">
                Enter password: <asp:TextBox ID="tbConPass" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Button ID="btnDeleteAccYes" runat="server" Text="Confrim" CssClass="btn btn-danger" OnClick="btnDeleteAccYes_Click" />
                <asp:Button ID="btnDeleteAccNo" runat="server" Text="Cancel" CssClass="btn btn-link" OnClick="btnDeleteAccNo_Click" />
            </div>
            
        </div>
    </asp:Panel>

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
