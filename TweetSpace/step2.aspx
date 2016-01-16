<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="step2.aspx.cs" Inherits="TweetSpace.step2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Choose a method to import data</h3>
    <asp:Panel ID="Panel1" runat="server" Height="216px">
        <asp:Button ID="Button1" runat="server" Text="Import from server" />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Import from local file" />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Start Streaming" />
        <br />
        <asp:Button ID="Button4" runat="server" Text="Stop Streaming" />
    </asp:Panel>
</asp:Content>
