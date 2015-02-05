using MultyBlog.Dal.Abstract;
using MultyBlog.Entities;
using MultyBlog.WebUI.Models;
using MultyBlog.WebUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MultyBlog.WebUI.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/

        private readonly IUserManager _userManager;


        public AuthenticationController(IUserManager userManager)
        {
            this._userManager = userManager;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationUserModel registrationUserModel)
        {
            
            if(string.IsNullOrEmpty(registrationUserModel.User.Email))
            {
                ModelState.AddModelError("User.Email", "Please enter your email address");
            }

            if (_userManager.IsUserRegistered(registrationUserModel.User.Username))
            {
                ModelState.AddModelError("User.Username", string.Format("{0} already registered", registrationUserModel.User.Username));
            }

            if(ModelState.IsValid)
            {
                

                tblUsers user = new tblUsers()
                {
                    UserName = registrationUserModel.User.Username,
                    Password = registrationUserModel.User.Password,
                    RegistrationDate = DateTime.Now,
                    Email = registrationUserModel.User.Email
                };

                bool isSuccesful = _userManager.InsertUser(user);

                return isSuccesful ? View("SuccessfullRegistration", registrationUserModel) : View("RegistrationFailed");
                
            }
            
            return View();
        }


        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserModel user)
        {
           //ModelState.AddModelError("Username", "Already Exist");
            if(ModelState.IsValid)
            {
                IUserLoginService loginHelper = new UserLoginService();

                IPrincipal currentUser = loginHelper.TryLogIn(user);
 
                if(currentUser != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, user.Persistent);
                    ControllerContext.HttpContext.User = new GenericPrincipal(new GenericIdentity(user.Username), null);
                    return View("SuccessfulLoged", user);
                }
                else
                {
                    ModelState.AddModelError("Username", "Wrong login or password");
                    return View();
                }

            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            string[] myCookies = Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            return Redirect("~/");
        }

    }
}
