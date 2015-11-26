<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TriviaGame.Views.Desktop.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <title>Profile Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" id="profilePage">
        <div class="container-fluid">
            <div id="contentWrapper"></div>
            <div class="container-fluid">
                <div class="navbar  navbar-custom">
                    <ul class="nav navbar-nav ">
                        <li><a runat="server" href="~/Views/Desktop/Games.aspx">Games</a></li>
                        <li><a runat="server" href="~/Views/Desktop/Contact.aspx">Contact</a></li>
                        <li><a runat="server" href="~/Views/Desktop/About.aspx">About</a></li>
                        <li>
                            <asp:LinkButton ID="LogoutButton" runat="server" OnClick="Logout_Click">Logout</asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div id="alert" style="display: none">
                    <a class="alert" href="#alert"></a>
                </div>
                <div class="panel-group" id="accordion">
                    <div class="panel panel-primary" id="panel1">

                        <div class="panel-heading">
                            <div class="panel-title" data-toggle="collapse"
                                data-target="#collapseOne">
                                <span class="label label-default" style="cursor: pointer">Personal Info</span>
                            </div>
                        </div>

                        <div id="collapseOne" class="panel-collapse collapse in">
                            <div class="panel-body" id="userInfo">
                                <table class="table table-responsive" id="user-info-table">
                                    <thead>
                                        <tr class="text-warning warning">
                                            <th>Picture</th>
                                            <th>Username</th>
                                            <th>Email</th>
                                            <th>Registradion Date</th>
                                            <th>Total Score</th>
                                            <th>Avg Score</th>
                                            <th>Games</th>
                                            <th>Place</th>
                                        </tr>
                                    </thead>
                                    <tbody id="Acontent">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-primary" id="panel2">
                        <div class="panel-heading">
                            <div class="panel-title" data-toggle="collapse"
                                data-target="#collapseTwo">
                                <span class="label label-primary" style="cursor: pointer">Games Results</span>
                            </div>
                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse in">
                            <div class="panel-body" id="gameInfo">
                                <table id="games-results-table" class="table table-striped">
                                    <thead>
                                        <tr class="text-warning warning">
                                            <th>Game Category</th>
                                            <th>Score</th>
                                            <th>Date Played</th>
                                            <th># Answered Questions</th>
                                        </tr>
                                    </thead>
                                    <tbody id="Bcontent">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
        //    $('#gameContent').hide();
            getFreshUserInfo();
        });
        var active = true;

        $('#accordion').on('show.bs.collapse', function () {
            if (active) $('#accordion .in').collapse('hide');
        });

    </script>
</asp:Content>
