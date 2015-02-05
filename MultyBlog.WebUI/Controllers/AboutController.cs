using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultyBlog.WebUI.Controllers
{
    public class AboutController : Controller
    {
        //
        // GET: /About/

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Author()
        {
            return View();
        }

        public ActionResult Aspnet()
        {
            return View();
        }

        public ActionResult Mvc()
        {
            return View();
        }

    }
}
