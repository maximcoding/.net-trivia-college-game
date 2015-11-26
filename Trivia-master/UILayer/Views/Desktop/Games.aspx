<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="TriviaGame.Views.Desktop.Games" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <title>Game Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="gamePage" runat="server">
        <div id="contentWrapper"></div>
        <div class="container-fluid">
            <div class="navbar  navbar-custom">
                <ul class="nav navbar-nav ">
                    <li><a runat="server" href="~/Views/Desktop/Profile.aspx">Profile</a></li>
                    <li><a runat="server" href="~/Views/Desktop/Contact.aspx">Contact</a></li>
                    <li><a runat="server" href="~/Views/Desktop/About.aspx">About</a></li>
                    <li>
                        <asp:LinkButton ID="LogoutButton" runat="server" OnClick="Logout_Click">Logout</asp:LinkButton>
                    </li>
                </ul>
            </div>


            <div class="alert overplay" style="display: none">
                <span id="alert" class="message"></span>
            </div>

            <div class="container-fluid" id="gamesList">
                <div id="game" class="row"></div>
            </div>
            <div id="gameContent" class="container-fluid">
                <table class="table table-bordered">
                    <thead>
                        <tr class="text-warning warning">
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
                <div>
                    <div id="questionContent">
                    </div>
                    <div id="answerContent">
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
        <%: Scripts.Render("~/javascript/scrollAndRotate") %>
    <script type="text/javascript">
        // When every window opens - its connecting
        $(document).ready(function () {
            var str = window.location.href;
            if (str.indexOf("?") < 0) {
                //      Connect();
            }
            $('#gameContent').hide();
            getGames();
        });
        $(window).unload(function () {
            var str = window.location.href;
            if (str.indexOf("?") < 0) {
                //    Disconnect();
            }
        });


        var clientGuid
        var userId



        function OnConnected(result) {
            clientGuid = result;
            SendRequest();
        }

        // every time sends request to detect changes on the page ( if its new Client GUID)
        function SendRequest() {
            commandObj = {
                "command": "CLIENTGUID",
                "ClientID": clientGuid
            };
            jsonObject = JSON.stringify(commandObj);
            $.ajax({
                type: "POST",
                url: pathToHandler,
                data: jsonObject,
                success: ProcessResponse,
                error: SendRequest
            });
        }

        // loop SendRequest to detect new Cliend GUID
        function ProcessResponse(result) {
            console.log(result);
            $("#contentWrapper").html(result);
            SendRequest();
        }
        function ConnectionRefused() {
            $("#contentWrapper").html("Unable to connect to Comet server. Reconnecting in 5 seconds...");
            setTimeout(Connect(), 5000);
        }


    </script>
</asp:Content>
