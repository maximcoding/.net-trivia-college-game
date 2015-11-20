<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TriviaUI.Views.Desktop.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Home Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
    <div style="display: none" class="alert alert-warning">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <h3>
            <span id="alert" class="label label-default"></span>
        </h3>
    </div>


    <div class="container">
        <!-- LOGIN FORM -->
        <div id="loginbox" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
            <div class="panel">
                <div class="text text-center">Login</div>
                <div style="padding-top: 30px" class="panel-body">
                    <form id="loginForm" class="form-horizontal" role="form" method="post">
                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-tag"></i></span>
                            <input id="login-username" type="text" class="form-control" name="email" value="" placeholder="email" />
                        </div>
                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <input id="login-password" type="password" class="form-control" name="password" placeholder="password" />
                        </div>

                        <div class="input-group remember-forgot">
                            <div class="checkbox">
                                <label>
                                    <input id="login-remember" type="checkbox" name="remember" value="1" />
                                    Remember me                                 
                                </label>
                                <label class="text text-warning">
                                    <a href="#">Forgot password?</a>
                                </label>

                            </div>
                        </div>
                        <!-- Login Buttons -->
                        <div style="margin-top: 10px" class="form-group">
                            <div class="btn-group btn-block">
                                <div class="form-group">
                                    <div id="btn-login">
                                        <input type="hidden" name="command" value="login" />
                                        <input type="submit" class="btn btn-block login" value="Login" />
                                    </div>
                                    <div id="btn-fblogin" class="btn btn-block facebook">
                                        Login with Facebook
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12 control">
                                <div style="border-top: 1px solid#888; padding-top: 15px; font-size: 85%">
                                    Don't have an account!
                                        <a href="#" onclick="$('#loginbox').hide(); $('#signupbox').show()">Sign Up Here
                                        </a>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <!-- REGISTER FORM -->
        <div id="signupbox" style="display: none; margin-top: 20px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
            <div class="panel panel-info">
                <div class="text text-center">Sign Up</div>
                <div class="panel-body">
                    <form id="registerForm" name="register" class="form-horizontal" role="form" action="http://localhost:63408/Views/Desktop/Games.aspx">


                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-tag"></i></span>
                            <input id="register-email" type="text" class="form-control" name="email" value="" placeholder="email" />
                        </div>

                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <input id="register-username" type="text" class="form-control" name="username" value="" placeholder="username" />
                        </div>

                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <input id="register-password" type="password" class="form-control" name="password" placeholder="password" />
                        </div>

                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <input id="register-password2" type="password" class="form-control" name="password_confirm" placeholder="confirm password" />
                        </div>

                        <!--Register Button -->
                        <div class="form-group">
                            <div id="btn-register">
                                <input type="hidden" value="register" name="command" />
                                <input type="submit" value="Register" class="btn btn-block login" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12 control">
                                <div style="border-top: 1px solid#888; padding-top: 15px; font-size: 85%">
                                    Back to                                        
                                    <a href="#" onclick="$('#signupbox').hide(); $('#loginbox').show()">Login
                                    </a>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").submit(httpSendFormJSON);
        });
    </script>
</asp:Content>
