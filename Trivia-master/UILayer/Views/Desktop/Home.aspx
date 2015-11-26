<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TriviaGame.Views.Desktop.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <title>Home Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="HomePage" role="form" runat="server" data-ajax="false">
        <div id="contentWrapper"></div>
        <div class="container-fluid">
            <div class="navbar  navbar-custom">
                <ul class="nav navbar-nav ">
                    <li><a runat="server" href="~/Views/Desktop/Contact.aspx">Contact</a></li>
                    <li><a runat="server" href="~/Views/Desktop/About.aspx">About</a></li>
                    <li><a runat="server" href="~/Views/Desktop/Home.aspx">Login</a></li>
                </ul>
             <h4><asp:Literal runat="server" ID="Alert" /></h4>
            </div>
            <asp:MultiView ID="MultiView" runat="server" ActiveViewIndex="0">

                <!-- LOGIN FORM -->
                <asp:View ID="LoginView" runat="server">
                    <div id="loginbox" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">

                        <div class="panel">
                            <div class="text text-center">Login</div>
                            <div style="padding-top: 30px" class="panel-body">

                                <div style="margin-bottom: 25px" class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-tag"></i></span>
                                    <asp:TextBox ID="LoginEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="LoginEmail"
                                    ValidationGroup="LoginGroup"
                                    ErrorMessage="Please Enter Your Email"
                                    CssClass="alert-warning"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>

                                <div style="margin-bottom: 25px" class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="LoginPass" TextMode="password" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="LoginPass"
                                    ValidationGroup="LoginGroup"
                                    ErrorMessage="Please Enter Your Password"
                                    CssClass="alert alert-warning"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>


                                <!-- Login Buttons -->
                                <div style="margin-top: 10px" class="form-group">
                                    <div class="btn-group btn-block">
                                        <div id="btn-login">
                                            <asp:Button ID="LoginButton" CssClass="btn btn-block login" runat="server"
                                                Text="Log In"
                                                OnClick="Login_Click"
                                                CausesValidation="true"
                                                ValidationGroup="LoginGroup" />
                                        </div>
                                        <div id="btn-fblogin" class="btn btn-block facebook">
                                            Login with Facebook                                  
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-12 control">
                                        <div style="border-top: 1px solid#888; padding-top: 15px; font-size: 85%">
                                            Don't have an account!                                 
                                   <asp:LinkButton ID="MoveToRegisterView" runat="server"
                                       OnClick="MoveToRegisterView_Click">Register</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <!-- REGISTER FORM -->
                <asp:View ID="RegisterView" runat="server">
                    <div id="signupbox" style="margin-top: 20px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">



                        <div class="panel panel-info">
                            <div class="text text-center">Sign Up</div>
                            <div class="panel-body">

                                <div style="margin-bottom: 25px" class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-tag"></i></span>
                                    <asp:TextBox ID="RegisterEmail" runat="server" CssClass="form-control" Text="email"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                    ControlToValidate="RegisterEmail"
                                    ValidationGroup="RegisterGroup"
                                    ErrorMessage="Please Enter Your Email" ForeColor="Red">
                                </asp:RequiredFieldValidator>




                                <div style="margin-bottom: 25px" class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    <asp:TextBox ID="RegisterUsername" CssClass="form-control" runat="server" Text="username"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                    ControlToValidate="RegisterUsername"
                                    ValidationGroup="RegisterGroup"
                                    ErrorMessage="Please Enter Your Username"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>


                                <div style="margin-bottom: 25px" class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="RegisterPassword" TextMode="password" CssClass="form-control" runat="server" Text="password"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                    ControlToValidate="RegisterPassword"
                                    ErrorMessage="Please Enter Your Password"
                                    ValidationGroup="RegisterGroup"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>


                                <div style="margin-bottom: 25px" class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="RegisterPasswordConfirm" CssClass="form-control" TextMode="password" runat="server" Text="confirm password"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                    ControlToValidate="RegisterPasswordConfirm"
                                    ValidationGroup="RegisterGroup"
                                    ErrorMessage="Please Confirm You Password"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>

                                <!--Register Button -->
                                <div class="form-group">
                                    <div id="btn-register">
                                        <!--When Register is clicked, only validation controls that are a part of RegisterGroup are validated.-->
                                        <asp:Button
                                            ID="RegisterButton"
                                            runat="server"
                                            Text="Register"
                                            OnClick="Register_Click"
                                            CssClass="btn btn-block login"
                                            CausesValidation="true"
                                            ValidationGroup="RegisterGroup" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12 control">
                                        <div style="border-top: 1px solid#888; padding-top: 15px; font-size: 85%">
                                            Back to                                                                                          
                                        <asp:LinkButton ID="BackToLoginView"
                                            runat="server"
                                            OnClick="BackToLoginView_Click"
                                            CausesValidation="false">Login
                                        </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
    <script>
        $(".alert").click(function () {
            $(".alert").hide("slow");
        });
    </script>
</asp:Content>
