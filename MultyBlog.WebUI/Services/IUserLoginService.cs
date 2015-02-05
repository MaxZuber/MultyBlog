using MultyBlog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MultyBlog.WebUI.Services
{
    public interface IUserLoginService
    {
        IPrincipal TryLogIn(UserModel userModel);

        IPrincipal AuthenticateRequest(IPrincipal currentUser);
    }
}
