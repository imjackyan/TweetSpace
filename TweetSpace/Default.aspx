<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TweetSpace._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Tweet Space</h1>
        <p class="lead">Tweet space is a site where nothing works. Yet.</p>
        <br />
        <p>What is your location?</p>
        <asp:Panel ID="Panel2" runat="server" Height="136px">
            <asp:Button ID="Button1" runat="server" Text="No Location" OnClick="Button1_Click" class="btn"/>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Coordinates" class="btn"/>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" Height="182px">
            <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None" CssClass="btn" placeholder="Longitude"></asp:TextBox>
            &nbsp;Longitude<br />
            <asp:TextBox ID="TextBox3" runat="server" BorderStyle="None" CssClass="btn" placeholder="Latitude"></asp:TextBox>
            &nbsp;Latitude<br />
            <asp:TextBox ID="TextBox2" runat="server" BorderStyle="None" CssClass="btn" placeholder="Radius"></asp:TextBox>
            &nbsp;Radius (km)<br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Next" class="btn"/>
        </asp:Panel>

    </div>



</asp:Content>
