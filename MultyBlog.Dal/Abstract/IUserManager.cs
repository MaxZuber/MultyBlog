using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyBlog.Dal.Abstract
{
    public interface IUserManager
    {
        bool IsUserRegistered(string userName);

        bool InsertUser(tblUsers user);

        tblUsers GetUserByUsername(string username);
    }
}
