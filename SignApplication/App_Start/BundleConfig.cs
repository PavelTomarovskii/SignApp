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

            bundles.Add(new ScriptBundle("~/bundles/application")
                .Include("~/Scripts/Application/Base/app.js")

                .Include("~/Scripts/Application/Menu/menuModule.js")
                .Include("~/Scripts/Application/Menu/Controllers/*.js")

                .Include("~/Scripts/Application/Info/infoModule.js")
                .Include("~/Scripts/Application/Info/Controllers/*.js")

                .Include("~/Scripts/Application/Document/documentModule.js")
                .Include("~/Scripts/Application/Document/Controllers/*.js")
            );

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/Angular/angular.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

        }
    }
}