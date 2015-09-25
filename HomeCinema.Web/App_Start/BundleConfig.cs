using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace HomeCinema.Web {
    public class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/vendors/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors")
                .Include(
                "~/Scripts/vendors/jquery.js",
                "~/Scripts/vendors/bootstrap.js",
                "~/Scripts/vendors/toastr.js",
                "~/Scripts/vendors/jquery.raty.js",
                "~/Scripts/vendors/respond.src.js",
                "~/Scripts/vendors/angular.js",
                "~/Scripts/vendors/angular-route.js",
                "~/Scripts/vendors/angular-cookies.js",
                "~/Scripts/vendors/angular-validator.js",
                "~/Scripts/vendors/angular-base64.js",
                "~/Scripts/vendors/angular-file-upload.js",
                "~/Scripts/vendors/angucomplete-alt.min.js",
                "~/Scripts/vendors/ui-bootstrap-tpls-0.13.1.js",
                "~/Scripts/vendors/underscore.js",
                "~/Scripts/vendors/raphael.js",
                "~/Scripts/vendors/morris.js",
                "~/Scripts/vendors/jquery.fancybox.js",
                "~/Scripts/vendors/jquery.fancybox-media.js",
                "~/Scripts/vendors/loading-bar.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/site.css",
                "~/Content/css/bootstrap.css",
                "~/Content/css/bootstrap-theme.css",
                "~/Content/css/font-awesome.css",
                "~/Content/css/morris.css",
                "~/Content/css/toastr.css",
                "~/Content/css/jquery.fancybox.css",
                "~/Content/css/loading-bar.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}