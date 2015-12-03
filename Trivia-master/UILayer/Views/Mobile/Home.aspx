<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TriviaGame.Views.Mobile.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <title>Home Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div data-role="page" id="homePage">
        <div id="heading-1" class="ui-corner-all">
            <div data-role="header" class="page-header logo">
                <h2>
                    <img class="displayed" style="border-radius: 50px" src="/Content/img/SmartTrivia.png" alt="SmartTriviaS" />
                </h2>
            </div>
        </div>
        <div data-role="main" class="ui-content">
            <div class="alert ui-loader ui-overlay-shadow"
                style="display: none; position: fixed; text-align: center; width: 500px; margin: -150px">
                <div id="alert" style="margin: 0px; padding: 30px"></div>
            </div>
            <div data-role="controlgroup" id="loginbox" data-mini="true">
                <form role="form" id="loginForm">
                    <fieldset data-role="fieldcontain">
                        <label for="email">
                            <h4>Email:</h4>
                        </label>
                        <input type="email" name="email" class="required email">
                    </fieldset>
                    <fieldset data-role="fieldcontain">
                        <label for="password">
                            <h4>Password:</h4>
                        </label>
                        <input type="password" name="password" class="required">
                    </fieldset>


                    <fieldset data-role="fieldcontain">
                        <input type="hidden" name="command" value="login">
                    </fieldset>
                    <br />
                    <input type="submit" value="Login" />
                </form>
                <div class="fieldgroup">
                    <h3>
                        <a href="#registerPage" data-rel="internal" id="link-1">Need An Account?</a>
                    </h3>
                </div>
                <br>
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


    <div data-role="page" id="registerPage">
        <style>
            .hiddenfile {
                width: 0px;
                height: 0px;
                overflow: hidden;
            }
        </style>
        <div id="heading-2" class="ui-corner-all">
            <div data-role="header" class="page-header logo">
                <h3>
                    <img class="displayed" style="border-radius: 50px" src="/Content/img/SmartTrivia.png" alt="SmartTriviaS" />
                </h3>
            </div>
        </div>
        <div data-role="main" class="ui-content">
            <div data-role="controlgroup" id="regiterbox" data-mini="true">
                <form role="form" id="registerForm" enctype="multipart/form-data">
                    <fieldset data-role="fieldcontain">
                        <label for="user">
                            <h4>Username:</h4>
                        </label>
                        <input type="text" name="user" class="required">
                    </fieldset>
                    <fieldset data-role="fieldcontain">
                        <label for="pass">
                            <h4>Password:</h4>
                        </label>
                        <input type="password" name="pass" class="required">
                    </fieldset>
                    <fieldset data-role="fieldcontain">
                        <label for="passConfirm">
                            <h4>Confirm Password:</h4>
                        </label>
                        <input type="password" name="passConfirm" class="required">
                    </fieldset>
                    <fieldset data-role="fieldcontain">
                        <label for="email">
                            <h4>Email:</h4>
                        </label>
                        <input type="email" name="email" class="required email">
                    </fieldset>
                    <fieldset data-role="fieldcontain">
                        <label for="image">
                            <h4>Choose Picture:</h4>
                        </label>
                        <img id="myUploadedImg" alt="Photo" style="width:180px;" />
                        <input type="file" id="Picture" data-clear-btn="false" name="image" accept="image/*">
                    </fieldset>

                    <fieldset data-role="fieldcontain">
                        <input type="hidden" name="command" value="register">
                    </fieldset>
                    <br />
                    <input type="submit" value="Register" id="registerButton">
                </form>
                <div class="fieldgroup">
                    <div class="fieldgroup">
                        <h3>Already registered? <a href="#homePage" data-rel="internal" id="link-2">Sign in</a>.
                        </h3>
                    </div>
                </div>
            </div>
        </div>
        <div id="footing-1" class="ui-corner-all">
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

        $('#registerForm').submit(sendJsonForm);
        $('#loginForm').submit(sendJsonForm);

        function sendJsonForm(event) {
            console.log('sending ..' + getRawJson(this));
            event.preventDefault();
            $.ajax({
                async: true,
                type: 'POST',
                url: pathToHandler,
                data: getRawJson(this),
                success: function (data) {
                    var result = JSON.parse(data);
                    console.log(result);
                    switch (result.status) {
                        case 200: // login Ok
                            $("#alert").append(result.message)
                            $(".alert").fadeIn(1500, function () {
                                $(location).attr('href', 'http://localhost:63408/Views/Mobile/Games.aspx');
                            });
                            break;
                        case 404: // user not found
                            var alertOriginalState = $(".alert").clone();
                            $("#alert").append(result.message)
                            $(".alert").fadeIn(1000, function () {
                                $(this).click(function () {
                                    $(".alert").replaceWith(alertOriginalState);
                                });
                            });
                            break;
                        default:
                            break;
                    }
                }
            });
        }

        var _URL = window.URL || window.webkitURL;
        $("#Picture").on('change', function () {

            var file, img;
            if ((file = this.files[0])) {
                img = new Image();
                img.onload = function () {
                    sendFile(file);
                };
                img.onerror = function () {
                    alert("Not a valid file:" + file.type);
                };
                img.src = _URL.createObjectURL(file);
            }
        });


        function sendFile(file) {

            var formData = new FormData();
         //   formData.append('file', $('#f_UploadImage')[0].files[0]);
            $.ajax({
                type: 'POST',
                url: '/CometAsyncHandler.ashx',
                data: formData,
                success: function (status) {
                    if (status != 'error') {
                        var my_path = "Content/img/avatars/" + status;
                        $("#myUploadedImg").attr("src", my_path);
                    }
                },
                processData: false,
                contentType: false,
                error: function () {
                    alert("Whoops something went wrong!");
                }
            });
        }

    </script>
</asp:Content>
