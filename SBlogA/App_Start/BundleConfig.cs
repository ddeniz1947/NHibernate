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


        }


    }
}