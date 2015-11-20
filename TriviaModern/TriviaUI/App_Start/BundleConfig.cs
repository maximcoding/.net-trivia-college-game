using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TriviaUI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254726
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                  "~/Scripts/WebForms/WebForms.js",
                  "~/Scripts/WebForms/WebUIValidation.js",
                  "~/Scripts/WebForms/MenuStandards.js",
                  "~/Scripts/WebForms/Focus.js",
                  "~/Scripts/WebForms/GridView.js",
                  "~/Scripts/WebForms/DetailsView.js",
                  "~/Scripts/WebForms/TreeView.js",
                  "~/Scripts/WebForms/WebParts.js"));

            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-1.9*"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-mobile").Include("~/Scripts/jquery.mobile-1.4.5*"));
            bundles.Add(new ScriptBundle("~/bundles/http").Include("~/Scripts/http*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/myscripts").Include("~/Scripts/myscripts.js"));
            bundles.Add(new ScriptBundle("~/bundles/CometRequester").Include("~/Scripts/CometRequester.js"));



            bundles.Add(new StyleBundle("~/bundles/Site").Include("~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/bundles/animate").Include("~/Content/animate.css"));
            bundles.Add(new StyleBundle("~/bundles/bootstrap").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/bundles/jquery-mobile").Include("~/Content/jquery.mobile-1.4.5.css"));
            bundles.Add(new StyleBundle("~/bundles/bootstrap-theme").Include("~/Content/bootstrap-theme.css"));
            bundles.Add(new StyleBundle("~/bundles/mytheme").Include("~/Content/mytheme.css"));
            bundles.Add(new StyleBundle("~/bundles/my-mobile").Include("~/Content/my-mobile.css"));







        }
    }
}