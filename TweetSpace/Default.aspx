<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Tweet Space</h1>
        <p class="lead">Tweet space is a site where nothing works. Yet.</p>
        <br />
        <p>What is your location?<asp:MultiView ID="MultiView1" runat="server">
            </asp:MultiView>
        </p>
        <asp:Panel ID="Panel1" runat="server" Height="136px">
            <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None"></asp:TextBox>
            &nbsp;Longitude<br />
            <asp:TextBox ID="TextBox3" runat="server" BorderStyle="None"></asp:TextBox>
            &nbsp;Latitude<br />
            <asp:TextBox ID="TextBox2" runat="server" BorderStyle="None"></asp:TextBox>
            &nbsp;Radius</asp:Panel>

    </div>



</asp:Content>
