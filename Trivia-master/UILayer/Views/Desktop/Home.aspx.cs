using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft;

using DALayer.Models;
using DALayer.Services;
using DALayer.Helpers;
using App_Code.Helpers;

namespace TriviaGame.Views.Desktop
{
    public partial class Home : System.Web.UI.Page
    {
        private JsonHelper<Object> _jsonHelper = null;
        PlayerService _playerService = null;
        private CometClientProcessor _cometProcessor;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDefaultView();
            }

        }

        private void SetDefaultView()
        {
            MultiView.ActiveViewIndex = 0;
        }


        protected void Login_Click(object sender, EventArgs e)
        {
            Login(LoginEmail.Text, LoginPass.Text);
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            _playerService = new PlayerService();
            _jsonHelper = new JsonHelper<Object>();
            string responseJSON = null;
            if (RegisterUsername.Text != "" &&
                RegisterPassword.Text != "" &&
                RegisterPasswordConfirm.Text != "" &&
                RegisterEmail.Text != "" &&
                RegisterPassword.Text == RegisterPasswordConfirm.Text)
            {
                Player newPlayer = new Player();
                newPlayer.username = RegisterUsername.Text;
                newPlayer.email = RegisterEmail.Text;
                // kod zashivrovali v settere 
                newPlayer.password = RegisterPassword.Text;
                newPlayer.image = "ehse netu picture";
                newPlayer.registration_date = DateTime.Now;

                if (!_playerService.CheckIfExists(newPlayer))
                {
                    System.Threading.Thread.Sleep(1000);
                    // do stuff here to log the user in ... 
                    if (_playerService.Insert(newPlayer))
                    {
                        System.Threading.Thread.Sleep(1000);
                        Login(newPlayer.email, newPlayer.password);
                    }
                }
                else
                {
                    _jsonHelper.status = 405;
                    _jsonHelper.message = "This email is registered,Please login or register another one";
                    responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelper);
                    HttpContext.Current.Response.Headers.Add("Content-type", "application/json");
                    HttpContext.Current.Response.Write(responseJSON);
                }
            }
            else
            {

                _jsonHelper.status = 406;
                _jsonHelper.message = "All fields required Or passwords doesn't match!";
                responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelper);
                HttpContext.Current.Response.Headers.Add("Content-type", "application/json");
                HttpContext.Current.Response.Write(responseJSON);
            }
        }

        private void Login(string email, string pass)
        {
            _jsonHelper = new JsonHelper<object>();
            _cometProcessor = new CometClientProcessor();
            _playerService = new PlayerService();
            Player player = new Player();
            player.password = LoginPass.Text;
            player.email = LoginEmail.Text;
            _playerService = new PlayerService();
            if (_playerService.Verify(player))
            {
                player = _playerService.FindByEmail(LoginEmail.Text);
                // Create  Cookie
                HttpCookie time = new HttpCookie("LastLogined", DateTime.Now.ToString());
                HttpCookie userEmail = new HttpCookie("userEMail", player.email);
                HttpCookie userId = new HttpCookie("userId", player.id.ToString());
                time.Expires = DateTime.Now.AddDays(1);
                userEmail.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(time);
                HttpContext.Current.Response.Cookies.Add(userEmail);
                HttpContext.Current.Response.Cookies.Add(userId);
                Session["Email"] = player.email;
                Session["Username"] = player.username;
                Response.Redirect("Games.aspx"); //if true - so code after this not working - its abort the thread
            }
            else
            {
                _jsonHelper.message = "This email and password not found,Please register or try again";
                _jsonHelper.status = 404;
                string responseJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_jsonHelper);
                HttpContext.Current.Response.Write(responseJSON);
            }
        }

        protected void BackToLoginView_Click(object sender, EventArgs e)
        {
            if (MultiView.ActiveViewIndex == 1)
            {
                MultiView.ActiveViewIndex = 0;
            }
            else
            {
                MultiView.ActiveViewIndex -= 1;
            }
        }
        protected void MoveToRegisterView_Click(object sender, EventArgs e)
        {
            if (MultiView.ActiveViewIndex == 0)
            {
                MultiView.ActiveViewIndex = 1;
            }
            else
            {
                MultiView.ActiveViewIndex -= 1;
            }
        }

    }

}