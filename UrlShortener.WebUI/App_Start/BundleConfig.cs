using System.Web.Optimization;

namespace UrlShortener.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/CSS").Include(
                     "~/Content/Themes/Default/Styles/Main.css"
                     ));

            bundles.Add(new ScriptBundle("~/Scripts/Angular").Include(
                "~/Scripts/angular.js"
                ));
        }
    }
}