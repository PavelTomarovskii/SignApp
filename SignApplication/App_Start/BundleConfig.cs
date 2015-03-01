using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SignApplication.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/Angular/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/uibootstrap")
                .Include("~/Scripts/Ui-bootstrap/ui-bootstrap-tpls-0.12.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/application")
                    .Include("~/Scripts/Application/Base/app.js")

                    .Include("~/Scripts/Application/Menu/menuModule.js")
                    .Include("~/Scripts/Application/Menu/Controllers/*.js")

                    .Include("~/Scripts/Application/Info/infoModule.js")
                    .Include("~/Scripts/Application/Info/Controllers/*.js")

                    .Include("~/Scripts/Application/Document/documentModule.js")
                    .Include("~/Scripts/Application/Document/Controllers/*.js")
                    .Include("~/Scripts/Application/Document/Directives/*.js")
                    .Include("~/Scripts/Application/Document/Factories/*.js")
                    .Include("~/Scripts/Application/Document/Services/*.js")

                    .Include("~/Scripts/Application/Request/request.module.js")
                    .Include("~/Scripts/Application/Request/Services/*.js")
                );

            bundles.Add(new StyleBundle("~/Default/css")
                .Include("~/Themes/Default/alexander/alexander.css")
                .Include("~/Themes/Default/css/Site.css"));

            //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

        }
    }
}