using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;


namespace SBlogA.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles) {

            bundles.Add(new StyleBundle("~/admin/styles")
                    .Include("~/content/css/bootstrap.css")
                    .Include("~/content/css/admin.css")
                );

            bundles.Add(new StyleBundle("~/styles")
                .Include("~/content/css/bootstrap.css")
                .Include("~/content/css/site.css")
            );
            bundles.Add(new ScriptBundle("~/admin/scripts")
                .Include("~/scripts/jquery-2.0.3.js")
                .Include("~/scripts/jquery.validate.js")
                .Include("~/scripts/jquery.validate.unobtrusive.js")
                .Include("~/scripts/bootstrap.js")
                .Include("~/areas/admin/scripts/forms.js")
                );

            

        }


    }
}