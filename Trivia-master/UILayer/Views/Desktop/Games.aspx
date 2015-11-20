<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="TriviaGame.Views.Desktop.Games" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <title>Game Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="gamePage" runat="server">
        <div id="contentWrapper">
            <div class="navbar  navbar-custom">
                <ul class="nav navbar-nav ">
                    <li role="presentation"><a href="<%= Page.ResolveUrl("/Views/Desktop/Profile.aspx") %>">Profile</a></li>
                    <li role="presentation"><a href="<%= Page.ResolveUrl("/Views/Desktop/Contact.aspx") %>">Contact</a></li>
                    <li role="presentation"><a href="<%= Page.ResolveUrl("/Views/Desktop/About.aspx") %>">About</a></li>
                    <li role="presentation">
                        <asp:LinkButton ID="LogoutButton" runat="server" OnClick="Logout_Click">Logout</asp:LinkButton>
                    </li>
                </ul>
            </div>


            <div class="alert" style="display: none">
                <span id="alert"></span>
            </div>

            <div class="container-fluid">
            <div id="game" class="row"></div>
                </div>
            <div id="gameContent">
                <table data-role="table" id="table-22" data-mode="columntoggle:none" class="ui-responsive table-stripe">
                    <thead>
                        <tr>
                            <th data-priority="1">Points</th>
                            <th data-priority="2">Question</th>
                            <th data-priority="3">Game</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td id="questionPoints"></td>
                            <td id="questionNumber"></td>
                            <td id="gameName"></td>
                        </tr>
                    </tbody>
                </table>
                <div class="ui-grid-solo">
                    <div class="ui-block-a" id="questionContent">
                    </div>
                    <div data-role="controlgroup" id="answerContent" data-iconpos="left">
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
    <%: Scripts.Render("~/javascript/myscripts") %>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#gameContent').hide();
            getGames();
        });
    </script>
</asp:Content>
