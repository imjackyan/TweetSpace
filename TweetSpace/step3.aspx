<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="step3.aspx.cs" Inherits="WebApplication1.step3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>What would you like to do with these tweets?</h2>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" height="700">
        <ContentTemplate>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" CssClass="btn"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Search" />
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Height="270px" Width="694px"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" CssClass="btn" Text="Plot" />
        </ContentTemplate>

    </asp:UpdatePanel>



</asp:Content>
