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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
            return;
        }
    }
}

