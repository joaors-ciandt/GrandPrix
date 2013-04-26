using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(GP.WebSite.App_Start.BundleConfig), "RegisterBundles")]

namespace GP.WebSite.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles()
		{
			// Add @Styles.Render("~/Content/bootstrap") in the <head/> of your _Layout.cshtml view
			// Add @Scripts.Render("~/bundles/bootstrap") after jQuery in your _Layout.cshtml view
			// When <compilation debug="true" />, MVC4 will render the full readable version. When set to <compilation debug="false" />, the minified version will be rendered automatically
			BundleTable.Bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap*"));
			BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css", "~/Content/bootstrap-responsive.css", "~/Content/Site.css"));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.unobtrusive*",
                       "~/Scripts/jquery.validate*"));

            //BundleTable.Bundles.Add(new ScriptBundle("~/bundles/formScripts").Include(                
            //    "~/Scripts/jquery-{version}.js",
            //    "~/Scripts/jquery.validate*",
            //    "~/Scripts/jquery.unobtrusive*",                
            //    "~/Scripts/bootstrap*"
            //    ));
            //BundleTable.Bundles.Add(new ScriptBundle("~/bundles/searchScripts").Include( 
            //     "~/Scripts/jquery-{version}.js",
            //     "~/Scripts/bootstrap*"
            //    ));


            //BundleTable.Bundles.Add(new StyleBundle("~/Content/css"));
        }
	}
}
