using System.Web;
using System.Web.Optimization;

namespace CMS.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // the base styles and scripts
            bundles.Add(new StyleBundle("~/css/base").Include(
                ));
            bundles.Add(new ScriptBundle("~/js/base").Include(
                "~/js/jquery-*",
                "~/js/modernizr-*"
                ));

            // common packages
            bundles.Add(new StyleBundle("~/p/css/common").Include(
                "~/packages/bootstrap-3.3.6/css/bootstrap.css",
                "~/packages/font-awesome-4.5.0/css/font-awesome.css",
                "~/packages/alertify/css/alertify.core.css",
                "~/packages/alertify/css/alertify.default.css"
                ));
            bundles.Add(new ScriptBundle("~/p/js/common").Include(
                "~/packages/bootstrap-3.3.6/js/bootstrap.js",
                "~/packages/alertify/js/alertify.js"
                ));

            // angular modules
            bundles.Add(new ScriptBundle("~/p/js/angular").Include(
                "~/packages/angularjs-1.5/angular.js",
                "~/packages/angularjs-1.5/angular-animate.js",
                "~/packages/angularjs-1.5/angular-route.js",
                "~/packages/angularjs-1.5/angular-sanitize.js"
                ));

            // admin panel
            bundles.Add(new StyleBundle("~/p/css/admin").Include(
                "~/packages/AdminLTE/css/AdminLTE.css",
                "~/packages/AdminLTE/css/skins/_all-skins.css",
                "~/Areas/Admin/Content/site.css"
                ));
            bundles.Add(new ScriptBundle("~/p/js/admin").Include(
                "~/packages/AdminLTE/js/app.js",
                "~/Areas/Admin/settings.js",
                "~/Areas/Admin/Content/app.js",
                "~/Areas/Admin/Content/directives/*.js",
                "~/js/angular-filters.js",
                "~/js/angular-directives.js"
                ));

            // HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries
            //! WARNING: Respond.js doesn't work if you view the page via file://
            bundles.Add(new ScriptBundle("~/js/ie8").Include(
                "~/js/html5shiv.min.js",
                "~/js/respond.min.js"
                ));
        }
    }
}
