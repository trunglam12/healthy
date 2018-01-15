using System.Web;
using System.Web.Optimization;

namespace SignalR
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                      "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                        "~/Scripts/jquery.mCustomScrollbar.concat.js",
                        "~/Scripts/admin.js"));

            bundles.Add(new StyleBundle("~/Content/css/site").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/font.css",
                      "~/Content/css/Site.css",
                      "~/Content/css/select2.css"));


            bundles.Add(new StyleBundle("~/Content/css/default").Include(
                      "~/Content/css/jquery.smartmenus.bootstrap.css",
                      "~/Content/css/default.css"));

            bundles.Add(new StyleBundle("~/Content/pagedList").Include(
                      "~/Content/css/PagedList.css"));


            bundles.Add(new StyleBundle("~/Content/admin").Include(
                      "~/Content/css/admin.css",
                      "~/Content/css/jquery.mCustomScrollbar.css",
                      "~/Content/css/select2.css"));


        }
    }
}
