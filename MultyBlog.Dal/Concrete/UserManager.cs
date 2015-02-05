using MultyBlog.Dal.Abstract;
using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyBlog.Dal.Concrete
{
    public class UserManager: AbstractManager, IManager, IUserManager
    {
        private static string connectionString;

        //static ArticleManager()
        //{
        //    connectionString = ConfigurationManager.ConnectionStrings["MultyBlogDbEntityWeb"].ConnectionString;
        //}

        //public ArticleManager()
        //    : base(connectionString)
        //{

        //}

        public UserManager(string connectionString) : base(connectionString) { }

        public bool IsUserRegistered(string userName)
        {
            using (DbContext context = this.CreateDbContext())
            {
                return context.Set<tblUsers>().SingleOrDefault(n => n.UserName == userName) != null ? true : false;
            }
        }

        public bool InsertUser(tblUsers user)
        {
            bool isSuccesss = true;

            using (DbContext context = this.CreateDbContext())
            {
                try
                {
                    context.Set<tblUsers>().Add(user);
                    context.SaveChanges();
                }
                catch(Exception e)
                {
                    isSuccesss = false;
                }
            }

            return isSuccesss;
        }

        public tblUsers GetUserByUsername(string username)
        {
            tblUsers retUser;

            using(DbContext context = this.CreateDbContext())
            {
                retUser = context.Set<tblUsers>()
                    .Include(n => n.tblArticles)
                    .Include(n => n.tblComments)
                    .SingleOrDefault(n => n.UserName == username);
            }

            return retUser;
        }

    }
}
