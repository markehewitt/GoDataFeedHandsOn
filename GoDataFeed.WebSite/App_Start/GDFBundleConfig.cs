using System.Web.Optimization;

namespace GoDataFeed.WebSite.App_Start
{
    public class GDFBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/jquery")
                    .Include("~/Scripts/jquery-{version}.js")
                    .Include("~/Scripts/jquery-ui-{version}.js")
                    );

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
        }
    }
}