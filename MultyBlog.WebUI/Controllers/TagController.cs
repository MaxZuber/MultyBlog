using MultyBlog.Dal.Abstract;
using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultyBlog.WebUI.Controllers
{
    public class TagController : Controller
    {
        //
        // GET: /Tag/


        private readonly ITagsManager _tagsManager;

        public TagController(ITagsManager tagsManager)
        {
            this._tagsManager = tagsManager;
        }

        public ActionResult Index(string tag)
        {
            List<tblArticles> articles = _tagsManager.GetAllArticlesWithTag(tag);

            ViewBag.Articles = articles;
            ViewBag.Tag = tag;

            return View();
        }

    }
}
