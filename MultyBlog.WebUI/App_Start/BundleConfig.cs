using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MultyBlog.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            Bundle bundleScripts = new ScriptBundle("~/bundles/AllScript")
                .Include("~/Scripts/libs/jquery-{version}.js")
                .Include("~/Scripts/pages/AddComment.js");

            Bundle bundleScripts2 = new ScriptBundle("~/bundles/AllScript")
                .Include("~/Scripts/libs/jquery-{version}.js")
                .Include("~/Scripts/pages/AddComment.js");

            
            Bundle bundleStyles = new StyleBundle("~/bundles/AllStyles")
            .Include("~/Content/AddComment.css")
            .Include("~/Content/Article.css")
            .Include("~/Content/ArticleList.css")
            .Include("~/Content/Comments.css")
            .Include("~/Content/Global.css")
            .Include("~/Content/NewArticle.css");

            bundles.Add(bundleScripts);
            bundles.Add(bundleStyles);

            // Code removed for clarity.
           // BundleTable.EnableOptimizations = true;
        }
    }
}