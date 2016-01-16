<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>TweetSpace</h2>
    <h3>This is a cool app.</h3>
    <p>My ass is wide</p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get data" />
    <br />
    <asp:ListBox ID="ListBox1" runat="server" Height="485px" Width="524px"></asp:ListBox>
</asp:Content>
