using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace TriviaGame
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Javascript
            bundles.Add(new ScriptBundle("~/javascript/Comet").Include("~/Content/js/Comet.js"));
            bundles.Add(new ScriptBundle("~/javascript/build-games").Include("~/Content/js/build-games.js"));
            bundles.Add(new ScriptBundle("~/javascript/myscripts").Include("~/Content/js/myscripts.js"));
            bundles.Add(new ScriptBundle("~/javascript/zapas").Include("~/Content/js/zapas*"));
           
            // Javascript Frameworks
            bundles.Add(new ScriptBundle("~/javascript/modernizr").Include("~/Content/js/modernizr-*"));

            //CSS Frameworks
            bundles.Add(new StyleBundle("~/css/animate").Include("~/Content/css/animate.css"));
    
            //Css
            bundles.Add(new StyleBundle("~/css/home").Include("~/Content/css/Home.css"));
            bundles.Add(new StyleBundle("~/css/my-mobile").Include("~/Content/css/my-mobile*"));
            bundles.Add(new StyleBundle("~/css/my-theme").Include("~/Content/css/mytheme*"));
            bundles.Add(new StyleBundle("~/css/my-icons").Include("~/Content/css/jquery-mobile.icons*"));
            bundles.Add(new StyleBundle("~/css/registration").Include("~/Content/css/Registration*"));
            bundles.Add(new StyleBundle("~/css/messages").Include("~/Content/css/messages_css/messages.css"));
            

        }
    }
}