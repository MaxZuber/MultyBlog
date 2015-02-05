using MultyBlog.Dal.Abstract;
using MultyBlog.Entities;
using MultyBlog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace MultyBlog.WebUI.Services
{
    public class UserLoginService : IUserLoginService
    {
        public IPrincipal TryLogIn(UserModel userModel)
        {

            IUserManager userManager = DependencyResolver.Current.GetService<IUserManager>();

            tblUsers user = userManager.GetUserByUsername(userModel.Username);

            if (user != null && user.Password == userModel.Password)
            {
                return new GenericPrincipal(new GenericIdentity(userModel.Username), new string[] { "user" });
            }
            else
            {
                return null;
            }

        }

        public IPrincipal AuthenticateRequest(IPrincipal currentUser)
        {

            if (currentUser != null && currentUser.Identity != null && currentUser.Identity.IsAuthenticated == true)
            {
                IIdentity identity = currentUser.Identity;

                return new GenericPrincipal(identity, new string[] { "user" });
            }
            else
            {
                return null;
            }

        }
    }
}