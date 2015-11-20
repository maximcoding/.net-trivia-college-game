<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TriviaGame.Views.Mobile.Home1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <title>Home Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div data-role="page" id="homePage">
        <div data-role="main" class="ui-content">
            <div id="heading-1" class="ui-body ui-body-a ui-corner-all">
                <div data-role="header" class="page-header logo">
                    <h3>
                        <img class="displayed" src="/Content/img/SmartTrivia.png" alt="SmartTriviaS" />
                    </h3>
                </div>
            </div>
            <div data-role="controlgroup" id="loginbox" data-mini="true">

                <form id="loginForm" method="POST">
                    <fieldset data-role="fieldcontain">
                        <label for="email">Email:</label>
                        <input type="email" name="email" id="email" class="required email">
                    </fieldset>

                    <fieldset data-role="fieldcontain">
                        <label for="password">Password:</label>
                        <input type="password" name="password" id="password" class="required">
                    </fieldset>

                    <fieldset data-role="fieldcontain">
                        <input type="hidden" name="command" value="Login">
                    </fieldset>

                    <input type="submit" value="Login" />

                    <div class="fieldgroup">
                        <h4>
                            <a href="Register.aspx" data-rel="external" id="link-1">Need An Account?</a>
                        </h4>
                    </div>
                </form>
                <br>
            </div>
        </div>
        <div class="alert" style="display: none">
            <span id="alert"></span>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
    <script type="text/javascript">
        $("form").submit(httpSendFormJSON);
    </script>
</asp:Content>




