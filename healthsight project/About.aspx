<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="healthsight_project.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div style="display:flex;">
        <div style="width: 40%;">
            <h3>Meet the team!</h3>
            <img alt="Photo of four. From the left: Darsini, Xiaozhen, Wei Lun, Aisya" src="teampic.png" style="max-width:75%; height:auto;" />
            <h6>From the left: Darsini, Xiaozhen, Wei Lun, Aisya</h6>
        </div>
        <div style="width: 60%;">
            <h3>Why use Healthsight?</h3>
            <p>Benefits:</p>
            <ul>
                <li>Easy access to patient’s information regardless of which healthcare institution they went to. </li>
                <li>Retrieve past medical records & medicines. </li>
                <li>Append patient data if patient transfer to another hospital or polyclinic. </li>
                <li>View medicine details personalised for you. </li>
                <li>Book appointment across different clinics. </li>
            </ul>
        </div>
    </div>
</asp:Content>
