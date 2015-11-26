<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TriviaGame.Views.Mobile.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <title>Home Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div data-role="page" id="homePage">

        <div class="alert" style="display: none">
            <span id="alert"></span>
        </div>

        <div data-role="main" class="ui-content">
            <div id="heading-1" class="ui-body ui-body-a ui-corner-all">
                <div data-role="header" class="page-header logo">
                    <h3>
                        <img class="displayed" src="/Content/img/SmartTrivia.png" alt="SmartTriviaS" />
                    </h3>
                </div>
            </div>
            <div data-role="controlgroup" id="loginbox" data-mini="true">
                <form role="form" id="loginForm">
                    <fieldset data-role="fieldcontain">
                        <label for="email">Email:</label>
                        <input type="email" name="email" id="emailLogin" class="required email">
                    </fieldset>

                    <fieldset data-role="fieldcontain">
                        <label for="password">Password:</label>
                        <input type="password" name="password" id="passLogin" class="required">
                    </fieldset>


                    <fieldset data-role="fieldcontain">
                        <input type="hidden" name="command" value="login">
                    </fieldset>

                    <input type="submit" value="Login" />
                </form>
                <div class="fieldgroup">
                    <h4>
                        <a href="#registerPage" data-rel="internal" id="link-1">Need An Account?</a>
                    </h4>
                </div>
                <br>
            </div>
        </div>
    </div>


    <div data-role="page" id="registerPage">
        <div data-role="main" class="ui-content">
            <div id="heading-2" class="ui-body ui-body-a ui-corner-all">
                <div data-role="header" class="page-header logo">
                    <h3>
                        <img class="displayed" src="/Content/img/SmartTrivia.png" alt="SmartTriviaS" />
                    </h3>
                </div>
                <div class="ui-body ui-body-a ui-corner-all">
                    <div data-role="controlgroup" id="buttons2" data-mini="true">
                        <form role="form" id="registerForm">
                            <fieldset data-role="fieldcontain">
                                <label for="username">Username:</label>
                                <input type="text" name="user" class="required">
                            </fieldset>

                            <fieldset data-role="fieldcontain">
                                <label for="password">Password:</label>
                                <input type="password" name="pass" class="required">
                            </fieldset>

                            <fieldset data-role="fieldcontain">
                                <label for="password">Confirm Password:</label>
                                <input type="password" name="passConfirm" class="required">
                            </fieldset>

                            <fieldset data-role="fieldcontain">
                                <label for="email">Email:</label>
                                <input type="email" name="email" class="required email">
                            </fieldset>

                            <fieldset data-role="fieldcontain">
                                <input type="hidden" name="command" value="register">
                            </fieldset>

                            <br>

                            <input type="submit" value="Register" id="registerButton">
                        </form>
                        <div class="fieldgroup">
                            <div class="fieldgroup">
                                <p>Already registered? <a href="#homePage">Sign in</a>.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
    <script type="text/javascript">

        $('#registerForm').submit(sendJsonForm);
        $('#loginForm').submit(sendJsonForm);

        function sendJsonForm(event) {
            console.log('sending ..' + getRawJson(this));
            event.preventDefault();
            $.ajax({
                async: true,
                type: 'POST',
                url: pathToHandler,
                success: function () {
                    $(location).attr('href', 'http://localhost:63408/Views/Mobile/Games.aspx');
                },
                data: getRawJson(this)
            });
        }

    </script>
</asp:Content>
