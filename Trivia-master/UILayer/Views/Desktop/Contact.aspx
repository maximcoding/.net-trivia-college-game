<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TriviaGame.Views.Desktop.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <title>Contact Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="ContactPage" role="form" runat="server">
        <div id="contentWrapper"></div>
        <div class="container-fluid">
            <ul class="nav navbar-nav ">
                <li><a runat="server" href="~/Views/Desktop/Games.aspx">Games</a></li>
                <li><a runat="server" href="~/Views/Desktop/Contact.aspx">Contact</a></li>
                <li><a runat="server" href="~/Views/Desktop/About.aspx">About</a></li>
                <li>
                    <asp:LinkButton ID="LogoutButton" runat="server" OnClick="Logout_Click">Logout</asp:LinkButton>
                </li>
            </ul>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
