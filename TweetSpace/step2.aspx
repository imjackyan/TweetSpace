﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="step2.aspx.cs" Inherits="TweetSpace.step2" %>
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
</asp:Content>
