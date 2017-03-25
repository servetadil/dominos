using System.Web;
using System.Web.Optimization;

namespace Dominos.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/admin/jquery").Include(
               "~/_assets/js/jquery-{version}.js",
               "~/_assets/js/jquery-ui-1.9.2.min.js"));
        }
    }
}
