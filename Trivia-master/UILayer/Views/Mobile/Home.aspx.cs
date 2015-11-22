using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft;
using System.Windows;
using DALayer.Models;
using DALayer.Services;
using DALayer.Helpers;
using App_Code.Helpers;


namespace TriviaGame.Views.Mobile
{

    public partial class Home : System.Web.UI.Page
    {

        private JsonHelper<Object> _jsonHelper = null;
        PlayerService _playerService = null;
        private CometClientProcessor _cometProcessor;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                if (Request.Form["username"] != "" &&
                    Request.Form["passConfirm"] != "" &&
                    Request.Form["email"] != "" &&
                    Request.Form["password"] == Request.Form["passConfirm"]
                   )
                {
                }
                else if (Request.Form["email"] != null &&
                   Request.Form["password"] != null)
                {
                }
            }
            return;
        }
        //  Response.Redirect("Home.aspx");
    }
}

