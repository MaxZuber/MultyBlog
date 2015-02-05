using MultyBlog.Dal.Abstract;
using MultyBlog.Dal.Concrete;
using MultyBlog.Entities;
using MultyBlog.WebUI.Models;
using MultyBlog.WebUI.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace MultyBlog.WebUI.Controllers
{
    public class ArticleController : Controller
    {

        private readonly IArticleManager _articleManager;
        private readonly ICommentsManager _commentsManager;
        private readonly ITagsManager _tagsManager;

        public ArticleController(IArticleManager articleManager, ICommentsManager commentsManager, ITagsManager tagsManager)
        {
            this._articleManager = articleManager;
            this._commentsManager = commentsManager;
            this._tagsManager = tagsManager;
        }

        public ActionResult Index(int id)
        {
            var article = this._articleManager.GetById(id);
            var comments = _commentsManager.GetByArticleId(id).OrderByDescending(n => n.Date).ToList<tblComments>();

            ArticleContentModel articleContentModel = new ArticleContentModel()
            {
                Content = article.Content,
                Header = article.Header,
                Date = article.Date,
                Username = article.tblUsers.UserName,
                Tags =  _tagsManager.GetArticleTags(article.ID)
            };

            ViewBag.ArticleContentModel = articleContentModel;
            ViewBag.Comments = comments;
            ViewBag.ShowCommentForm = ControllerContext.HttpContext.User.IsInRole("user");

            ViewBag.ArticleID = id;

            return View("ArticleView");
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public ActionResult AddComment(int id, ArticleCommentModel comment)
        {


            comment.ArticleID = id;
            comment.Date = DateTime.Now;

            tblComments dbComment = new tblComments()
            {
                Comment = comment.Text,
                Date = comment.Date,
                ArticleID = comment.ArticleID,
                UserID = 1
            };

            var comments = _commentsManager.AddCommentToArticleById(id, dbComment).OrderByDescending(n => n.Date).ToList<tblComments>();
            ViewBag.Comments = comments;
            ViewBag.ArticleID = id;


            return View("CommentPartial");
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public ActionResult NewArticle()
        {

            return View();
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public ActionResult NewArticle(NewArticleModel newArticleModel)
        {
            if (newArticleModel.Tags.Length > 0)
            {
                ITagService tagService = new TagService();
                List<string> tagList = tagService.ParseTags(newArticleModel.Tags);

                List<tblTags> dbLinkedTags = tagService.FindOrAddTags(tagList);

                tblArticles article = new tblArticles()
                {
                    Content = newArticleModel.Content,
                    Header = newArticleModel.Header,
                    Date = DateTime.Now,
                    UserID = 1
                };
                this._articleManager.AddNewArticle(article);
                tagService.AttachTagToArticle(dbLinkedTags, article);

            }
            return Redirect(Url.Content("~/"));
        }

        public ActionResult All()
        {
            List<tblArticles> articles = _articleManager.GetAll();

            ViewBag.Articles = articles.OrderByDescending(n => n.Date).ToList();
            return View();
        }

        public ActionResult Popular()
        {
            List<tblArticles> articles = _articleManager.GetPopularToday();

            string retView;

            if(articles.Count > 0)
            {
                ViewBag.Articles = articles;

                retView = "Popular";
            }
            else
            {
                retView = "NoPopularArticles";
            }
            return View(retView);
        }

        public ActionResult My()
        {
            IIdentity user = HttpContext.User.Identity;

            List<tblArticles> articles = _articleManager.GetAll().Where(n => n.tblUsers.UserName == user.Name).ToList();

            ViewBag.Username = user.Name;
            ViewBag.ArticleCount = articles.Count;

            string retView;

            if (articles.Count > 0)
            {
                ViewBag.Articles = articles;

                retView = "MyArticles";
            }
            else
            {
                retView = "MyArticlesNotFound";
            }

            return View(retView);


        }
    }
}
