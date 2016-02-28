using System.Web;
using System.Web.Optimization;

namespace Komsky.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.easing.{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/font-awesome.css",
                        "~/Content/Theme/animate.min.css",
                        "~/Content/Theme/creative.css"));

            bundles.Add(new ScriptBundle("~/bundles/global").Include(
                        "~/Scripts/global.js",
                        "~/Scripts/init.js"));
            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
            "~/Scripts/Theme/jquery.fittext.js",
            "~/Scripts/Theme/wow.min.js",
            "~/Scripts/Theme/creative.js"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
