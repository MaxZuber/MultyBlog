using MultyBlog.Dal.Abstract;
using MultyBlog.Dal.Concrete;
using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultyBlog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        

        private readonly IArticleManager _articleManager;

        public HomeController(IArticleManager articleManager)
        {
            this._articleManager = articleManager;
        }


        public ActionResult Index()
        {
            List<tblArticles> articles = _articleManager.GetAll();

            ViewBag.Articles = articles.OrderByDescending(n => n.Date).Take(3).ToList();

            return View();
        }

    }
}
