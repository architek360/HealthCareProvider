using System.Web;
using System.Web.Optimization;

namespace HealthCareProvider
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.9.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(getStyleSheets());
           // bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

          //  bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css", "~/Content/bootstrap-responsive.csss"));
            bundles.Add(new ScriptBundle("~/bundles/AppJsFiles").Include(
                       "~/Scripts/bootstrap.js", "~/Scripts/StaticDataSourceList.js","~/Scripts/HealthCareProviderUtility.js"));

            bundles.Add(new StyleBundle("~/Content/jqueryUi").Include(
                        "~/Content/themes/base/jquery-ui.css"));
        }

        public static StyleBundle getStyleSheets()
        {
            var styles = new StyleBundle("~/Content/css");
            styles.Include("~/Content/site.css", "~/Content/bootstrap.css", "~/Content/bootstrap-responsive.csss");
            return styles;
        }
    }
}