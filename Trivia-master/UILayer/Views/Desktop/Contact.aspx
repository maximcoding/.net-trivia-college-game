<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TriviaGame.Views.Desktop.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <title>Contact Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="ContactPage" runat="server">
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
            <div class="container">
<div class="row">
  <div class="col-md-12">
  </div>
  <form role="form" action="" method="post" >
    <div class="col-lg-6">
      <div class="form-group">
        <label for="InputName">Your Name</label>
        <div class="input-group">
          <input type="text" class="form-control" name="InputName" id="InputName" placeholder="Enter Name" required>
          <span class="input-group-addon"><i class="glyphicon glyphicon-ok form-control-feedback"></i></span></div>
      </div>
      <div class="form-group">
        <label for="InputEmail">Your Email</label>
        <div class="input-group">
          <input type="email" class="form-control" id="InputEmail" name="InputEmail" placeholder="Enter Email" required  >
          <span class="input-group-addon"><i class="glyphicon glyphicon-ok form-control-feedback"></i></span></div>
      </div>
      <div class="form-group">
        <label for="InputMessage">Message</label>
        <div class="input-group"
>
          <textarea name="InputMessage" id="InputMessage" class="form-control" rows="5" required></textarea>
          <span class="input-group-addon"><i class="glyphicon glyphicon-ok form-control-feedback"></i></span></div>
      </div>
      <div class="form-group">
        <label for="InputReal">What is 4+3? (Simple Spam Checker)</label>
        <div class="input-group">
          <input type="text" class="form-control" name="InputReal" id="InputReal" required>
          <span class="input-group-addon"><i class="glyphicon glyphicon-ok form-control-feedback"></i></span></div>
      </div>
     <div id="btn-login">
                                            <asp:Button ID="SubmitButton" CssClass="btn btn-block login" runat="server"
                                                Text="Submit"
                                                OnClick="Submit_Click"
                                                CausesValidation="true"
                                                ValidationGroup="ContactGroup" />
                                        </div>    </div>
  </form>
  <hr class="featurette-divider hidden-lg">
  <div class="col-lg-5 col-md-push-1">
    <address>
    <h3>Office Location</h3>
    <p class="lead"><a href="https://www.google.com/maps/preview?ie=UTF-8&q=The+Pentagon&fb=1&gl=us&hq=1400+Defense+Pentagon+Washington,+DC+20301-1400&cid=12647181945379443503&ei=qmYfU4H8LoL2oATa0IHIBg&ved=0CKwBEPwSMAo&safe=on">The Pentagon<br>
Washington, DC 20301</a><br>
      Phone: XXX-XXX-XXXX<br>
      Fax: XXX-XXX-YYYY</p>
    </address>
  </div>
</div>

</div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
