<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="step3.aspx.cs" Inherits="TweetSpace.step3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>What would you like to do with these tweets?</h2>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" CssClass="btn"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Search" />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Show Scores" />
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Height="270px" Width="1008px"></asp:ListBox>
            <br />
            <br />
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn">
                <asp:ListItem>Positivity Values</asp:ListItem>
                <asp:ListItem>Keyword Frequency</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:Button ID="Button2" runat="server" CssClass="btn" Text="Plot" OnClick="Button2_Click" />
            &nbsp;<asp:TextBox ID="TextBox2" runat="server" BorderColor="Gray" BorderStyle="Solid" CssClass="btn" placeholder="Number of Data points"></asp:TextBox>
            <br />
            <br />
            <asp:Chart ID="Chart1" runat="server" Height="437px" Width="963px" OnLoad="Chart1_Load">
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
        </ContentTemplate>

    </asp:UpdatePanel>



</asp:Content>
