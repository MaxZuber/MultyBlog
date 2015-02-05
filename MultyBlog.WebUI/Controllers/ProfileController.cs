using MultyBlog.Dal.Abstract;
using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultyBlog.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        private readonly IUserManager _userManager;
        public ProfileController(IUserManager userManager)
        {
            this._userManager = userManager;
        }

        public ActionResult Index(string UserName)
        {
            tblUsers user = _userManager.GetUserByUsername(UserName);

            ViewBag.User = user;

            return View();
        }

    }
}
