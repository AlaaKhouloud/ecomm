using System.Web;
using System.Web.Optimization;

namespace proj
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //Template Admin
            bundles.Add(new ScriptBundle("~/JsAdmin").Include(
                      "~/Content/DemoAdmin/plugins/jQuery/jquery-2.2.3.min.js",
                      "~/Content/DemoAdmin/bootstrap/js/bootstrap.min.js",
                      "~/Content/DemoAdmin/plugins/slimScroll/jquery.slimscroll.min.js",
                      "~/Content/DemoAdmin/plugins/fastclick/fastclick.js",
                       "~/Content/DemoAdmin/dist/js/app.min.js",
                        "~/Content/DemoAdmin/dist/js/demo.js"
                      ));

            bundles.Add(new StyleBundle("~/CssAdmin").Include(
                      "~/Content/DemoAdmin/bootstrap/css/bootstrap.min.css",
                      "~/Content/DemoAdmin/dist/css/AdminLTE.min.css",
                      "~/Content/DemoAdmin/dist/css/skins/_all-skins.min.css"));
            //Table 
            bundles.Add(new StyleBundle("~/CssTable").Include(
                      "~/Content/DemoAdmin/plugins/datatables/dataTables.bootstrap.css",
                      "~/Content/DemoAdmin/dist/css/AdminLTE.min.css"));

            bundles.Add(new ScriptBundle("~/JsTable").Include(
                       "~/Content/DemoAdmin/plugins/jQuery/jquery-2.2.3.min.js",
                       "~/Content/DemoAdmin/bootstrap/js/bootstrap.min.js",
                       "~/Content/DemoAdmin/plugins/datatables/jquery.dataTables.min.js",
                       "~/Content/DemoAdmin/plugins/datatables/dataTables.bootstrap.min.js",
                        "~/Content/DemoAdmin/plugins/slimScroll/jquery.slimscroll.min.js",
                        "~/Content/DemoAdmin/plugins/fastclick/fastclick.js",
                         "~/Content/DemoAdmin/dist/js/app.min.js",
                         "~/Content/DemoAdmin/dist/js/demo.js"
                       ));


                   //Template User
                   bundles.Add(new ScriptBundle("~/JsUser").Include(
                     "~/Content/DemoUser/js/jquery.min.js",
                     "~/Content/DemoUser/js/bootstrap.min.js",
                     "~/Content/DemoUser/js/slick.min.js",
                     "~/Content/DemoUser/js/nouislider.min.js",
                      "~/Content/DemoUser/js/jquery.zoom.min.js",
                       "~/Content/DemoUser/js/main.js"
                     ));

                    bundles.Add(new StyleBundle("~/CssUser").Include(
                      "~/Content/DemoUser/css/bootstrap.min.css",
                      "~/Content/DemoUser/css/slick.css",
                      "~/Content/DemoUser/css/slick-theme.css",
                      "~/Content/DemoUser/css/nouislider.min.css",
                      "~/Content/DemoUser/css/font-awesome.min.css",
                      "~/Content/DemoUser/css/style.css"
                      ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
