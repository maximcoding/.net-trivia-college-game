<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TriviaGame.Views.Mobile.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div data-role="page" id="registerPage">
        <div data-role="main" class="ui-content">
            <div id="heading-1" class="ui-body ui-body-a ui-corner-all">
                <div data-role="header" class="page-header logo">
                    <h3>
                        <img class="displayed" src="/Content/img/SmartTrivia.png" alt="SmartTriviaS" />
                    </h3>
                </div>
                <div id="heading-2" class="ui-body ui-body-a ui-corner-all">
                    <div data-role="controlgroup" id="buttons2" data-mini="true">
                     
                        <form name="register" action="POST">
                            <fieldset data-role="fieldcontain">
                                <label for="username">Username:</label>
                                <input type="text" name="username" id="username" class="required">
                            </fieldset>

                            <fieldset data-role="fieldcontain">
                                <label for="password">Password:</label>
                                <input type="password" name="password" id="password" class="required">
                            </fieldset>

                            <fieldset data-role="fieldcontain">
                                <label for="password2">Confirm Password:</label>
                                <input type="password" name="password_confirm" id="password2" class="required">
                            </fieldset>

                            <fieldset data-role="fieldcontain">
                                <label for="email">Email:</label>
                                <input type="email" name="email" id="email" class="required email">
                            </fieldset>

                            <fieldset data-role="fieldcontain">
                                <input type="hidden" name="command" id="cmd" value="Register">
                            </fieldset>
                            <br>

                            <input type="submit" value="Register" id="registerButton">

                            <div class="fieldgroup">
                                <div class="fieldgroup">
                                    <p>Already registered? <a href="/Views/Mobile/Home.aspx">Sign in</a>.</p>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
                   <div class="alert" style="display:none">
                      <a id="alert" href="#alert"></a>
       </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
               <script type="text/javascript">
                   $("form").submit(httpSendFormJSON);
    </script>
</asp:Content>
