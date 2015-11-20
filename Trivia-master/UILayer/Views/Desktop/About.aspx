<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TriviaGame.Views.Desktop.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <title>About Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div class="navbar  navbar-custom">
                    <ul class="nav navbar-nav ">
                        <li role="presentation"><a href="<%= Page.ResolveUrl("/Views/Desktop/Games.aspx") %>">Games</a></li>
                        <li role="presentation"><a href="<%= Page.ResolveUrl("/Views/Desktop/Contact.aspx") %>">Contact</a></li>
                        <li role="presentation"><a href="<%= Page.ResolveUrl("/Views/Desktop/Home.aspx") %>">Logout</a></li>
                    </ul>
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
