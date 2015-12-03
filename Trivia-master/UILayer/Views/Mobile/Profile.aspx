<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TriviaGame.Views.Mobile.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    Profile Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div data-role="page" id="profilePage">
        <div data-role="header" class="page-header logo">
            <h3>
                <img class="displayed" src="/Content/img/SmartTrivia.png" style="border-radius: 50px" alt="SmartTriviaS" />
            </h3>
        </div>
        <div data-role="header" class="page-header logo">
            <div data-role="navbar" id="mobile-navbar" class="mobile-navbar">
                <ul>
                    <li><a href="/Views/Mobile/Games.aspx" data-icon="grid" data-transition="pop">Games</a></li>
                    <li><a href="/Views/Mobile/About.aspx" data-icon="info" data-transition="pop">About</a></li>
                    <li><a href="/Views/Mobile/Contact.aspx" data-icon="mail" data-transition="pop">Write us</a></li>
                    <li><a href="/Views/Mobile/Home.aspx" data-icon="lock" data-transition="pop" id="logout">Logout</a></li>

                </ul>
            </div>
        </div>
        <div data-role="content">
            <div data-role="collapsible-set" id="collapsible-set-1">
                <div data-role="collapsible">
                    <h4>Personal Info</h4>
                    <div data-role="main" class="ui-content">
                        <div class="ui-grid-b" id="userInfo">
                            <table data-role="table" id="user-info-table" data-mode="reflow" class="ui-responsive">
                                <thead>
                                    <tr>
                                        <th data-priority="persist">Picture</th>
                                        <th data-priority="1">Username</th>
                                        <th data-priority="2">Email</th>
                                        <th data-priority="3">Registradion Date</th>
                                        <th data-priority="4">Total Score</th>
                                        <th data-priority="5">Avg Score</th>
                                        <th data-priority="6">Games</th>
                                        <th data-priority="7">
                                            <abbr title="Rotten Tomato Place">Place</abbr></th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div data-role="collapsible">
                    <h4>Games History</h4>
                    <div data-role="main" class="ui-content">
                        <div class="ui-grid-a" id="gameInfo">
                            <table data-role="table" id="games-results-table" class="ui-responsive table-stripe">
                                <thead>
                                    <tr>
                                        <th data-priority="persist">Game Category</th>
                                        <th>Score</th>
                                        <th>Date Played</th>
                                        <th># Answered Questions</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="footing-2" class="ui-corner-all">
            <div data-role="footer" class="page-footer">
                <p>
                    <h3>&copy; <%: DateTime.Now.Year %> Dani Livshitz</h3>
                </p>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
    <script type="text/javascript">
        $('#logout').click(function (e) {
            e.preventDefault();
            console.log('login out ...');
            $.ajax({
                async: true,
                type: 'POST',
                url: pathToHandler,
                data: '{"categoryId":"' + gameId + '" , "command": "logout"}',
                success: onSuccess,
                error: startGame
            });
        });
    </script>
</asp:Content>
