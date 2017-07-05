using System.Web;
using System.Web.Optimization;

namespace TIROERP.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

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
                      //"~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/gentelella").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/fonts/css/font-awesome.min.css",
                      "~/Content/css/animate.min.css",
                      "~/Content/css/custom.css",
                      "~/Content/css/icheck/flat/green.css",
                      "~/Content/css/ion.rangeSlider.css",
                      "~/Content/css/ion.rangeSlider.skinFlat.css"));

            bundles.Add(new ScriptBundle("~/bundles/gentelellajs").Include(
                "~/Content/js/jquery-1.12.1.min.js",
                "~/Content/js/bootstrap.min.js",
                "~/Content/js/progressbar/bootstrap-progressbar.min.js",
                "~/Content/js/nicescroll/jquery.nicescroll.min.js",
                "~/Content/js/icheck/icheck.min.js",
                "~/Content/js/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                "~/Content/css/datatable/dataTables.bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatablejs").Include(
                "~/Content/js/datatable/dataTables.bootstrap.js",
                "~/Content/js/datatable/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                "~/Content/js/datepicker/jquery-ui.min.js"));

            bundles.Add(new StyleBundle("~/Content/datepicker").Include(
                      "~/Content/css/datepicker/jquery-ui.min.css"));


            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                "~/Content/js/select2/select2.full.min.js"));

            bundles.Add(new StyleBundle("~/Content/select2").Include(
                      "~/Content/css/select2/select2.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/wizard").Include(
               "~/Content/js/wizard/jquery.smartWizard.js",
               "~/Content/js/mask/jquery.inputmask.js",
               "~/Content/js/mask/mask.js",
               "~/Content/js/underscore/underscore.js",
               "~/Content/js/jasny-bootstrap/jasny-bootstrap.js"
               ));

            bundles.Add(new StyleBundle("~/Content/wizard").Include(
                     "~/Content/css/jasny-bootstrap/jasny-bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jasny").Include(
                "~/Content/js/jasny-bootstrap/jasny-bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/chosen").Include(
                     "~/Content/css/chosen/chosen.css"));

            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                "~/Content/js/chosen/chosen.jquery.js"));

        }
    }
}
