<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TriviaGame.Views.Desktop.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
        <title>Profile Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                <div class="navbar  navbar-custom">
                    <ul class="nav navbar-nav ">
                        <li role="presentation"><a href="<%= Page.ResolveUrl("/Views/Desktop/Games.aspx") %>">Games</a></li>
                        <li role="presentation"><a href="<%= Page.ResolveUrl("/Views/Desktop/Contact.aspx") %>">Contact</a></li>
                        <li role="presentation"><a href="<%= Page.ResolveUrl("/Views/Desktop/About.aspx") %>">About</a></li>
                        <li role="presentation"><a href="<%= Page.ResolveUrl("/Views/Desktop/Home.aspx") %>">Logout</a></li>
                    </ul>
            </div>
           <div id="alert" style="display:none">
    <a class="alert" href="#alert"></a>
       </div>


        <div data-role="content">
            <div data-role="collapsible-set" id="collapsible-set-1">
                <div data-role="collapsible">
                    <h4>Personal Info</h4>
                    <div data-role="main" class="ui-content">
                        <div class="ui-grid-a" id="userInfo">
                            <table data-role="table" id="user-info-table" class="ui-responsive">
                                <thead>
                                    <tr>
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
                                        <th>Game Category</th>
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

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
        <%: Scripts.Render("~/javascript/http") %>
    <%: Scripts.Render("~/javascript/myscripts") %>
    <script type="text/javascript">
        getUserInfo();
    </script>
</asp:Content>
