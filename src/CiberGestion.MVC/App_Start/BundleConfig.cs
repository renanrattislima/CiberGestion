using System.Web;
using System.Web.Optimization;

namespace CiberGestion.MVC
{
    public class BundleConfig
    {
        
        
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(

                        //"~/assets/js/jquery-{version}.js",
                        "~/assets/js/vendor/jquery.metisMenu.js",
                        "~/assets/js/main.js",
                       // "~/assets/js/vendor/bootstrap-{version}.min.js",
                        "~/assets/js/vendor/sb-admin.js",
                        "~/assets/js/vendor/jquery.dataTables.js",
                        "~/assets/js/vendor/dataTables.bootstrap.js",
                        //"~/assets/js/vendor/jquery.maskedinput.min.js",
                        //"~/assets/js/vendor/jquery.mask.js",
                        "~/assets/js/vendor/jquery-ui.js",
                        "~/Scripts/jquery.ui.widget.js",
                        "~/assets/js/vendor/jquery.customSelect.min.js",
                        //"~/Scripts/jquery.maskedinput.js",
                        "~/assets/js/vendor/bootstrap-multiselect.js",
                        "~/assets/js/vendor/bootstrap-multiselect-collapsible-groups.js"

                        ));

          /*  bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));*/

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/assets/css/vendor/bootstrap.css",
                     "~/assets/fonts/font-awesome/css/font-awesome.css",
                     "~/assets/css/vendor/sb-admin.css",
                     "~/assets/css/main.css",
                     "~/assets/css/vendor/bootstrap-multiselect.css",
                     "~/assets/css/vendor/morris-0.4.3.min.css",
                     "~/assets/css/vendor/timeline.css",
                     "~/assets/css/bootstrap-datepicker.css",
                     "~/assets/css/dataTables.bootstrap.css"
                   
                    ));

          }
    }
}