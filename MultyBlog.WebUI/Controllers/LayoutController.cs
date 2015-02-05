using MultyBlog.Dal.Abstract;
using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultyBlog.WebUI.Controllers
{
    public class LayoutController : Controller
    {
        //
        // GET: /Layout/

        private readonly ITagsManager _tagsManager;

        public LayoutController(ITagsManager tagsManager )
        {
            this._tagsManager = tagsManager;
        }

        public ActionResult Header()
        {
            bool isAuthenticated = ControllerContext.HttpContext.User.Identity.IsAuthenticated;
            string viewName = isAuthenticated ? "RegisteredPartial" : "AnonymousPartial";


            return View(viewName);
        }

        public ActionResult TopNavBar()
        {
            bool isAuthenticated = ControllerContext.HttpContext.User.Identity.IsAuthenticated;
            string viewName = isAuthenticated ? "RegisteredNavPartial" : "AnonymousNavPartial";


            return View(viewName);
        }

        public ActionResult PopularTags()
        {
            
            List<tblTags> popularTags =  _tagsManager.GetPopularTagsTop(3);
            ViewBag.PopularTags = popularTags;

            return View("PopularTagPartial");
        }
    }
}
