<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="step2.aspx.cs" Inherits="TweetSpace.step2" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Choose a method to import data</h3>
    <asp:Panel ID="Panel1" runat="server" Height="216px">
        <asp:Button ID="Button1" runat="server" Text="Import from server" BorderStyle="None" class="btn" />
        <br /><br />
        <asp:Button ID="Button2" runat="server" Text="Import from local file" BorderStyle="None" class="btn"/>
        <br /><br />
        <asp:Button ID="Button3" runat="server" Text="Start Streaming" BorderStyle="None" class="btn"/>
        <br /><br />
        <asp:Button ID="Button4" runat="server" Text="Stop Streaming" BorderStyle="None" class="btn"/>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="150px">
    </asp:Panel>
</asp:Content>
