using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using myBundle;
using System.Web.Http;
using System.Web.Mvc;

namespace TriviaGame
{
    public class Global : HttpApplication
    {


        protected void Application_Start()
        {

          //  WebApiConfig.Register(GlobalConfiguration.Configuration);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


     


    }
}