using MultyBlog.Dal.Abstract;
using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyBlog.Dal.Concrete
{
    public class ArticleManager : AbstractManager, IManager, IArticleManager
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

        public ArticleManager(string connectionString) : base(connectionString) { }

        public List<tblArticles> GetAll()
        {
            List<tblArticles> articles;

            using(var context = this.CreateDbContext() )
            {
                articles = context.Set<tblArticles>()
                    .Include(m => m.tblUsers)
                    .ToList();
            }
            return articles;
        }

        public tblArticles GetById(int ID)
        {
            tblArticles article;

            using (var context = this.CreateDbContext())
            {
                article = context.Set<tblArticles>()
                    .Include(n => n.tblUsers)
                    .Single(n => n.ID == ID);
            }
            return article;
        }

        public void AddNewArticle(tblArticles article)
        {
            using (var context = this.CreateDbContext())
            {

                //article.tblUsers = context.Set<tblUsers>().Single(n => n.ID == article.UserID);

                context.Set<tblArticles>().Add(article);
                context.SaveChanges();
            }
        }


        public List<tblArticles> GetPopularToday()
        {
            List<tblArticles> popularArticles;

            using (DbContext context = this.CreateDbContext())
            {
                popularArticles = context.Set<tblArticles>()
                    .Include(n => n.tblUsers)
                    .Where(n => DateTime.Today <= n.Date).ToList();
            }

            return popularArticles;
        }
    }
}
