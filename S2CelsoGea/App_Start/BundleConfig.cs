using System.Web;
using System.Web.Optimization;

namespace S2S2CelsoGea
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/aux").Include(
                        "~/Scripts/guardJs.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/loadingoverlay.min.js",
                        "~/Scripts/bootbox.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/datatablejs").Include(
                       "~/Scripts/DataTables/jquery.dataTables.min.js"));

            bundles.Add(new StyleBundle("~/Content/datatablestyle").Include(
                    "~/Content/DataTables/datatables.min.css"));
        }
    }
}
